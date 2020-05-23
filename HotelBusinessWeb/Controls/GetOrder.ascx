<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GetOrder.ascx.cs" Inherits="HotelBusinessWeb.Controls.GetOrder" %>

<div id="getOrder">
    <asp:Repeater ID="Repeater1" ItemType="HorelBusinessService.ViewModels.OrderViewModel"
                    SelectMethod="getOrder" runat="server" EnableViewState="false">
        <ItemTemplate>
           Бронь № <%# Item.Id %>
           Дата въезда <%# Item.ArrivalDate %>
           Дата выезда <%# Item.DepartureDate %>
           Статус заказа <%# Item.OrderStatus %>
            <table id="OrderService">
            <thead>
                <tr>
                    
                </tr>
            </thead>
            <tbody>
                <tr>
                    <%#Item.ServiceOrders%>                   
                </tr>
                <tr>
                    <%#Item.RoomOrders%>
                </tr>
            </tbody>
        </table>
        </ItemTemplate>
    </asp:Repeater>
</div>