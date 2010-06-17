using System;
namespace SpikeRhinoSecurity.Domain
{
	public class Customer
	{
		private Guid _entitySecurityKey;

		private string _customerId;

		private string _companyName;

		private string _contactName;

		private string _contactTitle;

		private string _address;

		private string _city;

		private string _region;

		private string _postalCode;

		private string _country;

		private string _phone;

		private string _fax;

		private System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.CustomerDemographic> _customerdemographics = new System.Collections.Generic.HashSet<SpikeRhinoSecurity.Domain.CustomerDemographic>();

		private System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Order> _orders = new System.Collections.Generic.HashSet<SpikeRhinoSecurity.Domain.Order>();


		public virtual Guid EntitySecurityKey
		{
			get
			{
				return _entitySecurityKey;
			}
			set
			{
				_entitySecurityKey = value;
			}
		}

		[NHibernate.Validator.Constraints.NotNullNotEmpty]
		public virtual string CustomerId
		{
			get
			{
				return _customerId;
			}
			set
			{
				_customerId = value;
			}
		}

		[NHibernate.Validator.Constraints.NotNullNotEmpty]
		public virtual string CompanyName
		{
			get
			{
				return _companyName;
			}
			set
			{
				_companyName = value;
			}
		}

		public virtual string ContactName
		{
			get
			{
				return _contactName;
			}
			set
			{
				_contactName = value;
			}
		}

		public virtual string ContactTitle
		{
			get
			{
				return _contactTitle;
			}
			set
			{
				_contactTitle = value;
			}
		}

		public virtual string Address
		{
			get
			{
				return _address;
			}
			set
			{
				_address = value;
			}
		}

		public virtual string City
		{
			get
			{
				return _city;
			}
			set
			{
				_city = value;
			}
		}

		public virtual string Region
		{
			get
			{
				return _region;
			}
			set
			{
				_region = value;
			}
		}

		public virtual string PostalCode
		{
			get
			{
				return _postalCode;
			}
			set
			{
				_postalCode = value;
			}
		}

		public virtual string Country
		{
			get
			{
				return _country;
			}
			set
			{
				_country = value;
			}
		}

		public virtual string Phone
		{
			get
			{
				return _phone;
			}
			set
			{
				_phone = value;
			}
		}

		public virtual string Fax
		{
			get
			{
				return _fax;
			}
			set
			{
				_fax = value;
			}
		}

		[NHibernate.Validator.Constraints.NotNull]
		public virtual System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.CustomerDemographic> Customerdemographics
		{
			get
			{
				return _customerdemographics;
			}
			private set
			{
				_customerdemographics = value;
			}
		}

		[NHibernate.Validator.Constraints.NotNull]
		public virtual System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Order> Orders
		{
			get
			{
				return _orders;
			}
			private set
			{
				_orders = value;
			}
		}

		public override string ToString()
		{
			return (_customerId == null ? "" : _customerId.ToString());
		}















		public virtual bool Equals(Customer other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (CustomerId != default(string))
			{
				return other.CustomerId == CustomerId;
			}
			return other.CustomerId == CustomerId && other.CompanyName == CompanyName && other.ContactName == ContactName && other.ContactTitle == ContactTitle && other.Address == Address && other.City == City && other.Region == Region && other.PostalCode == PostalCode && other.Country == Country && other.Phone == Phone && other.Fax == Fax && 1 == 1 && 1 == 1;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Customer)) return false;
			return Equals((Customer)obj);
		}

		public static bool operator ==(Customer left, Customer right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Customer left, Customer right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (CustomerId != default(string))
				{
					result = (result * 397) ^ CustomerId.GetHashCode();
				}
				else
				{
					result = (result * 397) ^ ((CustomerId != default(string)) ? CustomerId.GetHashCode() : 0);
					result = (result * 397) ^ ((CompanyName != default(string)) ? CompanyName.GetHashCode() : 0);
					result = (result * 397) ^ ((ContactName != default(string)) ? ContactName.GetHashCode() : 0);
					result = (result * 397) ^ ((ContactTitle != default(string)) ? ContactTitle.GetHashCode() : 0);
					result = (result * 397) ^ ((Address != default(string)) ? Address.GetHashCode() : 0);
					result = (result * 397) ^ ((City != default(string)) ? City.GetHashCode() : 0);
					result = (result * 397) ^ ((Region != default(string)) ? Region.GetHashCode() : 0);
					result = (result * 397) ^ ((PostalCode != default(string)) ? PostalCode.GetHashCode() : 0);
					result = (result * 397) ^ ((Country != default(string)) ? Country.GetHashCode() : 0);
					result = (result * 397) ^ ((Phone != default(string)) ? Phone.GetHashCode() : 0);
					result = (result * 397) ^ ((Fax != default(string)) ? Fax.GetHashCode() : 0);


				}
				return result;
			}
		}


	}
}