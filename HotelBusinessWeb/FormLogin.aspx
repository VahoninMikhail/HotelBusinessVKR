﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLogin.aspx.cs" Inherits="HotelBusinessWeb.FormLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             Логин<asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
            <br />
            Пароль<asp:TextBox ID="textBoxPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Вход" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click2" Text="Регистрация" />
        </div>
    </form>
</body>
</html>
