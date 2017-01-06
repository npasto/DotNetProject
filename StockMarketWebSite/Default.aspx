<%--

   routage HTML/WAP
--%>
<script language="C#" runat="server">

    public void Page_Load(Object sender, EventArgs e) {

        if (Request.Browser["IsMobileDevice"] == "true" ) {

            Response.Redirect("affStocksMobile.aspx");
        }
        else {

            Response.Redirect("affStocks2.aspx");
        }
    }

</script>
