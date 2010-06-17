using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;

namespace SpikeRhinoSecurity.Data
{
	public class CustomerDemographicRepository
	{

				private NHibernate.ISessionFactory _northwind;
				

		public CustomerDemographicRepository(NHibernate.ISessionFactory northwind)	
		{

						_northwind = northwind;
						
		}
		
		public void Create(SpikeRhinoSecurity.Domain.CustomerDemographic v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.CustomerDemographic Read(string customerTypeId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.CustomerDemographic>(customerTypeId);
		}

		public void Update(SpikeRhinoSecurity.Domain.CustomerDemographic v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.CustomerDemographic v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<SpikeRhinoSecurity.Domain.CustomerDemographic> Search(string customerTypeId, string customerDesc)
				{
					IQueryable<SpikeRhinoSecurity.Domain.CustomerDemographic> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.CustomerDemographic>();
								if(customerTypeId != default(string))
								{
									queryable = queryable.Where(x => x.CustomerTypeId.StartsWith(customerTypeId));
								}
											if(customerDesc != default(string))
								{
									queryable = queryable.Where(x => x.CustomerDesc.StartsWith(customerDesc));
								}
								
					return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.CustomerDemographic>(queryable);
				}
				
	}
}