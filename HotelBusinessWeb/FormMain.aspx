<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormMain.aspx.cs" Inherits="HotelBusinessWeb.FormMain" MasterPageFile="~/Hotel.Master" %>

<%@ Register assembly="System.Web.Mvc" namespace="System.Web.Mvc" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server" >
    <div id="content">
        <div class="content">
            <p>
                Выберите даты:
            </p>
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

            <p><a id="search" runat="server">Найти</a> <a id="secectNewDate" runat="server" visible="false">Выбрать другие даты</a> </p>

            <p>
                <asp:Label ID="LabelDate" runat="server" Text=""></asp:Label>
            </p>


             <asp:Repeater ID="Repeater1" ItemType="System.String"  runat="server" EnableViewState="false">
                <ItemTemplate>
                    <img src="" width="100" height="100"/>
                </ItemTemplate>
             </asp:Repeater >


            <div class="content-grid-info">
                <div class="post-info">
                    <p id="forms" runat="server" visible="false">
                        <%
                            foreach (HorelBusinessService.ViewModels.FormViewModel form in GetForms())
                            {
                                string s = Image(form.Id);
                                Response.Write(String.Format(@"
                        <div class='item'>
                            <img src='{5}' width='100' height='100'/>
                            <h2>{0}</h2>
                            <p>{1}</p>
                            <h4>{2:c}</h4>
                            <input id='addFormCount{3}' name='addFormCount{3}' type ='number' onkeypress='SupressInput(event)' min ='1' max = '{4}' value='1' runat = 'server'/>
                            <button name='addForm' type='submit' value='{3}'>
                                Выбрать
                            </button>
                        </div>",
                                        form.FormName, form.Specifications, form.Price, form.Id, form.Rooms.Count, s));
                            }
                        %>
                        <a id="next" runat="server">Далее</a>
                    </p>
                </div>

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
                    <a id="last" runat="server">Назад</a>
                </p>
            </div>
        </div>
    </div>

<script>
function SupressInput($event)
{
  $event.preventDefault();
}
</script>
    </asp:Content>
