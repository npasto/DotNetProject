<%@ Page Language="C#" AutoEventWireup="true" CodeFile="affStocks.aspx.cs" Inherits="affStocks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="1" class="tabBody">
            <tr class="tabEntete">
                <td style="width: 624px" >
                [header à venir]
                    </td>
            </tr>
            <tr>
                <td style="width: 624px">
                    Choisissez les valeurs de stocks à voir:</td>
            </tr>
            <tr>
                <td style="width: 624px; text-align: center">
                    <asp:DropDownList ID="ddlStocks" runat="server" Width="190px">
                    </asp:DropDownList>
                    <asp:Button ID="btGetStock" runat="server" OnClick="Button1_Click" Text="Afficher la valeur" /></td>
            </tr>
            <tr>
                <td style="width: 624px; height: 38px; text-align: center">
                    <asp:Label ID="lbStockValue" runat="server" Font-Size="Larger" ForeColor="Blue" Height="34px"
                        Text="[valeur insérée ici]" Width="127px"></asp:Label></td>
            </tr>
        </table>
        <br />
        &nbsp;</div>
    </form>
</body>
</html>
