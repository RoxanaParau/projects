using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSProject.Models
{
    public class Register
    {
        public string username { get; set; }
        public string password { get; set; }
        public int roleId { get; set; }
        public string email { get; set; }
    }
}