using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DTO
{
    /// <summary>
    /// Summary description for stockOwnedInfo
    /// </summary>
    public sealed class stockOwnedInfo
    {    
        private string _stockName = String.Empty;
        private int _nbStocksOwned = 0;

        public stockOwnedInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public stockOwnedInfo(string StName, int nbStOwned)
        {
            this.nbStocksOwned=nbStOwned;
            this.stockName = StName;
        }

    

        public int nbStocksOwned
        {
            get { return _nbStocksOwned; }
            set { _nbStocksOwned = value; }
        }

        public string stockName
        {
            get { return _stockName; }
            set { _stockName = value; }
        }
    }
}
