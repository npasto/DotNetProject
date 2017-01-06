using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for stockMarketSystem
/// </summary>
public class stockMarketSystem
{
    public static string[] stocksNames;
    public static StockMarketSimulator.MarketWatcher MW;
    public static string defaultPreferedStock;

    static stockMarketSystem()
    {

        stocksNames = new string[] { "MSFT", "ORCL", "IBM", "YAHO" };
        MW = new StockMarketSimulator.MarketWatcher(stocksNames);
        defaultPreferedStock = ConfigurationSettings.AppSettings["defPreferedStock"];

    }

    public stockMarketSystem()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
