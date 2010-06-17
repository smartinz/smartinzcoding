namespace Rhino.Security.Domain
{
	public class Permission 
	{

				private System.Guid _id;
				
				private System.Guid? _entitySecurityKey;
				
				private bool _allow;
				
				private int _level;
				
				private string _entityTypeName;
				
				private Rhino.Security.Domain.EntitiesGroup _entitiesGroup;
				
				private Rhino.Security.Domain.Operation _operation;
				
				private Rhino.Security.Domain.UsersGroup _usersGroup;
				
				private Rhino.Security.Domain.User _user;
				

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
				
				public virtual System.Guid? EntitySecurityKey
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
				
				public virtual bool Allow
				{ 
					get
					{
						return _allow;
					}
		set
					{
						_allow = value;
					}
				}
				
				public virtual int Level
				{ 
					get
					{
						return _level;
					}
		set
					{
						_level = value;
					}
				}
				
				public virtual string EntityTypeName
				{ 
					get
					{
						return _entityTypeName;
					}
		set
					{
						_entityTypeName = value;
					}
				}
				
				public virtual Rhino.Security.Domain.EntitiesGroup EntitiesGroup
				{ 
					get
					{
						return _entitiesGroup;
					}
		set
					{
						_entitiesGroup = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual Rhino.Security.Domain.Operation Operation
				{ 
					get
					{
						return _operation;
					}
		set
					{
						_operation = value;
					}
				}
				
				public virtual Rhino.Security.Domain.UsersGroup UsersGroup
				{ 
					get
					{
						return _usersGroup;
					}
		set
					{
						_usersGroup = value;
					}
				}
				
				public virtual Rhino.Security.Domain.User User
				{ 
					get
					{
						return _user;
					}
		set
					{
						_user = value;
					}
				}
				
		public override string ToString()
		{
			return (_id == null ? "" : _id.ToString());
		}

				
				
				
				
				
				
				
				
				

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(this, obj)) return true;
			var other = obj as Permission;
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