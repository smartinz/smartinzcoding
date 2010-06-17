namespace SpikeRhinoSecurity.Domain
{
	public class Supplier 
	{

				private int _supplierId;
				
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
				
				private string _homePage;
				
				private System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Product> _products = new System.Collections.Generic.HashSet<SpikeRhinoSecurity.Domain.Product>();
				

				public virtual int SupplierId
				{ 
					get
					{
						return _supplierId;
					}
		set
					{
						_supplierId = value;
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
				
				public virtual string HomePage
				{ 
					get
					{
						return _homePage;
					}
		set
					{
						_homePage = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Product> Products
				{ 
					get
					{
						return _products;
					}
		private set
					{
						_products = value;
					}
				}
				
		public override string ToString()
		{
			return (_supplierId == null ? "" : _supplierId.ToString());
		}

				
				
				
				
				
				
				
				
				
				
				
				
				

		public virtual bool Equals(Supplier other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (SupplierId != default(int))
			{
				return other.SupplierId == SupplierId;
			}
			return other.SupplierId == SupplierId && other.CompanyName == CompanyName && other.ContactName == ContactName && other.ContactTitle == ContactTitle && other.Address == Address && other.City == City && other.Region == Region && other.PostalCode == PostalCode && other.Country == Country && other.Phone == Phone && other.Fax == Fax && other.HomePage == HomePage && 1 == 1;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Supplier)) return false;
			return Equals((Supplier)obj);
		}
		
		public static bool operator ==(Supplier left, Supplier right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Supplier left, Supplier right)
		{
			return !Equals(left, right);
		}
				
		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (SupplierId != default(int))
				{
					result = (result * 397) ^ SupplierId.GetHashCode();
				}
				else
				{
					result = (result * 397) ^ ((SupplierId != default(int)) ? SupplierId.GetHashCode() : 0);
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
					result = (result * 397) ^ ((HomePage != default(string)) ? HomePage.GetHashCode() : 0);

				}
				return result;
			}
		}	

		
	}
}