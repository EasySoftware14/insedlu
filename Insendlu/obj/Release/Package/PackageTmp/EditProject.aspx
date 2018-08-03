<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProject.aspx.cs" Inherits="Insendlu.EditProject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit.HtmlEditor" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Project</title>
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

        <%--<div class="modal fade" id="projectModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal fade" id="projectModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <%--                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>--%>
        <%--                   <br/>
                        <i class="fa fa-exclamation-triangle fa-7x"></i>
                        <h2 class="semi-bold">Proposal Category</h2>
                        <hr />
                        <label for="proposalType">Category</label>
                        <asp:DropDownList runat="server" class="form-control" DataValueField="id" DataTextField="name" ID="proposalType"></asp:DropDownList>
                        <br/>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-link" data-dismiss="modal">Close</button>
                        <button id="projSpec" type="button" onclick="javascript:_doPostBack('ButtonA','');" class="btn btn-info" data-dismiss="modal">Submit</button>
                    </div>

                </div>
            </div>
        </div>
    </div>--%>

        <div class="container">
            <h2>Envelop System </h2>
            <br />
            <div id="smartwizard">
                <ul>
                    <li><a href="#step-1">Step 1<br />
                        <small>Proposal Details</small></a></li>
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
                        <small>Risk Analysis</small></a></li>
                    <li><a href="#step-13">Step 12<br />
                        <small>BBBEE Status</small></a></li>
                    <li><a href="#step-14">Step 13<br />
                        <small>Why Choose Us</small></a></li>
                    <li><a href="#step-15">Step 14<br />
                        <small>Conclusion</small></a></li>
                </ul>
                <div>
                <div id="step-1" class="">
                    <h2 class="top-content">Proposal Details</h2>
                    <hr />
                    <label>Client Name</label><br />
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
                    <label for="projectName">Proposal Name</label><br />
                    <input type="text" runat="server" required="required" class="form-control" id="ProjName" /><br />
                    <label>Proposal Description</label><br />
                    <asp:TextBox runat="server" Height="150" ValidateRequestMode="Enabled" TextMode="MultiLine" CssClass="form-control" ID="descriptionPro"></asp:TextBox>
                    <br />
                </div>
                    <div id="step-16" class="">
                        <label for="preparedFor"> Prepared For</label><br/>
                        <asp:TextBox runat="server" ID="preparedFor" CssClass="form-control"></asp:TextBox><br/>
                        <label for="preparedBy"> Prepared By</label><br/>
                        <asp:TextBox runat="server" ID="preparedBy" CssClass="form-control"></asp:TextBox><br/>
                        <label for="reasonForProposal">Reason For Proposal</label><br/>
                        <asp:TextBox runat="server" ID="reasonForProposal" CssClass="form-control"></asp:TextBox><br/>
                        <label>Address</label><br/>
                            <asp:TextBox runat="server"  placeholder="Line 1" ID="line1" CssClass="form-control"></asp:TextBox><br/>
                            <asp:TextBox runat="server"  placeholder="Line 2" ID="line2" CssClass="form-control"></asp:TextBox><br/>
                            <asp:TextBox runat="server"  placeholder="Surburb" ID="surburb" CssClass="form-control"></asp:TextBox><br/>
                            <asp:TextBox runat="server"  placeholder="Postal Code" ID="postalCode" CssClass="form-control" ></asp:TextBox><br/>
                            <asp:TextBox runat="server"  placeholder="Telephone Number" ID="telNumber" CssClass="form-control"></asp:TextBox><br/>
                            <asp:TextBox runat="server"  placeholder="Fax" ID="fax" CssClass="form-control"></asp:TextBox><br/>
                            <asp:TextBox runat="server"  placeholder="Email Address" ID="emailAddress" CssClass="form-control"></asp:TextBox><br/>
                            <asp:TextBox runat="server"  placeholder="CC" ID="cc" CssClass="form-control"></asp:TextBox><br/>
                        <br/>
                        <label for="confidentialStatement"> Statement Of Confidentiality</label> <br/>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="confidentialStatement" ForeColor="red" CssClass="form-control" Height="300"></asp:TextBox><br/>
                       <%-- <cc1:Editor ID="coverPage" Content="" ValidateRequestMode="Enabled" AutoFocus="True" runat="server" Height="250"></cc1:Editor>--%>
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
                     <br/>
                         <asp:UpdatePanel runat="server" ID="uploadPanel">
                            <ContentTemplate>
                                <asp:GridView ID="costPlanGrid" CssClass="table table-bordered table-hover" AllowCustomPaging="True" runat="server" AutoGenerateColumns="false" EmptyDataText="No files uploaded">
                                    <Columns>
                                        <asp:BoundField DataField="Text" HeaderText="File Name" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="lnkDownload" OnCommand="lnkDownload_OnCommand" CssClass="btn-block" Text="Download" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick="lnkDownload_OnClick"></asp:Button>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="lnkDelete" OnCommand="lnkDelete_OnCommand" CssClass="btn-block" Text="Delete" CommandArgument='<%# Eval("Value") %>' runat="server" OnClick="lnkDelete_OnClick" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                    </Columns>
                                </asp:GridView>
                                <br/> <br/>
                                <asp:FileUpload runat="server" ID="uploadfile" CssClass="file-image" AllowMultiple="True"/>
                            </ContentTemplate>
                        </asp:UpdatePanel>

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
                                                <label for="projValue">Project Value</label>
                                                <asp:TextBox runat="server" ID="projValue" CssClass="form-control"></asp:TextBox>
                                                
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
                        <cc1:Editor ID="whyChoose" runat="server" Height="250" TargetControlID="txtEditor"></cc1:Editor>
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
                <asp:Button CssClass="btn btn-primary" Visible="False" ID="SubmitButton" OnClick="Update_OnClick" Text="Update" runat="server"></asp:Button>
                <button id="submit" hidden="" class="btn btn-success" onclick="javascript:_doPostBack('submit','');">Update</button>
                <%--OnClick="SubmitButton_OnClick"--%>
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
            $("#submit").hide();
            $("#projectModal").modal({ backdrop: "static", keyboard: false });
            $("#coverPage").attr('required', true);
            //alert($("#projectName").val());
            $(document).ready(function () {

                //$("#smartwizard").on("leaveStep", function (e, anchorObject, stepNumber) {

                //    return confirm("Do you want to leave the step " + stepNumber + "?");
                //});
                $("#smartwizard").on("showStep", function (e, anchorObject, stepNumber) {

                    if (stepNumber === 13) {

                        $("#submit").show();
                    } else {
                        $("#submit").hide();
                    }

                });

                $("#SubmitButton").hide();
                $('#smartwizard').bootstrapWizard({
                    'onNext': function (tab, navigation, index) {

                        if (index == 13) {
                            $("#SubmitButton").show();
                        } else {
                            $("#SubmitButton").hide();
                        }
                        if (index === 2) {
                            var value = $("#coverPage").val();

                            if ($("#coverPage").val() === "") {
                                alert("Field cannot be empty");
                                return;
                                //return false;
                            }
                            return true;
                        }

                    },
                    'onTabShow': function (tab, navigation, index) {
                        console.log(index);
                        var $total = navigation.find('li').length;
                        var $current = index + 1;
                        if (index === 13) {
                            $("#SubmitButton").show();
                        } else {
                            $("#SubmitButton").hide();
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

