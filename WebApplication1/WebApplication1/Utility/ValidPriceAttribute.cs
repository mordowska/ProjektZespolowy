using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApplication1.Utility
{
    public class ValidPriceAttribute : Attribute, IModelValidator
    {
        public string ErrorMessage { get; set; }

        IEnumerable<ModelValidationResult> IModelValidator.Validate(ModelValidationContext context)
        {
            var price = context.Model as string;
            if (price == null)
            {
                return new List<ModelValidationResult> { new ModelValidationResult("", "Model is required") };
            }
            if (Regex.IsMatch(price, "^[0-9]{2}[,][0-9]{2}$"))
            {
                return Enumerable.Empty<ModelValidationResult>();
            }



            return new List<ModelValidationResult> { new ModelValidationResult("", ErrorMessage) };
        }
    }
}
