<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ClientsManagement.aspx.cs" Inherits="ClientsManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Gestion Clients</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GVClients" runat="server" AutoGenerateColumns="False" DataKeyNames="id"
            DataSourceID="clientsDS" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id"
                    Visible="False" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="log" HeaderText="log" SortExpression="log" NullDisplayText="entrer log" />
                <asp:BoundField DataField="pwd" HeaderText="pwd" SortExpression="pwd" NullDisplayText="entrer pwd" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btNewUtil" runat="server" OnClick="btNewUtil_Click" Text="Ajouter un client"
            Width="148px" /><br />
        <asp:ObjectDataSource ID="clientsDS" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
            OldValuesParameterFormatString="original_{0}" SelectMethod="GetClients" TypeName="ClientsDATableAdapters.clientsTableAdapter"
            UpdateMethod="Update" OnUpdating="clientsPortfoliosDS_Updating">
            <DeleteParameters>
                <asp:Parameter Name="Original_id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="log" Type="String" />
                <asp:Parameter Name="pwd" Type="String" />
                <asp:Parameter Name="Original_id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
          
            </InsertParameters>
        </asp:ObjectDataSource>
        &nbsp;
    
    </div>
    </form>
</body>
</html>
