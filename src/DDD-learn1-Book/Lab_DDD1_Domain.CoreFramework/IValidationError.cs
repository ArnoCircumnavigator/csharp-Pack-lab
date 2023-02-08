using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.CoreFramework
{
    public interface IValidationError
    {
        bool IsValid { get; }
        IEnumerable<ValidationErrorItem> GetErrors();
        IValidationError AddError(string errorKey);
        IValidationError AddError(string errorKey, params object[] parameters);
        IValidationError AddError(string errorKey, IList<object> parameters);
    }
}
