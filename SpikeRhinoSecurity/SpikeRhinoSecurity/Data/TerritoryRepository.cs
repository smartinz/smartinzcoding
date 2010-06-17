using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;

namespace SpikeRhinoSecurity.Data
{
	public class TerritoryRepository
	{

				private NHibernate.ISessionFactory _northwind;
				

		public TerritoryRepository(NHibernate.ISessionFactory northwind)	
		{

						_northwind = northwind;
						
		}
		
		public void Create(SpikeRhinoSecurity.Domain.Territory v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.Territory Read(string territoryId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Territory>(territoryId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Territory v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.Territory v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<SpikeRhinoSecurity.Domain.Territory> Search(string territoryId, string territoryDescription)
				{
					IQueryable<SpikeRhinoSecurity.Domain.Territory> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Territory>();
								if(territoryId != default(string))
								{
									queryable = queryable.Where(x => x.TerritoryId.StartsWith(territoryId));
								}
											if(territoryDescription != default(string))
								{
									queryable = queryable.Where(x => x.TerritoryDescription.StartsWith(territoryDescription));
								}
								
					return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Territory>(queryable);
				}
				
	}
}