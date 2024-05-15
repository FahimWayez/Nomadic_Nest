using BLL.DTOs;
using BLL.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ServiceController : ApiController
    {
        [HttpGet]
        [Route("api/service/paged")]
        public HttpResponseMessage GetPaged([FromUri] int pageNumber, [FromUri] int pageSize)
        {
            var data = ServiceService.GetPaged(pageNumber, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpGet]
        [Route("api/service/filter")]
        public HttpResponseMessage Filter([FromUri] string filterBy, [FromUri] string value)
        {
            try
            {
                var data = ServiceService.Filter(filterBy, value);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/service/sort")]
        public HttpResponseMessage Sort([FromUri] string sortBy, [FromUri] bool ascending)
        {
            try
            {
                var data = ServiceService.Sort(sortBy, ascending);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        //[Logged]
        [HttpGet]
        [Route("api/service/search")]
        public HttpResponseMessage Search([FromUri] string term)
        {
            var data = ServiceService.Search(term);
            if (data == null || !data.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Services found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[Logged]
        [HttpPost]
        [Route("api/service/create")]
        public HttpResponseMessage Create(ServiceDTO u)
        {
            ServiceService.Create(u);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        //[Logged]
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
        //[Logged]
        [HttpPut]
        [Route("api/service/update/{id}")]
        public HttpResponseMessage update(int id, ServiceDTO u)
        {
            var data = ServiceService.Update(id, u);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        //[Logged]
        [HttpDelete]
        [Route("api/service/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = ServiceService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
