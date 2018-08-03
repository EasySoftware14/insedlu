<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Submitted.aspx.cs" Inherits="Insendlu.Submitted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-6">
                <h2 class="label-danger">Attach Documents</h2>
                <br />
                <asp:FileUpload runat="server" ID="uploadDocs" AllowMultiple="True" CssClass="fa-upload" />
                <br />
                <br/>
                <asp:LinkButton runat="server" ID="back" CssClass="fa-backward" OnClick="back_OnClick"> Back</asp:LinkButton> |
                <asp:Button runat="server" ID="attachDocs" OnClick="attachDocs_OnClick" CssClass="btn btn-success" Text="Attach Document(s)" />
                <br/>
                <br/>
                <label class="label-success" runat="server" id="success"></label>
            </div>
        </div>
    </div>
</asp:Content>
