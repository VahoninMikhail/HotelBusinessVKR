<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Change.aspx.cs" Inherits="HotelBusinessWeb.Change" MasterPageFile="~/Hotel.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        Старый пароль: <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            <br />
            Новый пароль:&nbsp; <asp:TextBox ID="TextBoxNewPassword" runat="server"></asp:TextBox>
            <br />
            Подтверждение пароля: <asp:TextBox ID="TextBoxConfirmPassword" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Сохранить" />
            <asp:Button ID="Button2" runat="server" Text="Отмена" />
      </div>
</asp:Content>
