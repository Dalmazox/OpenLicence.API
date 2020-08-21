using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace OpenLicence.Presentation.API.Helpers
{
    public class ValidationHelper
    {
        public static object BeautifyReturn(ValidationResult result)
            => result.Errors?.Select(error => new { Field = error.PropertyName, Message = error.ErrorMessage });
    }
}