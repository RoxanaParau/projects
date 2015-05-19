using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CMSProject.DAL;
using PagedList.Mvc;

namespace CMSProject.Controllers
{
    public class UserController : Controller
    {
        
        //
        // GET: /User/

        public ActionResult Index()
        {

            UsersServiceReference.UserServiceClient obj = new UsersServiceReference.UserServiceClient();
            return View(obj.GetUsers());
        }

    }
}
