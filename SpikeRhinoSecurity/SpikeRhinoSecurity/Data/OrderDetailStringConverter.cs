using System;

namespace SpikeRhinoSecurity.Data
{
	public class OrderDetailStringConverter : SpikeRhinoSecurity.Infrastructure.IStringConverter<SpikeRhinoSecurity.Domain.OrderDetail>
	{
		const char KeySeparator = '\\';
		private readonly SpikeRhinoSecurity.Data.OrderDetailRepository _repository;

		public OrderDetailStringConverter(SpikeRhinoSecurity.Data.OrderDetailRepository repository)
		{
			_repository = repository;
		}

		public string ToString(SpikeRhinoSecurity.Domain.OrderDetail obj)
		{
			return obj.OrderId.ToString() + KeySeparator + obj.ProductId.ToString();
		}

		public SpikeRhinoSecurity.Domain.OrderDetail FromString(string str)
		{
			string[] keys = ParseKeys(str, 2);
			return _repository.Read(Convert.ToInt32(keys[0]), Convert.ToInt32(keys[1]));
		}
		
		/// <summary>
		/// Parses the keys.
		/// </summary>
		/// <param name="keyValues">The key values.</param>
		/// <param name="expectedNumberOfKeys">The expected number of keys.</param>
		/// <returns>The array containing the keys.</returns>
		public static string[] ParseKeys(string keyValues, int expectedNumberOfKeys)
		{
			string[] keys = keyValues.Split(KeySeparator);
			foreach (string key in keys)
			{
				if (key.Trim() == string.Empty)
					throw new ArgumentException("One of the provided keys is empty.", "keyValues");
			}

			if (keys.Length != expectedNumberOfKeys)
				throw new ArgumentException("The number of keys provided does not match the number of expected keys for this object.", "keyValues");

			return keys;
		}
	}
}