﻿using BLL.DTOs;
using BLL.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class PostController : ApiController
    {

        //[Logged]
        [HttpGet]
        [Route("api/post/sort")]
        public HttpResponseMessage Sort([FromUri] string sortBy, [FromUri] bool ascending)
        {
            try
            {
                var data = PostService.Sort(sortBy, ascending);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

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
