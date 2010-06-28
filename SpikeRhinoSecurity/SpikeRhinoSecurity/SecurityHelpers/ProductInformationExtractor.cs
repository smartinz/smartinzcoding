using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpikeRhinoSecurity.Domain;
using Rhino.Security.Interfaces;

namespace SpikeRhinoSecurity.SecurityHelpers
{
	public class ProductInformationExtractor : IEntityInformationExtractor<Product>
	{
		#region IEntityInformationExtractor<Customer> Members

		public string GetDescription(Guid securityKey)
		{
			return string.Format("customer with securityKey: {0}", securityKey);
		}

		public Guid GetSecurityKeyFor(Product entity)
		{
			return entity.EntitySecurityKey;
		}

		public string SecurityKeyPropertyName
		{
			get { return "EntitySecurityKey"; }
		}

		#endregion
	}
}
