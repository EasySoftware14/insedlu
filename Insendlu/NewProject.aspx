<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewProject.aspx.cs" Inherits="Insendlu.NewProject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HtmlEditor" TagPrefix="cc1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>New Project</title>
    <!-- Bootstrap -->
    <link href="assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/css/prettify.min.css" rel="stylesheet" />
    <link href="assets/css/wizard.css" rel="stylesheet" />
    <link href="assets/css/smart_wizard.min.css" rel="stylesheet" />
    <link href="assets/css/smart_wizard_theme_circles.min.css" rel="stylesheet" />
    <link href="assets/css/smart_wizard_theme_arrows.min.css" rel="stylesheet" />
    <link href="assets/css/smart_wizard_theme_dots.min.css" rel="stylesheet" />
</head>
<body>

    <form runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div class="modal fade" id="projectModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <%--                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>--%>
                        <br>
                        <i class="fa fa-exclamation-triangle fa-7x"></i>
                        <h2 class="semi-bold">Proposal Category</h2>
                        <hr />
                        <label for="proposalType">Category</label>
                        <asp:DropDownList runat="server" class="form-control" DataValueField="id" DataTextField="name" ID="proposalType"></asp:DropDownList>
                        <br>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                        <button id="projSpec" type="button" onclick="javascript:_doPostBack('ButtonA','');" class="btn btn-info" data-dismiss="modal">Submit</button>
                    </div>

                </div>
            </div>
        </div>
        <div class="modal fade" id="envelopType" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <%--                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>--%>
                        <br>
                        <i class="fa fa-exclamation-triangle fa-7x"></i>
                        <h2 class="semi-bold">Envelop Type</h2>
                        <hr />
                        <label for="typeEnvelop">Envelop Type</label>
                        <select class="form-control" id="typeEnvelop" runat="server">
                            <option value="technical">Technical</option>
                            <option value="financial">Financial</option>
                        </select>
                        <br>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                        <button id="btnenvelopType" type="button" class="btn btn-info" data-dismiss="modal">Submit</button>
                    </div>

                </div>
            </div>
        </div>
        <div class="modal fade" id="isComplteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <%--                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>--%>
                        <br>
                        <i class="fa fa-exclamation-triangle fa-7x"></i>
                        <h2 class="semi-bold">Completion Confirmation</h2>
                        <hr />
                        <label for="isComplete">Is the proposal finished compiling ?</label>
                        <select class="form-control" id="isComplete" runat="server">
                            <option value="1">Complete</option>
                            <option value="2">InComplete</option>
                        </select>
                        <br>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                        <asp:Button CssClass="btn btn-primary align-left" ID="save" OnCommand="save_OnCommand" OnClick="SubmitButton_OnClick" Text="Submit" runat="server"></asp:Button>
                    </div>

                </div>
            </div>
        </div>
        <div class="container">
            
            <div class="row" id="proposalDetails">
                <div class="col-lg-12">
                    <h2 class="top-content">Proposal Details</h2>
                    <hr />
                    <label>Client</label><br />
                    <asp:TextBox runat="server" ID="clientName" Required="Required" CssClass="form-control"></asp:TextBox><br />
                    <label runat="server">Sector</label><br />
                    <asp:DropDownList runat="server" ID="drpSector" Required="Required" DataValueField="id" DataTextField="name" Width="200" CssClass="select2 dropdown-caret-right dropdown-100" /><br />
                    <br />
                    <label for="type">Proposal Type</label><br />
                    <asp:DropDownList runat="server" ID="type" Required="Required" DataValueField="id" DataTextField="name" Width="200" CssClass="select2 dropdown-caret-right dropdown-100" />
                    <br />
                    <br />
                    <label for="projectEnvelope">Envelop System</label><br />
                    <select runat="server" datavaluefield="id" required="required" datatextfield="name" style="width: 220px" class="select2 dropdown-caret-right dropdown-100" id="projectEnvelope">
                    </select>
                    <br />
                    <br />
                    <label for="projectName"> Title</label><br />
                    <input type="text" runat="server" required="required" class="form-control" id="ProjName" /><br />
                    <label>Description</label><br />
                    <asp:TextBox runat="server" Height="150" ValidateRequestMode="Enabled" TextMode="MultiLine" CssClass="form-control" ID="descriptionPro"></asp:TextBox>
                    <br />
                    <br />
                    <button id="continue" class="btn-app">Continue</button>

                </div>
            </div>
            <div id="financialId" hidden="">
                <h2 class="top-content">Financial Proposal</h2>
            </div>
            <br />
            <div hidden="" id="technicalId">
                <h2 class="top-content">Technical Proposal</h2>
            </div>
            <br />
            <div id="smartwizard" class="technical" hidden="">
                <ul>
                    <li><a href="#step-16">Step 2<br />
                        <small>Cover page</small></a></li>
                    <li><a href="#step-2">Step 3<br />
                        <small>Executive Summary</small></a></li>
                    <li><a href="#step-5">Step 4<br />
                        <small>Company Background</small></a></li>
                    <li><a href="#step-3">Step 5<br />
                        <small>Scope of Work</small></a></li>
                    <li><a href="#step-6">Step 6<br />
                        <small>Proposed Methodology</small></a></li>
                    <li><a href="#step-7">Step 7<br />
                        <small>Implementation Plan</small></a></li>
                    <li><a href="#step-8">Step 8<br />
                        <small>Project Cost</small></a></li>
                    <li><a href="#step-10">Step 9<br />
                        <small>Project Team</small></a></li>
                    <li><a href="#step-11">Step 10<br />
                        <small>Project References</small></a></li>
                    <li><a href="#step-12">Step 11<br />
                        <small>Project Risk Analysis</small></a></li>
                    <li><a href="#step-13">Step 12<br />
                        <small>BBBEE Status</small></a></li>
                    <li><a href="#step-14">Step 13<br />
                        <small>Why Choose Us</small></a></li>
                    <li><a href="#step-15">Step 14<br />
                        <small>Conclusion</small></a></li>
                </ul>
                <div>
                    <div id="step-16" class="">
                        <label for="preparedFor"> Prepared For</label><br/>
                        <asp:TextBox runat="server" ID="preparedFor" CssClass="form-control"></asp:TextBox><br/>
                        <label for="reasonForProposal"> Bid</label><br/>
                        <asp:TextBox runat="server" ID="reasonForProposal" CssClass="form-control"></asp:TextBox><br/>

                        <label for="preparedBy"> Prepared By</label><br/>
                        <asp:TextBox runat="server" ID="preparedBy" CssClass="form-control"></asp:TextBox><br/>
                        <label>Address</label><br/>
                        <asp:TextBox runat="server" ID="line1" CssClass="form-control"></asp:TextBox><br/>
                        <asp:TextBox runat="server" ID="line2" CssClass="form-control"></asp:TextBox><br/>
                        <asp:TextBox runat="server" ID="surburb" CssClass="form-control"></asp:TextBox><br/>
                        <asp:TextBox runat="server" ID="postalCode" CssClass="form-control"></asp:TextBox><br/>
                        <asp:TextBox runat="server" ID="telNumber" CssClass="form-control"></asp:TextBox><br/>
                        <asp:TextBox runat="server" ID="fax" CssClass="form-control"></asp:TextBox><br/>
                        <asp:TextBox runat="server" ID="emailAddress" CssClass="form-control"></asp:TextBox><br/>
                        <asp:TextBox runat="server" ID="cc" CssClass="form-control"></asp:TextBox><br/>
                        
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="confidentialStatement" CssClass="form-control"></asp:TextBox><br/>

                        <%--<cc1:Editor ID="coverPage" Content="" ValidateRequestMode="Enabled" AutoFocus="True" runat="server" Height="250"></cc1:Editor>--%>
                    </div>
                    <div id="step-2" class="">
                        <cc1:Editor ID="execSummary" Content="" runat="server" Height="250"></cc1:Editor>
                    </div>
                    <div id="step-5" class="">
                        <h4>Background</h4>
                        <asp:TextBox runat="server" ID="backgroundStatement" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        <br />
                        <h4>Mission Statement</h4>
                        <asp:TextBox runat="server" ID="missionStatement" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <h4>Service Offering</h4>
                         <asp:ListBox runat="server" SelectionMode="Multiple" ID="serviceOffering" />

                       <%-- <cc1:Editor ID="companyBackground" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>--%>
                    </div>
                    <div id="step-3" class="">
                        <%--<cc1:Editor ID="projScope" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>--%>
                        <br />
                        <h4>Aim</h4>
                        <asp:TextBox runat="server" ID="projScopeAim" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        <br />
                        <h4>Purpose</h4>
                        <asp:TextBox runat="server" ID="purpose" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <h4>Deliverables</h4>
                        <asp:TextBox runat="server" ID="deliverables" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div id="step-6" class="">

                        <cc1:Editor ID="propMethodology" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>
                    <div id="step-7" class="">

                        <cc1:Editor ID="implemantation" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>
                    <div id="step-8" class="">
                        <%--  <asp:UpdatePanel runat="server">
                            <ContentTemplate>--%>
                        <br />
                        <label>Upload Project Cost Document. </label>
                        <br />
                        <h5>Please note allowed file formats are as follow:
                            <label class="label-important">jpg, pdf, doc, docx, png, .xlx</label></h5>
                        <br />
                        <asp:FileUpload runat="server" ID="fileUpload" CssClass="upload-icon" AllowMultiple="True"/> 
                       <%-- <ajaxToolkit:AjaxFileUpload ID="technicalProjCost" AllowedFileTypes="xls,xlsx,docx,pdf,png,jpg,img,gif" OnUploadComplete="AjaxFileUpload1_OnUploadComplete" runat="server" />--%>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>

                        <%-- <cc1:Editor ID="costPlan" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>--%>
                    </div>
                    <div id="step-10" class="">
                        <cc1:Editor ID="projTeam" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>
                    <div id="step-11" class="">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <ajaxToolkit:ModalPopupExtender runat="server" ID="editCvPopUp" CancelControlID="cnlCV" BackgroundCssClass="modalBackground" TargetControlID="editCV" PopupControlID="cvPnlPopup" />
                                <ajaxToolkit:ModalPopupExtender runat="server" ID="editRefPopUp" CancelControlID="btnCancel" BackgroundCssClass="modalBackground" TargetControlID="editReference" PopupControlID="pnlPopup" />
                                
                                <asp:Panel runat="server" ID="cvPnlPopup" OnPreRender="cvPnlPopup_OnPreRender" TabIndex="-1" aria-hidden="true" Style="display: none" CssClass="modalPopup" role="dialog">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <br>
                                                <i class="fa fa-exclamation-triangle fa-7x"></i>
                                                <h2 class="semi-bold">CV Update</h2>
                                                <hr />
                                                 <label for="name"> Full Name</label>
                                                <asp:TextBox runat="server" ID="name" Enabled="False" CssClass="form-control"></asp:TextBox>
                                                <br/>
                                                <label for="responsibility"> Responsibilities</label>
                                                <asp:TextBox runat="server" ID="responsibility" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                                <br/>
                                                <label for="qualification"> Qualification</label>
                                                <asp:TextBox runat="server" TextMode="MultiLine" Width="" ID="qualification" CssClass="form-control"></asp:TextBox>
                                                <br/>
                                               
                                                <asp:Button runat="server" ID="cnlCV" Text="Cancel" OnClick="cnlCV_OnClick" CssClass="btn-danger"/>
                                                <asp:Button runat="server" ID="updateCV" CssClass="btn-success" Text="Update CV" OnClick="updateCV_OnClick" OnCommand="updateCV_OnCommand" />
                                            </div>

                                        </div>
                                    </div>
                                </asp:Panel>

                                <asp:Panel runat="server" ID="pnlPopup" OnPreRender="pnlPopup_OnPreRender" TabIndex="-1" aria-hidden="true" Style="display: none" CssClass="modalPopup" role="dialog">
                              
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <br>
                                                <i class="fa fa-exclamation-triangle fa-7x"></i>
                                                <h2 class="semi-bold">Reference Update</h2>
                                                <hr />
                                                <label for="client_Name">Client Name</label>
                                                <asp:TextBox runat="server" ID="client_Name" CssClass="form-control"></asp:TextBox>
                                                <br/>
                                                <label for="projectDetails">Project Details</label>
                                                <asp:TextBox runat="server" TextMode="MultiLine" Width="" ID="projectDetails" CssClass="form-control"></asp:TextBox>
                                                <br/>
                                                <label for="txtDuration">Duration</label>
                                                <asp:TextBox runat="server" ID="txtDuration" CssClass="form-control"></asp:TextBox>
                                                <br/>
                                                <label for="contactPerson">Contact Person</label>
                                                <asp:TextBox runat="server" ID="contactPerson" CssClass="form-control"></asp:TextBox>
                                                <br/>
                                                <label for="projValue">Project Value</label>
                                                <asp:TextBox runat="server" ID="projValue" CssClass="form-control"></asp:TextBox>&nbsp; <asp:CheckBox CssClass="checkbox-inline" runat="server" ID="showValue" Text=" Show Value?"/>
                                                
                                                <br />
                                                <asp:Button runat="server" ID="btnCancel" Text="Cancel" OnClick="btnCancel_OnClick" CssClass="btn-danger"/>
                                                <asp:Button runat="server" ID="btnEditReference" CssClass="btn-success" Text="Update" OnClick="btnEditReference_OnClick" OnCommand="btnEditReference_OnCommand" />
                                            </div>

                                        </div>
                                    </div>
                                </asp:Panel>
                                <br/><br/>
                                <div class="panel-group">
                                    <div class="panel panel-default">
                                        <a class="panel-default" data-toggle="collapse" data-parent="#accordion1" href="">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">CV</h3>
                                            </div>
                                        </a>
                                        <div id="collapseOne" class="">
                                            <div class="panel-body">

                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="cvs" CssClass="dropdown-75" /></td>
                                                        <td>
                                                            <asp:Button runat="server" ID="btnAddCv" CommandName="AddCv" CssClass="btn-primary" OnClick="btnAddCv_OnClick" OnCommand="btnAddCv_OnCommand" Text="Add" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <label runat="server" visible="False" id="lblCV">CVs to be added: </label>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ListBox runat="server" SelectionMode="Single" OnTextChanged="lstBoxCV_OnTextChanged" OnSelectedIndexChanged="lstBoxCV_OnSelectedIndexChanged" Visible="False" ID="lstBoxCV" /></td>
                                                        <td></td>
                                                        <td>
                                                            <asp:Button runat="server" Visible="False" ID="editCV" OnClick="editCV_OnClick" Enabled="False" Text="Edit CV" CssClass="btn-yellow" OnCommand="editCV_OnCommand" /> &nbsp;&nbsp;<asp:Button runat="server" ID="removeCV" Visible="False" Text="Remove" CssClass="btn-danger" OnClick="refCV_OnClick" OnCommand="refCV_OnCommand" /></td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <asp:Label runat="server" Visible="False" ID="cvIds"></asp:Label></th>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="panel-group">
                                    <div class="panel panel-info">
                                        <a class="panel-info" data-toggle="collapse" data-parent="#accordion1" href="">
                                            <div class="panel-heading">
                                                <h3 class="panel-title">REFERENCES </h3>
                                            </div>
                                        </a>
                                        <div id="collapseTwo" class="">
                                            <div class="panel-body">
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList runat="server" ID="refDrpList" CssClass="dropdown-75" /></td>
                                                        <td>
                                                            <asp:Button runat="server" ID="references" CommandName="AddRef" CssClass="btn-primary" OnClick="references_OnClick" OnCommand="references_OnCommand" Text="Add" /></td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <label runat="server" visible="False" id="lblReference">Reference to be added: </label>
                                                        </th>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:ListBox runat="server" SelectionMode="Single" OnTextChanged="refList_OnTextChanged" OnSelectedIndexChanged="refList_OnSelectedIndexChanged" Visible="False" ID="refList" /></td>
                                                        <td>
                                                            <asp:Button runat="server" Visible="False" Enabled="False" Text="Edit Reference" ID="editReference" OnClick="editReference_OnClick" CssClass="btn-yellow" OnCommand="editReference_OnCommand" /> &nbsp;&nbsp;<asp:Button runat="server" ID="removeReference" Visible="False" CssClass="btn-danger" Text="Remove" OnClick="removeReference_OnClick" OnCommand="removeReference_OnCommand" /></td>
                                                    </tr>
                                                    <tr>
                                                        <th>
                                                            <asp:Label runat="server" Visible="False" ID="lblref"></asp:Label></th>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--<cc1:Editor ID="projReference" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>--%>
                    </div>
                    <div id="step-12" class="">
                        <cc1:Editor ID="riskanalysis" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>
                    <div id="step-13" class="">
                        <cc1:Editor ID="BBEstatus" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>
                    <div id="step-14" class="">
                        <br/>
                        <label for="heading">Header</label><br/>
                        <asp:TextBox runat="server" ID="heading" CssClass="form-control" TextMode="MultiLine"></asp:TextBox><br />
                         <label for="bulletedPoints">Bullet Points (separated by # key)</label><br/>
                        <asp:TextBox runat="server" ID="bulletedPoints" CssClass="form-control" TextMode="MultiLine"></asp:TextBox><br />
                        <cc1:Editor ID="whyChoose" runat="server" Visible="False" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>
                    <div id="step-15" class="">
                        <cc1:Editor ID="conclusion" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>

                </div>
            </div>
            <div id="smartwizardFinancial" hidden="">

                <ul>
                    <li><a href="#step-18">Step 2<br />
                        <small>Cover page</small></a></li>
                    <li><a href="#step-19">Step 3<br />
                        <small>Executive Summary</small></a></li>
                    <li><a href="#step-20">Step 4<br />
                        <small>Project Cost</small></a></li>
                    <li><a href="#step-21">Step 5<br />
                        <small>Project Reference</small></a></li>
                    <li><a href="#step-22">Step 6<br />
                        <small>Conclusion</small></a></li>
                </ul>
                <div>
                    <div id="step-18" class="">
                        <cc1:Editor ID="financialCoverPage" Content="" ValidateRequestMode="Enabled" AutoFocus="True" runat="server" Height="250"></cc1:Editor>
                    </div>
                    <div id="step-19" class="">
                        <cc1:Editor ID="finaceExecSummary" Content="" runat="server" Height="250"></cc1:Editor>
                    </div>
                    <div id="step-20" class="">
                        <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" AllowedFileTypes="doc,docx,pdf" OnUploadComplete="AjaxFileUpload1_OnUploadComplete" runat="server" />

                        <cc1:Editor ID="financeProjectCost" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>
                    <div id="step-21" class="">

                        <cc1:Editor ID="financeProjReference" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>
                    <div id="step-22" class="">

                        <cc1:Editor ID="financeConclusion" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
                    </div>

                </div>
            </div>
            <div class="pull-right">
                <br />
                <div style="margin-left: 900px">
                    <button id="submit" hidden="" class="btn btn-primary align-left">Save Work</button><%--//onclick="javascript:_doPostBack('submit','');"--%>
                </div>
            </div>
            <br />
            <br />
            <hr />
        </div>
        <script src="http://code.jquery.com/jquery-latest.js"></script>
        <script src="assets/js/jquery-2.1.4.min.js"></script>
        <script src="assets/js/bootstrap.min.js"></script>
        <script src="assets/js/jquery.smartWizard.min.js"></script>
        <script src="assets/js/jquery.bootstrap.wizard.js"></script>
        <script src="assets/js/prettify.min.js"></script>

        <script type="text/javascript">
            $('#smartwizard').smartWizard({
                //anchorSettings: {
                //    anchorClickable: true, // Enable/Disable anchor navigation
                //    enableAllAnchors: true, // Activates all anchors clickable all times
                //    markDoneStep: true, // add done css
                //    markAllPreviousStepsAsDone: true, // When a step selected by url hash, all previous steps are marked done
                //    removeDoneStepOnNavigateBack: false, // While navigate back done step after active step will be cleared
                //    enableAnchorOnDoneStep: true // Enable/Disable the done steps navigation
                //},
                selected: 0,
                autoAdjustHeight: true,
                useURLhash: true,
                showStepURLhash: true,
                theme: 'default',
                transitionEffect: 'fade',
                transitionSpeed: '400',
                disabledSteps: [],
                toolbarSettings: {
                    toolbarPosition: 'both',
                    toolbarExtraButtons: [
                        { label: 'Finish', css: 'btn-info', onClick: function () { alert('Finish Clicked'); } },
                        { label: 'Cancel', css: 'btn-danger', onClick: function () { $('#smartwizard').smartWizard("reset"); } }
                    ]
                }
            });
        </script>

        <script type="text/javascript">
            $('#smartwizard').smartWizard();
            $("#smartwizardFinancial").smartWizard();
            $("#submit").hide();
            $("#submit").hide();
            $("#coverPage").attr('required', true);
            //alert($("#projectName").val());
            $(document).ready(function () {
                $("#envelope").attr('checked', false);
                $("#smartwizard").hide();
                $("#smartwizardFinancial").hide();
                $("#submit").hide();
                $('input[type="radio"]').click(function () {
                    $("#projectModal").modal({ backdrop: "static", keyboard: false });
                    if ($(this).prop("checked") == true && $(this).prop("id") == "envelope") {
                        $("#smartwizard").show();
                        $("#smartwizardFinancial").show();
                        $("#oneEnvelop").attr("checked", false);
                        $("#submit").show();
                    } else if ($(this).prop("checked") == true && $(this).prop("id") == "oneEnvelop") {
                        //$("#smartwizardFinancial").show();
                        $("#smartwizard").show();
                        $("#envelope").attr("checked", false);
                        $("#submit").show();
                    }

                });
                function validate() {
                    var clientName = $("#clientName").val();
                    var department = $("#txtDepartment").val();
                    var projectName = $("#ProjName").val();
                    var description = $("#descriptionPro").val();
                    var ft = true;

                    if (clientName === "" || department === "" || projectName === "" || description === "") {
                        alert("NOTE: Clint Name, Department, Project Name and Description are Required fields.");
                        ft = false;
                    }
                    return ft;

                }
                $('#continue').click(function () {
                    var selectedEnvelop = $('#projectEnvelope :selected').text();
                    $("#submit").show();
                    if (!validate()) return false;
                    if (selectedEnvelop == "Two Envelop")
                        $("#envelopType").modal({ backdrop: "static", keyboard: false });
                    else {
                        $("#proposalDetails").prop("hidden", true);
                        $("#smartwizard").show();
                        $("#technicalId").show();
                        $("#envelopLabel").prop('hidden', true);
                        $("#financialId").hide();
                    }
                    return false;
                });
                $('#btnenvelopType').click(function () {
                    var selectedEnvelop = $('#typeEnvelop :selected').text();
                    $("#proposalDetails").prop("hidden", true);

                    if (selectedEnvelop === "Technical") {
                        $("#technicalId").show();
                        $("#financialId").hide();
                        $("#smartwizard").show();
                        $("#envelopLabel").prop('hidden', true);
                    }
                    else {
                        $("#technicalId").hide();
                        $("#financialId").show();
                        $("#smartwizardFinancial").show();
                        $("#envelopLabel").prop('hidden', true);
                    }
                });

                $('#submit').click(function () {

                    $("#isComplteModal").modal({ backdrop: "static", keyboard: false });
                    return false;
                });
                //$("#smartwizard").on("leaveStep", function (e, anchorObject, stepNumber) {

                //    return confirm("Do you want to leave the step " + stepNumber + "?");
                //});
                $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber) {
                    if (stepNumber === 15) {

                        $("#submit").show();
                        $("#SubmitButton").hide();
                    } else {
                        //$("#submit").hide();
                        $("#SubmitButton").show();
                    }

                });

                $('#smartwizard').bootstrapWizard({
                    'onNext': function (tab, navigation, index) {

                        if (index == 15) {
                            $("#SubmitButton").show();
                        } else {
                            $("#SubmitButton").show();
                        }
                        //if (index === 2) {
                        //    var value = $("#coverPage").val();

                        //    if ($("#coverPage").val() === "") {
                        //        alert("Field cannot be empty");
                        //        return;
                        //        //return false;
                        //    }

                        //    return true;
                        //}

                    },
                    'onTabShow': function (tab, navigation, index) {
                        console.log(index);
                        var $total = navigation.find('li').length;
                        var $current = index + 1;
                        if (index === 15) {
                            $("#SubmitButton").show();
                        } else {
                            $("#SubmitButton").show();
                        }
                        var $percent = ($current / $total) * 100;
                        $('#rootwizard .progress-bar').css({ width: $percent + '%' });
                    }
                });
                $('#rootwizard .finish').click(function () {

                    //alert('Finished!, Starting over!');
                    $('#rootwizard').find("a[href*='tab1']").trigger('click');
                });

                window.prettyPrint && window.prettyPrint();
            });
        </script>
    </form>

</body>

</html>
