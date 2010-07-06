using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rhino.Security.Interfaces;
using NHibernate;
using Rhino.Security.Services;

namespace Rhino.Security.Mgmt.Data
{
	public class AuthorizationRepositoryFactory
	{
		ISessionFactory _sessionFactory;
		public AuthorizationRepositoryFactory(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
		}

		public IAuthorizationRepository Create()
		{
			return new AuthorizationRepository(_sessionFactory.GetCurrentSession());
		}
	}
}
