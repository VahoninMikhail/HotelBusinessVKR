<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormReg.aspx.cs" Inherits="HotelBusinessWeb.FormReg" MasterPageFile="~/Hotel.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div class="container">

            <form data-toggle="validator">
                <div class="form-group has-feedback">
                    <label for="input-name" class="sr-only">ФИО</label>
                    <input type="text" class="form-control" id="inputName" runat="server"
                        data-required-error="Поле не заполнено" placeholder="Имя, фамилия" required />
                    <div class="help-block with-errors">Обязательное поле</div>
                </div>
                <div class="form-group has-feedback">
                    <label for="input-email" class="sr-only">Адрес почты</label>
                    <input type="email" class="form-control" id="inputEmail" runat="server"
                        data-required-error="Поле не заполнено" placeholder="Адрес почты" required />
                    <div class="help-block with-errors">Обязательное поле</div>
                </div>
                <div class="form-group has-feedback">
                    <label for="input-tel" class="sr-only">Адрес почты</label>
                    <input type="tel" class="form-control" id="inputTel" runat="server"
                        data-required-error="Поле не заполнено" placeholder="Номер телефона" required />
                    <div class="help-block with-errors">Обязательное поле</div>
                </div>
                <div class="form-group has-feedback">
                    <label for="input-password" class="sr-only">Придумайте пароль</label>
                    <input type="password" class="form-control" id="inputPassword" runat="server"
                        data-required-error="Поле не заполнено" placeholder="Введите пароль" required />
                    <div class="help-block with-errors">Обязательное поле</div>
                </div>
                <div class="form-group has-feedback">
                    <label for="input-confirm" class="sr-only">Пароль еще раз</label>
                    <input type="password" class="form-control" id="inputConfirm" runat="server"
                        data-required-error="Поле не заполнено"
                        data-match-error="Пароли не совпадают"
                        data-match="#inputPassword" placeholder="Подтвердите пароль" required />
                    <div class="help-block with-errors">Обязательное поле</div>
                </div>
                <div class="form-group">
                    <button id="Register" type="submit" class="btn btn-default" runat="server">Регистрация</button>
                </div>
            </form>
      </div>
     </div>
</asp:Content>
