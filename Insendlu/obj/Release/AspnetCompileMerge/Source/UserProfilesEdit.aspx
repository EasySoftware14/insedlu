<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfilesEdit.aspx.cs" Inherits="Insendlu.UserProfilesEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" hidden="">
        <div class="row">
            <div class="col-lg-11">
                <br />
                <h1 class="profile-info-name">Profile</h1>
                <hr />
                <table class="table">
                    <tr>
                        <td class="">
                            <label id="Label1" runat="server">First Name</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <input type="text" id="txtNames" disabled="True" runat="server" class="form-control" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label id="Label2" runat="server">Surname</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <input type="text" id="txtSurnames" disabled="True" runat="server" class="form-control" /></td>
                    </tr>
                    <tr>
                        <td>
                            <label id="Label4" runat="server">Position</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td></td>
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
                            <label id="Label5" runat="server">Motivational Letter</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="motivation" Height="150" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            <%--<input type="text" id="txtBio" Height="150px" textmode="multiline" runat="server" class="form-group" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="Label6" runat="server">Past experience</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>

                            <%--<input type="text" id="txtBio" Height="150px" textmode="multiline" runat="server" class="form-group" />--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label id="profPic" runat="server">Profile Picture</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            
                    </tr>

                    <tr>
                        <td>
                            <label id="cv" runat="server">Attach CV</label></td>
                        <td>&nbsp;&nbsp;</td>
                        <td>
                            <asp:Button runat="server" ID="btnView" Text="View CV" CssClass="form-view-data" />
                            <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" AllowedFileTypes="doc,docx,pdf" OnUploadComplete="AjaxFileUpload1_OnUploadComplete" runat="server" />

                        </td>

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
                        <td>
                    </tr>

                </table>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="span3 well">
            <center>
        <a href="#aboutModal" data-toggle="modal" data-target="#myModal"><img runat="server" id="ImgageCopy" name="aboutme" width="140" height="140" border="0" class="img-circle" src="assets/images/avatars/user.jpg" alt="Photo" /></a>
        <h3><label id="txtDisplayName" runat="server"></label> <label id="txtDisplaySurname" runat="server"></label></h3>
        <em>click my face for more</em>
		</center>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"></button>
                        <h4 class="modal-title" id="myModalLabel">More About Myself</h4>
                    </div>
                    <div class="modal-body">
                        <center>
                        <img runat="server" id="image" name="aboutme" width="140" height="140" border="0" class="img-circle" src="assets/images/avatars/user.jpg" alt="Photo" />
                   <%-- <img src="https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcRbezqZpEuwGSvitKy3wrwnth5kysKdRqBW54cAszm_wiutku3R" name="aboutme" width="140" height="140" border="0" class="img-circle"></a>--%>
                    <h3 class="media-heading"> <label id="txtName" runat="server"></label> <label id="txtSurname" runat="server"></label> <small>South Africa</small></h3>
                        <hr/>
                        <center>
                            <p class="text-left"><strong> Position: </strong><br>
                                <asp:TextBox runat="server" ID="txtPosition" CssClass="form-control"></asp:TextBox></p>
                            <br/>
                        </center>
                        <center>
                            <p class="text-left"><strong> Cell: </strong><br>
                                <asp:TextBox runat="server" ID="cellphone" CssClass="form-control"></asp:TextBox></p>
                            <br/>
                        </center>
                        
                        <center>
                            <p class="text-left"><strong> Email: </strong><br>
                                <asp:TextBox runat="server" ID="email" CssClass="form-control" ReadOnly="True"></asp:TextBox></p>
                            <br/>
                        </center>
                    <p class="text-left"><strong> Qualification(s): </strong><br/>
                        <asp:TextBox runat="server" ID="qualification" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></p>
                        <br/>
                    </center>
                        <center>
                        <p class="text-left"><strong> Department: </strong><br>
                            <asp:TextBox runat="server" ID="department" CssClass="form-control"></asp:TextBox></p>
                        <br/>
                    </center>
                        <center>
                        <p class="text-left"><strong> Responsibilities: </strong><br>
                            <asp:TextBox runat="server" ID="responsibility" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></p>
                        <br/>
                    </center>
                        <center>
                    <p class="text-left"><strong> Biography: </strong><br>
                        <asp:TextBox runat="server" ID="biography" Height="150" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></p>
                        <br/>
                    </center>
                        <center>
                        <p class="text-left"><strong> Awards: </strong><br>
                            <asp:TextBox runat="server" ID="awards" CssClass="form-control"></asp:TextBox></p>
                        <br/>
                    </center>
                        <center>
                        <p class="text-left"><strong> Personal Interest: </strong><br>
                            <asp:TextBox runat="server" ID="personalInterest" TextMode="MultiLine" CssClass="form-control"></asp:TextBox></p>
                        <br/>
                    </center>
                        <center>
                            <p class="text-left"><strong> Profile Picture </strong><br>
                                <asp:FileUpload ID="FileUpload" AllowMultiple="False" CssClass="file-image" runat="server" /></p>
                            <br/>
                        </center>
                    </div>
                    <div class="modal-footer">
                        <center>
                        <button type="button" class="btn btn-default" data-dismiss="modal"> Close</button>
                         <asp:Button runat="server" CssClass="btn btn-success" ID="btnUpdate" Text="Update Now" OnClick="btnUpdate_OnClick" />
                   
                    </center>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
