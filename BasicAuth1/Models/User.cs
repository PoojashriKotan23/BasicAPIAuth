using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BasicAuth1.Models
{
    public class User
    {

        [DataMember(EmitDefaultValue = false, Name = "UserName", Order = 0)]
        public string Username { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Password", Order = 1)]
        public string Password { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Roles", Order = 2)]
        public string Role { get; set; }
        [DataMember(EmitDefaultValue = false, Name = "Email", Order = 3)]
        public string Email { get; set; }
        internal static List<User> GetUser()
        {
            List<User> list = new List<User>()
            {
                new User{Username="Poojashri",Password="Bangalore",Role="Admin",Email="p@"},
                new User{Username="Pooja",Password="Udupi",Role="Admin",Email="p@"},
                new User{Username="Shri",Password="Hasan",Role="User",Email="p@"},
                new User{Username="Poo",Password="Delhi",Role="Employee",Email="p@"},
            };
            return list;
        }
    }
}