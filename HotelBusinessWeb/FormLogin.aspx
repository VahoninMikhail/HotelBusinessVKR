<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLogin.aspx.cs" Inherits="HotelBusinessWeb.FormLogin" MasterPageFile="~/Hotel.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
             Логин<asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
            <br />
            Пароль<asp:TextBox ID="textBoxPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Вход" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click2" Text="Регистрация" />
    </div>
</asp:Content>
