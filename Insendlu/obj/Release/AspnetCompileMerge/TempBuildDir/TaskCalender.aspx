<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskCalender.aspx.cs" Inherits="Insendlu.TaskCalender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
            <div class="col-md-12">
                <label style="font-size: x-large"> Tasks Calendar</label>
            </div>
        </div>
        <div class="row">
            
            <hr />
            <div class="col-md-12">
                <h1> Task Calender</h1>
                <asp:Calendar ID="taskCalender" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" BorderWidth="1px" OnSelectionChanged="taskCalender_OnSelectionChanged" DayNameFormat="Full" Font-Names="Verdana" Font-Size="8pt" ForeColor="#663399" Height="500px" OnDayRender="taskCalender_OnDayRender" ShowGridLines="True" ToolTip="Tasks" TitleFormat="Month" Width="1189px">
                    <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="5px" />
                    <NextPrevStyle Font-Size="9pt" ForeColor="lightblue" />
                    <OtherMonthDayStyle ForeColor="#CC9966" />
                    <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                    <SelectorStyle BackColor="#FFCC66" />
                    <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" />
                    <TodayDayStyle BackColor="#339933" ForeColor="White" />
                </asp:Calendar>
            </div>
            
            <br />

        </div>
</asp:Content>
