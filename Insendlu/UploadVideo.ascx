<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadVideo.ascx.cs" Inherits="Insendlu.UploadVideo" %>

<head>
    <style type="text/css">
        .style1 {
            width: 100%;
        }
    </style>
</head>
<div class="col-xs-11">
    <table class="table table-bordered table-hover">
        <tr>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
        </tr>
        <tr><td><label></label></td></tr>
        <tr>
            <td>
                <asp:Button ID="ButtonUpload" CssClass="glyphicon-cloud-upload" runat="server" OnClick="ButtonUpload_Click" Text="Upload" />
            </td>

        </tr>
    </table>
    <button id="cancelButton" class="btn btn-flat">Back</button>
</div>

