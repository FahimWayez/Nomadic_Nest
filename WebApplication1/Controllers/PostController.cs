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
    public class PostController : ApiController
    {
        //[Logged]
        [HttpPost]
        [Route("api/post/create")]
        public HttpResponseMessage Create(PostDTO u)
        {
            PostService.Create(u);
            return Request.CreateResponse(HttpStatusCode.OK);

        }
        //[Logged]
        [HttpGet]
        [Route("api/post/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = PostService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/post/all")]
        public HttpResponseMessage Get()
        {
            var data = PostService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        //[Logged]
        [HttpPut]
        [Route("api/post/update/{id}")]
        public HttpResponseMessage update(int id, PostDTO u)
        {
            var data = PostService.Update(id, u);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        //[Logged]
        [HttpDelete]
        [Route("api/post/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = PostService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
