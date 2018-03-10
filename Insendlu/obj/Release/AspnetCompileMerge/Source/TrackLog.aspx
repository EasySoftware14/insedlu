<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackLog.aspx.cs" Inherits="Insendlu.TrackLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        .wrap {
            white-space: normal;
            width: 100px;
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
                
                <h2 class="">Summary </h2>
                <asp:Label runat="server" ID="projectsummary" CssClass="label-pink"></asp:Label>

            </div>
            <br />
        </div>
        <hr />
        <div class="row-fluid">
            <div class="col-sm-6 col-lg-12">
                <div id="logging" runat="server">
                    <br />
                    <h3 style="color: tomato">Choose action below: </h3>
                    <br />
                    <table class="table">

                        <tr>
                            <td>
                                <asp:Button runat="server" ID="proposal" Text="Proposal" OnClick="proposal_OnClick" CssClass="btn btn-success" />
                            </td>
                            <td class="label-light"></td>
                        </tr>
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
                                <asp:Button runat="server" ID="admin" OnClick="admin_OnClick" Text="Supervisor" CssClass="btn btn-danger" />
                            </td>
                            <td class="label-default"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="parameter" OnClick="parameter_OnClick" Text="Parameters" CssClass="btn btn-grey" />
                            </td>
                            <td class="label-pink"></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="log" Text="Track Work" OnClick="log_OnClick" CssClass="btn btn-yellow" />
                            </td>
                            <td class="label-important"></td>
                        </tr>
                    </table>

                    <br />

                </div>


            </div>
        </div>
    </div>


</asp:Content>

