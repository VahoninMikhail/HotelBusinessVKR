<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="HotelBusinessWeb.Account" MasterPageFile="~/Hotel.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
            <h2>Личный кабинет</h2>
            <h2>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </h2>
            <p class="actionButtons">
            
            </p>
        <asp:GridView ID="GridViewOrder" runat="server">
                    </asp:GridView>
        <table id="OrderService">            
            <thead>
                <tr>
                    <th>Номер брони</th>                   
                    <th>ArrivalDate</th>
                    <th>DepartureDate</th>
                    <th>OrderStatus</th>
                    <th>Sum</th>
                </tr>
            </thead>
            <tbody>               
                <asp:Repeater ID="Repeater1" ItemType="HorelBusinessService.ViewModels.OrderViewModel"
                    SelectMethod="GetOrders" runat="server" EnableViewState="false">                    
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Id %></td>
                            <td><%# Item.ArrivalDate%></td>
                            <td><%# Item.DepartureDate%></td>
                            <td><%# Item.OrderStatus%></td>
                            <td><%# Item.Sum%></td> 
                            <td>                                
                                <button type="submit" class="actionButtons" name="save"
                                    value="<%#Item.Id %>">                                
                                    Сохранить в PDF</button>
                                <button type="submit" class="actionButtons" name="GetOrder"
                                    value="<%#Item.Id %>">
                                    Подробно</button>                               
                            </td>                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>      
      </div>
</asp:Content>
