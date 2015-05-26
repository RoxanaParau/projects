using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CMSProject;
using UserService.Models;
namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    public class Service1 : IService1
    {
        private Models.CMSProjectEntities db;
        public Service1()
        {
            db = new Models.CMSProjectEntities();
        }
        public UserService.Models.User[] GetUsers()
        {

            var res = db.User.ToArray();
            return res;
        }
        public UserService.Models.Role[] GetRoles()
        {

            var res = db.Role.ToArray();
            return res;
        }

        public bool InsertUser(UserDetails user)
        {
            try
            {
                User u = new User();
                u.Email = user.Email;
                u.Password = user.Password;
                u.role_ID = user.IdRole;
                u.Username = user.UserName;
                db.User.Add(u);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int GetuserId(UserDetails loginUser)
        {
            if (db.User.Where(user => user.Username == loginUser.UserName && user.Password == Helpers.SHA1.Encode(loginUser.Password)).Count() == 0)
                return 0;
            else
                return db.User.Where(user => user.Username == username && user.Password == Helpers.SHA1.Encode(password)).Select(u => u.ID).ToList()[0];
        }

        public UserDetails GetUser(int id)
        {
            var temp = db.User.Where(user => user.ID == id);
            UserDetails result = new UserDetails();
            result.UserName = temp.Select(u => u.Username).ToList()[0];
            result.IdRole = (int)temp.Select(u => u.role_ID).ToList()[0];
            result.Email = temp.Select(u => u.Email).ToList()[0];
            return result;
        }
    }
}
