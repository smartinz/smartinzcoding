using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;
using Microsoft.Practices.ServiceLocation;
using Rhino.Security.Interfaces;
using Rhino.Security;

namespace SpikeRhinoSecurity.Data
{
	public class CategoryRepository
	{

		private NHibernate.ISessionFactory _northwind;


		public CategoryRepository(NHibernate.ISessionFactory northwind)
		{

			_northwind = northwind;

		}

		public void Create(SpikeRhinoSecurity.Domain.Category v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.Category Read(int categoryId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Category>(categoryId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Category v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.Category v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<SpikeRhinoSecurity.Domain.Category> Search(int? categoryId, string categoryName, string description)
		{
			IQueryable<SpikeRhinoSecurity.Domain.Category> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Category>();
			if (categoryId != default(int?))
			{
				queryable = queryable.Where(x => x.CategoryId == categoryId);
			}
			if (categoryName != default(string))
			{
				queryable = queryable.Where(x => x.CategoryName.StartsWith(categoryName));
			}
			if (description != default(string))
			{
				queryable = queryable.Where(x => x.Description.StartsWith(description));
			}

			return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Category>(queryable);
		}

		public IPresentableSet<SpikeRhinoSecurity.Domain.Category> Search()
		{
			IQueryable<SpikeRhinoSecurity.Domain.Category> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Category>();

			((INHibernateQueryable)queryable).QueryOptions.RegisterCustomAction(x =>
ServiceLocator.Current.GetInstance<IAuthorizationService>().AddPermissionsToQuery(ServiceLocator.Current.GetInstance<IUser>(),
"/Category/Search",
x));

			return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Category>(queryable);
		}


	}
}