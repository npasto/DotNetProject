using System;


using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;

using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;


namespace DAL
{
    /// <summary>
    /// cette classe gere l'accès aux données de la BD Client
    /// </summary>
    public class DAClients
    {
        public DAClients()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static List<DTO.stockOwnedInfo> getOwnedStockByClientID(int id)
        {
            List<DTO.stockOwnedInfo> res = null;
            string sqlCommand;

            sqlCommand = string.Format("select idStock, nbOwned from clientsPortfolios where idClient ={0}", id);

            using (SqlConnection myConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dev\\Dotnet\\3-TPs\\BDfolder\\Bank.mdf;Integrated Security=True;Connect Timeout=30"))
            using (SqlCommand myCMD = new SqlCommand(sqlCommand, myConn))
            {
                myConn.Open();
                SqlDataReader myReader = myCMD.ExecuteReader();

                if (myReader.HasRows)
                {
                    res = new List<DTO.stockOwnedInfo>();
                    DTO.stockOwnedInfo stockOwnedInfoInstance;

                    while (myReader.Read())
                    {

                        stockOwnedInfoInstance = new DTO.stockOwnedInfo(myReader.GetString(0), (int)myReader.GetInt32(1));
                        res.Add(stockOwnedInfoInstance);

                    }
                    myReader.Close();
                }

            }

            return res;
        }
        public static int checkLogin(string log, string pwd)
        {
            string sqlCommand;

            sqlCommand = string.Format("select id from clients where log ='{0}' and pwd='{1}'", log, pwd);

            /// Dotnet / 3 - TPs / BDfolder / Bank.mdf
            //using (SqlConnection myConn = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=D:\\DEV\\2-DotNet\\3-TPs\\BDfolder\\Bank.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"))
            using (SqlConnection myConn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Dev\\Dotnet\\3-TPs\\BDfolder\\Bank.mdf;Integrated Security=True;Connect Timeout=30"))
            using (SqlCommand myCMD = new SqlCommand(sqlCommand, myConn))
            {
                myConn.Open();
                SqlDataReader myReader = myCMD.ExecuteReader();

                if (myReader.HasRows)
                {
                    myReader.Read();
                    return (int)myReader.GetInt32(0);
                }
                else
                {
                    return 0;
                }

            }
        }
        public static EDM.client checkLoginEDM(string log, string pwd)
        {
            using (EDM.BankEntities entities = new EDM.BankEntities())
            {

                ObjectQuery<EDM.client> Clients = entities.clientSet;//.Where("it.id="+tbLog.Text+" and it.log="+tbPwd.Text);

                var selectedClients = from myClient in Clients
                              where myClient.log == log
                                  && myClient.pwd == pwd
                              select myClient;
                //contact.ContactID == order.Contact.ContactID
                //    && order.TotalDue < 500.00M
                //select myClient


                //int idClient =
                //BF.LoginManager.checkLogin(, tbPwd.Text);
                if (selectedClients.Count<EDM.client>() == 0)
                {
                    return null;
                }
                else
                {
                    Clients.First<EDM.client>().clientsPortfolios.Load();
                    return Clients.First<EDM.client>();
                }
            }
        }
    }
}
