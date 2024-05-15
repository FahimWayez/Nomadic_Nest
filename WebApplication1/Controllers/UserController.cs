using BLL.DTOs;
using BLL.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user/paged")]
        public HttpResponseMessage GetPaged([FromUri] int pageNumber, [FromUri] int pageSize)
        {
            var data = UserService.GetPaged(pageNumber, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[Logged]
        [HttpGet]
        [Route("api/user/search")]
        public HttpResponseMessage Search([FromUri] string term)
        {
            var data = UserService.Search(term);
            if (data == null || !data.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Users found.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

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

        [HttpGet]
        [Route("api/user/{id}/posts")]
        public HttpResponseMessage GetUserPost(int id)
        {
            var data = UserService.GetUserPost(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/{id}/services")]
        public HttpResponseMessage GetUserServer(int id)
        {
            var data = UserService.GetUserService(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[Logged]
        [HttpPut]
        [Route("api/user/update/{id}")]
        public HttpResponseMessage update(int id, UserDTO u)
        {
            var data = UserService.Update(id, u);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPut]
        [Route("api/user/change_pass/{id}")]
        public HttpResponseMessage ChangePassword(int id, UserDTO u)
        {
            var data = UserService.ChangePassword(id, u);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //[Logged]
        [HttpDelete]
        [Route("api/user/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var data = UserService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
