<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatusUpdate.aspx.cs" Inherits="Insendlu.StatusUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" id="changestatusContainer">
        <div class="row">
            <div class="col-lg-12">
                <h1>Update Status for Proposal: <asp:Label runat="server" ID="proposal"></asp:Label></h1>
                <hr/>
                <label>Status: </label> <label id="currentStats" runat="server"></label>
                <asp:DropDownList runat="server" DataTextField="name" DataValueField="id" ID="statusDropdown" CssClass="dropdown-caret"/>
                <br/>
                <br/>
                 <asp:Label runat="server" ID="statusLabel" Visible="False"></asp:Label>
                <br/>
                <br/>
                <asp:LinkButton runat="server" ID="back" CssClass="btn-link-2" OnClick="back_OnClick"><< Back</asp:LinkButton> |
                <asp:Button runat="server" ID="changeStatus" OnClick="changeStatus_OnClick" CssClass="btn btn-success" Text="Update Status"/>
            </div>
        </div>
    </div>
</asp:Content>
