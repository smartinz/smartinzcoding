using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.Practices.ServiceLocation;
using SpikeRhinoSecurity.Data;
using Rhino.Security.Interfaces;
using Rhino.Security.Model;
using System.Diagnostics;
using SpikeRhinoSecurity.Domain;

namespace SpikeRhinoSecurity.Tests
{
	[TestFixture]
	public class EntityLevelSecurityTest : BaseTest
	{
		[Test]
		public void Default_should_be_deny()
		{
			var operationName = "/Customer/Read";
			var readOperationOnCustomer = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("Guests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);

			var customerRepository = ServiceLocator.Current.GetInstance<CustomerRepository>();

			//customerRepository.Search("").AsEnumerable().ToList().ForEach(x =>
			//{
			//    x.EntitySecurityKey = Guid.NewGuid();
			//    customerRepository.Update(x);
			//});

			var customerToSecure = customerRepository.Read("ALFKI");

			Assert.IsFalse(AuthZService.IsAllowed(SampleUser, operationName));
			Assert.IsFalse(AuthZService.IsAllowed(SampleUser, customerToSecure, operationName));

			Debug.WriteLine(AuthZService.GetAuthorizationInformation(SampleUser, customerToSecure, operationName));
		}

		[Test]
		public void Guest_user_should_not_be_able_to_read_entity()
		{
			var operationName = "/Customer/Read";
			var readOperationOnCustomer = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("Guests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);

			var customerRepository = ServiceLocator.Current.GetInstance<CustomerRepository>();

			var customerToSecure = customerRepository.Read("ALFKI");

			var permissionBuilder = ServiceLocator.Current.GetInstance<IPermissionsBuilderService>();
			permissionBuilder.Deny(readOperationOnCustomer)
				.For(guestGroup)
				.On(customerToSecure)
				.DefaultLevel()
				.Save();

			Assert.IsFalse(AuthZService.IsAllowed(SampleUser, customerToSecure, operationName));

			Debug.WriteLine(AuthZService.GetAuthorizationInformation(SampleUser, customerToSecure, operationName));
		}

		[Test]
		public void Guest_user_should_be_allowed_on_secured_entity()
		{
			var operationName = "/Customer/Read";
			var readOperationOnCustomer = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("Guests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);

			var customerRepository = ServiceLocator.Current.GetInstance<CustomerRepository>();

			var customerToSecure = customerRepository.Read("ALFKI");

			var permissionBuilder = ServiceLocator.Current.GetInstance<IPermissionsBuilderService>();
			permissionBuilder.Allow(readOperationOnCustomer)
				.For(guestGroup)
				.On(customerToSecure)
				.DefaultLevel()
				.Save();

			Debug.WriteLine(AuthZService.GetAuthorizationInformation(SampleUser, customerToSecure, operationName));
			Debug.WriteLine(AuthZService.GetAuthorizationInformation(SampleUser, operationName));

			Assert.IsTrue(AuthZService.IsAllowed(SampleUser, customerToSecure, operationName));
			Assert.IsFalse(AuthZService.IsAllowed(SampleUser, operationName));
		}


		[Test]
		public void Guest_user_trying_to_search_secured_entity_should_get_no_results()
		{
			var operationName = "/Customer/Read";
			var readOperationOnCustomer = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("Guests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);

			var customerRepository = ServiceLocator.Current.GetInstance<CustomerRepository>();

			var customerToSecure = customerRepository.Read("ALFKI");

			var c = new Customer();
			c.CustomerId = customerToSecure.CustomerId;

			var permissionBuilder = ServiceLocator.Current.GetInstance<IPermissionsBuilderService>();
			permissionBuilder.Allow(readOperationOnCustomer)
				.For(guestGroup)
				.OnEverything()
				.DefaultLevel()
				.Save();

			permissionBuilder.Allow(readOperationOnCustomer)
				.For(AdminUser)
				.OnEverything()
				.DefaultLevel()
				.Save();

			permissionBuilder.Deny(readOperationOnCustomer)
				.For(guestGroup)
				.On(customerToSecure)
				.DefaultLevel()
				.Save();

			// read as an Admin
			Debug.WriteLine(AuthZService.GetAuthorizationInformation(CurrentUser, customerToSecure, operationName));
			Assert.That(customerRepository.Search("A", null, null, null, null,null,null,null,null,null, null).AsEnumerable().FirstOrDefault(x => x.CustomerId == "ALFKI"), Is.Not.Null);

			// read as a Guest
			CurrentUser = SampleUser;
			Debug.WriteLine(AuthZService.GetAuthorizationInformation(CurrentUser, customerToSecure, operationName));
			Assert.That(customerRepository.Search("A", null, null, null, null, null, null, null, null, null, null).AsEnumerable().FirstOrDefault(x => x.CustomerId == "ALFKI"), Is.Null);
		}
	}
}
