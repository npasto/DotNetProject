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

public partial class ClientsManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void clientsPortfoliosDS_Updating(object sender, ObjectDataSourceMethodEventArgs e)
    {
        //throw new Exception("The method or operation is not implemented.");
    }
    protected void btNewUtil_Click(object sender, EventArgs e)
    {
        clientsDS.Insert();
        GVClients.DataBind();
        GVClients.PageIndex = GVClients.PageCount;
        GVClients.EditIndex = GVClients.Rows.Count - 1;

    }
}
