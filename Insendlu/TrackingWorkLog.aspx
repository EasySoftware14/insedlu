<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrackingWorkLog.aspx.cs" Inherits="Insendlu.TrackingWorkLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1> Tracking Work</h1>
                <hr />
                <div id="buttons" runat="server">
                    
                </div>
            </div>
            <hr />  
        </div>
         <div class="row-fluid">
            <div class="col-sm-6 col-lg-12">
                <asp:Label runat="server" Visible="False" CssClass="label-danger" ID="lblInfo" Text="Sorry there is no Work Log currently, please start to add work."></asp:Label>
                <div id="logging" runat="server">
                    <br />
                    <h3 style="color:tomato"> Choose action below for: <label runat="server" id="lblProjectName"></label></h3>
                    <br />
                    <table class="table">

                        <tr>
                            <td>
                                <asp:Button runat="server" ID="proposal" Text="Proposal" OnClick="proposal_OnClick" CssClass="btn btn-success" />
                            </td>
                            <td class="label-light"><asp:Label runat="server" ID="proposalMore"> More on Proposal or Project</asp:Label> </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="docs" Text="Documents" OnClick="docs_OnClick" CssClass="btn btn-pink" />
                            </td>
                             <td class="label-purple"><asp:Label runat="server" ID="documents"> See Documents related to a Project</asp:Label> See Documents related to a Project</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="timeline" OnClick="timeline_OnClick" Text="Project Time-Line" CssClass="btn btn-primary" />
                            </td>
                             <td class="label-info"> <asp:Label runat="server" ID="timelineProj"> This is Time Line as to how far has the Project gone</asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="admin" OnClick="admin_OnClick" Text="Supervisor" CssClass="btn btn-danger" />
                            </td>
                             <td class="label-default"><asp:Label runat="server" ID="projAdmin"> More info about the Project Administrator</asp:Label> </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="parameter" OnClick="parameter_OnClick" Text="Parameters" CssClass="btn btn-grey" />
                            </td>
                             <td class="label-pink"><asp:Label runat="server" ID="projParameter"> Parameter as the Project</asp:Label>  </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" ID="log" Text="Track Work" OnClick="log_OnClick" CssClass="btn btn-yellow" />
                            </td>
                            <td class="label-important"> <asp:Label runat="server" ID="trackWorklog"> This is a Working Log Normal Interface</asp:Label> </td>
                        </tr>
                    </table>

                    <br />

                </div>


            </div>
        </div>
    </div>
</asp:Content>
