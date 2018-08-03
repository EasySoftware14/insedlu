<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Insendlu.AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  <%--  <script type="text/javascript">
        $(document).ready(function () {
            $("#addUser").modal({ backdrop: "static", keyboard: false });
        });
    </script>--%>

    <div class="modal fade" id="addUser" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <br>
                    <h2 class="semi-bold">Adding User</h2>
                    <hr />
                    <label for="name">Name</label>
                    <asp:TextBox runat="server" Required="Required" class="form-control" ID="userName" />
                    <label for="surname">Surname</label>
                    <asp:TextBox runat="server" Required="Required" class="form-control" ID="lastName" />
                    <label for="emailAddress">Email Address</label>
                    <asp:TextBox runat="server" Required="Required" ValidEmail="true" class="form-control email" ID="emailAddress" />
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="emailAddress" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                    <br />
                    <select id="userType" runat="server" class="select dropdown-100">
                        <option selected="selected">*** Select ***</option>
                        <option value="1"> Admin</option>
                        <option value="2"> User</option>

                    </select>
                    <asp:RegularExpressionValidator runat="server" ControlToValidate="userType"></asp:RegularExpressionValidator>
                    <br>
                </div>

                <div class="modal-footer">
                    <button type="button" id="btnCloseModal" class="btn btn-link" data-dismiss="modal">Close</button>
                    <asp:Button runat="server" OnClientClick="javascript:_doPostBack('ButtonA','');" Text="Add" OnClick="addNewUser_OnClick" CausesValidation="True" CssClass="btn btn-sm btn-flat" ID="addNewUser" />
                </div>

            </div>
        </div>
    </div>


    <%--<div class="container-fluid">
        <div class="row-fluid">
            <div class="col-md-12 " >
                <br />
                <br />
                <div class="form-group">
                    <label class="label-light" style="font-size: 20px">New User Registration</label>
                <hr/>
                    <label class="form-label"><span class="text-error"></span>Name</label>
                    <div class="input-with-icon right">
                        <input type="text" class="form-control" id="name" runat="server" />
                    </div>
                    <label class="form-label"><span class="text-error"></span>Surname</label>
                    <div class="input-with-icon right">
                        <input type="text" class="form-control" id="surname" runat="server" />
                    </div>
                    <label class="form-label"><span class="text-error"></span>Email Address</label>
                    <div class="input-with-icon right">
                        <input type="email" class="form-control email" id="email" runat="server" />
                    </div>
                    <div class="input-with-icon right">
                         <label class="form-label"><span class="text-error"></span>User Type</label>
                        <br/>
                        <select id="userType" runat="server" class="select dropdown-100">
                            <option selected="selected">*** Select ***</option>
                            <option value="1">User</option>
                            <option value="2">Admin</option>
                        </select>
                    </div>
                    <br/>
                    <br/>
                    <a href="Proposals.aspx" class="btn-link-2"><< Back</a> |
                    <input type="button" id="btnCancel" value="Cancel" class="cancel"/> |
                    <asp:Button runat="server" ID="addUser" CssClass="btn btn-success" Text="Add User" OnClick="addUser_OnClick"/>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
