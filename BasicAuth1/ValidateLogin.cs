using BasicAuth1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuth1
{
    public class ValidateLogin
    {
        //check if user exist or not
        public static bool LoginUser(string username,string password)
        {
            return User.GetUser().Any(User => User.Username.Equals(username) && User.Password.Equals(password));
        }
        //Get user details
        public static User GetUserDetails(string username,string password)
        {
            return  User.GetUser().FirstOrDefault(User => User.Username.Equals(username) && User.Password.Equals(password));
        }
        
    }
}