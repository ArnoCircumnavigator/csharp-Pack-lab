﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_DDD1_Domain.CoreFramework
{
    [Serializable]
    public class DomainException : Exception
    {
        public IValidationError ValidationError { get; private set; }

        public DomainException()
        {
            ValidationError = new ValidationError();
        }

        public DomainException(string errorKey) : this()
        {
            ValidationError.AddError(errorKey);
        }
        public DomainException(string errorKey, params object[] parameters) : this()
        {
            ValidationError.AddError(errorKey, parameters);
        }
        public DomainException(string errorKey, IList<object> parameters) : this()
        {
            ValidationError.AddError(errorKey, parameters);
        }
    }
}
