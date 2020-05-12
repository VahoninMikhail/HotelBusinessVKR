<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormCreateZakaz.aspx.cs" Inherits="PekaMarketEmploeeWebView.FormCreateZakaz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 411px; width: 1300px">
    <form id="form1" runat="server">
    <div style="height: 464px; width: 1286px">
    
        Клиент&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownListClient" runat="server" Height="16px" Width="285px" AutoPostBack="True">
        </asp:DropDownList>
        &nbsp;&nbsp;<br />
        <br />
&nbsp;Товар<asp:DropDownList ID="DropDownListProduct" runat="server" Height="16px" style="margin-left: 8px" Width="188px" OnSelectedIndexChanged="DropDownListProduct_SelectedIndexChanged" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            &nbsp;Количество
            <asp:TextBox ID="TextBoxCount" runat="server" AutoPostBack="True" OnTextChanged="TextBoxCount_TextChanged"></asp:TextBox>
            <br />
            &nbsp;Сумма<asp:TextBox ID="TextBoxPrice" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
        <br />
        <asp:Button ID="ButtonSave" runat="server" Text="Сохранить" OnClick="ButtonSave_Click" />
        <asp:Button ID="ButtonCancel" runat="server" Text="Отмена" OnClick="ButtonCancel_Click" />
    
    </div>
    </form>
</body>
</html>
