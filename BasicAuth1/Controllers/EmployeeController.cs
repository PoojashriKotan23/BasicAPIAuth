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
    [BasicAutentication]
    public class EmployeeController : ApiController
    {
        public List<Employee> GetEmplpyees()
        {
            return Employee.GetEmployee();
        }
    }
}
