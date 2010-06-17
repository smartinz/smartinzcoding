using System.Collections.Generic;
using System.Linq;
using Nexida.Infrastructure;
using NHibernate.Validator.Engine;

namespace Rhino.Security.Infrastructure
{
	public class NHibernateValidator : Nexida.Infrastructure.IValidator
	{
		private readonly ValidatorEngine _engine;

		public NHibernateValidator(ValidatorEngine engine)
		{
			_engine = engine;
		}

		public IEnumerable<ValidationError> Validate(object entity)
		{
			return _engine.Validate(entity).Select(x => new ValidationError
			{
				PropertyPath = x.PropertyPath,
				Message = x.Message
			});
		}
	}
}