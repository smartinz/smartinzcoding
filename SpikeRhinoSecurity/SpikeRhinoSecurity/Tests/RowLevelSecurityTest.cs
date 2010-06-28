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
using NHibernate;

namespace SpikeRhinoSecurity.Tests
{
	[TestFixture]
	public class RowLevelSecurityTest : BaseTest
	{
		[Test]
		public void Should_return_no_product_because_of_missing_permissions_on_category()
		{
			#region Restrict permissions on all categories

			var operationName = "/Category/Read";
			var readOperationOnCategory = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("TmpGuests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);

			// now, by default, "TmpGuests" group has no access to the "/Category/Read" operation

			Assert.IsFalse(AuthZService.IsAllowed(SampleUser, operationName));

			#endregion

			var productRepository = ServiceLocator.Current.GetInstance<ProductRepository>();
			var count = productRepository.Search(null, null).Count();

			Assert.That(count, Is.EqualTo(0));

			Debug.WriteLine(AuthZService.GetAuthorizationInformation(SampleUser, operationName));
		}

		[Test]
		public void Should_return_only_products_related_to_allowed_categories()
		{
			#region Restrict permissions on a single category

			var operationName = "/Category/Read";
			var readOperationOnCategory = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("TmpGuests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);
			
			// now, by default, "TmpGuests" group has no access to the "/Category/Read" operation

			Assert.IsFalse(AuthZService.IsAllowed(SampleUser, operationName));

			// allow a single category
			var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
			var allowedCategory = categoryRepository.Read(1);
			var deniedCategory = categoryRepository.Read(2);

			var permissionBuilder = ServiceLocator.Current.GetInstance<IPermissionsBuilderService>();
			permissionBuilder.Allow(readOperationOnCategory)
				.For(guestGroup)
				.On(allowedCategory)
				.DefaultLevel()
				.Save();

			Assert.IsFalse(AuthZService.IsAllowed(SampleUser, operationName));
			Assert.IsTrue(AuthZService.IsAllowed(SampleUser, allowedCategory, operationName));

			#endregion

			var productRepository = ServiceLocator.Current.GetInstance<ProductRepository>();
			Assert.That(productRepository.Search(null, deniedCategory).Count(), Is.EqualTo(0));
			Assert.That(productRepository.Search(null, allowedCategory).Count(), Is.GreaterThan(0));

			Debug.WriteLine(AuthZService.GetAuthorizationInformation(SampleUser, operationName));


			//productRepository.Search(null, null).AsEnumerable().ToList().ForEach(x =>
			//{
			//    x.EntitySecurityKey = Guid.NewGuid();
			//    productRepository.Update(x);
			//});

			//categoryRepository.Search().AsEnumerable().ToList().ForEach(x =>
			//{
			//    x.EntitySecurityKey = Guid.NewGuid();
			//    categoryRepository.Update(x);
			//});
		}

		[Test]
		public void Should_return_only_product_related_to_allowed_categories2()
		{
			#region Restrict permissions on a single category

			var operationName = "/Category/Read";
			var readOperationOnCategory = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("TmpGuests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);

			// now, by default, "TmpGuests" group has no access to the "/Category/Read" operation

			Assert.IsFalse(AuthZService.IsAllowed(SampleUser, operationName));

			// allow a single category
			var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
			var allowedCategory = categoryRepository.Read(1);
			var deniedCategory = categoryRepository.Read(2);

			var permissionBuilder = ServiceLocator.Current.GetInstance<IPermissionsBuilderService>();
			permissionBuilder.Allow(readOperationOnCategory)
				.For(guestGroup)
				.OnEverything()
				.DefaultLevel()
				.Save();

			var g = ServiceLocator.Current.GetInstance<IPermissionsService>().GetGlobalPermissionsFor(SampleUser, operationName);

			permissionBuilder.Deny(readOperationOnCategory)
				.For(guestGroup)
				.On(deniedCategory)
				.DefaultLevel()
				.Save();

			Assert.IsTrue(AuthZService.IsAllowed(SampleUser, operationName));
			Assert.IsTrue(AuthZService.IsAllowed(SampleUser, allowedCategory, operationName));
			Assert.IsFalse(AuthZService.IsAllowed(SampleUser, deniedCategory, operationName));

			#endregion

			CurrentUser = SampleUser; // simulate different user

			var productRepository = ServiceLocator.Current.GetInstance<ProductRepository>();
			//var p = productRepository.Read(1);
			//var countWithDenied = productRepository.Search(null, deniedCategory).Count();
			//var countWithAllowed = productRepository.Search(null, allowedCategory).Count();
			//var all = productRepository.Search(null, null).Count();

			Assert.That(productRepository.Search(null, deniedCategory).Count(), Is.EqualTo(0));
			Assert.That(productRepository.Search(null, allowedCategory).Count(), Is.GreaterThan(0));

			Debug.WriteLine(AuthZService.GetAuthorizationInformation(SampleUser, operationName));
		}
	}
}
