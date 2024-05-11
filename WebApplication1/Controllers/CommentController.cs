using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Auth;

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
    }
}
