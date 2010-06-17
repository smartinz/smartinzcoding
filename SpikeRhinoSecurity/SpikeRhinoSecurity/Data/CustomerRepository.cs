using System.Linq;
using NHibernate.Linq;
using SpikeRhinoSecurity.Infrastructure;
using Microsoft.Practices.ServiceLocation;
using Rhino.Security.Interfaces;
using Rhino.Security;

namespace SpikeRhinoSecurity.Data
{
	public class CustomerRepository
	{

		private NHibernate.ISessionFactory _northwind;


		public CustomerRepository(NHibernate.ISessionFactory northwind)
		{

			_northwind = northwind;

		}

		public void Create(SpikeRhinoSecurity.Domain.Customer v)
		{
			_northwind.GetCurrentSession().Save(v);
		}

		public SpikeRhinoSecurity.Domain.Customer Read(string customerId)
		{
			return _northwind.GetCurrentSession().Load<SpikeRhinoSecurity.Domain.Customer>(customerId);
		}

		public void Update(SpikeRhinoSecurity.Domain.Customer v)
		{
			_northwind.GetCurrentSession().Update(v);
		}

		public void Delete(SpikeRhinoSecurity.Domain.Customer v)
		{
			_northwind.GetCurrentSession().Delete(v);
		}

		public IPresentableSet<SpikeRhinoSecurity.Domain.Customer> Search(string customerId, string companyName, string contactName, string contactTitle, string address, string city, string region, string postalCode, string country, string phone, string fax)
		{
			IQueryable<SpikeRhinoSecurity.Domain.Customer> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Customer>();
			if (customerId != default(string))
			{
				queryable = queryable.Where(x => x.CustomerId.StartsWith(customerId));
			}
			if (companyName != default(string))
			{
				queryable = queryable.Where(x => x.CompanyName.StartsWith(companyName));
			}
			if (contactName != default(string))
			{
				queryable = queryable.Where(x => x.ContactName.StartsWith(contactName));
			}
			if (contactTitle != default(string))
			{
				queryable = queryable.Where(x => x.ContactTitle.StartsWith(contactTitle));
			}
			if (address != default(string))
			{
				queryable = queryable.Where(x => x.Address.StartsWith(address));
			}
			if (city != default(string))
			{
				queryable = queryable.Where(x => x.City.StartsWith(city));
			}
			if (region != default(string))
			{
				queryable = queryable.Where(x => x.Region.StartsWith(region));
			}
			if (postalCode != default(string))
			{
				queryable = queryable.Where(x => x.PostalCode.StartsWith(postalCode));
			}
			if (country != default(string))
			{
				queryable = queryable.Where(x => x.Country.StartsWith(country));
			}
			if (phone != default(string))
			{
				queryable = queryable.Where(x => x.Phone.StartsWith(phone));
			}
			if (fax != default(string))
			{
				queryable = queryable.Where(x => x.Fax.StartsWith(fax));
			}

			((INHibernateQueryable)queryable).QueryOptions.RegisterCustomAction(x =>
	ServiceLocator.Current.GetInstance<IAuthorizationService>().AddPermissionsToQuery(ServiceLocator.Current.GetInstance<IUser>(),
	"/Customer/Read",
	x));

			return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Customer>(queryable);
		}

		public IPresentableSet<SpikeRhinoSecurity.Domain.Customer> Search(string contactName)
		{
			IQueryable<SpikeRhinoSecurity.Domain.Customer> queryable = _northwind.GetCurrentSession().Linq<SpikeRhinoSecurity.Domain.Customer>();
			if (contactName != default(string))
			{
				queryable = queryable.Where(x => x.ContactName.StartsWith(contactName));
			}



			return new SpikeRhinoSecurity.Infrastructure.QueryablePresentableSet<SpikeRhinoSecurity.Domain.Customer>(queryable);
		}

	}
}