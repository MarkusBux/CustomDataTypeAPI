# Custom DataType / ValueType WebAPI
This project is a PoC/spike project to evaluate how to deal with custom data types within ASP.Net WebAPI 2.

Covered areas
* Sample ValueType implementation
* Newtonsoft.JSON Converter
* ModelBinder
* Handle ModelState errors
* Using ActionFilter/Exception filter
* Opt-Out of global registered Action/Exception fiters for a specifc controller or action

# Missing functionality
* XML serialization and deserialization of custom value type through ASP.Net API ModelBinding

# References
Blogs, documentations,... is used to get the things up and running.
* https://blog.magnusmontin.net/2020/04/03/custom-data-types-in-asp-net-core-web-apis/
* https://www.devtrends.co.uk/blog/dependency-injection-in-action-filters-in-asp.net-core
* https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api#model-binders
* https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/model-validation-in-aspnet-web-api
* https://rehansaeed.com/gethashcode-made-easy/