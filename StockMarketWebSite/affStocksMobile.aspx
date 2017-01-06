<%@ Page Language="C#" AutoEventWireup="true" CodeFile="affStocksMobile.aspx.cs" Inherits="affStocksMobile" %>
<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:Form id="Form1" runat="server">&nbsp; <mobile:SelectionList ID="SelectionList1"
        Runat="server">
    </mobile:SelectionList> <mobile:Command ID="Command1" Runat="server" OnClick="Command1_Click">voir</mobile:Command> <br /></mobile:Form>
    <mobile:Form ID="Form2" Runat="server">
        <mobile:Label
        ID="Label1" Runat="server">Label</mobile:Label>
        <br />
        <mobile:Command ID="Command2" Runat="server" OnClick="Command2_Click">retour</mobile:Command>
    </mobile:Form>
</body>
</html>
