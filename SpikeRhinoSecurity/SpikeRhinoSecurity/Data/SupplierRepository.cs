using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;

namespace SpikeRhinoSecurity.Data
{
	public class SupplierRepository
	{

				private NHibernate.ISessionFactory _northwind;
				

		public SupplierRepository(NHibernate.ISessionFactory northwind)	
		{

						_northwind = northwind;
						
		}
		
		public void Create(SpikeRhinoSecurity.Domain.Supplier v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.Supplier Read(int supplierId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Supplier>(supplierId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Supplier v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.Supplier v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

				public IPresentableSet<SpikeRhinoSecurity.Domain.Supplier> Search(int? supplierId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax, string homePage)
				{
					IQueryable<SpikeRhinoSecurity.Domain.Supplier> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Supplier>();
								if(supplierId != default(int?))
								{
									queryable = queryable.Where(x => x.SupplierId == supplierId);
								}
											if(companyName != default(string))
								{
									queryable = queryable.Where(x => x.CompanyName.StartsWith(companyName));
								}
											if(contactName != default(string))
								{
									queryable = queryable.Where(x => x.ContactName.StartsWith(contactName));
								}
											if(contactTitle != default(string))
								{
									queryable = queryable.Where(x => x.ContactTitle.StartsWith(contactTitle));
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
											if(phone != default(string))
								{
									queryable = queryable.Where(x => x.Phone.StartsWith(phone));
								}
											if(fax != default(string))
								{
									queryable = queryable.Where(x => x.Fax.StartsWith(fax));
								}
											if(homePage != default(string))
								{
									queryable = queryable.Where(x => x.HomePage.StartsWith(homePage));
								}
								
					return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Supplier>(queryable);
				}
				
	}
}