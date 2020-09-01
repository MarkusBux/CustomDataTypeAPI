using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using WebApplication1.Filters;
using WebApplication1.Converters;
using WebApplication1.ModelBinder;
using WebApplication1.Models.ValueTypes;
using Microsoft.Ajax.Utilities;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Some API/JSON Formatter configuration
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            var xmlFormatter = config.Formatters.XmlFormatter;
            xmlFormatter.Indent = true;

            // Register JSON Formatter for OrderNumber data type
            jsonFormatter.SerializerSettings.Converters.Add(new OrderNumberNewtonsoftJsonConverter());

            // Set this formatter as first formatter
            config.Formatters.Insert(0, jsonFormatter);

            // Globally register Filters...
            // Every filter will be applied on every execution
            //config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new NotImplExceptionFilterAttribute());


            // Add the ModelBinder for OrderNumber and OrderNumber? types
            config.Services.Insert(typeof(ModelBinderProvider), 0, new SimpleModelBinderProvider(typeof(OrderNumber), new OrderNumberModelBinder()));
            config.Services.Insert(typeof(ModelBinderProvider), 1, new SimpleModelBinderProvider(typeof(OrderNumber?), new OrderNumberModelBinder()));
            
            // Below is not working for Nullable Types
            //config.Services.Add(typeof(ModelBinderProvider), new SimpleModelBinderProvider(typeof(OrderNumber?), new OrderNumberModelBinder()));
            //config.Services.Add(typeof(ModelBinderProvider), new SimpleModelBinderProvider(typeof(OrderNumber), new OrderNumberModelBinder()));
        }
    }
}
