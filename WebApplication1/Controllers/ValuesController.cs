using System;
using System.Net;
using System.Web.Http;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Models.ValueTypes;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller for testing custom data/value type
    /// </summary>
    [RoutePrefix("api/Values"), ValidateModelFilter]
    public class ValuesController : ApiController
    {
        /// <summary>
        /// Test Action for query string ModelBinding tests
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        [Route("", Name = "ParamId")]
        public IHttpActionResult GetByQueryString([FromUri] OrderNumber? orderNumber)
        {
            
            if (orderNumber.HasValue)
                return Ok(new CustomOrder() { Order = orderNumber.Value, ComputerName = "TestPC" });
            else
                return StatusCode(status: HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Test Action for attribute routing ModelBinding tests
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns></returns>
        [Route("{orderNumber:alpha}", Name = "ValidId")]
        public IHttpActionResult GetByAttributeRouting([FromUri] OrderNumber orderNumber)
        {
            var v = new CustomOrder() { ComputerName = "TestPC", Order = "Test" };
            OrderNumber number = "Test";
            string t = number;
            return Ok(v);
        }

        /// <summary>
        /// Testaction for IExceptionFilter
        /// </summary>
        /// <returns></returns>
        [Route("NotImpl")]
        [HttpGet]
        public IHttpActionResult NotImpl()
        {
            throw new NotImplementedException("This method is not yet ready!");
        }

        /// <summary>
        /// Test action for exception filter opt-out
        /// </summary>
        /// <returns></returns>
        [Route("NotImplExc"), NotImplExceptionFilterOptOut]
        [HttpGet]
        public IHttpActionResult NotImplExc()
        {
            throw new NotImplementedException("This method is not yet ready!");
        }

        /// <summary>
        /// Test action for ModelBinding of complex types by message body
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(CustomOrder value)
        {
            CustomOrder createdValue = value;
            var uri1 = Url.Link("ValidId", new { orderNumber = createdValue.Order });
            var uri2 = Url.Link("ParamId", new { orderNumber = createdValue.Order });
            return Created(new Uri(uri1), createdValue);
        }

        /// <summary>
        /// Empty Test action
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] string value)
        {
            // NoOp
            return Ok();
        }

        /// <summary>
        /// Empty Test action
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            // NoOp
            return Ok();
        }
    }
}
