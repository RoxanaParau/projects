using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using CMSProject.Models;

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
        public ActionResult Index(Register model)
        {

            return View();
        }
       
        public ActionResult Register(Register model)
        {          
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            try
            {
                if (model.email != null && model.username != null && model.password != null)
                {

                    const string url = "http://localhost:50679/Service1.svc/InsertUser";
                    req = (HttpWebRequest)WebRequest.Create(url);
                    req.Method = "POST";
                    req.ContentType = "application/xml; charset=utf-8";
                    req.Timeout = 30000;
                    req.Headers.Add("SOAPAction", url);


                    var xmlDoc = new XmlDocument { XmlResolver = null };
                    xmlDoc.Load(Server.MapPath("PostData.xml"));

                    string sXml = "<UserDetails xmlns='http://schemas.datacontract.org/2004/07/UserService'><Email>" + model.email + "</Email><IdRole>" +
                        model.roleId + "</IdRole><Password>" + Helpers.SHA1.Encode(model.password) + "</Password><UserName>" + model.username + "</UserName></UserDetails>";
                    xmlDoc.InnerXml = sXml;
                    req.ContentLength = sXml.Length;

                    var sw = new StreamWriter(req.GetRequestStream());
                    sw.Write(sXml);
                    sw.Close();

                    res = (HttpWebResponse)req.GetResponse();
                    Stream responseStream = res.GetResponseStream();
                    var streamReader = new StreamReader(responseStream);

                    //Read the response into an xml document
                    var soapResonseXmlDocument = new XmlDocument();
                    soapResonseXmlDocument.LoadXml(streamReader.ReadToEnd());

                    //return only the xml representing the response details (inner request)
                    //TextBox1.Text = soapResonseXmlDocument.InnerXml;
                    ////Response.Write(soapResonseXMLDocument.InnerXml);
                    ViewBag.result = "User registered Successfully!";
                    model.email = null;
                    model.password = null;
                    model.roleId = 0;
                    model.username = null;
                }
                else
                {
                    ViewBag.result = "";
                }
               
            }
            catch (Exception ex)
            {
               ViewBag.result = ex.Message;
            }
            ModelState.Clear();  
            return View();
        }

    }
}
