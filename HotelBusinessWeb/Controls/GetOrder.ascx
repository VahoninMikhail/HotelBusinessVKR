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

    <%
                        foreach (HorelBusinessService.ViewModels.ServiceViewModel service in getOrder())
                        {
                            Response.Write(String.Format(@"
                        <div class='item'>
                            <h3>{0}</h3>
                            {1}
                            <h4>{2:c}</h4>
                            <input id='addServiceCount{3}' name='addServiceCount{3}' type ='number' onkeypress='SupressInput(event)' min ='1' value='1' runat = 'server'/>
                            <button name='addService' type='submit' value='{3}'>
                                Выбрать
                            </button>
                        </div>",
                                service.ServiceName, service.ServiceSpecification, service.Price, service.Id));
                        }
                    %>
</div>