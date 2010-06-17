namespace Rhino.Security.Domain
{
	public class UsersGroup 
	{

				private System.Guid _id;
				
				private string _name;
				
				private Rhino.Security.Domain.UsersGroup _parent;
				
				private System.Collections.Generic.ICollection<Rhino.Security.Domain.UsersGroup> _allParent = new System.Collections.Generic.HashSet<Rhino.Security.Domain.UsersGroup>();
				
				private System.Collections.Generic.ICollection<Rhino.Security.Domain.User> _users = new System.Collections.Generic.HashSet<Rhino.Security.Domain.User>();
				
				private System.Collections.Generic.ICollection<Rhino.Security.Domain.UsersGroup> _allChildren = new System.Collections.Generic.HashSet<Rhino.Security.Domain.UsersGroup>();
				
				private System.Collections.Generic.ICollection<Rhino.Security.Domain.UsersGroup> _directChildren = new System.Collections.Generic.HashSet<Rhino.Security.Domain.UsersGroup>();
				

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
				
				public virtual Rhino.Security.Domain.UsersGroup Parent
				{ 
					get
					{
						return _parent;
					}
		set
					{
						_parent = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual System.Collections.Generic.ICollection<Rhino.Security.Domain.UsersGroup> AllParent
				{ 
					get
					{
						return _allParent;
					}
		private set
					{
						_allParent = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual System.Collections.Generic.ICollection<Rhino.Security.Domain.User> Users
				{ 
					get
					{
						return _users;
					}
		private set
					{
						_users = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual System.Collections.Generic.ICollection<Rhino.Security.Domain.UsersGroup> AllChildren
				{ 
					get
					{
						return _allChildren;
					}
		private set
					{
						_allChildren = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual System.Collections.Generic.ICollection<Rhino.Security.Domain.UsersGroup> DirectChildren
				{ 
					get
					{
						return _directChildren;
					}
		private set
					{
						_directChildren = value;
					}
				}
				
		public override string ToString()
		{
			return (_id == null ? "" : _id.ToString());
		}

				
				
				
				
				
				
				

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(this, obj)) return true;
			var other = obj as UsersGroup;
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