<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormMain.aspx.cs" Inherits="HotelBusinessWeb.FormMain" MasterPageFile="~/Hotel.Master" %>

<%@ Register assembly="System.Web.Mvc" namespace="System.Web.Mvc" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server" >
    <div class="content-grid-info" runat="server">
         <div id="content">          
        <div class="content"> 
    <div class="container">                      
            <table id="cartTableService">
                <thead>
                    <tr>
                        <th>
                            <asp:Calendar ID="CalendarFrom" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" ToolTip="Дата не может быть меньше настоящей" Width="350px">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                        </th>
                        <th>
                            <asp:Calendar ID="CalendarBefore" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                <TodayDayStyle BackColor="#CCCCCC" />
                            </asp:Calendar>
                        </th>
                    </tr>
                </thead>
            </table>

            <pre><a id="search" runat="server">Найти</a> <a id="secectNewDate" runat="server" visible="false">Выбрать другие даты</a></pre>

            <pre><asp:Label ID="LabelDate" runat="server" Text=""></asp:Label></pre>
                                       
                    <p id="forms" runat="server" visible="false">
                        <%
                            foreach (HorelBusinessService.ViewModels.FormViewModel form in GetForms())
                            {                                

                                List<string> imList = ImageList(form.Id);
                                
                                Response.Write(String.Format(@"
                                  <div class='item'>  
                                    <div class='row'>"));

                                foreach(var i in imList)
                                {
                                    Response.Write(String.Format(@"<div class='col-md-3 col-sm-4 col-xs-6 thumb'>
                                    <a data-fancybox='gallery{1}' href='{0}'>
                                    <img class='img-responsive' src='{0}' alt=''>
                                    </a>
                                    </div>", i, form.Id));
                                }
                                List<string> serviceName = ServiceNames(form.Id);

                            Response.Write(String.Format(@"
                            </div>
                            <h3>{0}</h3>
                            {1}
                            <h4>{2:c}</h4>
                            <input id='addFormCount{3}' name='addFormCount{3}' type ='number' onkeypress='SupressInput(event)' min ='1' max ={4} value='1' runat = 'server'/>
                            <button name='addForm' type='submit' value='{3}'>
                                Выбрать
                            </button>

                            <a name='OpenFreeService' value='{3}'>
                                Открыть бесплатные услуги данного вида номера
                            </a>
                        </div>",
                                    form.FormName, form.Specifications, form.Price, form.Id, Convert.ToInt32(form.Rooms.Count)));


                                foreach(var i in serviceName)
                                {
                                Response.Write(String.Format(@"
                               <a name='OpenFreeService' value='{1}'>
                                <table>
                                     <tbody>
                                         <tr>
                                            <td>{0}</td>
                                         </tr>
                                     </tbody>
                                </table>
                               </a>", i, form.Id));
                                }
                            }
                    %>
                        <pre><a id="next" runat="server">Далее</a></pre>
                    </p>

                <p id="serv" runat="server" visible="false">
                    <%
                        foreach (HorelBusinessService.ViewModels.ServiceViewModel service in GetServices())
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
                    <pre><a id="last" runat="server">Назад</a></pre>
                </p>
           </div>
         </div>
        </div>
       </div>

<!-- jQuery -->
<script src="/Scripts/jquery-3.3.1.min.js"></script>
<!-- Bootstrap JS -->
<script src="/Scripts/bootstrap.min.js"></script>
<!-- fancyBox JS -->
<script src="/Scripts/jquery.fancybox.min.js"></script>
<script>
$(function() {
    var options = {
        srcNode: 'img',             // grid items
        margin: '15px',             // margin in pixel
        width: '240px',             // grid item width in pixel
        max_width: '',              // dynamic gird item width
        resizable: true,            // re-layout if window resize
        transition: 'all 0.5s ease' // support transition for CSS3
    };
    $('.grid').gridify(options);
});
</script>


<script>
function SupressInput($event)
{
  $event.preventDefault();
}
</script>
    </asp:Content>
