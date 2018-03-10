<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Consultancy.aspx.cs" Inherits="Insendlu.UserPages.Consultancy" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HtmlEditor" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2 class=""> Consultancy </h2><br/>
                <hr/>
                 <cc1:Editor ID="consultancy" Content="" runat="server" Width="900" Height="300"></cc1:Editor>
                <br/>
                 <asp:Label runat="server" ID="lblSuccess" Visible="False"></asp:Label>
                <br/>
                <br/>
                <asp:LinkButton runat="server" ID="back" CssClass="btn-link-2" Text=" Back" OnClick="cancel_OnClick"></asp:LinkButton> |
                <asp:Button runat="server" ID="submit" Text="Save" OnClick="submit_OnClick" CssClass="btn btn-success"/>
            </div>
        </div>
    </div>
</asp:Content>
