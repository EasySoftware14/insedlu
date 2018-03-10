<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Insendlu.ResetPassword" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta charset="utf-8" />
    <title>Insedlu</title>

    <meta name="description" content="User login page" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

    <!-- bootstrap & fontawesome -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />

    <!-- text fonts -->
    <link rel="stylesheet" href="assets/css/fonts.googleapis.com.css" />

    <!-- ace styles -->
    <link rel="stylesheet" href="assets/css/ace.min.css" />

    <!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" />
		<![endif]-->
    <link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

    <!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

    <!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

    <!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
</head>

<body class="login-layout">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="modal fade" id="passreset" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <%--                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>--%>
                        <br>
                        <i class="fa fa-exclamation-triangle fa-7x"></i>
                        <h2 class="semi-bold">Password Reset</h2>
                        <hr />

                        <h4>Password reset successfully</h4>

                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                        <a href="index.aspx" data-dismiss="modal" class="btn btn-block">Thank You</a>
                    </div>

                </div>
            </div>
        </div>

        <div class="main-container">
            <div class="main-content">
                <div class="row">
                    <div class="col-sm-10 col-sm-offset-1">
                        <div class="login-container">
                            <div class="center">
                                <h1>
                                    <i class="ace-icon fa fa-leaf green"></i>
                                    <span class="red">Companion</span>
                                    <span class="white" id="id-text2">Pulse</span>
                                </h1>
                                <h4 class="blue" id="id-company-text">&copy; Insedlu</h4>
                            </div>

                            <div class="space-6"></div>

                            <div class="position-relative">
                                <div id="login-box" class="login-box visible widget-box no-border">
                                    <div class="widget-body">
                                        <div class="widget-main">
                                            <h4 class="header blue lighter bigger">
                                                <i class="ace-icon fa fa-coffee green"></i>
                                                Please Enter Your Information
                                            </h4>

                                            <div class="space-6"></div>

                                            <fieldset>
                                                <label class="block clearfix">

                                                    <label class="block clearfix">
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="email" id="txtEmail" runat="server" class="form-control" placeholder="Email" />
                                                            <i class="ace-icon fa fa-lock"></i>
                                                        </span>
                                                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                                                        <span class="block input-icon input-icon-right">
                                                            <input type="password" runat="server" id="newPass" class="form-control" placeholder="New Password" />
                                                            <i class="ace-icon fa fa-lock"></i>
                                                        </span>
                                                        <span class="block input-icon input-icon-right">
                                                            <input type="password" runat="server" id="passconfirm" class="form-control" placeholder="Confirm Password" />
                                                            <i class="ace-icon fa fa-lock"></i>
                                                        </span>
                                                        <br />
                                                        <label class="input-error" id="error"></label>
                                                        <br />
                                                        <asp:Button runat="server" ID="submit" OnClientClick="javascript:_doPostBack('ButtonA','');" Text="Submit" CssClass="btn btn-success" />
                                                    </label>
                                                </label>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="assets/js/jquery-2.1.4.min.js"></script>
        <script src="http://code.jquery.com/jquery-latest.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.bootstrap.wizard.js"></script>
        <script src="assets/js/prettify.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {

                var pass1 = "";
                var pass2 = "";
                var check = false;

                $("#passconfirm").keypress(function () {

                    pass1 = $("#newPass").val();
                    pass2 = $(this).val();
                    //alert(pass1 + " " + pass2);

                    if (pass1 !== pass2) {
                        check = false;

                    } else if (pass1 === pass2) {
                        check = true;
                        $("#error").hide();
                    }

                });
                $("#btnSubmit").click(function () {

                    if (check) {
                        $("#passreset").modal({ backdrop: "static", keyboard: false });
                    } else {
                        $("#error").val("Password Dont match");
                    }


                });


            });
        </script>
    </form>

</body>
</html>
