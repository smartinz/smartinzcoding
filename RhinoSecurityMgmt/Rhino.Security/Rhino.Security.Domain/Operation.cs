namespace Rhino.Security.Domain
{
	public class Operation 
	{

				private System.Guid _id;
				
				private string _name;
				
				private string _comment;
				
				private Rhino.Security.Domain.Operation _parent;
				
				private System.Collections.Generic.ICollection<Rhino.Security.Domain.Operation> _children = new System.Collections.Generic.HashSet<Rhino.Security.Domain.Operation>();
				

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
				
				public virtual string Comment
				{ 
					get
					{
						return _comment;
					}
		set
					{
						_comment = value;
					}
				}
				
				public virtual Rhino.Security.Domain.Operation Parent
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
				public virtual System.Collections.Generic.ICollection<Rhino.Security.Domain.Operation> Children
				{ 
					get
					{
						return _children;
					}
		private set
					{
						_children = value;
					}
				}
				
		public override string ToString()
		{
			return (_id == null ? "" : _id.ToString());
		}

				
				
				
				
				

		public override bool Equals(object obj)
		{
			if(ReferenceEquals(this, obj)) return true;
			var other = obj as Operation;
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