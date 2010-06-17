using System.Linq;
using NHibernate.Linq;
using Nexida.Infrastructure;

namespace Rhino.Security.Data
{
	public class UserRepository : Nexida.Infrastructure.IRepository
	{

				private NHibernate.ISessionFactory _northwindWithSecurity;
				

		public UserRepository(NHibernate.ISessionFactory northwindWithSecurity)	
		{

						_northwindWithSecurity = northwindWithSecurity;
						
		}
		
		public void Create(Rhino.Security.Model.User v)
		{
			_northwindWithSecurity.GetCurrentSession().Save(v);
		}

		public Rhino.Security.Model.User Read(System.Int64 id)
		{
			return _northwindWithSecurity.GetCurrentSession().Load<Rhino.Security.Model.User>(id);
		}

		public void Update(Rhino.Security.Model.User v)
		{
			_northwindWithSecurity.GetCurrentSession().Update(v);
		}

		public void Delete(Rhino.Security.Model.User v)
		{
			_northwindWithSecurity.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<Rhino.Security.Model.User> Search(System.Int64? id, string name)
				{
					IQueryable<Rhino.Security.Model.User> queryable = _northwindWithSecurity.GetCurrentSession().Linq<Rhino.Security.Model.User>();
								if(id != default(System.Int64?))
								{
									queryable = queryable.Where(x => x.Id == id);
								}
											if(!string.IsNullOrEmpty(name))
								{
									queryable = queryable.Where(x => x.Name.StartsWith(name));
								}
								
					return new Nexida.Infrastructure.QueryablePresentableSet<Rhino.Security.Model.User>(queryable);
				}
				
	}
}