using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class affStocks : System.Web.UI.Page
{
    public static StockMarketSimulator.MarketWatcher MW;
    static string[] stocksNames;

    static affStocks()
    {

        stocksNames = new string[] { "MSFT", "ORCL", "IBM", "YAHO" };
        MW = new StockMarketSimulator.MarketWatcher(stocksNames);

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // !!! sinon exécuté à chaque fois !!!
        if (!IsPostBack)
        {
            this.ddlStocks.DataSource = stocksNames;
            this.ddlStocks.DataBind();
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string SelectedStock;
        //MessageBox.Show("in proc");
        if (this.ddlStocks.SelectedIndex != -1)
        {
            SelectedStock = (this.ddlStocks.Items[ddlStocks.SelectedIndex]).ToString();
            this.lbStockValue.Text = MW.GetStockValue(SelectedStock) + " " + MW.GetStockInitialValue(SelectedStock) + " " + MW.GetStockDelta(SelectedStock);


        }
    }
}

