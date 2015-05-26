using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace UserService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "Users", ResponseFormat = WebMessageFormat.Json)]
        UserService.Models.User[] GetUsers();

        [OperationContract]
        [WebGet(UriTemplate = "Roles", ResponseFormat = WebMessageFormat.Json)]
        UserService.Models.Role[] GetRoles();

        [OperationContract]
        [WebInvoke(UriTemplate = "InsertUser", Method = "POST", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        bool InsertUser(UserDetails user);
        [OperationContract]
        [WebInvoke(UriTemplate = "GetUserId", Method = "POST", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        int GetuserId(UserDetails loginUser);
        [OperationContract]
        [WebInvoke(UriTemplate = "GetUser", Method = "POST", ResponseFormat = WebMessageFormat.Xml, RequestFormat = WebMessageFormat.Xml,BodyStyle = WebMessageBodyStyle.Bare)]
        UserDetails GetUser(int id);
    }
    [DataContract]
    public class UserDetails
    {
        string username = string.Empty;
        string password = string.Empty;
        int roleId = 0;
        string email = string.Empty;

        [DataMember]
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        [DataMember]
        public int IdRole
        {
            get { return roleId; }
            set { roleId = value; }
        }
        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
