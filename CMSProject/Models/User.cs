using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CMSProject.Models
{
    [DataContract]
    public class User
    {
            [DataMember]
        public int ID { get; set; }
            [DataMember]
      
        public string Username { get; set; }
            [DataMember]
        public string Password { get; set; }
            [DataMember]
        public string Email { get; set; }
            [DataMember]
        public int IdRole { get; set; }
         [DataMember]
        public virtual Role role { get; set; }
    }
}