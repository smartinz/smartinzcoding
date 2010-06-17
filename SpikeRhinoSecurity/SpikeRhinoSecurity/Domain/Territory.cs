namespace SpikeRhinoSecurity.Domain
{
	public class Territory 
	{

				private string _territoryId;
				
				private string _territoryDescription;
				
				private System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Employee> _employees = new System.Collections.Generic.HashSet<SpikeRhinoSecurity.Domain.Employee>();
				
				private SpikeRhinoSecurity.Domain.Region _region;
				

				[NHibernate.Validator.Constraints.NotNullNotEmpty]
				public virtual string TerritoryId
				{ 
					get
					{
						return _territoryId;
					}
		set
					{
						_territoryId = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNullNotEmpty]
				public virtual string TerritoryDescription
				{ 
					get
					{
						return _territoryDescription;
					}
		set
					{
						_territoryDescription = value;
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
				public virtual SpikeRhinoSecurity.Domain.Region Region
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
				
		public override string ToString()
		{
			return (_territoryId == null ? "" : _territoryId.ToString());
		}

				
				
				
				

		public virtual bool Equals(Territory other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (TerritoryId != default(string))
			{
				return other.TerritoryId == TerritoryId;
			}
			return other.TerritoryId == TerritoryId && other.TerritoryDescription == TerritoryDescription && 1 == 1 && other.Region == Region;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Territory)) return false;
			return Equals((Territory)obj);
		}
		
		public static bool operator ==(Territory left, Territory right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Territory left, Territory right)
		{
			return !Equals(left, right);
		}
				
		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (TerritoryId != default(string))
				{
					result = (result * 397) ^ TerritoryId.GetHashCode();
				}
				else
				{
					result = (result * 397) ^ ((TerritoryId != default(string)) ? TerritoryId.GetHashCode() : 0);
					result = (result * 397) ^ ((TerritoryDescription != default(string)) ? TerritoryDescription.GetHashCode() : 0);

					result = (result * 397) ^ ((Region != default(SpikeRhinoSecurity.Domain.Region)) ? Region.GetHashCode() : 0);
				}
				return result;
			}
		}	

		
	}
}