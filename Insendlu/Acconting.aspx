<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Acconting.aspx.cs" Inherits="Insendlu.Acconting" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit.HtmlEditor" Assembly="AjaxControlToolkit, Version=16.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function uploadFinished() {
            alert("Upload Finished");
        }
        function uploadError() {
            alert("Upload Failed, please try again");
        }
    </script>
     <br/>
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <h1> Accounting Documents</h1><br/>
                <hr/>
                <h3 class="label-info" style="text-align: center; background-color: blanchedalmond "> Click below to upload documents</h3>
                <br/>
                <ajaxToolkit:AjaxFileUpload ID="accountingFiles" OnUploadComplete="accountingFiles_OnUploadComplete" ClearFileListAfterUpload="True" OnClientUploadError="uploadError"  OnClientUploadComplete="uploadFinished" AutoStartUpload="False" Mode="Auto" AllowedFileTypes="xls,xlsx" CssClass="ace ace-file-multiple" runat="server" />
                <br/>
               <span class="align-left"> <asp:LinkButton runat="server" ID="cancel" CssClass="btn btn-link-2 align-left" Text="Back" OnClick="cancel_OnClick"></asp:LinkButton>
                   <i class="fa-external-link-square"></i>
               </span>
                
            </div>
        </div>
    </div>
</asp:Content>
