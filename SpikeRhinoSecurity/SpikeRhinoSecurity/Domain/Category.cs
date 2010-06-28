using System;
namespace SpikeRhinoSecurity.Domain
{
	public class Category
	{
		private Guid _entitySecurityKey;

		private int _categoryId;

		private string _categoryName;

		private string _description;

		private byte[] _picture;

		private System.Collections.Generic.ICollection<SpikeRhinoSecurity.Domain.Product> _products = new System.Collections.Generic.HashSet<SpikeRhinoSecurity.Domain.Product>();

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

		public virtual int CategoryId
		{
			get
			{
				return _categoryId;
			}
			set
			{
				_categoryId = value;
			}
		}

		[NHibernate.Validator.Constraints.NotNullNotEmpty]
		public virtual string CategoryName
		{
			get
			{
				return _categoryName;
			}
			set
			{
				_categoryName = value;
			}
		}

		public virtual string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
			}
		}

		public virtual byte[] Picture
		{
			get
			{
				return _picture;
			}
			set
			{
				_picture = value;
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
			return (_categoryId == null ? "" : _categoryId.ToString());
		}







		public virtual bool Equals(Category other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (CategoryId != default(int))
			{
				return other.CategoryId == CategoryId;
			}
			return other.CategoryId == CategoryId && other.CategoryName == CategoryName && other.Description == Description && other.Picture == Picture && 1 == 1;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Category)) return false;
			return Equals((Category)obj);
		}

		public static bool operator ==(Category left, Category right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Category left, Category right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (CategoryId != default(int))
				{
					result = (result * 397) ^ CategoryId.GetHashCode();
				}
				else
				{
					result = (result * 397) ^ ((CategoryId != default(int)) ? CategoryId.GetHashCode() : 0);
					result = (result * 397) ^ ((CategoryName != default(string)) ? CategoryName.GetHashCode() : 0);
					result = (result * 397) ^ ((Description != default(string)) ? Description.GetHashCode() : 0);
					result = (result * 397) ^ ((Picture != default(byte[])) ? Picture.GetHashCode() : 0);

				}
				return result;
			}
		}


	}
}