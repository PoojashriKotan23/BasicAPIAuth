using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuth1.BasicAuth
{
    public class BasicAutentication : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
             if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
            }
            else
            {
                try
                {
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;
                    //username:password base64 encoded   YWRtaW46cGFzc3dvcmQ=
                    string decodedAuth = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                    string[] usernamepassword = decodedAuth.Split(':');
                    string username = usernamepassword[0];
                    string password = usernamepassword[1];

                    if (ValidateLogin.LoginUser(username, password))
                    {
                        var UserDetails = ValidateLogin.GetUserDetails(username,password);
                        var identity = new GenericIdentity(username);
                        identity.AddClaim(new Claim(ClaimTypes.Name,UserDetails.Username));
                        identity.AddClaim(new Claim(ClaimTypes.Email, UserDetails.Email));

                        IPrincipal principal = new GenericPrincipal(identity, UserDetails.Role.Split(','));

                        Thread.CurrentPrincipal = principal;
                           if(HttpContext.Current!=null)
                            {
                                HttpContext.Current.User = principal;
                            }
                        else
                        {
                            actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Access Denied");
                        }
                           
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid User");
                    }
                }
                catch (Exception)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "InternalServerError-Please try after sometime");
                }

            }
        }
    }
}