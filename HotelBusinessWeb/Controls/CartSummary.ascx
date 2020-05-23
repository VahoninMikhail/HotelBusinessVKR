<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CartSummary.ascx.cs" Inherits="HotelBusinessWeb.Controls.CartSummary" %>

<div id="cartSummary">
    <span class="caption" EnableViewState="false">
        <b>В корзине:</b>
        <span id="csQuantity" runat="server"></span> услуг(и),
        <span id="csRoomQuantity" runat="server"></span> комнат(ы),
        <span id="csTotal" runat="server"></span>
    </span>
    <a id="csLink" runat="server">Корзина</a>
    <a id="removeAll" runat="server">Очистить корзину</a>
</div>