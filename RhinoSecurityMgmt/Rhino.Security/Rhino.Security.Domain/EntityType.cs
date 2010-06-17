namespace Rhino.Security.Domain
{
	public class EntityType 
	{

				private System.Guid _id;
				
				private string _name;
				

				public virtual System.Guid Id
				{ 
					get
					{
						return _id;
					}
		set
					{
						_id = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNullNotEmpty]
				public virtual string Name
				{ 
					get
					{
						return _name;
					}
		set
					{
						_name = value;
					}
				}
				
		public override string ToString()
		{
			return (_id == null ? "" : _id.ToString());
		}

				
				

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(this, obj)) return true;
			var other = obj as EntityType;
			if(ReferenceEquals(null, other)) return false;
			if (Id != default(System.Guid))
			{
				return other.Id == Id;
			}
			return base.Equals(obj);
		}
				
		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (Id != default(System.Guid))
				{
					result = (result * 397) ^ Id.GetHashCode();
				}
				else
				{
					result = base.GetHashCode();
				}
				return result;
			}
		}	

		
	}
}