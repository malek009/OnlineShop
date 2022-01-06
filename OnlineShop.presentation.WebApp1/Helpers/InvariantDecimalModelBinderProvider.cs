using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.presentation.WebApp1.Helpers
{
    public class InvariantDecimalModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            if (!context.Metadata.IsComplexType && (context.Metadata.ModelType == typeof(double) || context.Metadata.ModelType == typeof(double?)))
            {
                return new InvariantDecimalModelBinder(context);
            }

            return null;
        }
    }

    public class InvariantDecimalModelBinder : IModelBinder
    {
        private readonly SimpleTypeModelBinder _baseBinder;

        public InvariantDecimalModelBinder(ModelBinderProviderContext context)
        {
            var loggerFactory = context.Services.GetRequiredService<ILoggerFactory>();
            _baseBinder = new SimpleTypeModelBinder(context.Metadata.ModelType, loggerFactory);
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                var valueAsString = valueProviderResult.FirstValue;
                double result;

                // Use invariant culture
                if (double.TryParse(valueAsString, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out result))
                {
                    bindingContext.Result = ModelBindingResult.Success(result);
                    return Task.CompletedTask;
                }
            }

            return _baseBinder.BindModelAsync(bindingContext);
        }
    }
}
