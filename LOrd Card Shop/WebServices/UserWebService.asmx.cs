using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace LOrd_Card_Shop.WebServices
{
    /// <summary>
    /// Summary description for UserWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public String LoginUser(string username, string password)
        {
            return Json.Encode(UserHandler.LoginUser(username, password));
        }

        [WebMethod]
        public String RegisterUser(string username, string email, string password, string gender)
        {

            return Json.Encode(UserHandler.RegisterUser(username, email, password, gender));
        }
        [WebMethod]
        public String UpdateUser(int userId, string username, string email, string password, string gender)
        {

            return Json.Encode(UserHandler.UpdateUser(userId, username, email, password, gender));
        }
        [WebMethod]
        public String GetSession(int cookieId)
        {
            return Json.Encode(UserHandler.GetSession(cookieId));
        }
    }
}
