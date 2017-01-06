<%@ Page Language="C#" AutoEventWireup="true" CodeFile="affStocks4EDM.aspx.cs" Inherits="affStocks4EDM" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="maintable" border="0" class="tabBody" style="height: 265px">
            <tr class="tabEntete">
                <td style="width: 624px; height: 23px;" valign="middle" bordercolor="#663366">
                    stock favori:
                    <asp:Label ID="lbHeader" runat="server" ForeColor="White" Text="[header à insérer ici dynamiquement]"
                        Width="243px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 624px; height: 39px;" bordercolor="#663366">
                    Choisissez les valeurs de stocks à voir:</td>
            </tr>
            <tr>
                <td style="width: 624px; text-align: center" bordercolor="#663366">
                    <asp:DropDownList ID="ddlStocks" runat="server" Width="190px">
                    </asp:DropDownList>
                    <asp:Button ID="btGetStock" runat="server" OnClick="Button1_Click" Text="Afficher la valeur" />
                    <asp:Button ID="btPref" runat="server" OnClick="btPref_Click" Text="valeur péférée" /></td>
            </tr>
            <tr>
                <td style="width: 624px; height: 38px; text-align: center" bordercolor="#663366">
                    <asp:Label ID="lbStockValue" runat="server" Font-Size="Larger" ForeColor="Blue" Height="34px"
                        Text="[valeur insérée ici]" Width="127px"></asp:Label></td>
            </tr>
            <tr>
                <td bordercolor="#663366" style="width: 624px; height: 38px; text-align: center">
                    <%--<asp:Button ID="btVoirPF" runat="server" OnClick="btVoirPF_Click" Text="Voir valeur portefeuille" />--%>
                    log:
                    <asp:TextBox ID="tbLog" runat="server"></asp:TextBox>
                    pwd:
                    <asp:TextBox ID="tbPwd" runat="server"></asp:TextBox><br />
                    <br />
                    <asp:GridView ID="GVStocks" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="idStock" HeaderText="id Stock" ReadOnly="True" />
                            <asp:BoundField DataField="Valorization" HeaderText="valeur" ReadOnly="True" SortExpression="Valorization" />
                        </Columns>
                    </asp:GridView>
                    <br />
                    total : &nbsp;<asp:Label ID="lbTotal" runat="server" EnableTheming="True" ForeColor="Red"
                        Text="[activez le bouton]" Width="141px"></asp:Label></td>
            </tr>
        </table>
        <br />
        <br />
        &nbsp;</div>
    </form>
</body>
</html>
