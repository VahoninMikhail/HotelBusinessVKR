<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="HotelBusinessWeb.CartView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Ваша корзина</h2>
        <table id="cartTableService">
            <thead>
                <tr>
                    <th>Айди</th>
                    <th>Название услуги</th>
                    <th>Количество</th>
                    <th>Цена</th>
                    <th>Общая стоимость</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="HorelBusinessService.ViewModels.ServiceOrderViewModel"
                    SelectMethod="GetCartLines" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.ServiceId %></td>
                            <td><%# Item.ServiceName %></td>
                            <td><%# Item.Count.ToString("c")%></td>
                            <td><%# Item.Price.ToString("c")%></td>
                            <td><%# ((Item.Total).ToString("c"))%></td>
                            <td>
                                <button type="submit" class="actionButtons" name="remove"
                                    value="<%#Item.ServiceId %>">
                                    Удалить</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>

            <table id="cartTableRoom">
            <thead>
                <tr>
                    <th>Айди</th>
                    <th>Название комнаты</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater2" ItemType="HorelBusinessService.ViewModels.RoomOrderViewModel"
                    SelectMethod="GetCartLinesRoom" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.RoomId %></td>
                            <td><%# Item.RoomName %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <p class="actionButtons">
            <a href="<%= ReturnUrl %>">Продолжить покупки</a>
        </p>
        </div>
        <asp:Button ID="ButtonReservation" runat="server" OnClick="ButtonReservation_Click" Text="Забронировать" />
    </form>
</body>
</html>
