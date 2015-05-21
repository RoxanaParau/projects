using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMSProject.Controllers
{
    public class MVCWCFClientController : Controller
    {
        //
        // GET: /MVCWCFClient/
        /*@*
In the  HTML code for view, the Angular binding is done using the following directives:

ng-app – bound with Module for the bootstrapping
ng-controller – bound with the Controller, so that the $scope declared in the controller can be bound with the UI.
ng-repeat - This is an iteration for $scope.Employees so that the data from it can be shown in Table.
*@
         */
        public ActionResult Index()
        {
            return View();
        }

    }
}
