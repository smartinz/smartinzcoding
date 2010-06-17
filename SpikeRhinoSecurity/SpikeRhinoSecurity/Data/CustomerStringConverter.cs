using System;

namespace SpikeRhinoSecurity.Data
{
	public class CustomerStringConverter : SpikeRhinoSecurity.Infrastructure.IStringConverter<SpikeRhinoSecurity.Domain.Customer>
	{
		const char KeySeparator = '\\';
		private readonly SpikeRhinoSecurity.Data.CustomerRepository _repository;

		public CustomerStringConverter(SpikeRhinoSecurity.Data.CustomerRepository repository)
		{
			_repository = repository;
		}

		public string ToString(SpikeRhinoSecurity.Domain.Customer obj)
		{
			return obj.CustomerId.ToString();
		}

		public SpikeRhinoSecurity.Domain.Customer FromString(string str)
		{
			string[] keys = ParseKeys(str, 1);
			return _repository.Read(keys[0]);
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