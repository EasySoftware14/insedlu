<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TaskUpdate.aspx.cs" Inherits="Insendlu.TaskUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="changestatusContainer">
        <div class="row">
            <h1>Update Task Status </h1>
            <hr />
            <div class="col-lg-8">
                <label>Task</label>
                <asp:DropDownList runat="server" ID="tasks" AutoPostBack="True" OnSelectedIndexChanged="tasks_OnSelectedIndexChanged" DataTextField="body" DataValueField="id" CssClass="dropdown-caret" />
            </div>
            <div class="col-lg-4">
                <label>Status: </label>
                <label id="currentStats" runat="server"></label>
                <asp:DropDownList runat="server" ID="statusDropdown" CssClass="dropdown-caret" />
            </div>

        </div>
        <div class="row">
            <br/>
            <div class="col-lg-2 col-lg-offset-5">
                <asp:Label runat="server" ID="statusLabel" Visible="False"></asp:Label>
                <asp:Button runat="server" ID="changeStatus" OnClick="changeStatus_OnClick" CssClass="btn btn-success" Text="Update Status" />
                <br/>
                <br/>
                &nbsp;&nbsp; <asp:LinkButton runat="server" ID="back" CssClass="btn btn-primary" OnClick="back_OnClick"> Dashboard</asp:LinkButton>               
                   
            </div>
        </div>
    </div>



</asp:Content>
