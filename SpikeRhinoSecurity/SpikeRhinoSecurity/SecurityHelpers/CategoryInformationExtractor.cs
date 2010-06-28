using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpikeRhinoSecurity.Domain;
using Rhino.Security.Interfaces;

namespace SpikeRhinoSecurity.SecurityHelpers
{
	public class CategoryInformationExtractor : IEntityInformationExtractor<Category>
	{
		#region IEntityInformationExtractor<Product> Members

		public string GetDescription(Guid securityKey)
		{
			return string.Format("customer with securityKey: {0}", securityKey);
		}

		public Guid GetSecurityKeyFor(Category entity)
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
