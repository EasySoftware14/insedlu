<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProjectTimeLine.aspx.cs" Inherits="Insendlu.ProjectTimeLine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="Scripts/jquery-3.1.1.min.js"></script>
    <script type="text/javascript">
        function showModal() {
            $("#dateModal").modal({ backdrop: "static", keyboard: false });
        }
    </script>

    <div class="modal fade" id="dateModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <br>
                    <i class="fa fa-credit-card fa-7x"></i>
                    <h4 id="myModalLabel" class="semi-bold"></h4>
                    <br>
                    <p class="no-margin">
                        Driver must be older than 15 and younger than 120.
                    <br />
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal">Close</button>
                </div>
            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
   
    <div class="container-fluid">
        <div class="row">
            <label style="font-size: x-large">Project Time-Line</label>
            <hr />
            <div class="col-md-12">
                <asp:Button runat="server" ID="backToTrack" Text="Back to TrackWork" CssClass="btn btn-primary" OnClick="backToTrack_OnClick"/>
                <br/>
                <br/>
                <asp:Calendar ID="timeline" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" OnSelectionChanged="timeline_OnSelectionChanged" DayNameFormat="Full" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="250px" OnDayRender="timeline_OnDayRender" ShowGridLines="True" ToolTip="Project Time-Line" TitleFormat="Month" Width="1089px">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="lightblue" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="lightGreen" ForeColor="White" />
                </asp:Calendar>
            </div>
            
            <br />

        </div>
        <div class="row">
            <h2>Keys :</h2>
            <br />
            <div class="col-lg-4">
                <table class="table table-bordered">
                    <tr>
                        <td class="" style="font-size: xx-large">Colour</td>
                         <td class="" style="font-size: xx-large"> Asset </td>
                        
                       
                    </tr>
                    <tr>
                        <td style="background-color: aqua"></td>

                         <td class="" style="font-size: x-large">Accommodation</td>
                        
                    </tr>
                    <tr>
                        <td style="background-color: DarkGoldenrod"></td>
                        <td class="" style="font-size: large">Telephone</td>
                        
                        
                    </tr>
                    <tr>
                        <td style="background-color: Aquamarine"></td>
                        <td class="" style="font-size: x-large">Internet</td>
                    </tr>
                    <tr>
                        <td style="background-color: LawnGreen"></td>
                        <td class="" style="font-size: large">Print Material</td>
                    </tr>
                    <tr>
                        <td style="background-color: LightBlue"></td>
                        <td class="" style="font-size: x-large">Refreshments</td>
                    </tr>
                     <tr>
                        <td style="background-color: Chocolate"></td>
                        <td class="" style="font-size: large">Employees</td>
                    </tr>
                    <tr>
                        <td style="background-color: IndianRed"></td>
                        <td class="" style="font-size: x-large">Vehicle</td>
                    </tr>
                </table>
            </div>
            <div class="col-lg-4 col-lg-offset-4">
                <h2 class="label-info"> Notifications</h2>
                
            </div>

        </div>
    </div>
      <%--  <asp:Calendar ID="timelineCalender" runat="server" CssClass="calendar-table" ShowGridLines="True" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" OnDayRender="timeline_OnDayRender" Font-Size="9pt" ForeColor="Black" Height="318px" NextPrevFormat="FullMonth" Width="1080px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>--%>
</asp:Content>

