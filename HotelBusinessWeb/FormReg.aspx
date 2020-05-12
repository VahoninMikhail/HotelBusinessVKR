<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormReg.aspx.cs" Inherits="HotelBusinessWeb.FormReg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ФИО<asp:TextBox ID="TextBoxFIO" runat="server"></asp:TextBox>
            <br />
            Логин<asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox>
            <br />
            Пароль<asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            <br />
            Подтверждение пароля<asp:TextBox ID="TextBoxConfirmPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Сохранить" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click2" Text="Отмена" />
        </div>
    </form>
</body>
</html>
