using BLL.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApplication1.Auth
{
    public class RoleAuthorize : AuthorizationFilterAttribute
    {
        private readonly string[] _roles;

        public RoleAuthorize(params string[] roles)
        {
            _roles = roles;
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            if (token == null || !AuthService.isTokenValid(token.ToString()))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { Msg = "Invalid or missing token" });
                return;
            }

            var userRole = AuthService.GetUserRoleFromToken(token.ToString());
            if (!_roles.Contains(userRole))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden, new { Msg = "You do not have permission to access this resource" });
            }
        }
    }
}
