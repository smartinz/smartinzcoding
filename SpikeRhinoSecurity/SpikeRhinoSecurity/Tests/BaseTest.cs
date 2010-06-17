using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NHibernate;
using SpikeRhinoSecurity.Data;
using SpikeRhinoSecurity.Infrastructure;
using Microsoft.Practices.ServiceLocation;
using SpikeRhinoSecurity.Domain;
using NHibernate.Cfg;
using Rhino.Security.Services;
using Rhino.Security.Interfaces;
using Rhino.Security.Model;
using Rhino.Security;
using NHibernate.Context;
using SpikeRhinoSecurity.SecurityHelpers;
using NHibernate.Tool.hbm2ddl;

namespace SpikeRhinoSecurity.Tests
{
	[TestFixture]
	public abstract class BaseTest
	{
		protected ISessionFactory SessionFactory;
		protected ISession CurrentSession;
		protected ServiceLocatorImpl ServiceLocatorImpl;
		protected IAuthorizationRepository AuthZRepository;
		protected IAuthorizationService AuthZService;
		protected User SampleUser;
		protected User AdminUser;
		protected User CurrentUser;

		static BaseTest()
		{
			log4net.Config.XmlConfigurator.Configure();
		}

		[TestFixtureSetUp]
		public void TestFixtureSetUp()
		{
			ServiceLocatorImpl = Init();

			AuthZRepository = ServiceLocator.Current.GetInstance<IAuthorizationRepository>();
			AuthZService = ServiceLocator.Current.GetInstance<IAuthorizationService>();

		}

		[TestFixtureTearDown]
		public void TestFixtureTearDown()
		{
			CurrentSessionContext.Unbind(SessionFactory);
		}

		[SetUp]
		public void SetUp()
		{
			CurrentSession = SessionFactory.GetCurrentSession();
			CurrentSession.BeginTransaction();

			SampleUser = new User { Name = ("Stefano") };
			CurrentSession.Save(SampleUser);

			AdminUser = new User { Name = ("Admin") };
			CurrentSession.Save(AdminUser);

			CurrentUser = AdminUser;

			ServiceLocatorImpl.Add(typeof(IUser), () => CurrentUser);
		}

		[TearDown]
		public void TearDown()
		{
			if (CurrentSession != null)
			{
				if (CurrentSession.Transaction != null && CurrentSession.Transaction.IsActive)
				{
					CurrentSession.Transaction.Rollback();
				}
				CurrentSession.Close();
			}
		}

		private ServiceLocatorImpl Init()
		{
			var nhConfig = new Configuration();
			Security.Configure<User>(nhConfig, SecurityTableStructure.Prefix);

			SessionFactory = nhConfig.Configure().BuildSessionFactory();
			CurrentSessionContext.Bind(SessionFactory.OpenSession());


			//var s = new SchemaExport(nhConfig);
			//s.SetOutputFile(@"c:\temp\out.txt");
			//s.Execute(true, false, false);


			NHibernate.Validator.Cfg.Environment.SharedEngineProvider.GetEngine().Configure();

			var impl = new ServiceLocatorImpl();
			ServiceLocator.SetLocatorProvider(() => impl);
			impl.Add(typeof(CategoryRepository), () => new CategoryRepository(SessionFactory));
			impl.Add(typeof(CustomerDemographicRepository), () => new CustomerDemographicRepository(SessionFactory));
			impl.Add(typeof(CustomerRepository), () => new CustomerRepository(SessionFactory));
			impl.Add(typeof(EmployeeRepository), () => new EmployeeRepository(SessionFactory));
			impl.Add(typeof(OrderDetailRepository), () => new OrderDetailRepository(SessionFactory));
			impl.Add(typeof(OrderRepository), () => new OrderRepository(SessionFactory));
			impl.Add(typeof(ProductRepository), () => new ProductRepository(SessionFactory));
			impl.Add(typeof(RegionRepository), () => new RegionRepository(SessionFactory));
			impl.Add(typeof(ShipperRepository), () => new ShipperRepository(SessionFactory));
			impl.Add(typeof(SupplierRepository), () => new SupplierRepository(SessionFactory));
			impl.Add(typeof(TerritoryRepository), () => new TerritoryRepository(SessionFactory));
			impl.Add(typeof(IStringConverter<Customer>), () => new CustomerStringConverter(new CustomerRepository(SessionFactory)));
			impl.Add(typeof(IStringConverter<Product>), () => new ProductStringConverter(new ProductRepository(SessionFactory)));
			impl.Add(typeof(IStringConverter<Category>), () => new CategoryStringConverter(new CategoryRepository(SessionFactory)));
			impl.Add(typeof(NHibernate.Validator.Engine.ValidatorEngine), () => NHibernate.Validator.Cfg.Environment.SharedEngineProvider.GetEngine());

			impl.Add(typeof(IAuthorizationRepository), () => new AuthorizationRepository(SessionFactory.GetCurrentSession()));
			impl.Add(typeof(IPermissionsService), () => new PermissionsService(ServiceLocator.Current.GetInstance<IAuthorizationRepository>(), SessionFactory.GetCurrentSession()));
			impl.Add(typeof(IAuthorizationService), () => new AuthorizationService(ServiceLocator.Current.GetInstance<IPermissionsService>(), ServiceLocator.Current.GetInstance<IAuthorizationRepository>()));
			impl.Add(typeof(IPermissionsBuilderService), () => new PermissionsBuilderService(SessionFactory.GetCurrentSession(), ServiceLocator.Current.GetInstance<IAuthorizationRepository>()));

			impl.Add(typeof(IEntityInformationExtractor<Customer>), () => new CustomerInformationExtractor());

			return impl;
		}

	}
}
