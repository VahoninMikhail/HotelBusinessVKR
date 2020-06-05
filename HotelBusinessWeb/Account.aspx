<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="HotelBusinessWeb.Account" MasterPageFile="~/Hotel.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div class="container">  
            <h2>Личный кабинет</h2>
            <h2>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </h2>
           
<div class="modal fade" id="myModal" tabindex="-1" role="dialog">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">×</button>
        <h4 class="modal-title" id="myModalLabel">Подробности заказа</h4>
      </div>
      <div class="modal-body">
          <%
              int orderId;
              if (int.TryParse(Request.Form["GetOrder"], out orderId))
              {
                  foreach(var i in GetOrder(orderId).RoomOrders)
                  {
                      Response.Write(String.Format(@"
                                <table class='table'>
                                     <thead>
                                        <tr>
                                            <th>Номер</th>                   
                                            <th>Стоимость</th>
                                        </tr>
                                     </thead>
                                     <tbody>
                                         <tr>
                                            <td>{0}</td>
                                            <td>{1}</td>
                                         </tr>
                                     </tbody>
                                </table>", i.FormName, i.Price));
                  }
                  foreach(var i in GetOrder(orderId).ServiceOrders)
                  {
                      Response.Write(String.Format(@"
                                <table class='table'>
                                     <thead>
                                        <tr>
                                            <th>Услуга</th>                   
                                            <th>Оплаченные дни</th>
                                            <th>Цена</th>
                                            <th>Сумма</th>
                                        </tr>
                                     </thead>
                                     <tbody>
                                         <tr>
                                            <td>{0}</td>
                                            <td>{1}</td>
                                            <td>{2}</td>
                                            <td>{3}</td>
                                         </tr>
                                     </tbody>
                                </table>", i.ServiceName, i.Count, i.Price, i.Total));
                  }
              }
              if (int.TryParse(Request.Form["Review"], out orderId))
              {
                  Response.Write(String.Format(@"
<div class='input-group'>
                    <pre><label for='input-Text'>ФИО</label></pre>
                    <input type='text' class='form-control' aria-label='Default' name='inputText' id='inputText' aria-describedby='inputGroup-sizing-default'/>

                    <pre><button id='PostReview' name='PostReview' type='submit' value='{0}'>Отправить отзыв</button></pre> </div>", orderId));
              }
              %>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Закрыть</button>
      </div>
    </div>
  </div>
</div>

            <pre>Список Заказов:</pre>
            <a href="#myModal" id="button1" class="btn btn-primary" aria-disabled="true" visible="false" data-toggle="modal" data-target="#myModal">Последняя открытая</a>
        <table class="table" id="OrderService">            
            <thead>
                <tr>
                    <th>Номер брони</th>                   
                    <th>Дата въезда</th>
                    <th>Дата выезда</th>
                    <th>Статус заказа</th>
                    <th>Сумма</th>
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
                                <button name="GetOrder" class="actionButtons" id="GetOrder"
                                    value="<%#Item.Id %>">
                                    Подробно</button>
                                <button name="Review" class="actionButtons" id="Review"
                                    value="<%#Item.Id %>">
                                    Отправить отзыв</button>
                            </td>                           
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>      
      </div>
     </div>

<!--<script runat="server">
     /*   public void Page_Load(Object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ClientScriptManager cs = Page.ClientScript;
                StringBuilder cstext1 = new StringBuilder();

                String csname1 = "PopupScript";
                Type cstype = this.GetType();

                cstext1.Append("<script type=\"text/javascript\"> window.onload = function () {");
                cstext1.Append("var button = document.getElementById('button')");
                cstext1.Append("button.click()");
                cstext1.Append("} </");
                cstext1.Append("script>");
            cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
            ScriptManager.RegisterStartupScript(this, typeof(string), "Error", cstext1.ToString(), true);
        }
    }*/
</script> -->

    <script type="text/javascript">
    window.onload = function () {
        var button = document.getElementById('button1');        
        button.click();
    };
</script>
</asp:Content>
