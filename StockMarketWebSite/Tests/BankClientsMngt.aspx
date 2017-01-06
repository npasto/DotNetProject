<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BankClientsMngt.aspx.cs" Inherits="Tests_BankClientsMngt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GVClients" runat="server" DataSourceID="clientDS" AutoGenerateColumns="False" DataKeyNames="id" CellPadding="4" ForeColor="#333333" GridLines="None">
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" Visible="False" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            </Columns>
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        
        <asp:ObjectDataSource ID="clientDS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetClients" TypeName="DaBankTableAdapters.clientsTableAdapter" UpdateMethod="Update">
            <UpdateParameters>
                <asp:Parameter Name="id" Type="Int32" />
                <asp:Parameter Name="name" Type="String" />
             </UpdateParameters>
        </asp:ObjectDataSource>
        
        <asp:GridView ID="GVClientsPFLines" runat="server" AutoGenerateColumns="False" DataKeyNames="idClient,idStock" DataSourceID="clientPortfolioDS" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="idClient" HeaderText="idClient" ReadOnly="True" SortExpression="idClient" InsertVisible="False" />
                <asp:BoundField DataField="idStock" HeaderText="idStock" ReadOnly="True" SortExpression="idStock" />
                <asp:BoundField DataField="nbOwned" HeaderText="nbOwned" SortExpression="nbOwned" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
        </asp:GridView>
        <asp:ObjectDataSource ID="clientPortfolioDS" runat="server" DeleteMethod="Delete"
            InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCustomerPortfolioLines"
            TypeName="DaBankTableAdapters.clientsPortfoliosTableAdapter" UpdateMethod="Update">
            <DeleteParameters>
                <asp:Parameter Name="Original_idClient" Type="Int32" />
                <asp:Parameter Name="Original_idStock" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="idClient" Type="Int32" />
                <asp:Parameter Name="idStock" Type="String" />
                <asp:Parameter Name="nbOwned" Type="Int32" />
                <asp:Parameter Name="Original_idClient" Type="Int32" />
                <asp:Parameter Name="Original_idStock" Type="String" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="GVClients" Name="id" PropertyName="SelectedValue"
                    Type="Int32" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="idClient" Type="Int32" />
                <asp:Parameter Name="idStock" Type="String" />
                <asp:Parameter Name="nbOwned" Type="Int32" />
            </InsertParameters>
        </asp:ObjectDataSource>
        &nbsp; 
    </div>
    </form>
</body>
</html>
