using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication1.Utility
{
    public class ValidNameAttribute : Attribute, IModelValidator
    {
        public string ErrorMessage { get; set; }

        IEnumerable<ModelValidationResult> IModelValidator.Validate(ModelValidationContext context)
        {
            var name = context.Model as string;
            if (name == null)
            {
                return new List<ModelValidationResult> { new ModelValidationResult("", "Model is required") };
            }
            if (Regex.IsMatch(name, "^[A-Z]+.*$"))
            {
                return Enumerable.Empty<ModelValidationResult>();
            }



            return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage) };
        }
    }
}
