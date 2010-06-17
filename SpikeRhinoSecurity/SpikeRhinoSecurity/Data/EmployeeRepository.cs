using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;

namespace SpikeRhinoSecurity.Data
{
	public class EmployeeRepository
	{

				private NHibernate.ISessionFactory _northwind;
				

		public EmployeeRepository(NHibernate.ISessionFactory northwind)	
		{

						_northwind = northwind;
						
		}
		
		public void Create(SpikeRhinoSecurity.Domain.Employee v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.Employee Read(int employeeId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Employee>(employeeId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Employee v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.Employee v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<SpikeRhinoSecurity.Domain.Employee> Search(int? employeeId, string lastName, string firstName, string title, string titleOfCourtesy, System.DateTime? birthDate, System.DateTime? hireDate, string address, string city, string region, string postalCode, string country, string homePhone, string extension, string notes, string photoPath)
				{
					IQueryable<SpikeRhinoSecurity.Domain.Employee> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Employee>();
								if(employeeId != default(int?))
								{
									queryable = queryable.Where(x => x.EmployeeId == employeeId);
								}
											if(lastName != default(string))
								{
									queryable = queryable.Where(x => x.LastName.StartsWith(lastName));
								}
											if(firstName != default(string))
								{
									queryable = queryable.Where(x => x.FirstName.StartsWith(firstName));
								}
											if(title != default(string))
								{
									queryable = queryable.Where(x => x.Title.StartsWith(title));
								}
											if(titleOfCourtesy != default(string))
								{
									queryable = queryable.Where(x => x.TitleOfCourtesy.StartsWith(titleOfCourtesy));
								}
											if(birthDate != default(System.DateTime?))
								{
									queryable = queryable.Where(x => x.BirthDate == birthDate);
								}
											if(hireDate != default(System.DateTime?))
								{
									queryable = queryable.Where(x => x.HireDate == hireDate);
								}
											if(address != default(string))
								{
									queryable = queryable.Where(x => x.Address.StartsWith(address));
								}
											if(city != default(string))
								{
									queryable = queryable.Where(x => x.City.StartsWith(city));
								}
											if(region != default(string))
								{
									queryable = queryable.Where(x => x.Region.StartsWith(region));
								}
											if(postalCode != default(string))
								{
									queryable = queryable.Where(x => x.PostalCode.StartsWith(postalCode));
								}
											if(country != default(string))
								{
									queryable = queryable.Where(x => x.Country.StartsWith(country));
								}
											if(homePhone != default(string))
								{
									queryable = queryable.Where(x => x.HomePhone.StartsWith(homePhone));
								}
											if(extension != default(string))
								{
									queryable = queryable.Where(x => x.Extension.StartsWith(extension));
								}
											if(notes != default(string))
								{
									queryable = queryable.Where(x => x.Notes.StartsWith(notes));
								}
											if(photoPath != default(string))
								{
									queryable = queryable.Where(x => x.PhotoPath.StartsWith(photoPath));
								}
								
					return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Employee>(queryable);
				}
				
	}
}