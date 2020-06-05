<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormLogin.aspx.cs" Inherits="HotelBusinessWeb.FormLogin" MasterPageFile="~/Hotel.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
 <div class="container">


<form data-toggle="validator">
    <div class="form-group has-feedback">
        <label for="input-email" class="sr-only">Адрес почты</label>
        <input type="email" class="form-control" id="inputEmail" runat="server"
               data-required-error="Поле не заполнено" placeholder="Адрес почты" required/>
        <div class="help-block with-errors">Обязательное поле</div>
    </div>
    <div class="form-group has-feedback">
        <label for="input-password" class="sr-only">Пароль</label>
        <input type="password" class="form-control" id="inputPassword" runat="server"
               data-required-error="Поле не заполнено" placeholder="Введите пароль" required/>
        <div class="help-block with-errors">Обязательное поле</div>
    </div>
    <div class="form-group">
        <button id="login" type="submit" class="btn btn-default" runat="server">Вход</button>
    </div>
</form>

    </div>
   </div>
</asp:Content>
