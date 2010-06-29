using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;
using SpikeRhinoSecurity.Domain;
using Microsoft.Practices.ServiceLocation;
using Rhino.Security.Interfaces;
using Rhino.Security;
using NHibernate;
using NHibernate.Criterion;

namespace SpikeRhinoSecurity.Data
{
	public class ProductRepository
	{

		private NHibernate.ISessionFactory _northwind;


		public ProductRepository(NHibernate.ISessionFactory northwind)
		{

			_northwind = northwind;

		}

		public void Create(SpikeRhinoSecurity.Domain.Product p)
		{
			_northwind.GetCurrentSession().Save(p);

			// now, associate it with the correct security EntitiesGroup
			if (p.Category != null)
			{
				var authorizationRepository = ServiceLocator.Current.GetInstance<IAuthorizationRepository>();
				var eg = authorizationRepository.GetAssociatedEntitiesGroupsFor(p.Category).FirstOrDefault(); // TODO: fix this 
				if (eg != null)
				{
					authorizationRepository.AssociateEntityWith(p, eg);
				}
			}
		}

		public SpikeRhinoSecurity.Domain.Product Read(int productId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Product>(productId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Product v)
		{
			_northwind.GetCurrentSession().Update(v);

			// now, make sure it is still associated with the correct security EntitiesGroup
			if (v.Category != null)
			{
				var expectedNewEntitiesGroupName = string.Format("Category{0}", v.Category.CategoryId);

				var authorizationRepository = ServiceLocator.Current.GetInstance<IAuthorizationRepository>();
				var currentEntitiesGroupForProduct = authorizationRepository.GetAssociatedEntitiesGroupsFor(v);
				
				// this is incorrect but it'll do for now (the product might be associated to more than one eg and we need to remove only from the one on category here)
				foreach (var eg in currentEntitiesGroupForProduct.Where(x => x.Name != expectedNewEntitiesGroupName))
				{
					authorizationRepository.DetachEntityFromGroup(v, eg.Name);
				}

				// associate to new entity group if existing
				var newEntityGroup = authorizationRepository.GetEntitiesGroupByName(expectedNewEntitiesGroupName);
				if (newEntityGroup != null)
				{
					authorizationRepository.AssociateEntityWith(v, newEntityGroup);
				}
			}
		}

		public void Delete(SpikeRhinoSecurity.Domain.Product v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<SpikeRhinoSecurity.Domain.Product> Search(int? productId, string productName, string quantityPerUnit, decimal? unitPrice, short? unitsInStock, short? unitsOnOrder, short? reorderLevel, bool? discontinued)
		{
			IQueryable<SpikeRhinoSecurity.Domain.Product> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Product>();
			if (productId != default(int?))
			{
				queryable = queryable.Where(x => x.ProductId == productId);
			}
			if (productName != default(string))
			{
				queryable = queryable.Where(x => x.ProductName.StartsWith(productName));
			}
			if (quantityPerUnit != default(string))
			{
				queryable = queryable.Where(x => x.QuantityPerUnit.StartsWith(quantityPerUnit));
			}
			if (unitPrice != default(decimal?))
			{
				queryable = queryable.Where(x => x.UnitPrice == unitPrice);
			}
			if (unitsInStock != default(short?))
			{
				queryable = queryable.Where(x => x.UnitsInStock == unitsInStock);
			}
			if (unitsOnOrder != default(short?))
			{
				queryable = queryable.Where(x => x.UnitsOnOrder == unitsOnOrder);
			}
			if (reorderLevel != default(short?))
			{
				queryable = queryable.Where(x => x.ReorderLevel == reorderLevel);
			}
			if (discontinued != default(bool?))
			{
				queryable = queryable.Where(x => x.Discontinued == discontinued);
			}

			return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Product>(queryable);
		}

		public IPresentableSet<SpikeRhinoSecurity.Domain.Product> Search(string productName, Category category)
		{
			IQueryable<SpikeRhinoSecurity.Domain.Product> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Product>();
			if (productName != default(string))
			{
				queryable = queryable.Where(x => x.ProductName.StartsWith(productName));
			}
			if (category != null)
			{
				queryable = queryable.Where(x => x.Category == category);
			}

			((INHibernateQueryable)queryable).QueryOptions.RegisterCustomAction(x =>
				ServiceLocator.Current.GetInstance<IAuthorizationService>().AddPermissionsToQuery(ServiceLocator.Current.GetInstance<IUser>(),
				"/Category/Read", x));

			return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Product>(queryable);
		}

	}
}