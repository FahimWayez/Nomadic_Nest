using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("api/order/create")]
        public HttpResponseMessage Create(OrderDTO u)
        {
            OrderService.Create(u);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/order/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = OrderService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/order/all")]
        public HttpResponseMessage Get()
        {
            var data = OrderService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[HttpPut]
        //[Route("api/post/update/{id}")]
        //public HttpResponseMessage update(int id, OrderDTO u)
        //{
        //    var data = OrderService.Update(id, u);
        //    return Request.CreateResponse(HttpStatusCode.OK, data);
        //}
            

        [HttpDelete]
        [Route("api/order/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = OrderService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
