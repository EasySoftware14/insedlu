<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewProposal.aspx.cs" Inherits="Insendlu.UserPages.ViewProposal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <h1>
                <asp:Label runat="server" CssClass="label-light" ID="projectName"></asp:Label></h1>
            <hr />
            <div class="col-lg-6">

                <h2>Breakdown Schedule</h2>
                <br />
                <label class="label">Proposal Name</label>
                <input type="text" id="nameOfProject" runat="server" class="form-control" />
                <%--                <asp:TextBox runat="server" ID="nameOfProject" ReadOnly="True" CssClass="form-control"></asp:TextBox>--%>
                <br />
                <label class="label">Department</label>
                <input type="text" id="department" runat="server" class="form-control" />

                <%--                <asp:TextBox runat="server" ID="department" ReadOnly="True" CssClass="form-control"></asp:TextBox>--%>
                <br />
                <label class="label">Duration</label>
                <input type="text" id="duration" runat="server" class="form-control" />

                <%--                <asp:TextBox runat="server" ID="duration" CssClass="form-control"></asp:TextBox>--%>

                <br />
                <asp:Button runat="server" ID="schedule" CssClass="btn btn-success" Text="Create Scheduling" OnClick="schedule_OnClick" />
                <%--                <button id="schedule" class="btn btn-success">Create Schedule</button>--%>
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
    </div>
</asp:Content>
