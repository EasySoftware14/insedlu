<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewProposal.aspx.cs" Inherits="Insendlu.ViewProposal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <h1>
                <asp:Label runat="server" CssClass="label-light" ID="projectName"></asp:Label></h1>
            <hr />
            <div class="col-lg-6">
                <asp:Button runat="server" ID="btnScheduling" CssClass="btn btn-block" Text="Scheduling" OnClick="btnScheduling_OnClick"/>
            </div>
            <div class="col-lg-6">
                <asp:Button runat="server" ID="btnProjection" CssClass="btn btn-block btn-danger" Text="Projection" OnClick="btnProjection_OnClick"/>
            </div>
        </div>
        <br />
        <div class="row" id="calenId" runat="server" hidden="hidden">
            <div class="col-lg-12">
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                <asp:TextBox runat="server" ID="cal"></asp:TextBox>
                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="cal" DefaultView="Days" runat="server" />
            </div>
           
        </div>
        
        <div class="row" id="scheduling" Visible="False" runat="server">
            <div class="col-lg-12">
                 <h2>Breakdown Schedule</h2>
                <br />
                <label class="label">Proposal Name</label>
                <input type="text" id="nameOfProject" runat="server" class="form-control" />
                <br />
                <label class="label">Sector</label><br/>
                <asp:DropDownList runat="server" ID="drpSector" Required="Required" DataValueField="id" DataTextField="name" Width="200" CssClass="select2 dropdown-caret-right dropdown-100" />
                <br />
                <br />
                <label class="label">Start Date</label>
                <asp:TextBox runat="server" ID="durationStartDate" CssClass="form-control"></asp:TextBox>
                <br />
                <label class="label">End Date</label>

                <asp:TextBox runat="server" ID="durationEndDate" CssClass="form-control"></asp:TextBox>

                <br />
                <asp:Button runat="server" ID="schedule" CssClass="btn btn-success" Text="Create Scheduling" OnClick="schedule_OnClick" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy hh:mm:ss" TargetControlID="durationStartDate" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Format="dd/MM/yyyy hh:mm:ss" TargetControlID="durationEndDate" />
            </div>
        </div>

        <div class="row" id="projectionSetup" Visible="False" runat="server">
            <div class="col-lg-12">
                
            </div>
        </div>
    </div>
</asp:Content>
