using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;

namespace SpikeRhinoSecurity.Data
{
	public class OrderDetailRepository
	{

				private NHibernate.ISessionFactory _northwind;
				

		public OrderDetailRepository(NHibernate.ISessionFactory northwind)	
		{

						_northwind = northwind;
						
		}
		
		public void Create(SpikeRhinoSecurity.Domain.OrderDetail v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.OrderDetail Read(int orderId, int productId)
		{
			var keyObject = new SpikeRhinoSecurity.Domain.OrderDetail {OrderId = orderId, ProductId = productId};
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.OrderDetail>(keyObject);
		}

		public void Update(SpikeRhinoSecurity.Domain.OrderDetail v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.OrderDetail v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<SpikeRhinoSecurity.Domain.OrderDetail> Search(int? orderId, int? productId, decimal? unitPrice, short? quantity, float? discount)
				{
					IQueryable<SpikeRhinoSecurity.Domain.OrderDetail> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.OrderDetail>();
								if(orderId != default(int?))
								{
									queryable = queryable.Where(x => x.OrderId == orderId);
								}
											if(productId != default(int?))
								{
									queryable = queryable.Where(x => x.ProductId == productId);
								}
											if(unitPrice != default(decimal?))
								{
									queryable = queryable.Where(x => x.UnitPrice == unitPrice);
								}
											if(quantity != default(short?))
								{
									queryable = queryable.Where(x => x.Quantity == quantity);
								}
											if(discount != default(float?))
								{
									queryable = queryable.Where(x => x.Discount == discount);
								}
								
					return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.OrderDetail>(queryable);
				}
				
	}
}