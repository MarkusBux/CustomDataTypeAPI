using System;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using WebApplication1.Models.ValueTypes;

namespace WebApplication1.ModelBinder
{
    /// <summary>
    /// Model Binder implementation for OrderNumber & OrderNumber? type
    /// </summary>
    public class OrderNumberModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(OrderNumber) && bindingContext.ModelType != typeof(OrderNumber?))
                return false;

            var value = bindingContext.ValueProvider.GetValue(bindingContext?.ModelName);
            if (value is null)
                return false;

            var rawValue = value.RawValue as string;

            try
            {
                bindingContext.Model = new OrderNumber(rawValue);

            }
            catch (ArgumentException ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
                return false;
            }
            return true;
        }
    }
}