using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class CommentController : ApiController

    {
        //[Logged]
        [HttpPost]
        [Route("api/comment/create")]
        public HttpResponseMessage Create(CommentDTO u)
        {
            CommentService.Create(u);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        //[Logged]
        [HttpGet]
        [Route("api/comment/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = CommentService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[Logged]
        [HttpGet]
        [Route("api/comment/all")]
        public HttpResponseMessage Get()
        {
            var data = CommentService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[Logged]
        [HttpPut]
        [Route("api/comment/update/{id}")]
        public HttpResponseMessage update(int id, CommentDTO u)
        {
            var data = CommentService.Update(id, u);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[Logged]
        [HttpDelete]
        [Route("api/comment/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = CommentService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpGet]
        [Route("api/comment/search")]
        public HttpResponseMessage Search([FromUri] string term)
        {
            var data = CommentService.Search(term);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpGet]
        [Route("api/comment/sort")]
        public HttpResponseMessage Sort([FromUri] string sortBy, [FromUri] bool ascending)
        {
            try
            {
                var data = CommentService.Sort(sortBy, ascending);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
