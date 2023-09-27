using BasicAuth1.BasicAuth;
using BasicAuth1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicAuth1.Controllers
{
    [RoutePrefix ("api/Employees")]
    [BasicAutentication]
    public class EmployeeController : ApiController
    {
        //GetFewEmployee
        [Route("GetFewEmployee")]
        [BasicAuthorizationAttribute(Roles="Employee")]
        public HttpResponseMessage GetFewEmployee()
        {
            return Request.CreateResponse(HttpStatusCode.OK,Employee.GetEmployee().Where(e=>e.ID<103));
        }
        [Route("GetMoreEmployee")]
        [BasicAuthorizationAttribute(Roles = "User")]
        //GetMoreEmployee
        public HttpResponseMessage GetMoreEmployee()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Employee.GetEmployee().Where(e => e.ID <106));
        }
        [Route("GetAllEmployee")]
        [BasicAuthorizationAttribute(Roles = "Admin")]
        //GetAllEmployee
        public HttpResponseMessage GetAllEmployee()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Employee.GetEmployee());
        }
    } 
}
