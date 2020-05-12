<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCreateOrder.aspx.cs" Inherits="HotelBusinessWeb.FormCreateOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="DropDownListForm" runat="server">
            </asp:DropDownList>
            <asp:TextBox ID="TextBoxCount" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" OnClick="ButtonAdd_Click" />
    </form>
</body>
</html>
