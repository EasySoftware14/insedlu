<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsedluBcc.aspx.cs" Inherits="Insendlu.InsedluBcc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
        <div class="row">
            <h1 class="">Insedlu BCC</h1>
            <hr />
            <div class="col-md-12">
                <asp:Calendar ID="bcc" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" OnSelectionChanged="bcc_OnSelectionChanged" DayNameFormat="Full" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="250px" OnDayRender="bcc_OnDayRender" ShowGridLines="True" ToolTip="Project Time-Line" TitleFormat="Month" Width="1089px">
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
    </div>

</asp:Content>
