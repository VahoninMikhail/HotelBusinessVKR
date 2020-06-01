<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="HotelBusinessWeb.CartView" MasterPageFile="~/Hotel.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
            <h2>Ваша корзина</h2>
   
                    <%                      
                            decimal cartTotal = CartTotal;
                            Response.Write(String.Format(@"
                        <div class='item'>
                           <iframe src='https://money.yandex.ru/quickpay/button-widget?targets=%D0%9E%D0%BF%D0%BB%D0%B0%D1%82%D0%B0%20%D0%B7%D0%B0%D0%BA%D0%B0%D0%B7%D0%B0&default-sum={0}&button-text=12&yamoney-payment-type=on&button-size=m&button-color=orange&successURL=http%3A%2F%2Flocalhost%3A51229%2FPaymentSuccessful.aspx&quickpay=small&account=4100115194924455&' width='184' height='36' frameborder='0' allowtransparency='false' scrolling='no'></iframe>
                           <iframe src='https://money.yandex.ru/quickpay/button-widget?targets=%D0%9E%D0%BF%D0%BB%D0%B0%D1%82%D0%B0%20%D0%B7%D0%B0%D0%BA%D0%B0%D0%B7%D0%B0&default-sum={0}&button-text=12&any-card-payment-type=on&button-size=m&button-color=orange&successURL=http%3A%2F%2Flocalhost%3A51229%2FPaymentSuccessful.aspx&quickpay=small&account=4100115194924455&' width='184' height='36' frameborder='0' allowtransparency='false' scrolling='no'></iframe>
                        </div>",
                                cartTotal));
                    %>

        <asp:Button ID="ButtonRemoveAll" runat="server" Text="Очистить корзину" OnClick="ButtonRemoveAll_Click" />
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
                    SelectMethod="GetCartLinesRoom" runat="server" EnableViewState="false">
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
        <asp:Button ID="ButtonReservation" runat="server" OnClick="ButtonReservation_Click" Text="Забронировать" />
    </div>
</asp:Content>

