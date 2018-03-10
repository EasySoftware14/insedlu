<%@ Page Language="C#" MasterPageFile="Site.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Insendlu.Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HtmlEditor" TagPrefix="cc1" %>
<%@ Register Src="UploadVideo.ascx" TagName="UploadVideo" TagPrefix="uc1" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server" ID="profile">

    <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }
    </style>
    <script type="text/javascript">
        function showTasksModal() {
            $("#tasksModalPopup").modal({ backdrop: "static", keyboard: false });
        }
    </script>
    <div class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" id="myModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancel" href="#" aria-hidden="true">×</a>
                    <br>
                    <i class="fa fa-exclamation-triangle fa-7x"></i>
                    <h4 class="semi-bold">Are you sure you want to Decline / Reject application for
                                                        <br />
                        Me</h4>
                    <h4 class="semi-bold" style="color: #f35958">Note: This application will be deleted.</h4>
                    <br>
                </div>
                <div class="modal-footer">
                    <a href="#" class=" btn btn-info">Close</a>
                    <a href="#" class="btn btn-success">Confirm</a>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" id="slideShow">
        <div class="modal-dialog" style="width: 850px">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancel" href="#" aria-hidden="true">×</a>
                    <h2 class="semi-bold">Insedlu Companion-pulse Slide Show</h2>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_OnTick"></asp:Timer>
                            <asp:Image runat="server" Height="300" Width="800" ID="imageSlide" />
                        </ContentTemplate>

                    </asp:UpdatePanel>

                </div>
                <div class="modal-footer">
                    <a href="#" data-dismiss="modal" class="btn btn-info">Close</a>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" tabindex="-1" runat="server" aria-labelledby="myModalLabel" aria-hidden="true" id="userSuccess">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancel" href="#" aria-hidden="true">×</a>
                    <br>
                    <i class="fa fa-exclamation-triangle fa-7x"></i>
                    <h4 class="semi-bold">Are you sure you want to Decline / Reject application for
                                                        <br />
                        Me</h4>
                    <h4 class="semi-bold" style="color: #f35958">Note: This application will be deleted.</h4>
                    <br>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" id="taskModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancelButton" href="#" aria-hidden="true">×</a>
                    <br>
                    <h4 class="semi-bold"> Adding Task</h4>
                    <br>
                </div>
                <div class="modal-body">
                    <label>Tasks</label>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="taskForTheDay" CssClass="form-control" Height="100"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button runat="server" ID="addTask" CssClass="btn-block" OnClick="addTask_OnClick" Text="Add Task" />
                    <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" id="tasksModalPopup">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancelButton" data-dismiss="modal" aria-hidden="true">×</a>
                    <br>
                    <h4 class="semi-bold"><i class="fa fa-bars" aria-hidden="true"></i> My Task(s)</h4>
                    <br>
                </div>
                <div class="modal-body">
                    <label>Tasks</label>
                    <br />
                    <asp:TextBox TextMode="MultiLine" Height="200" Enabled="False" CssClass="form-control" runat="server" ID="myTasksList"></asp:TextBox>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" id="assignTaskModalPopup">
        <div class="modal-dialog" style="width: 850px">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancelButton" data-dismiss="modal" aria-hidden="true">×</a>
                    <br>
                    <h4 class="semi-bold"><i class="fa fa-bars" aria-hidden="true"></i> Assigning Task</h4>
                    <br>
                </div>
                <div class="modal-body">
                    <table>
                        <tr>
                            <td>
                                <label>Tasks</label></td>
                            <td>Assignee</td>
                        </tr>
                        <tr>

                            <td>
                                <div>
                                    <asp:ListBox runat="server" ID="tasks" DataTextField="body" DataValueField="id" SelectionMode="Single" Height="300" />
                                </div>

                            </td>
                            <td>
                                <div>
                                    <asp:ListBox runat="server" Height="300" Width="200px" CssClass="list-group-item" ID="userList" SelectionMode="Single" DataValueField="id" DataTextField="name" />
                                </div>

                            </td>
                        </tr>
                    </table>

                    <br />

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                    <asp:Button runat="server" ID="assignTask" CssClass="btn btn-success" OnClick="assignTask_OnClick" Text="Assign" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" id="assignedModalPopup">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancelButton" data-dismiss="modal" aria-hidden="true">×</a>
                    <br>
                    <h4 class="semi-bold"><i class="fa fa-bars" aria-hidden="true"></i> Assigned Task(s)</h4>
                    <br>
                </div>
                <div class="modal-body">
                    <table>
                        <tr>
                            <td>
                                <asp:ListBox runat="server" Width="550px" visible="False" SelectionMode="Single" ID="lstAssignedTasks" />
                            </td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="lblWarning" CssClass="warning" Visible="false"> No task currently assigned</asp:Label>
                    <br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" id="createdAssignedModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancelButton" data-dismiss="modal" aria-hidden="true">×</a>
                    <br>
                    <h4 class="semi-bold"><i class="fa fa-bars" aria-hidden="true"></i> Task(s) in Progress</h4>
                    <br>
                </div>
                <div class="modal-body">
                    <table>
                        <tr>
                            <td>
                                <asp:ListBox runat="server" Width="550px" Visible="False" CssClass="list-group-item" ID="inProgress" DataValueField="id" DataTextField="body" />
                            </td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="lblNoTask" CssClass="warning" Visible="false"> No task currently in progress</asp:Label>
                    <br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" id="statusUpdateModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancelButton" data-dismiss="modal" aria-hidden="true">×</a>
                    <br>
                    <h4 class="semi-bold"><i class="fa fa-bars" aria-hidden="true"></i> Update Task</h4>
                    <br>
                </div>
                <div class="modal-body">
                    <label>Task</label>
                    <asp:DropDownList runat="server" ID="tasksToUpdate" DataTextField="body" DataValueField="id" CssClass="dropdown-caret" />
                    <label>Status: </label>
                    <label id="currentStats" runat="server"></label>
                    <asp:DropDownList runat="server" ID="statusDropdown" CssClass="dropdown-caret" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button runat="server" ID="changeStatus" OnClick="changeStatus_OnClick" CssClass="btn btn-success" Text="Update Status" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" tabindex="-1" aria-labelledby="myModalLabel" aria-hidden="true" id="completedTaskModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancelButton" data-dismiss="modal" aria-hidden="true">×</a>
                    <br>
                    <h4 class="semi-bold"><i class="fa fa-bars" aria-hidden="true"></i> Completed Taks(s)</h4>
                    <br>
                </div>
                <div class="modal-body">
                    <table>
                        <tr>
                            <td>
                                <asp:ListBox runat="server" Width="550px" Visible="False" CssClass="list-group-item" ID="completedTasks" DataValueField="id" DataTextField="body" />
                            </td>
                        </tr>
                    </table>
                    <asp:Label runat="server" ID="noComplete" CssClass="warning" Visible="false"> No task currently completed</asp:Label>
                    <br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="projectModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <a class="close" id="cancelButton" data-dismiss="modal" aria-hidden="true">×</a>
                    <br>
                    <h4 class="semi-bold fa-tasks"> Add Task</h4>

                </div>
                <div class="modal-body">
                    <label for="taskDesciption">Description</label>
                    <asp:TextBox runat="server" TextMode="MultiLine" Height="100" ID="taskDesciption" Required="Required" CssClass="form-control"></asp:TextBox>
                    <br>
                    <label for="attachment">Attachment</label>
                    <asp:FileUpload runat="server" CssClass="attachment" AllowMultiple="True" ID="attachments" />
                    <br />
                    <label for="dueDate">Due Date</label>
                    <asp:TextBox ID="dueDate" CssClass="form-control" ReadOnly="False" runat="server" required="required" />
                    <ajaxToolkit:CalendarExtender ID="dueDateExtender" Animated="True" Format="dd/MM/yyyy" runat="server" TargetControlID="dueDate" />

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                    <asp:Button ID="taskAdding" CssClass="btn btn-success" runat="server" OnClick="addTask_OnClick" Text="Add Task"></asp:Button>

                </div>

            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <br />
            <div class="page-header text-center">
                <span class="width-80 line-height-125 label label-xlg label-inverse arrowed-in arrowed-in-right">Dashboard</span>

            </div>

        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-3">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4>To Do</h4>
                    </div>
                    <br />
                    <div class="panel-footer clearfix">
                        <div class="pull-left">
                            <button id="btnModalPopup" class="btn btn-primary">Add</button>
                            <button id="assignModalPopup" class="btn btn-primary">Assign</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-warning">
                    <div class="panel-heading">
                        <h4><i class="fa fa-bars" aria-hidden="true"></i>&nbsp;My Task</h4>
                    </div>
                    <br />
                    <div class="panel-footer clearfix">
                        <div class="pull-left">
                            <button id="myTodayTasks" class="btn btn-success">My Tasks</button>
                            <button id="assignedTasks" class="btn btn-info">Assigned</button>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <ul class="fa-ul">
                            <li>
                                <h4><i class="fa-li fa fa-spinner fa-spin"></i>In Progress</h4>
                            </li>
                        </ul>
                    </div>
                    <br />
                    <div class="panel-footer clearfix">
                        <div class="pull-left">
                            <button id="createdAssigned" class="btn btn-primary">Started</button>
                            <button id="statusUpdate" class="btn btn-primary">Update Status</button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-3">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <ul class="fa-ul">
                            <li><i class="fa-li fa fa-check-square"></i>
                                <h4>Done</h4>
                            </li>
                        </ul>
                    </div>
                    <br />
                    <div class="panel-footer clearfix">
                        <div class="pull-left">
                            <button id="completedTasksBtn" class="btn btn-primary">Completed Tasks</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div class="row">

            <div class="col-lg-4" hidden="">
                <h1 style="color: lightgreen; text-decoration: indianred; font-family: sans-serif" hidden="">What To Do ?</h1>
                <hr />



                <table class="table table-hover" hidden="">
                    <tr>
                        <th>My Tasks</th>
                        <th>Others Tasks</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton runat="server" Text="My Task" Visible="False" ID="myTask" OnClick="myTask_OnClick" CssClass="btn btn-link"></asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" ID="otherTasks" Visible="False" OnClientClick="showTasksModal();" CssClass="btn-link"></asp:LinkButton></td>

                    </tr>
                </table>

                <button id="taskModalBtn" class="btn-block">Add Task</button>
            </div>
            <div class="col-lg-4 col-lg-offset-1" hidden="">
                <h1 class="" style="color: lightblue">Companion Profile</h1>
                <hr />
                <div id="user-profile-1" class="user-profile row">
                    <div class="col-xs-12 col-sm-3 center">
                        <div>
                            <%--<span class="profile-picture">--%>
                            <table class="table-hover">
                                <tr>
                                    <td class="no-margin">
                                        <h4>
                                            <asp:Label runat="server" Font-Bold="True" ID="lblName"></asp:Label></h4>
                                    </td>

                                </tr>
                                <tr>

                                    <td class="">

                                        <asp:HyperLink runat="server" CssClass="nav-user-photo" ImageHeight="250" ImageWidth="300" NavigateUrl="UserProfilesEdit.aspx" ID="image"></asp:HyperLink>
                                        <%--<img src="assets/images/avatars/avatar.png" height="150" width="200" id="image" runat="server" alt="profile picture"/>--%>
                                    </td>

                                </tr>


                            </table>


                            <%-- </span>--%>
                            <div class="profile-info-value">
                            </div>
                            <%--<div class="space-4"></div>--%>
                        </div>

                    </div>

                    <%--  <div class="col-xs-12 col-sm-9">--%>


                    <%--<div class="space-20"></div>
                    <div class="space-6"></div>--%>
                    <%--</div>--%>
                </div>
            </div>
        </div>
        <%--<br />--%>
        <div class="row">
            <div class="col-lg-12">
                <h1 style="color: olive; font-style: normal; font-family: sans-serif; text-align: center;">Companion Treadmills</h1>
                <hr />

                <asp:Panel ID="PnlMain" Visible="False" CssClass="modalPopup" align="center" Style="display: none" runat="server">


                    <label>Testing Pop Up</label>
                </asp:Panel>
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="PnlMain" PopupControlID="PnlMain" BackgroundCssClass="modalBackground" runat="server"></ajaxToolkit:ModalPopupExtender>
                <div>
                    <asp:GridView runat="server" Visible="True" ID="datagridview" CssClass="table table-bordered table-hover" AllowPaging="True"
                        CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#003300" BorderStyle="Solid"
                        BorderWidth="1px" Font-Size="11pt" PageSize="5" Font-Names="Century" OnPageIndexChanging="datagridview_PageIndexChanging"
                        OnRowCommand="datagridview_RowCommand" AutoGenerateColumns="False" OnRowEditing="datagridview_OnRowEditing" DataKeyNames="id">
                        <RowStyle BackColor="#EFF3FB" BorderColor="Black" BorderWidth="1px" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <EditRowStyle BackColor="#2461BF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                        <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                        <Columns>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:Label runat="server" Visible="False" ID="lblId" Text='<%# Eval("id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblProjName" Text='<%# Eval("name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Created Date">
                                <ItemTemplate>
                                    <asp:Label runat="server" ID="lblDate" Text='<%# Eval("created_at", "{0:D}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ButtonField ButtonType="Button" Text="TimeLine" CommandName="timeline"
                                ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                            <asp:ButtonField ButtonType="Button" Text="Chattels" CommandName="asset"
                                ControlStyle-BackColor="#507CD2" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                        </Columns>
                    </asp:GridView>
                </div>


            </div>
        </div>
    </div>

    <div class="container" id="default">


        <%--        <div class="row">
            <br />
            <div class="col-md-4">
                <button type="button" id="basicInfo" style="height: 150px; width: 150px" class="btn btn-info" data-toggle="collapse" data-target="#demo">Companion Profile</button>
            </div>
            <div class="col-md-4">
                <button type="button" id="learn" style="height: 150px; width: 150px" class="btn btn-success" data-toggle="collapse" data-target="#demo1">Learn & Support</button>
            </div>
            <%--<div class="col-md-3">
                <button type="button" id="library" style="height: 150px; width: 150px" class="btn btn-pink" data-toggle="collapse" data-target="#demo2">Approved Props</button>
            </div>--%>
        <%--<div class="col-md-4">
                <button type="button" id="MyTasks" style="height: 150px; width: 150px" class="btn btn-pink" data-toggle="collapse" data-target="#demo3">My Tasks</button>
            </div>
        </div>--%>

        <div class="row-fluid">
            <div id="demo" class="collapse">
                <br />
                <br />

            </div>

            <div class="collapse" id="demo1">
                <div class="col-md-3 col-md-offset-4">
                    <br />
                    <button type="button" class="btn btn-app" id="tut">Tutorial</button>
                    <button type="button" class="btn btn-app" id="guide">User Guide</button>
                    <button type="button" class="btn btn-app" id="story">Tell A Story</button>
                </div>
            </div>
            <div class="collapse" id="demo2">
                <div class="col-md-3 col-md-offset-4">
                    <br />
                    &nbsp;&nbsp;
                    <button type="button" id="research" class="btn btn-app">Action</button>
                    <%--                    <button type="button" id="consult" class="btn btn-app">Consultancy</button>--%>
                    <%-- <asp:Button runat="server" ID="viewTask" OnClick="viewTask_OnClick" Text="View Task" />--%>
                </div>
            </div>

            <%--<div class="collapse" id="demo3">
                <div class="col-md-3 col-md-offset-8">
                    <br />
                    &nbsp;&nbsp;
                    <button type="button" id="tasks" class="btn btn-app">Add Tasks</button>
                    <button type="button" id="viewtasks" class="btn btn-app red2">View Tasks</button>
                    <%-- <asp:Button runat="server" ID="viewTask" OnClick="viewTask_OnClick" Text="View Task" />--%>
            <%--  </div>
            </div>--%>
        </div>
        <div class="row">
            <%-- <div class="col-lg-12" id="map" style="height: 400px; width: 95%">
                <script>
                    function initMap() {
                        var uluru = { lat: -25.363, lng: 131.044 };
                        var map = new google.maps.Map(document.getElementById('map'), {
                            zoom: 4,
                            center: uluru
                        });
                        var marker = new google.maps.Marker({
                            position: uluru,
                            map: map
                        });
                    }
                </script>
                <script async defer
                    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB-2qxYU0MlEWXAiFweKL_Yj83dOpa51WM &callback=initMap">
                </script>
            </div>--%>
        </div>
    </div>
    <div class="container" id="containerShow" hidden="hidden">
        <div class="row">
            <div class="col-lg-11">
                <br />
                <h1 class="">Edit Profile</h1>
                <hr />
                <table class="table table-striped">
                    <tr>
                        <td class="">
                            <label id="Label1" runat="server">First Name</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <input type="text" id="txtName" disabled="True" runat="server" class="form-control" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label id="Label2" runat="server">Surname</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <input type="text" id="txtSurname" disabled="True" runat="server" class="form-control" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label id="Label4" runat="server">Position</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <input type="text" id="txtPosition" runat="server" class="form-control" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label id="Label3" runat="server">Contact Number</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtContact" CssClass="form-control"></asp:TextBox>
                            <%--<input type="text" id="txtContact" runat="server" class="form-group" /></td>--%>
                    </tr>
                    <tr>
                        <td>
                            <label id="Label5" runat="server">Biography</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="textBio" Height="150" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            <%--<input type="text" id="txtBio" Height="150px" textmode="multiline" runat="server" class="form-group" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="cv" runat="server">My CV</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <input type="file" id="myCV" runat="server" class="attached-file" /></td>

                    </tr>
                    <%-- <tr>
                        <td>
                            <label id="Label5" runat="server">New Password</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <input type="text" id="newPassword" runat="server" class="form-group" /></td>
                    </tr>--%>

                    <tr>
                        <td></td>
                    </tr>

                </table>
                <br />
                <table class="table table-striped">
                    <tr>
                        <td>
                            <label id="profPic"><span class="fa fa-picture-o">Profile Picture</span></label></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:FileUpload ID="FileUpload" AllowMultiple="False" CssClass="fa fa-upload" runat="server" /></td>
                    </tr>
                </table>
                <br />
                <br />
                <div style="padding-left: 120px">
                    <asp:Button runat="server" ID="cancelUpdate" Text="<< Back" CssClass="btn-link" OnClick="cancel_OnClick" />
                    |                            
                <asp:Button runat="server" ID="changeProfilePic" CssClass="btn btn-success" Text="Update Profile" OnClick="changeProfilePic_OnClick" />
                </div>

            </div>
        </div>
    </div>
    <div class="container" id="containerTut" hidden="hidden">
        <div class="row">
            <div class="col-lg-11">
                <br />

                <h2 class="label-light">Learn & Support - Tutorial(s)</h2>
                <hr />
                <br />
                <button type="button" id="addTut" class="btn btn-app red2">Add Tut</button>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server" BackColor="White" CssClass="table table-bordered table-hover" AllowPaging="True"
                    CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#003300" BorderStyle="Solid"
                    BorderWidth="1px" OnRowCommand="GridView1_OnRowCommand" Font-Size="11pt" PageSize="10" Font-Names="Century"
                    AutoGenerateColumns="False" DataKeyNames="id">
                    <RowStyle BackColor="#EFF3FB" BorderColor="Black" BorderWidth="1px" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <Columns>
                        <%-- <asp:TemplateField>
                            <ItemTemplate>
                                <object id="player" classid="clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6"
                                    height="170" width="300">
                                    <param name="url" value='<%# "VideoHandler.ashx?id=" + Eval("id") %>' />
                                    <param name="showcontrols" value="true" />
                                    <param name="autostart" value="true" />
                                </object>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblId" Text='<%# Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Video Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblName" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Type of Video">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblType" Text='<%# Eval("content_type") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Date Added">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDate" Text='<%# Eval("created_at","{0:D}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ButtonType="Button" Text="Download" CommandName="Download"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />

                    </Columns>
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
                <br />
                <br />
                <button id="cancelButton" class="cancel">< Back</button>
            </div>
        </div>
    </div>
    <div class="container" id="containerStory" hidden="hidden">
        <div class="row">
            <div class="col-lg-12">
                <br />

                <h2 class="label-light">Learn & Support - Tell my story</h2>
                <hr />
                <button type="button" id="viewStory" class="btn btn-app red2">View Story</button>
                <br />
                <br />
                <cc1:Editor runat="server" Height="350" Width="900" ID="editor"></cc1:Editor>
                <br />

                <div style="padding-left: 350px">
                    <button class="cancel" id="cancelStory">< Back</button>|
                <asp:Button runat="server" OnClick="saveStory_OnClick" ID="saveStory" CssClass="btn btn-info2" Text="Save My Story" />
                </div>
            </div>
        </div>
    </div>
    <div class="container" id="containerGuide" hidden="hidden">
        <div class="row">
            <div class="col-lg-10">
                <br />

                <h2 class="label-light">Learn & Support - Add User Guide</h2>
                <hr />
                <button type="button" id="addGuide" class="btn btn-app red2">Add Guide</button>
                <br />
                <br />

                <asp:GridView runat="server" ID="GuideView" CssClass="table table-bordered table-hover" AllowSorting="True" AllowPaging="True" AutoGenerateColumns="False"
                    CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#003300" BorderStyle="Solid"
                    BorderWidth="1px" Font-Size="11pt" PageSize="10" Font-Names="Century" OnPageIndexChanging="GuideView_PageIndexChanging"
                    DataKeyNames="id" OnRowDeleting="GuideView_OnRowDeleting" OnRowCommand="GuideView_OnRowCommand">
                    <RowStyle BackColor="#EFF3FB" BorderColor="Black" BorderWidth="1px" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblId" Text='<%# Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Project Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblProjName" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Created Date">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDate" Text='<%# Eval("created_at","{0:D}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:ButtonField ButtonType="Button" Text="Download" CommandName="Download"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                        <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="Delete"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                    </Columns>

                </asp:GridView>
                <br />
                <label id="lblGuideError" style="color: red" runat="server"></label>
                <br />
                <button id="cancelButton" class="btn btn-link-2">< Back</button>
            </div>
        </div>
    </div>
    <div class="container" id="containerTasks" hidden="hidden">
        <div class="row">
            <div class="col-lg-12">
                <br />

                <h2 class="label-light"><i class="fa fa-bars" aria-hidden="true"></i>My Tasks</h2>
                <hr />
                <cc1:Editor runat="server" Height="350" Width="900" ID="myTasksEditor"></cc1:Editor>
                <br />

                <div style="padding-left: 350px">
                    <button class="btn btn-link-2" id="cancelTasks">< Back</button>
                    |
                    <asp:Button runat="server" OnClick="btnMyTasks_OnClick" ID="btnMyTasks" CssClass="btn btn-info2" Text="Save My Tasks" />
                </div>

            </div>
        </div>
    </div>
    <div class="container" id="containerViewTasks" hidden="hidden">
        <div class="row">
            <div class="col-lg-12">
                <br />

                <h2 class="label-light">My Tasks</h2>
                <hr />
                <cc1:Editor runat="server" Height="350" Width="900" ID="view"></cc1:Editor>
                <br />
                <label runat="server" style="color: red" id="errorMessage"></label>
                <br />
                <br />
                <button class="btn btn-link-2" id="cancelTasks">< Back</button>
            </div>
        </div>
    </div>
    <div class="container" id="containerViewStory" hidden="hidden">
        <div class="row">
            <div class="col-lg-12">
                <br />

                <h2 class="label-light">My Story</h2>
                <hr />
                <cc1:Editor runat="server" Height="350" Width="900" ID="viewstoryEditor"></cc1:Editor>
                <br />
                <label runat="server" style="color: red" id="viewStoryError"></label>
                <br />
                <br />
                <button class="btn btn-link-2" id="cancelTasks">< Back</button>
            </div>
        </div>
    </div>
   <%-- <div class="container" id="containerAddGuide" hidden="hidden">
        <div class="row">
            <div class="col-lg-12">
                <br />
                <h2 class="">Learn & Support - User Guide</h2>
                <hr />
                <br />
                <asp:FileUpload ID="GuideUpload" CssClass="glyphicon-upload" AllowMultiple="True" runat="server" />
                <br />
                <br />
                <button id="cancelButton" class="btn btn-link-2">< Back</button>
                |
                <asp:Button runat="server" ID="Button1" CssClass="btn btn-success" Text="Upload Guide (s)" OnClick="UploadGuide_OnClick" />
            </div>
        </div>
    </div>--%>
    <div class="container" id="mySpaceContainer" hidden="hidden">
        <div class="row">
            <div class="col-lg-12">
                <br />
                <h2 class="">My Space </h2>
                <hr />
                <br />
                <asp:FileUpload ID="mySpaceUpload" CssClass="glyphicon-upload" AllowMultiple="True" runat="server" />
                <br />
                <br />
                <button id="cancelButton" class="btn-link-2">Back</button>
                |
                <asp:Button runat="server" ID="btnMySpace" CssClass="btn btn-success" Text="My Space Upload" OnClick="btnMySpace_OnClick" />
            </div>
        </div>
    </div>
    <div class="container" id="containerLibrary" hidden="hidden">
        <div class="row">
            <div class="col-lg-12">
                <br />
                <h2 class="label-light">Approved Proposals </h2>
                <hr />
                <br />

                <asp:GridView runat="server" ID="researchGrid" CssClass="table table-bordered table-hover" AllowPaging="True"
                    CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#003300" BorderStyle="Solid"
                    BorderWidth="1px" Font-Size="11pt" PageSize="10" Font-Names="Century" OnPageIndexChanging="research_PageIndexChanging"
                    OnRowCommand="research_RowCommand" AutoGenerateColumns="False" OnRowEditing="research_OnRowEditing" DataKeyNames="id">
                    <RowStyle BackColor="#EFF3FB" BorderColor="Black" BorderWidth="1px" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblId" Text='<%# Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Project Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblProjName" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Created Date">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDate" Text='<%# Eval("created_at","{0:D}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:ButtonField ButtonType="Button" Text="Research" CommandName="Research"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                        <asp:ButtonField ButtonType="Button" Text="Consultancy" CommandName="Consult"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>
    <div id="addResearch" hidden="hidden" runat="server">
        <cc1:Editor ID="Editor1" Content="" runat="server" Width="900" Height="300"></cc1:Editor>
        <br />
        <asp:LinkButton runat="server" ID="LinkButton1" CssClass="fa-external-link" Text="Cancel" OnClick="cancel_OnClick"></asp:LinkButton>
        <asp:Button runat="server" ID="submit" Text="Submit" OnClick="submit_OnClick" CssClass="btn btn-success" />
    </div>
    <div class="container" id="containerConsultancy" hidden="hidden">
        <div class="row">
            <div class="col-lg-12">
                <br />
                <h2 class="label-light">Consultancy </h2>
                <hr />
                <br />

                <asp:GridView runat="server" ID="GridView2" CssClass="table table-bordered table-hover" AllowPaging="True"
                    CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#003300" BorderStyle="Solid"
                    BorderWidth="1px" Font-Size="11pt" PageSize="10" Font-Names="Century" OnPageIndexChanging="research_PageIndexChanging"
                    OnRowCommand="research_RowCommand" AutoGenerateColumns="False" OnRowEditing="research_OnRowEditing" DataKeyNames="id">
                    <RowStyle BackColor="#EFF3FB" BorderColor="Black" BorderWidth="1px" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblId" Text='<%# Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Project Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblProjName" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Created Date">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDate" Text='<%# Eval("created_at","{0:D}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:ButtonField ButtonType="Button" Text="Research" CommandName="Research"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                        <asp:ButtonField ButtonType="Button" Text="Consultancy" CommandName="Consult"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
    <div class="container" id="containerAddTutorial" hidden="hidden">
        <div class="row">
            <div class="col-lg-12">
                <br />
                <h2 class="label-light">Learn & Support - Add Tutorial</h2>
                <hr />
                <br />
                <uc1:UploadVideo ID="UploadVideo1" runat="server" />
                <br />
                <br />
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <object id="player" classid="clsid:6BF52A52-394A-11D3-B153-00C04F79FAA6"
                            height="170" width="300">
                            <param name="url" value='<%# "VideoHandler.ashx?id=" + Eval("id") %>' />
                            <param name="showcontrols" value="true" />
                            <param name="autostart" value="true" />
                        </object>
                    </ItemTemplate>

                </asp:Repeater>
                <br />

            </div>
        </div>
    </div>

</asp:Content>
