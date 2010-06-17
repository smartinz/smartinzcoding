using System.Linq;
using NHibernate.Linq;
using Nexida.Infrastructure;

namespace Rhino.Security.Data
{
	public class PermissionRepository : Nexida.Infrastructure.IRepository
	{

				private NHibernate.ISessionFactory _northwindWithSecurity;
				

		public PermissionRepository(NHibernate.ISessionFactory northwindWithSecurity)	
		{

						_northwindWithSecurity = northwindWithSecurity;
						
		}
		
		public void Create(Rhino.Security.Model.Permission v)
		{
			_northwindWithSecurity.GetCurrentSession().Save(v);
		}

		public Rhino.Security.Model.Permission Read(System.Guid id)
		{
			return _northwindWithSecurity.GetCurrentSession().Load<Rhino.Security.Model.Permission>(id);
		}

		public void Update(Rhino.Security.Model.Permission v)
		{
			_northwindWithSecurity.GetCurrentSession().Update(v);
		}

		public void Delete(Rhino.Security.Model.Permission v)
		{
			_northwindWithSecurity.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<Rhino.Security.Model.Permission> Search(System.Guid? id, System.Guid? entitySecurityKey, bool? allow, int? level, string entityTypeName)
				{
					IQueryable<Rhino.Security.Model.Permission> queryable = _northwindWithSecurity.GetCurrentSession().Linq<Rhino.Security.Model.Permission>();
								if(id != default(System.Guid?))
								{
									queryable = queryable.Where(x => x.Id == id);
								}
											if(entitySecurityKey != default(System.Guid?))
								{
									queryable = queryable.Where(x => x.EntitySecurityKey == entitySecurityKey);
								}
											if(allow != default(bool?))
								{
									queryable = queryable.Where(x => x.Allow == allow);
								}
											if(level != default(int?))
								{
									queryable = queryable.Where(x => x.Level == level);
								}
											if(!string.IsNullOrEmpty(entityTypeName))
								{
									queryable = queryable.Where(x => x.EntityTypeName.StartsWith(entityTypeName));
								}
								
					return new Nexida.Infrastructure.QueryablePresentableSet<Rhino.Security.Model.Permission>(queryable);
				}
				
	}
}