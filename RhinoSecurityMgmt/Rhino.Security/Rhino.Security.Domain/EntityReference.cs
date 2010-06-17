namespace Rhino.Security.Domain
{
	public class EntityReference 
	{

				private System.Guid _id;
				
				private System.Guid _entitySecurityKey;
				
				private Rhino.Security.Domain.EntityType _type;
				

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
				
				public virtual System.Guid EntitySecurityKey
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
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual Rhino.Security.Domain.EntityType Type
				{ 
					get
					{
						return _type;
					}
		set
					{
						_type = value;
					}
				}
				
		public override string ToString()
		{
			return (_id == null ? "" : _id.ToString());
		}

				
				
				

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(this, obj)) return true;
			var other = obj as EntityReference;
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