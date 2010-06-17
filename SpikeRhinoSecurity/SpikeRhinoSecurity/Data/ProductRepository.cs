using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;
using SpikeRhinoSecurity.Domain;

namespace SpikeRhinoSecurity.Data
{
	public class ProductRepository
	{

		private NHibernate.ISessionFactory _northwind;


		public ProductRepository(NHibernate.ISessionFactory northwind)
		{

			_northwind = northwind;

		}

		public void Create(SpikeRhinoSecurity.Domain.Product v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.Product Read(int productId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Product>(productId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Product v)
		{
			_northwind.GetCurrentSession().Update(v);
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

			return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Product>(queryable);
		}

	}
}