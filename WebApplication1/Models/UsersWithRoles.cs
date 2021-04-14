using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication1.Models
{
    public class UsersWithRoles
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }

}