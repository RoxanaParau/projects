using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml;

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
       
        public ActionResult Register()
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            try
            {
                const string url = "http://localhost:50679/Service1.svc/InsertUser";
                req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/xml; charset=utf-8";
                req.Timeout = 30000;
                req.Headers.Add("SOAPAction", url);


                var xmlDoc = new XmlDocument { XmlResolver = null };
                xmlDoc.Load(Server.MapPath("PostData.xml"));
                string sXml = xmlDoc.InnerXml;
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
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
         
            return View("Register");
        }

    }
}
