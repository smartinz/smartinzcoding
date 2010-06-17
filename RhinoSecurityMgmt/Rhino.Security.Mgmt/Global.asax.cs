﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Castle.Facilities.FactorySupport;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;
using Conversation;
using Conversation.NHibernate;
using Rhino.Security.Mgmt.Controllers;
using Rhino.Security.Mgmt.Data;
using Rhino.Security.Model;
using Rhino.Security.Mgmt.Dtos;
using log4net.Config;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Web.Mvc;
using MvcContrib.Castle;
using Nexida.Infrastructure;
using NHibernate;
using NHibernate.Validator.Cfg;
using NHibernate.Validator.Engine;
using Nexida.CodeGen.TemplateProject.CSharp.MvcExt.Infrastructure;
using Rhino.Security.Mgmt.Model;

namespace Rhino.Security.Mgmt
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("favicon.ico");
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new{ controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
				);
		}

		protected void Application_Start()
		{
			XmlConfigurator.Configure();

			IWindsorContainer ioc = new WindsorContainer();
			ioc.AddFacility<FactorySupportFacility>();

			ioc.Register(Component.For<ValidatorEngine>().UsingFactoryMethod(CreateValidatorEngine));
			ioc.Register(Component.For<Nexida.Infrastructure.IValidator>().ImplementedBy<NHibernateValidator>());

			ioc.Register(Component.For<ISessionFactory>().UsingFactoryMethod(CreateSessionFactory));
			ioc.Register(Component.For<IConversationFactory>().UsingFactoryMethod(CreateConversationFactory));
			ioc.Register(Component.For<IConversation>().UsingFactoryMethod(CreateConversation).LifeStyle.PerWebRequest);

			ioc.Register(Component.For<IMappingEngine>().UsingFactoryMethod(MappingEngineBuilder.Build));

			ioc.Register(AllTypes.FromAssemblyContaining<UserStringConverter>().BasedOn(typeof(IStringConverter<>)).WithService.Base());
			ioc.Register(AllTypes.FromAssemblyContaining<UserFactory>().BasedOn(typeof(IFactory<>)).WithService.Base());
			ioc.Register(AllTypes.FromAssemblyContaining<UserRepository>().BasedOn<IRepository>());

			ioc.RegisterControllers(typeof(UserController).Assembly);
			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(ioc));

			AreaRegistration.RegisterAllAreas();
			RegisterRoutes(RouteTable.Routes);
			ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
			ModelBinders.Binders.DefaultBinder = new DefaultToNullModelBinder(ModelBinders.Binders.DefaultBinder);
			ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(ioc));
		}

		private static ValidatorEngine CreateValidatorEngine()
		{
			var cfg = new XmlConfiguration();
			cfg.Mappings.Add(new MappingConfiguration(typeof(User).Assembly.FullName, null));
			var ve = new ValidatorEngine();
			ve.Configure(cfg);
			return ve;
		}

		private static ISessionFactory CreateSessionFactory(IKernel kernel)
		{
			var validatorEngine = kernel.Resolve<ValidatorEngine>();

			var nhConfig = new NHibernate.Cfg.Configuration();
			Security.Configure<User>(nhConfig, SecurityTableStructure.Prefix);

			NHibernate.Cfg.Configuration nhCfg = new NHibernate.Cfg.Configuration().Configure()
				.SetProperty(NHibernate.Cfg.Environment.CurrentSessionContextClass, typeof(ConversationSessionContext).AssemblyQualifiedName)
				.AddAssembly(typeof(User).Assembly);

			nhCfg.Initialize(validatorEngine);
			return nhCfg.BuildSessionFactory();
		}

		private static IConversationFactory CreateConversationFactory(IKernel kernel)
		{
			return new NHibernateConversationFactory(kernel.ResolveAll<ISessionFactory>());
		}

		private static IConversation CreateConversation(IKernel kernel)
		{
			return kernel.Resolve<IConversationFactory>().Open();
		}
	}
}