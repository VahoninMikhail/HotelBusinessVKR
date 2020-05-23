<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCreateOrder.aspx.cs" Inherits="HotelBusinessWeb.FormCreateOrder" MasterPageFile="~/Hotel.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
            <asp:DropDownList ID="DropDownListForm" runat="server">
            </asp:DropDownList>
            <asp:TextBox ID="TextBoxCount" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonAdd" runat="server" Text="Добавить" OnClick="ButtonAdd_Click" />
    </div>
</asp:Content>
