using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;

namespace SpikeRhinoSecurity.Data
{
	public class RegionRepository
	{

				private NHibernate.ISessionFactory _northwind;
				

		public RegionRepository(NHibernate.ISessionFactory northwind)	
		{

						_northwind = northwind;
						
		}
		
		public void Create(SpikeRhinoSecurity.Domain.Region v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.Region Read(int regionId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Region>(regionId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Region v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.Region v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<SpikeRhinoSecurity.Domain.Region> Search(int? regionId, string regionDescription)
				{
					IQueryable<SpikeRhinoSecurity.Domain.Region> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Region>();
								if(regionId != default(int?))
								{
									queryable = queryable.Where(x => x.RegionId == regionId);
								}
											if(regionDescription != default(string))
								{
									queryable = queryable.Where(x => x.RegionDescription.StartsWith(regionDescription));
								}
								
					return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Region>(queryable);
				}
				
	}
}