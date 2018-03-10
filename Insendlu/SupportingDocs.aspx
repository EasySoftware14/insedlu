<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupportingDocs.aspx.cs" Inherits="Insendlu.SupportingDocs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h1>More Info For Proposal Name: <span id="propposalName" runat="server" style="color: green"></span></h1>
            <hr />
            <div class="col-sm-6 col-md-6">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <a class="panel-default" data-toggle="collapse" data-parent="#accordion1" href="#collapseOne">
                            <div class="panel-heading">
                                <h3 class="panel-title">Comments</h3>
                            </div>
                        </a>
                        <div id="collapseOne" class="panel-collapse collapse">
                            <div class="panel-body">
                                <h4 style="text-align: center" class="label-holder fa-commenting"> Add Comment</h4>
                                <hr />
                                <asp:TextBox runat="server" Width="500" Height="200" TextMode="MultiLine" ID="propComment" CssClass="form-control"></asp:TextBox>
                                <hr />
                                <div class="pull_right">
                                    <asp:Button runat="server" ID="comments" CssClass="col-lg-push-4 btn btn-success" OnClick="comments_OnClick" Text="Add Comment" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-6 col-md-6 col-md-offset-0">
                <div class="panel-group">
                    <div class="panel panel-info">
                        <a class="panel-info" data-toggle="collapse" data-parent="#accordion1" href="#collapseTwo">
                            <div class="panel-heading">
                                <h3 class="panel-title">Attachments </h3>
                            </div>
                        </a>
                        <div id="collapseTwo" class="panel-collapse collapse">
                            <div class="panel-body">
                                <h3 style="text-align: center">Adding Attachments</h3>
                                <hr />
                                <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" AllowedFileTypes="doc,docx,pdf,xls,xlsx" OnUploadComplete="AjaxFileUpload1_OnUploadComplete" runat="server" />
                               <%-- <asp:FileUpload runat="server" AllowMultiple="True" ID="upload" CssClass="dz-upload" />
                                <hr />
                                <asp:Button runat="server" ID="attachments" OnClick="attachments_OnClick" CssClass="col-lg-push-4  btn btn-default" Text="Add Attachments" />--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-5 col-md-6">
                <div class="panel-group">
                    <div class="panel panel-danger">
                        <a class="panel-danger" data-toggle="collapse" data-parent="#accordion1" href="#collapseThree">
                            <div class="panel-heading">
                                <h3 class="panel-title">Tag</h3>
                            </div>
                        </a>
                        <div id="collapseThree" class="panel-collapse collapse">
                            <div class="panel-body">
                                <h4 style="text-align: center">Tag Individuals </h4>
                                <hr />
                                <table class="table table-striped">
                                    <tr>
                                        <td>
                                            <label>Select Users to tag</label>
                                        </td>
                                        <td>
                                            <asp:ListBox runat="server" ToolTip="Hold down CTRL key to select more than one user" Width="200" CssClass="list-group-item" ID="userList" SelectionMode="Multiple" DataValueField="id" DataTextField="name" />

                                        </td>
                                    </tr>
                                </table>
                                <hr />
                                <asp:Button runat="server" OnClick="tagging_OnClick" ID="tagging" CssClass="col-lg-push-5 btn btn-info" Text="Tag" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
