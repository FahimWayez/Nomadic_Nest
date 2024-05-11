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
    public class ServiceController : ApiController
    {
        [HttpPost]
        [Route("api/service/create")]
        public HttpResponseMessage Create(ServiceDTO u)
        {
            ServiceService.Create(u);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        [HttpGet]
        [Route("api/service/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ServiceService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/service/all")]
        public HttpResponseMessage Get()
        {
            var data = ServiceService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPut]
        [Route("api/service/update/{id}")]
        public HttpResponseMessage update(int id, ServiceDTO u)
        {
            var data = ServiceService.Update(id, u);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpDelete]
        [Route("api/service/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = ServiceService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
