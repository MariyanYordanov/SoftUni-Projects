using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace HouseRentingSystem.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult result = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (result != ValueProviderResult.None && !string.IsNullOrEmpty(result.FirstValue))
            {
                decimal currentValue = 0m;
                bool succsess = false;

                try
                {
                    string decValue = result.FirstValue;
                    decValue = decValue.Replace(".",CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decValue = decValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    currentValue= Convert.ToDecimal(decValue);
                    succsess = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (succsess)
                {
                    bindingContext.Result = ModelBindingResult.Success(currentValue);
                }
            }

            return Task.CompletedTask;
        }
    }
}
