using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Microsoft.Practices.ServiceLocation;
using Rhino.Security.Interfaces;
using Rhino.Security;
using Rhino.Security.Model;
using SpikeRhinoSecurity.Domain;
using NHibernate;

namespace SpikeRhinoSecurity.Tests
{
	[TestFixture]
	public class GenericTest : BaseTest
	{
		[Test]
		public void TestThis()
		{
			//Create "AdminUserGroup" UsersGroup                  
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().CreateUsersGroup("AdminUserGroup");
			//Create Child group for "AdminUserGroup"
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().CreateChildUserGroupOf("AdminUserGroup", "GuestUserGroup");

			//Create two operations: root /Content          operation 
			//              and its child /Content/Manage   operation
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().CreateOperation("/Content/Manage");
			//Create third operation as child of the /Content
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().CreateOperation("/Content/View");
			//add user to "AdminUserGroup", so all further permissions for "AdminUserGroup"
			//group are aslo applied for the user also               
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().AssociateUserWith(ServiceLocator.Current.GetInstance<IUser>(), "AdminUserGroup");

			//Create Permission using Builder Pattern 
			//and its fluent interface:               
			ServiceLocator.Current.GetInstance<IPermissionsBuilderService>()
				//Allow "/Content" Operation 
			  .Allow("/Content")
				//for "AdminUserGroup"
			  .For("AdminUserGroup")
				//Could be specified On an entityGroup 
				//or an entity that implemented IEntityInformationExtractor  
			  .OnEverything()
				//Here could be specified Permission priority Level
				//DefaultLevel is equal with 1
			  .DefaultLevel()
			  .Save();

			//Create Deny permission for user with level 5    
			ServiceLocator.Current.GetInstance<IPermissionsBuilderService>()
			  .Deny("/Content/View")
			  .For(ServiceLocator.Current.GetInstance<IUser>())
			  .OnEverything()
			  .Level(5)
			  .Save();

			//Ask users allowance for an Operation
			bool isAllowedContentOp = ServiceLocator.Current.GetInstance<IAuthorizationService>().IsAllowed(ServiceLocator.Current.GetInstance<IUser>(), "/Content");
			bool isAllowedContentManageOp = ServiceLocator.Current.GetInstance<IAuthorizationService>().IsAllowed(ServiceLocator.Current.GetInstance<IUser>(), "/Content/Manage");

			Console.WriteLine("Has access to /Content: {0}", isAllowedContentOp);
			Console.WriteLine("Has access to /Content/Manage: {0}", isAllowedContentManageOp);

			//Retrieve Rhino Security entities  
			UsersGroup adminUsersGroupWithoutUser = ServiceLocator.Current.GetInstance<IAuthorizationRepository>().GetUsersGroupByName("AdminUserGroup");
			Operation contentViewOp = ServiceLocator.Current.GetInstance<IAuthorizationRepository>().GetOperationByName("/Content/View");
			Permission[] userArtPermission = ServiceLocator.Current.GetInstance<IPermissionsService>().GetPermissionsFor(ServiceLocator.Current.GetInstance<IUser>());

			Console.WriteLine("Returned UsersGroup: {0}", adminUsersGroupWithoutUser.Name);
			Console.WriteLine("Returned Operation: {0}", contentViewOp.Name);

			//First userArtPermission[0] doesn't have User Group because it wasn't associated
			// with any group, it was associated directly with user (...Deny("/Content/View").For(userArt)...)
			//Second permission (userArtPermission[1]) is associated to Group "AdminUserGroup"
			// (...Allow("/Content").For("AdminUserGroup")..)
			Console.WriteLine("Returned Permission UsersGroup: {0}", userArtPermission[1].UsersGroup.Name);

			//Retrieve athorization info that can help to 
			//understand reason of allowance (or not) of an operation
			//its very helpful for debuging
			AuthorizationInformation authInfo = ServiceLocator.Current.GetInstance<IAuthorizationService>().GetAuthorizationInformation(ServiceLocator.Current.GetInstance<IUser>(), "/Content");

			Console.WriteLine("Get Athorization Info: {0}", authInfo);

			//Cleanup created entities
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().RemoveOperation("/Content/Manage");
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().RemoveOperation("/Content/View");
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().RemoveOperation("/Content");
			//Remove child group first
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().RemoveUsersGroup("GuestUserGroup");
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().RemoveUsersGroup("AdminUserGroup");
			ServiceLocator.Current.GetInstance<IAuthorizationRepository>().RemoveUser(ServiceLocator.Current.GetInstance<IUser>());
			CurrentSession.Delete(ServiceLocator.Current.GetInstance<IUser>());
		}
	}
}
