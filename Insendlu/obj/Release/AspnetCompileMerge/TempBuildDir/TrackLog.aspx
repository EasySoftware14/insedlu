<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackLog.aspx.cs" Inherits="Insendlu.TrackLog" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=18.1.0.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .wrap {
            white-space: normal;
            width: 100px;
        }
    </style>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #0DA9D0;
            padding: 0;
        }
        .modalPopup .header
        {
            background-color: #2FBDF1;
            height: 30px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .body
        {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
            margin-bottom: 5px;
        }
    </style>
    <div class="container-fluid">
        <div class="row-fluid">
            <h1 class="">Tracking Work Log</h1>
            <hr />
            <div class="col-lg-8 col-md-offset-2">

                <asp:Button runat="server" ID="projName" Height="200" ForeColor="tomato" OnClick="projName_OnClick" Width="650" CssClass="wrap" />

                <%--<label class="fa fa-file" for="projects"> <span style="font-size: x-large;color: darkolivegreen"> Choose Project</span></label>
                <br/>
                <asp:DropDownList runat="server" AutoPostBack="True" ID="projects" OnTextChanged="projects_OnTextChanged" CssClass="dropdown-caret-right" OnSelectedIndexChanged="projects_OnSelectedIndexChanged" DataValueField="id" DataTextField="name"/>
                <ajaxToolkit:DropDownExtender ID="DropDownExtender1"  runat="server" TargetControlID="projects"></ajaxToolkit:DropDownExtender>--%>
            </div>
            <div class="col-lg-2">
                
                <h2 class=""> Summary </h2>
                <asp:Label runat="server" ID="projectsummary" CssClass="label-pink"></asp:Label>

            </div>
            <br />
        </div>
        <hr />
        <div class="row-fluid">
            <div class="col-sm-6 col-lg-12">
                
                <cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
                                        PopupControlID="pnlPopup" TargetControlID="admin" BackgroundCssClass="modalBackground" CancelControlID="btnHide">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup panel-default" Style="display: none;width: 350px;">
                    <div class="panel-heading">
                        Project Members / Supervisors 
                    </div>
                    <div class="panel-body">
                        <h3><asp:Label runat="server" ID="membersList"></asp:Label></h3>
                        <br/>
                        <asp:Button runat="server" ID="btnHide" CssClass="btn btn-danger" Text="Close"/>
                    </div>
                </asp:Panel>

                <div id="logging" runat="server">
                    <br />
                    <h3 style="color: tomato"> Choose action below: </h3>
                    <br />
                    <table class="table">
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="docs" Text="Documents" OnClick="docs_OnClick" CssClass="btn btn-pink" />
                            </td>
                            <td class="label-purple"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="timeline" OnClick="timeline_OnClick" Text="Project Time-Line" CssClass="btn btn-primary" />
                            </td>
                            <td class="label-info"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="admin" OnClick="admin_OnClick" Text="Members" CssClass="btn btn-danger" />
                            </td>
                            <td class="label-default"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="parameter" OnClick="parameter_OnClick" Text="Parameters" CssClass="btn btn-grey" />
                            </td>
                            <td class="label-pink"></td>
                        </tr>
                       <%-- <tr>
                            <td>
                                <asp:Button runat="server" ID="log" Text="Track Work" OnClick="log_OnClick" CssClass="btn btn-yellow" />
                            </td>
                            <td class="label-important"></td>
                        </tr>--%>
                    </table>

                    <br />

                </div>
            </div>
        </div>
    </div>
</asp:Content>

