<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssignUserToProject.aspx.cs" Inherits="Insendlu.AssignUserToProject" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.ToolboxIcons" TagPrefix="cc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="modal fade" id="successModal" runat="server" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <br>
                    <i class="fa fa-exclamation-triangle fa-7x"></i>
                    <h4 class="semi-bold">Users Successfully assigned to the project</h4>
                    <br>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-info" data-dismiss="modal">Close</button>

                </div>

            </div>
        </div>
    </div>
    <%--  <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" TargetControlID="lblHidden" PopupControlID="btnOk" runat="server">
    </ajaxToolkit:ModalPopupExtender>--%>

    <div class="container">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="">Assigning Users to Proposal</h1>
                <br/>
               
                <hr/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <br />
                
                <br />
                <div class="form-group">
                    <label for="projectList" class="fa-product-hunt"> Proposal Name</label><br />
                    <asp:DropDownList runat="server" ID="projectList" Width="200px" DataTextField="name" DataValueField="id" ToolTip="Select Project to assign users" CssClass="dropdown" />

                </div>
               </div>
            <div class="col-lg-4">
                <br />
                <br />
                <div class="form-group">
                    <label for="userList" class="fa-users"> Select Users</label>
                    <br/>
                    <%--<asp:DropDownList runat="server" ID="users" CssClass="dropdown-caret" DataTextField="name" DataValueField="id" Width="200"/>
                    <br/>--%>
                    <asp:ListBox runat="server" Width="200px" CssClass="list-group-item" ID="userList" SelectionMode="Multiple" DataValueField="id" DataTextField="name" />
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-4 col-lg-offset-4">
                <br />
                <a href="Dashboard.aspx" class="back-to-login-link">Back</a> |
                <asp:Button runat="server" OnClick="OnClick" CssClass="col-xs-reset responsive-min" Text="Reset"/> | <asp:Button runat="server" Text="Assign Users" ID="Assign" CssClass="btn btn-success" OnClick="Assign_OnClick" />
            </div>
        </div>

    </div>

</asp:Content>
