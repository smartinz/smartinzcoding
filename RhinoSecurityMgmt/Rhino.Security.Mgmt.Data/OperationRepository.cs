using System.Linq;
using NHibernate.Linq;
using Nexida.Infrastructure;

namespace Rhino.Security.Mgmt.Data
{
	public class OperationRepository : Nexida.Infrastructure.IRepository
	{

				private NHibernate.ISessionFactory _northwindWithSecurity;
				

		public OperationRepository(NHibernate.ISessionFactory northwindWithSecurity)	
		{

						_northwindWithSecurity = northwindWithSecurity;
						
		}
		
		public void Create(Rhino.Security.Model.Operation v)
		{
			_northwindWithSecurity.GetCurrentSession().Save(v);
		}

		public Rhino.Security.Model.Operation Read(System.Guid id)
		{
			return _northwindWithSecurity.GetCurrentSession().Load<Rhino.Security.Model.Operation>(id);
		}

		public void Update(Rhino.Security.Model.Operation v)
		{
			_northwindWithSecurity.GetCurrentSession().Update(v);
		}

		public void Delete(Rhino.Security.Model.Operation v)
		{
			_northwindWithSecurity.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<Rhino.Security.Model.Operation> Search(System.Guid? id, string name, string comment)
				{
					IQueryable<Rhino.Security.Model.Operation> queryable = _northwindWithSecurity.GetCurrentSession().Linq<Rhino.Security.Model.Operation>();
								if(id != default(System.Guid?))
								{
									queryable = queryable.Where(x => x.Id == id);
								}
											if(!string.IsNullOrEmpty(name))
								{
									queryable = queryable.Where(x => x.Name.StartsWith(name));
								}
											if(!string.IsNullOrEmpty(comment))
								{
									queryable = queryable.Where(x => x.Comment.StartsWith(comment));
								}
								
					return new Nexida.Infrastructure.QueryablePresentableSet<Rhino.Security.Model.Operation>(queryable);
				}
				
	}
}