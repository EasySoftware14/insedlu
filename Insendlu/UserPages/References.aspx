<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="References.aspx.cs" Inherits="Insendlu.UserPages.References" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagPrefix="as" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $("#btnUpload").click(function () {
            alert("clicked")
            var files = $("#fileUpload")[0].files;
            alert("files here: ", files);
            if (files.length > 0) {
                alert("In")
                var formData = new FormData();

                for (var i = 0; i < files.length; i++) {
                    formData.append(files[i].name, files[i]);
                }

                $.ajax({
                    url: 'UploadHandler.ashx',
                    method: 'post',
                    data: formData,
                    contentType: false,
                    processDate: false,
                    success: function () {
                        alert("success")
                    },
                    error: function (err) {
                        alert(err.statusText)
                    }
                });
            }

        });
    </script>
    
    <div class="form-group">
        <div class="container">
            <div class="row">
                <br/>
                <h2 class="panel-heading">References</h2>
                <hr/>
                <div class="col-md-10">
<%--                    <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" OnUploadComplete="AjaxFileUpload1_OnUploadComplete" OnUploadStart="AjaxFileUpload1_OnUploadStart" runat="server"  />--%>
                    
                    Select Files: <asp:FileUpload CssClass="upload-icon" runat="server" AllowMultiple="True" ID="fileUpload"/>
                    <br/>
                    <asp:Button runat="server" ID="upload" Text="Upload Files" OnClick="upload_OnClick"/>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
