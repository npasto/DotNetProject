using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Mobile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class affStocksMobile : System.Web.UI.MobileControls.MobilePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SelectionList1.DataSource = stockMarketSystem.stocksNames;
            this.SelectionList1.DataBind();
        }
    }
    protected void Command1_Click(object sender, EventArgs e)
    {
        //MessageBox.Show("in proc");
        if (this.SelectionList1.Selection != null)
        {
            this.Label1.Text = this.SelectionList1.Selection.Text+" "+stockMarketSystem.MW.GetStockValue(this.SelectionList1.Selection.Text) + " " + stockMarketSystem.MW.GetStockInitialValue(this.SelectionList1.Selection.Text) + " " + stockMarketSystem.MW.GetStockDelta(this.SelectionList1.Selection.Text);

            ActiveForm = Form2;


        }
    }
    protected void Command2_Click(object sender, EventArgs e)
    {
        ActiveForm = Form1;
    }
}
