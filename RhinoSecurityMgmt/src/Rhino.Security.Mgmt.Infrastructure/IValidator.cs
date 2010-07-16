using System.Collections.Generic;

namespace Nexida.Infrastructure
{
    public interface IValidator
    {
        IEnumerable<ValidationError> Validate(object entity);
    }
}