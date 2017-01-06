<%--

   renvoie du XML

--%>
<script language="C#" runat="server">

    public void Page_Load(Object sender, EventArgs e) {

        Response.ContentType = "text/xml";
        Response.Write("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?>");
        Response.Write("<myPreferedStock><name>");
        Response.Write(Request.QueryString["stock"]);
            Response.Write("</name><value>");
            Response.Write(stockMarketSystem.MW.GetStockValue(Request.QueryString["stock"]));
        Response.Write("</value></myPreferedStock>");
        

        
    }

</script>