<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormMain.aspx.cs" Inherits="HotelBusinessWeb.FormMain" %>

<%@ Register assembly="System.Web.Mvc" namespace="System.Web.Mvc" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

      <p>
          <asp:Calendar ID="CalendarFrom" runat="server" Width="175px"></asp:Calendar>                                     
          <asp:Calendar ID="CalendarBefore" runat="server" Width="178px"></asp:Calendar>
      </p>
              
            <asp:TextBox ID="TextBoxCountForm" runat="server"></asp:TextBox>
            <asp:GridView ID="GridViewForm" runat="server" OnSelectedIndexChanged="GridViewForm_SelectedIndexChanged" DataKeyNames = "Id">
            </asp:GridView>
            <asp:TextBox ID="TextBoxCountService" runat="server" EnableTheming="True"></asp:TextBox>
            <asp:GridView ID="GridViewService" runat="server" OnSelectedIndexChanged="GridViewService_SelectedIndexChanged" DataKeyNames = "Id" OnPreRender="GridViewService_PreRender" EnableModelValidation="False">
            </asp:GridView>

            <p>
                
            </p>
            <asp:DropDownList ID="DropDownListForm" runat="server">
            </asp:DropDownList>
            <asp:Button ID="ButtonAddForm" runat="server" Text="Добавить" OnClick="ButtonAddForm_Click" />
            <asp:GridView ID="GridViewZakazRoom" runat="server">
            </asp:GridView>
            <asp:DropDownList ID="DropDownListService" runat="server">
            </asp:DropDownList>
            <asp:Button ID="ButtonAddService" runat="server" Text="Добавить" />
            <asp:GridView ID="GridViewZakazService" runat="server">
            </asp:GridView>
        </div>
        <input id="Hidden2" type="hidden" />
        <p>
            <input id="Hidden1" type="hidden" />
            <asp:Button ID="Save" runat="server" Text="Заказать" OnClick="Save_Click" />
            <asp:Button ID="ButtonCancel" runat="server" Text="Отмена" />

            <asp:Button ID="btnInsert" runat="server" onclientclick= "OpenInsert()" Text="Insert"/>
        
        </p>
    </form>
</body>
</html>