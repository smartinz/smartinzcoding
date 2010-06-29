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
			#region Setup

			var operationName = "/Category/Read";
			var readOperationOnCategory = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("TmpGuests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);

			var permissionBuilder = ServiceLocator.Current.GetInstance<IPermissionsBuilderService>();
			permissionBuilder.Allow(readOperationOnCategory)
				.For(AdminUser)
				.OnEverything()
				.DefaultLevel()
				.Save();

			CurrentSession.Flush();

			#endregion

			var productRepository = ServiceLocator.Current.GetInstance<ProductRepository>();

			CurrentUser = AdminUser; // simulate admin user
			Assert.That(productRepository.Search(null, null).Count(), Is.GreaterThan(0));

			CurrentUser = SampleUser; // simulate different user
			Assert.That(productRepository.Search(null, null).Count(), Is.EqualTo(0));

			Debug.WriteLine(AuthZService.GetAuthorizationInformation(SampleUser, operationName));
		}

		[Test]
		public void Should_return_only_products_related_to_allowed_categories()
		{
			#region Setup

			var operationName = "/Category/Read";
			var readOperationOnCategory = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("TmpGuests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);
			var entitiesGroupForCategory1 = AuthZRepository.CreateEntitiesGroup("Category1");

			var permissionBuilder = ServiceLocator.Current.GetInstance<IPermissionsBuilderService>();
			permissionBuilder.Allow(readOperationOnCategory)
				.For(AdminUser)
				.OnEverything()
				.DefaultLevel()
				.Save();

			var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
			var allowedCategory = categoryRepository.Read(1);
			var deniedCategory = categoryRepository.Read(2);
			AuthZRepository.AssociateEntityWith(allowedCategory, entitiesGroupForCategory1);

			CurrentSession.Flush();

			var productRepository = ServiceLocator.Current.GetInstance<ProductRepository>();
			productRepository.Search(null, allowedCategory).AsEnumerable().ToList().ForEach(x =>
			{
				AuthZRepository.AssociateEntityWith(x, entitiesGroupForCategory1);
			});

			permissionBuilder.Allow(readOperationOnCategory)
				.For(SampleUser)
				.On(entitiesGroupForCategory1)
				.DefaultLevel()
				.Save();

			CurrentSession.Flush();

			#endregion

			CurrentUser = SampleUser; // simulate different user

			Assert.That(productRepository.Search(null, deniedCategory).Count(), Is.EqualTo(0));
			Assert.That(productRepository.Search(null, allowedCategory).Count(), Is.GreaterThan(0));
		}

		[Test]
		public void New_allowed_product_should_be_returned_in_search_result()
		{
			#region Setup

			var operationName = "/Category/Read";
			var readOperationOnCategory = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("TmpGuests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);

			var permissionBuilder = ServiceLocator.Current.GetInstance<IPermissionsBuilderService>();
			permissionBuilder.Allow(readOperationOnCategory)
				.For(AdminUser)
				.OnEverything()
				.DefaultLevel()
				.Save();

			var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
			var allowedCategory = categoryRepository.Read(1);
			var deniedCategory = categoryRepository.Read(2);
			var entitiesGroupForCategory1 = AuthZRepository.CreateEntitiesGroup(string.Format("Category{0}",allowedCategory.CategoryId));
			AuthZRepository.AssociateEntityWith(allowedCategory, entitiesGroupForCategory1);

			CurrentSession.Flush();

			var productRepository = ServiceLocator.Current.GetInstance<ProductRepository>();
			productRepository.Search(null, allowedCategory).AsEnumerable().ToList().ForEach(x =>
			{
				AuthZRepository.AssociateEntityWith(x, entitiesGroupForCategory1);
			});

			permissionBuilder.Allow(readOperationOnCategory)
				.For(SampleUser)
				.On(entitiesGroupForCategory1)
				.DefaultLevel()
				.Save();

			CurrentSession.Flush();

			#endregion

			CurrentUser = SampleUser; // simulate different user
			var countOfAllowedProductsBeforeAddingNewProduct = productRepository.Search(null, null).Count();

			// now add a new product
			var p = new Product
			{
				Category = allowedCategory,
				Discontinued = false,
				EntitySecurityKey = Guid.NewGuid(),
				ProductName = "new test product"
			};

			productRepository.Create(p);
			CurrentSession.Flush();

			Assert.That(productRepository.Search(null, null).Count(), Is.EqualTo(countOfAllowedProductsBeforeAddingNewProduct + 1));
		}

		[Test]
		public void Updated_product_should_now_be_denied()
		{
			#region Setup

			var operationName = "/Category/Read";
			var readOperationOnCategory = AuthZRepository.CreateOperation(operationName);
			UsersGroup guestGroup = AuthZRepository.CreateUsersGroup("TmpGuests");
			AuthZRepository.AssociateUserWith(SampleUser, guestGroup);

			var permissionBuilder = ServiceLocator.Current.GetInstance<IPermissionsBuilderService>();
			permissionBuilder.Allow(readOperationOnCategory)
				.For(AdminUser)
				.OnEverything()
				.DefaultLevel()
				.Save();

			var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
			var allowedCategory = categoryRepository.Read(1);
			var deniedCategory = categoryRepository.Read(2);
			var entitiesGroupForCategory1 = AuthZRepository.CreateEntitiesGroup(string.Format("Category{0}", allowedCategory.CategoryId));
			AuthZRepository.AssociateEntityWith(allowedCategory, entitiesGroupForCategory1);

			CurrentSession.Flush();

			var productRepository = ServiceLocator.Current.GetInstance<ProductRepository>();
			productRepository.Search(null, allowedCategory).AsEnumerable().ToList().ForEach(x =>
			{
				AuthZRepository.AssociateEntityWith(x, entitiesGroupForCategory1);
			});

			permissionBuilder.Allow(readOperationOnCategory)
				.For(SampleUser)
				.On(entitiesGroupForCategory1)
				.DefaultLevel()
				.Save();

			CurrentSession.Flush();

			#endregion

			CurrentUser = SampleUser; // simulate different user
			var countOfAllowedProductsBeforeAddingNewProduct = productRepository.Search(null, null).Count();

			// now update a product: change category, so it's denied
			var p = productRepository.Search(null, allowedCategory).AsEnumerable().First();
			p.Category = deniedCategory;
			productRepository.Update(p);
			CurrentSession.Flush();

			Assert.That(productRepository.Search(null, null).Count(), Is.EqualTo(countOfAllowedProductsBeforeAddingNewProduct -1));
		}

		private void ForceNewSecurityKeysOnEntities()
		{

			var productRepository = ServiceLocator.Current.GetInstance<ProductRepository>();
			productRepository.Search(null, null).AsEnumerable().ToList().ForEach(x =>
			{
				x.EntitySecurityKey = Guid.NewGuid();
				productRepository.Update(x);
			});

			var categoryRepository = ServiceLocator.Current.GetInstance<CategoryRepository>();
			categoryRepository.Search().AsEnumerable().ToList().ForEach(x =>
			{
				x.EntitySecurityKey = Guid.NewGuid();
				categoryRepository.Update(x);
			});
		}
	}
}
