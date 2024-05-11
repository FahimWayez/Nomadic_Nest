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
    public class UserController : ApiController
    {        
        [HttpPost]
        [Route("api/user/create")]
        public HttpResponseMessage Create(UserDTO u)
        {
            UserService.Create(u);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpGet]
        [Route("api/user/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = UserService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/all")]
        public HttpResponseMessage Get()
        {
            var data = UserService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpPut]
        [Route("api/user/update/{id}")]
        public HttpResponseMessage update(int id,UserDTO u)
        {
            var data = UserService.Update(id,u);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Logged]
        [HttpDelete]
        [Route("api/user/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
