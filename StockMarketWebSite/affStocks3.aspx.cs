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

using System.Collections.Generic;

public partial class affStocks3 : System.Web.UI.Page
{
    //class toto
    //{
    //    public int id;
    //    public toto() { }
    //}

    static string srvUrl = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        // !!! sinon exécuté à chaque fois !!!
        

        //ArrayList t = new ArrayList();
        //t.Add(new toto());
        //toto[] ar = t.ToArray(typeof(toto)) as toto[];

        string preferedStockName =string.Empty;

        if (!IsPostBack)
        {
            this.ddlStocks.DataSource = stockMarketSystem.stocksNames;
            this.ddlStocks.DataBind();

            if (srvUrl == String.Empty)
            {
                int lastSlashIndex = Page.Request.Url.ToString().LastIndexOf("/");
                srvUrl = Page.Request.Url.ToString().Substring(0, lastSlashIndex);
            }

        }


        if (Session["preferedStock"] == null)
        {
            Session["preferedStock"] = stockMarketSystem.defaultPreferedStock;
            preferedStockName = stockMarketSystem.defaultPreferedStock;
        }
        else
        {
            preferedStockName = Session["preferedStock"].ToString();
        }


        //this.lbHeader = xmlHelper.Transform_XMLFile_With_XSLTFile("http://localhost:1276/StockMarketWebSite/getXmlHeader.aspx", "http://localhost:1276/StockMarketWebSite/header.xsl");
        //vieux TP XML commenté
        //this.lbHeader.Text = xmlHelper.Transform_XMLFile_With_XSLTFile(srvUrl + "/getXmlHeader.aspx?stock="+preferedStockName, srvUrl + "/header.xsl");





    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string SelectedStock;
        //MessageBox.Show("in proc");
        if (this.ddlStocks.SelectedIndex != -1)
        {
            SelectedStock = (this.ddlStocks.Items[ddlStocks.SelectedIndex]).ToString();
            this.lbStockValue.Text = stockMarketSystem.MW.GetStockValue(SelectedStock) + " " + stockMarketSystem.MW.GetStockInitialValue(SelectedStock) + " " + stockMarketSystem.MW.GetStockDelta(SelectedStock);


        }
    }
    protected void btPref_Click(object sender, EventArgs e)
    {
        if (this.ddlStocks.SelectedIndex != -1)
        {
            Session["preferedStock"] = (this.ddlStocks.Items[ddlStocks.SelectedIndex]).ToString();
        }
    }
    protected void btVoirPF_Click(object sender, EventArgs e)
    {
        if (tbLog.Text == "" || tbPwd.Text == "")
        {
            lbTotal.Text = "Entrez Log/pwd svp";
        }
        else
        {
            int idClient = BF.LoginManager.checkLogin(tbLog.Text, tbPwd.Text);
            if (idClient == 0)
            {
                lbTotal.Text = "Mauvais Log/pwd";
            }
            else
            {
                List<DTO.valorizedStockInfo> LstVSI = BF.PortfolioManager.getCurrentPorfolioValorization(idClient);
                this.GVStocks.DataSource = LstVSI;
                this.GVStocks.DataBind();
                float total = 0;
                foreach (DTO.valorizedStockInfo VS in LstVSI)
                {
                    total += VS.valorization;
                }
                this.lbTotal.Text = total.ToString() + "€";
            }
        }
    }
}

