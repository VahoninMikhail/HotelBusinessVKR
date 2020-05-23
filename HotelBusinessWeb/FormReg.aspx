<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormReg.aspx.cs" Inherits="HotelBusinessWeb.FormReg" MasterPageFile="~/Hotel.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
            ФИО<asp:TextBox ID="TextBoxFIO" runat="server"></asp:TextBox>
            <br />
            Логин/Почта<asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox>
            <br />
            Номер телефона<asp:TextBox ID="TextBoxPhoneNumber" runat="server"></asp:TextBox>
            <br />
            Пароль<asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            <br />
            Подтверждение пароля<asp:TextBox ID="TextBoxConfirmPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Сохранить" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click2" Text="Отмена" />
      </div>
</asp:Content>
