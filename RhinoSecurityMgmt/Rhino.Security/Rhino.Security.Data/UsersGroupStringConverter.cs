using System;

namespace Rhino.Security.Data
{
	public class UsersGroupStringConverter : Nexida.Infrastructure.IStringConverter<Rhino.Security.Model.UsersGroup>
	{
		const char KeySeparator = '\\';
		private readonly Rhino.Security.Data.UsersGroupRepository _repository;

		public UsersGroupStringConverter(Rhino.Security.Data.UsersGroupRepository repository)
		{
			_repository = repository;
		}

		public string ToString(Rhino.Security.Model.UsersGroup obj)
		{
			return obj.Id.ToString();
		}

		public Rhino.Security.Model.UsersGroup FromString(string str)
		{
			if(string.IsNullOrEmpty(str))
			{
				throw new ArgumentException("Must be a non null, non empty value", "str");
			}
			string[] keys = ParseKeys(str, 1);
			return _repository.Read(new System.Guid(keys[0]));
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