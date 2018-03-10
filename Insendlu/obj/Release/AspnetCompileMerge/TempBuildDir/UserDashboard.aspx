<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="Insendlu.UserDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HtmlEditor" TagPrefix="cc1" %>
<%@ Register Src="UploadVideo.ascx" TagName="UploadVideo" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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

    <div class="container" id="default">
        <div class="row">
            <div class="page-header text-center">

                <span class="width-80 label label-xlg label-inverse arrowed-in arrowed-in-right">Dashboard</span>

            </div>

        </div>
        <br />
        <div class="row">
            <div id="user-profile-1" class="user-profile row">
                <div class="col-xs-12 col-sm-3 center">
                    <div>
                        <span class="profile-picture">
                            <img src="assets/images/avatars/avatar.png" height="150" width="200" id="image" runat="server" />
                        </span>

                        <div class="space-4"></div>

                        <div class="width-80 label label-inverse label-xlg arrowed-in arrowed-in-right">
                            <div class="inline position-relative">
                                <a href="#" class="btn btn-sm" id="showContainer">
                                    <i class="ace-icon fa fa-circle edit"></i>
                                    &nbsp;
															<span class="white">EDIT INFO</span>
                                </a>
                                <%--                                <a id="showContainer" class="btn btn-app">EDIT INFO</a>--%>
                                <ul class="align-left dropdown-menu dropdown-caret dropdown-lighter">
                                    <li class="dropdown-header">Change Status </li>

                                    <li>
                                        <a href="#">
                                            <i class="ace-icon fa fa-circle green"></i>
                                            &nbsp;
																	<span class="green">Available</span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="#">
                                            <i class="ace-icon fa fa-circle red"></i>
                                            &nbsp;
																	<span class="red">Busy</span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="#">
                                            <i class="ace-icon fa fa-circle grey"></i>
                                            &nbsp;
																	<span class="grey">Invisible</span>
                                        </a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>

                    <div class="space-6"></div>

                </div>

                <div class="col-xs-12 col-sm-9">


                    <div class="space-12"></div>

                    <div class="profile-user-info profile-user-info-striped">
                        <div class="profile-info-row">
                            <div class="profile-info-name">Name </div>

                            <div class="profile-info-value">
                                <span class="editable" runat="server" id="lblName"></span>
                            </div>
                        </div>
                        <div class="profile-info-row">
                            <div class="profile-info-name">Position </div>

                            <div class="profile-info-value">
                                <span class="editable" runat="server" id="lblPosition"></span>
                            </div>
                        </div>
                        <div class="profile-info-row">
                            <div class="profile-info-name">Contact Number </div>

                            <div class="profile-info-value">
                                <span class="editable" runat="server" id="lblContact"></span>
                            </div>
                        </div>

                        <div class="profile-info-row">
                            <div class="profile-info-name">Email Address </div>

                            <div class="profile-info-value">
                                <span class="editable" runat="server" id="lblEmail"></span>
                            </div>
                        </div>

                    </div>

                    <div class="space-20"></div>





                    <div class="space-6"></div>


                </div>
            </div>
            <div class="hr hr16 dotted"></div>
            <div class="center">
                <div class="center">
                    <%--<button class="btn btn-white btn-info btn-xlg">Library</button>--%>
                    <div class="btn-group text-center">
                        <button data-toggle="dropdown" class="btn btn-white btn-inverse btn-xlg dropdown-toggle">
                            Tasks
															<i class="ace-icon fa fa-angle-down icon-on-right"></i>
                        </button>

                        <ul class="text-center dropdown-menu dropdown-success dropdown-menu-right">
                            <li>
                                <button type="button" id="tasks" class="btn btn-white btn-inverse btn-sm no-border">Add Task</button>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <button type="button" id="viewtasks" class="btn btn-white btn-inverse btn-sm no-border">View Task</button>
                            </li>
                            <li class="divider"></li>
                        </ul>
                    </div>
                    <!-- /.btn-group -->
                    <div class="btn-group text-center">
                        <button data-toggle="dropdown" class="btn btn-white btn-info btn-xlg dropdown-toggle">
                            Learn and Support
															<i class="ace-icon fa fa-angle-down icon-on-right"></i>
                        </button>

                        <ul class="text-center dropdown-menu dropdown-success dropdown-menu-right">
                            <li>
                                <button type="button" id="tut" class="btn btn-white btn-inverse btn-sm no-border">Tutorials</button>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <button type="button" id="guide" class="btn btn-white btn-inverse btn-sm no-border">User Guide</button>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <button type="button" id="story" class="btn btn-white btn-inverse btn-sm no-border">Tell A Story</button>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <button type="button" id="myspace" class="btn btn-white btn-inverse btn-sm no-border">My Space</button>
                            </li>
                        </ul>
                    </div>
                    <!-- /.btn-group -->
                </div>
            </div>
        </div>


        <br />

        <hr />
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
            <div class="col-lg-12" id="map" style="height: 400px;width: 95%">
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
            </div>
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
                            <label id="profPic">Profile Picture</label></td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:FileUpload ID="FileUpload" AllowMultiple="False" CssClass="file-image" runat="server" /></td>
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

                <h2 class="label-light">My Tasks</h2>
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
    <div class="container" id="containerAddGuide" hidden="hidden">
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
    </div>
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
                <button id="cancelButton" class="btn btn-link-2"> Back</button>
                |
                <asp:Button runat="server" ID="btnMySpace" CssClass="btn btn-success" Text="My Space Upload" OnClick="UploadGuide_OnClick" />
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
