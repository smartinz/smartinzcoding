namespace SpikeRhinoSecurity.Domain
{
	public class Employee 
	{

				private int _employeeId;
				
				private string _lastName;
				
				private string _firstName;
				
				private string _title;
				
				private string _titleOfCourtesy;
				
				private System.DateTime? _birthDate;
				
				private System.DateTime? _hireDate;
				
				private string _address;
				
				private string _city;
				
				private string _region;
				
				private string _postalCode;
				
				private string _country;
				
				private string _homePhone;
				
				private string _extension;
				
				private byte[] _photo;
				
				private string _notes;
				
				private string _photoPath;
				
				private SpikeRhinoSecurity.Domain.Employee _employee_1;
				
				private System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Employee> _employees = new System.Collections.Generic.HashSet<SpikeRhinoSecurity.Domain.Employee>();
				
				private System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Territory> _territories = new System.Collections.Generic.HashSet<SpikeRhinoSecurity.Domain.Territory>();
				
				private System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Order> _orders = new System.Collections.Generic.HashSet<SpikeRhinoSecurity.Domain.Order>();
				

				public virtual int EmployeeId
				{ 
					get
					{
						return _employeeId;
					}
		set
					{
						_employeeId = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNullNotEmpty]
				public virtual string LastName
				{ 
					get
					{
						return _lastName;
					}
		set
					{
						_lastName = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNullNotEmpty]
				public virtual string FirstName
				{ 
					get
					{
						return _firstName;
					}
		set
					{
						_firstName = value;
					}
				}
				
				public virtual string Title
				{ 
					get
					{
						return _title;
					}
		set
					{
						_title = value;
					}
				}
				
				public virtual string TitleOfCourtesy
				{ 
					get
					{
						return _titleOfCourtesy;
					}
		set
					{
						_titleOfCourtesy = value;
					}
				}
				
				public virtual System.DateTime? BirthDate
				{ 
					get
					{
						return _birthDate;
					}
		set
					{
						_birthDate = value;
					}
				}
				
				public virtual System.DateTime? HireDate
				{ 
					get
					{
						return _hireDate;
					}
		set
					{
						_hireDate = value;
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
				
				public virtual string HomePhone
				{ 
					get
					{
						return _homePhone;
					}
		set
					{
						_homePhone = value;
					}
				}
				
				public virtual string Extension
				{ 
					get
					{
						return _extension;
					}
		set
					{
						_extension = value;
					}
				}
				
				public virtual byte[] Photo
				{ 
					get
					{
						return _photo;
					}
		set
					{
						_photo = value;
					}
				}
				
				public virtual string Notes
				{ 
					get
					{
						return _notes;
					}
		set
					{
						_notes = value;
					}
				}
				
				public virtual string PhotoPath
				{ 
					get
					{
						return _photoPath;
					}
		set
					{
						_photoPath = value;
					}
				}
				
				public virtual SpikeRhinoSecurity.Domain.Employee Employee_1
				{ 
					get
					{
						return _employee_1;
					}
		set
					{
						_employee_1 = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Employee> Employees
				{ 
					get
					{
						return _employees;
					}
		private set
					{
						_employees = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Territory> Territories
				{ 
					get
					{
						return _territories;
					}
		private set
					{
						_territories = value;
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
			return (_employeeId == null ? "" : _employeeId.ToString());
		}

				
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				
				

		public virtual bool Equals(Employee other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (EmployeeId != default(int))
			{
				return other.EmployeeId == EmployeeId;
			}
			return other.EmployeeId == EmployeeId && other.LastName == LastName && other.FirstName == FirstName && other.Title == Title && other.TitleOfCourtesy == TitleOfCourtesy && other.BirthDate == BirthDate && other.HireDate == HireDate && other.Address == Address && other.City == City && other.Region == Region && other.PostalCode == PostalCode && other.Country == Country && other.HomePhone == HomePhone && other.Extension == Extension && other.Photo == Photo && other.Notes == Notes && other.PhotoPath == PhotoPath && other.Employee_1 == Employee_1 && 1 == 1 && 1 == 1 && 1 == 1;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Employee)) return false;
			return Equals((Employee)obj);
		}
		
		public static bool operator ==(Employee left, Employee right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Employee left, Employee right)
		{
			return !Equals(left, right);
		}
				
		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (EmployeeId != default(int))
				{
					result = (result * 397) ^ EmployeeId.GetHashCode();
				}
				else
				{
					result = (result * 397) ^ ((EmployeeId != default(int)) ? EmployeeId.GetHashCode() : 0);
					result = (result * 397) ^ ((LastName != default(string)) ? LastName.GetHashCode() : 0);
					result = (result * 397) ^ ((FirstName != default(string)) ? FirstName.GetHashCode() : 0);
					result = (result * 397) ^ ((Title != default(string)) ? Title.GetHashCode() : 0);
					result = (result * 397) ^ ((TitleOfCourtesy != default(string)) ? TitleOfCourtesy.GetHashCode() : 0);
					result = (result * 397) ^ ((BirthDate != default(System.DateTime?)) ? BirthDate.GetHashCode() : 0);
					result = (result * 397) ^ ((HireDate != default(System.DateTime?)) ? HireDate.GetHashCode() : 0);
					result = (result * 397) ^ ((Address != default(string)) ? Address.GetHashCode() : 0);
					result = (result * 397) ^ ((City != default(string)) ? City.GetHashCode() : 0);
					result = (result * 397) ^ ((Region != default(string)) ? Region.GetHashCode() : 0);
					result = (result * 397) ^ ((PostalCode != default(string)) ? PostalCode.GetHashCode() : 0);
					result = (result * 397) ^ ((Country != default(string)) ? Country.GetHashCode() : 0);
					result = (result * 397) ^ ((HomePhone != default(string)) ? HomePhone.GetHashCode() : 0);
					result = (result * 397) ^ ((Extension != default(string)) ? Extension.GetHashCode() : 0);
					result = (result * 397) ^ ((Photo != default(byte[])) ? Photo.GetHashCode() : 0);
					result = (result * 397) ^ ((Notes != default(string)) ? Notes.GetHashCode() : 0);
					result = (result * 397) ^ ((PhotoPath != default(string)) ? PhotoPath.GetHashCode() : 0);
					result = (result * 397) ^ ((Employee_1 != default(SpikeRhinoSecurity.Domain.Employee)) ? Employee_1.GetHashCode() : 0);



				}
				return result;
			}
		}	

		
	}
}