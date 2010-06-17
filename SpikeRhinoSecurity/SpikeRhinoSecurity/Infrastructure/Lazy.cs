using System;

namespace SpikeRhinoSecurity.Infrastructure
{
	public class Lazy<T>
	{
		private readonly Func<T> _initializer;
		private bool _initialized;
		private T _reference;

		public Lazy(Func<T> initializer)
		{
			_initializer = initializer;
			_initialized = false;
			_reference = default(T);
		}

		public Lazy(T reference)
		{
			_reference = reference;
			_initialized = true;
			_initializer = () => { throw new Exception(string.Format("Undefined initializer delegate for Lazy reference of type {0}", typeof(T))); };
		}

		public T Reference
		{
			get
			{
				if (!_initialized)
				{
					_reference = _initializer();
					_initialized = true;
				}
				return _reference;
			}
			set
			{
				_reference = value;
				_initialized = true;
			}
		}

		public static implicit operator T(Lazy<T> lazy)
		{
			return lazy.Reference;
		}

		public static implicit operator Lazy<T>(T reference)
		{
			return new Lazy<T>(reference);
		}
	}
}