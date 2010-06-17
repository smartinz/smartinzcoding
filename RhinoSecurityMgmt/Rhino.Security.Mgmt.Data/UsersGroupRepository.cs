using System.Linq;
using NHibernate.Linq;
using Nexida.Infrastructure;

namespace Rhino.Security.Mgmt.Data
{
	public class UsersGroupRepository : Nexida.Infrastructure.IRepository
	{

				private NHibernate.ISessionFactory _northwindWithSecurity;
				

		public UsersGroupRepository(NHibernate.ISessionFactory northwindWithSecurity)	
		{

						_northwindWithSecurity = northwindWithSecurity;
						
		}
		
		public void Create(Rhino.Security.Model.UsersGroup v)
		{
			_northwindWithSecurity.GetCurrentSession().Save(v);
		}

		public Rhino.Security.Model.UsersGroup Read(System.Guid id)
		{
			return _northwindWithSecurity.GetCurrentSession().Load<Rhino.Security.Model.UsersGroup>(id);
		}

		public void Update(Rhino.Security.Model.UsersGroup v)
		{
			_northwindWithSecurity.GetCurrentSession().Update(v);
		}

		public void Delete(Rhino.Security.Model.UsersGroup v)
		{
			_northwindWithSecurity.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<Rhino.Security.Model.UsersGroup> Search(System.Guid? id, string name)
				{
					IQueryable<Rhino.Security.Model.UsersGroup> queryable = _northwindWithSecurity.GetCurrentSession().Linq<Rhino.Security.Model.UsersGroup>();
								if(id != default(System.Guid?))
								{
									queryable = queryable.Where(x => x.Id == id);
								}
											if(!string.IsNullOrEmpty(name))
								{
									queryable = queryable.Where(x => x.Name.StartsWith(name));
								}
								
					return new Nexida.Infrastructure.QueryablePresentableSet<Rhino.Security.Model.UsersGroup>(queryable);
				}
				
	}
}