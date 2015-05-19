using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CMSProject.DAL;
using CMSProject.Models;

namespace CMSProject.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private CMSContext db = new CMSContext();
        
        public List<UserType> GetUsers()
        {
            var x = from n in db.Users select n;
            List<UserType> res = new List<UserType>();
            foreach (var i in x.ToList<User>())
            {
                res.Add(new UserType
                {
                    Email = i.Email,
                    Username = i.Username
                });
            }
            return res;
        }
    }
}
