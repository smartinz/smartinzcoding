using System;
namespace SpikeRhinoSecurity.Domain
{
	public class Product
	{
		private Guid _entitySecurityKey;

		private int _productId;

		private string _productName;

		private string _quantityPerUnit;

		private decimal? _unitPrice;

		private short? _unitsInStock;

		private short? _unitsOnOrder;

		private short? _reorderLevel;

		private bool _discontinued;

		private SpikeRhinoSecurity.Domain.Category _category;

		private SpikeRhinoSecurity.Domain.Supplier _supplier;

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

		public virtual int ProductId
		{
			get
			{
				return _productId;
			}
			set
			{
				_productId = value;
			}
		}

		[NHibernate.Validator.Constraints.NotNullNotEmpty]
		public virtual string ProductName
		{
			get
			{
				return _productName;
			}
			set
			{
				_productName = value;
			}
		}

		public virtual string QuantityPerUnit
		{
			get
			{
				return _quantityPerUnit;
			}
			set
			{
				_quantityPerUnit = value;
			}
		}

		public virtual decimal? UnitPrice
		{
			get
			{
				return _unitPrice;
			}
			set
			{
				_unitPrice = value;
			}
		}

		public virtual short? UnitsInStock
		{
			get
			{
				return _unitsInStock;
			}
			set
			{
				_unitsInStock = value;
			}
		}

		public virtual short? UnitsOnOrder
		{
			get
			{
				return _unitsOnOrder;
			}
			set
			{
				_unitsOnOrder = value;
			}
		}

		public virtual short? ReorderLevel
		{
			get
			{
				return _reorderLevel;
			}
			set
			{
				_reorderLevel = value;
			}
		}

		public virtual bool Discontinued
		{
			get
			{
				return _discontinued;
			}
			set
			{
				_discontinued = value;
			}
		}

		public virtual SpikeRhinoSecurity.Domain.Category Category
		{
			get
			{
				return _category;
			}
			set
			{
				_category = value;
			}
		}

		public virtual SpikeRhinoSecurity.Domain.Supplier Supplier
		{
			get
			{
				return _supplier;
			}
			set
			{
				_supplier = value;
			}
		}

		public override string ToString()
		{
			return (_productId == null ? "" : _productId.ToString());
		}












		public virtual bool Equals(Product other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			if (ProductId != default(int))
			{
				return other.ProductId == ProductId;
			}
			return other.ProductId == ProductId && other.ProductName == ProductName && other.QuantityPerUnit == QuantityPerUnit && other.UnitPrice == UnitPrice && other.UnitsInStock == UnitsInStock && other.UnitsOnOrder == UnitsOnOrder && other.ReorderLevel == ReorderLevel && other.Discontinued == Discontinued && other.Category == Category && other.Supplier == Supplier;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(Product)) return false;
			return Equals((Product)obj);
		}

		public static bool operator ==(Product left, Product right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Product left, Product right)
		{
			return !Equals(left, right);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int result = 0;
				if (ProductId != default(int))
				{
					result = (result * 397) ^ ProductId.GetHashCode();
				}
				else
				{
					result = (result * 397) ^ ((ProductId != default(int)) ? ProductId.GetHashCode() : 0);
					result = (result * 397) ^ ((ProductName != default(string)) ? ProductName.GetHashCode() : 0);
					result = (result * 397) ^ ((QuantityPerUnit != default(string)) ? QuantityPerUnit.GetHashCode() : 0);
					result = (result * 397) ^ ((UnitPrice != default(decimal?)) ? UnitPrice.GetHashCode() : 0);
					result = (result * 397) ^ ((UnitsInStock != default(short?)) ? UnitsInStock.GetHashCode() : 0);
					result = (result * 397) ^ ((UnitsOnOrder != default(short?)) ? UnitsOnOrder.GetHashCode() : 0);
					result = (result * 397) ^ ((ReorderLevel != default(short?)) ? ReorderLevel.GetHashCode() : 0);
					result = (result * 397) ^ ((Discontinued != default(bool)) ? Discontinued.GetHashCode() : 0);
					result = (result * 397) ^ ((Category != default(SpikeRhinoSecurity.Domain.Category)) ? Category.GetHashCode() : 0);
					result = (result * 397) ^ ((Supplier != default(SpikeRhinoSecurity.Domain.Supplier)) ? Supplier.GetHashCode() : 0);
				}
				return result;
			}
		}


	}
}