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
    /// Summary description for valorizedStockInfo
    /// </summary>
    public sealed class valorizedStockInfo
    {

        private string _stockName = String.Empty;
        private float _valorization;

        public valorizedStockInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public valorizedStockInfo(string StName, float valo)
        {
            this.stockName = StName;
            this.valorization = valo;
        }


        public float valorization
        {
            get { return _valorization; }
            set { _valorization = value; }
        }

        public string stockName
        {
            get { return _stockName; }
            set { _stockName = value; }
        }
    } 
}
