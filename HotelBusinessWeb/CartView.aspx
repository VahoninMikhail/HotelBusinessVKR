<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="HotelBusinessWeb.CartView" MasterPageFile="~/Hotel.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div class="container">
            <h2>Ваша корзина</h2>

               <%   if(GetCartLinesRoom().GetEnumerator().MoveNext() == true)
                   {
                       DateTime ArrDate = GetCartLinesRoom().ElementAt(0).ArrivalDate;
                       DateTime DepDate = GetCartLinesRoom().ElementAt(0).DepartureDate;
                      Response.Write(String.Format(@"<pre><h4>Въезд:{0} Выезд:{1}</h4></pre>", ArrDate, DepDate));
                   }
                %>

            <asp:Button ID="ButtonRemoveAll" runat="server" Text="Очистить корзину" OnClick="ButtonRemoveAll_Click" />  
            <pre>Список номеров:</pre>
            <table class="table table-striped" id="cartTableRoom">                
                <thead class="thead-dark" id="theadTableRoom" runat="server">
                    <tr>
                        <th>Вид номера</th>
                        <th>Стоимость</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="Repeater2" ItemType="HorelBusinessService.ViewModels.RoomOrderViewModel"
                        SelectMethod="GetCartLinesRoom" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <tr>
                                <td><%# Item.FormName %></td>
                                <td><%# Item.Price %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

            <pre>Список услуг:</pre>
            <table class="table table-striped table-dark" id="cartTableService">
                <thead id="theadTableService" runat="server">
                    <tr>
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
            <p class="actionButtons">
                <a href="<%= ReturnUrl %>">Продолжить покупки</a>
            </p>

            <div class="item">
                <pre><h4>Вы можете забронировать номер бесплатно и оплатить на месте любым удобным способом</h4><asp:Button ID="ButtonReservation" runat="server" OnClick="ButtonReservation_Click" Text="Забронировать" /></pre>
                
                <%                      
                    decimal cartTotal = CartTotal;
                    Response.Write(String.Format(@"<pre><code><h4>Или оплатить покупку сразу</h4>
                        <iframe src='https://money.yandex.ru/quickpay/button-widget?targets=%D0%9E%D0%BF%D0%BB%D0%B0%D1%82%D0%B0%20%D0%B7%D0%B0%D0%BA%D0%B0%D0%B7%D0%B0&default-sum={0}&button-text=12&any-card-payment-type=on&button-size=m&button-color=orange&successURL=http%3A%2F%2Flocalhost%3A51229%2FPaymentSuccessful.aspx&quickpay=small&account=4100115194924455&' width='184' height='36' frameborder='0' allowtransparency='false' scrolling='no'></iframe>
                        </code></pre>", cartTotal));
                %>
            </div>
        </div>
    </div>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
    <!-- jQuery -->
<script src="/Scripts/jquery-3.3.1.min.js"></script>
<!-- Bootstrap JS -->
<script src="/Scripts/bootstrap.min.js"></script>
</asp:Content>

