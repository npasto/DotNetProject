using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;



namespace BF
{
    /// <summary>
    /// Summary description for LoginManager
    /// </summary>
    public class LoginManager
    {
        public LoginManager()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static int checkLogin(string log, string pwd)
        {
            return DAL.DAClients.checkLogin(log, pwd);
        }

        /// <summary>
        /// réalisé avec l'ORM EDM
        /// </summary>
        /// <param name="log"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static EDM.client checkLoginEDM(string log, string pwd)
        {
            
            return DAL.DAClients.checkLoginEDM(log, pwd);
        }
    }
    
}