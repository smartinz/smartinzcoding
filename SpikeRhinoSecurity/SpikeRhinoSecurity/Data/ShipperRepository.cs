using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;

namespace SpikeRhinoSecurity.Data
{
	public class ShipperRepository
	{

				private NHibernate.ISessionFactory _northwind;
				

		public ShipperRepository(NHibernate.ISessionFactory northwind)	
		{

						_northwind = northwind;
						
		}
		
		public void Create(SpikeRhinoSecurity.Domain.Shipper v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.Shipper Read(int shipperId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Shipper>(shipperId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Shipper v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.Shipper v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<SpikeRhinoSecurity.Domain.Shipper> Search(int? shipperId, string companyName, string phone)
				{
					IQueryable<SpikeRhinoSecurity.Domain.Shipper> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Shipper>();
								if(shipperId != default(int?))
								{
									queryable = queryable.Where(x => x.ShipperId == shipperId);
								}
											if(companyName != default(string))
								{
									queryable = queryable.Where(x => x.CompanyName.StartsWith(companyName));
								}
											if(phone != default(string))
								{
									queryable = queryable.Where(x => x.Phone.StartsWith(phone));
								}
								
					return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Shipper>(queryable);
				}
				
	}
}