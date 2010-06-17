using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;

namespace SpikeRhinoSecurity.Data
{
	public class OrderRepository
	{

				private NHibernate.ISessionFactory _northwind;
				

		public OrderRepository(NHibernate.ISessionFactory northwind)	
		{

						_northwind = northwind;
						
		}
		
		public void Create(SpikeRhinoSecurity.Domain.Order v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.Order Read(int orderId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Order>(orderId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Order v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.Order v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<SpikeRhinoSecurity.Domain.Order> Search(int? orderId, System.DateTime? orderDate, System.DateTime? requiredDate, System.DateTime? shippedDate, decimal? freight, string shipName, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry)
				{
					IQueryable<SpikeRhinoSecurity.Domain.Order> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Order>();
								if(orderId != default(int?))
								{
									queryable = queryable.Where(x => x.OrderId == orderId);
								}
											if(orderDate != default(System.DateTime?))
								{
									queryable = queryable.Where(x => x.OrderDate == orderDate);
								}
											if(requiredDate != default(System.DateTime?))
								{
									queryable = queryable.Where(x => x.RequiredDate == requiredDate);
								}
											if(shippedDate != default(System.DateTime?))
								{
									queryable = queryable.Where(x => x.ShippedDate == shippedDate);
								}
											if(freight != default(decimal?))
								{
									queryable = queryable.Where(x => x.Freight == freight);
								}
											if(shipName != default(string))
								{
									queryable = queryable.Where(x => x.ShipName.StartsWith(shipName));
								}
											if(shipAddress != default(string))
								{
									queryable = queryable.Where(x => x.ShipAddress.StartsWith(shipAddress));
								}
											if(shipCity != default(string))
								{
									queryable = queryable.Where(x => x.ShipCity.StartsWith(shipCity));
								}
											if(shipRegion != default(string))
								{
									queryable = queryable.Where(x => x.ShipRegion.StartsWith(shipRegion));
								}
											if(shipPostalCode != default(string))
								{
									queryable = queryable.Where(x => x.ShipPostalCode.StartsWith(shipPostalCode));
								}
											if(shipCountry != default(string))
								{
									queryable = queryable.Where(x => x.ShipCountry.StartsWith(shipCountry));
								}
								
					return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Order>(queryable);
				}
				
	}
}