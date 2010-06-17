namespace Rhino.Security.Domain
{
	public class EntitiesGroup 
	{

				private System.Guid _id;
				
				private string _name;
				
				private Rhino.Security.Domain.EntitiesGroup _parent;
				
				private System.Collections.Generic.ICollection<Rhino.Security.Domain.EntitiesGroup> _directChildren = new System.Collections.Generic.HashSet<Rhino.Security.Domain.EntitiesGroup>();
				
				private System.Collections.Generic.ICollection<Rhino.Security.Domain.EntityReference> _entities = new System.Collections.Generic.HashSet<Rhino.Security.Domain.EntityReference>();
				
				private System.Collections.Generic.ICollection<Rhino.Security.Domain.EntitiesGroup> _allChildren = new System.Collections.Generic.HashSet<Rhino.Security.Domain.EntitiesGroup>();
				
				private System.Collections.Generic.ICollection<Rhino.Security.Domain.EntitiesGroup> _allParents = new System.Collections.Generic.HashSet<Rhino.Security.Domain.EntitiesGroup>();
				

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
				
				public virtual Rhino.Security.Domain.EntitiesGroup Parent
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
				public virtual System.Collections.Generic.ICollection<Rhino.Security.Domain.EntitiesGroup> DirectChildren
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
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual System.Collections.Generic.ICollection<Rhino.Security.Domain.EntityReference> Entities
				{ 
					get
					{
						return _entities;
					}
		private set
					{
						_entities = value;
					}
				}
				
				[NHibernate.Validator.Constraints.NotNull]
				public virtual System.Collections.Generic.ICollection<Rhino.Security.Domain.EntitiesGroup> AllChildren
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
				public virtual System.Collections.Generic.ICollection<Rhino.Security.Domain.EntitiesGroup> AllParents
				{ 
					get
					{
						return _allParents;
					}
		private set
					{
						_allParents = value;
					}
				}
				
		public override string ToString()
		{
			return (_id == null ? "" : _id.ToString());
		}

				
				
				
				
				
				
				

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(this, obj)) return true;
			var other = obj as EntitiesGroup;
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