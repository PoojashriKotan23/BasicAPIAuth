using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuth1
{
    public class ValidateLogin
    {
        public static bool LoginUser(string username,string password)
        {
            if (username=="admin" && password=="password")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}