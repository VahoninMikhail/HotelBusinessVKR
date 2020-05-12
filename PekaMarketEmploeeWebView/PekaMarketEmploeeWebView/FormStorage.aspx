<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormStorage.aspx.cs" Inherits="PekaMarketEmploeeWebView.FormStorage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Название&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="textBoxFIO" runat="server" Height="16px" Width="280px" AutoPostBack="True"></asp:TextBox>
        &nbsp;
        <br />
        <br />
        <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Сохранить" />
        <asp:Button ID="ButtonCancel" runat="server" OnClick="ButtonCancel_Click" Text="Отмена" Height="25px" />
    
        <br />
    
    </div>
    </form>
</body>
</html>
