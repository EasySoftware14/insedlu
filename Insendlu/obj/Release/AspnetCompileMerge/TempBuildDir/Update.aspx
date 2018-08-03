<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="Insendlu.Update" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h2>UPDATE</h2>
        </div>

    </div>
    <hr />
    <div class="row">
        <div class="col-lg-4">
            <button id="assetUpdate" type="button" class="btn btn-lighter btn-success"> Assets / Variables</button>
        </div>
        <div class="col-lg-4">
            <button id="updateMembers" type="button" class="btn btn-app btn-info"> Members</button>
        </div>
        <div class="col-lg-4">
            <button id="documentUpate" type="button" class="btn btn-lighter btn-flat"> Additional Documents</button>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-lg-12">
            <div class="panel" id="assetPanel" hidden="">
                <br />
                <div class="panel-group">
                    <div class="panel panel-info">
                        <a class="panel-success" data-toggle="collapse" data-parent="#accordion1" href="#collapseOne">
                            <div class="panel-heading">
                                <h3 class="panel-title" style="color: lightblue; font-size: x-large"> LOG WORK </h3>
                            </div>
                        </a>
                        <div id="collapseOne" class="collapse">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label style="font-size: large">DATE</label>
                                        <br />
                                        <asp:TextBox runat="server" required="required" Wrap="True" ID="start_period" ReadOnly="True" Placeholder="Select Date" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Animated="True" TodaysDateFormat="dd/mm/yyyy" TargetControlID="start_period" runat="server" />
                                        <br />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label style="font-size: large">Accommodation  </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="accLocation" ToolTip="Location" Placeholder="Location" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ToolTip="Total Cost" ID="accUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ToolTip="Total Cost" ID="accCost" Placeholder="Total Cost" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label style="font-size: large">Employees  </label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ToolTip="Employee Type" ID="empType" Placeholder="Employee Type" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ToolTip="Number Of employees" ID="empNumber" Placeholder="Number Of Employees" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ToolTip="Employee Cost a day" ID="empUnitCost" Placeholder="Unit Cost a day" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ToolTip="Employee Cost a day" ID="empCostPerDay" Placeholder="Employee Cost a day" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label style="font-size: large">Print Material  </label>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="materialName" Placeholder="Material Name" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="matQuantity" Placeholder="Material Quantity" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="matUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="matCost" Placeholder="Material Cost" CssClass="form-control"></asp:TextBox>

                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label style="font-size: large">Vehicle</label>
                                        &nbsp;&nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="vType" Placeholder="Vehicle Type" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="vMilage" Placeholder="Vehicle Mileage" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="vUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>

                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="vCost" Placeholder="Vehicle Cost" CssClass="form-control"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label style="font-size: large">Refreshments </label>
                                        &nbsp;&nbsp;

                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="RefUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="refCost" Placeholder="Refreshment Cost" CssClass="form-control"></asp:TextBox>

                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label style="font-size: large">Telephone  </label>
                                        &nbsp;&nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="telephoneUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="telCost" Placeholder="Telephone Cost" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label style="font-size: large">WIFI / Data  </label>
                                        &nbsp;&nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="wifiCosteach" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="wifiCost" Placeholder="WIFI Cost" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <label style="font-size: large">Field Work Statistics  </label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="pulseUnitCost" Placeholder="Unit Cost" ToolTip="Pulse Count" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <asp:TextBox runat="server" ID="pulseCount" TextMode="Number" Placeholder="Pulse Count" ToolTip="Pulse Count" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-lg-3">
                                        <select runat="server" datavaluefield="id" datatextfield="name" class="select2 dropdown-caret-right dropdown-100" id="fieldWorkDrop"></select>
                                    </div>
                                </div>

                                <div class="panel" id="moreAsset">
                                    <br />
                                    <div class="panel-group">
                                        <div class="panel panel-info">
                                            <a class="panel-info" data-toggle="collapse" data-parent="#accordion1" href="#collapseMore">
                                                <div class="panel-heading">
                                                    <h3 class="panel-title" style="color: lightsalmon; font-size: x-large"> More Assets </h3>
                                                </div>
                                            </a>
                                            <div id="collapseMore" class="collapse">
                                                <div class="panel-body">

                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <label style="font-size: large"> Project Management Fees  </label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" placeholder="Total Cost" CssClass="form-control" ID="projeManagTotalCost"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <label style="font-size: large">Contingency Fees  </label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" Placeholder="Total Cost" CssClass="form-control" ID="contiTotalCost"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <label style="font-size: large">Survey Monkey  </label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" Placeholder="Total Cost" CssClass="form-control" ID="survTotalCost"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <label style="font-size: large">Data Analyst  </label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" PlaceHolder="Employee" CssClass="form-control" ID="dataEmployee"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" Placeholder="Total Cost" CssClass="form-control" ID="dataTotalCost"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <label style="font-size: large">Logistics  </label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" PlaceHolder="Details" CssClass="form-control" ID="logDetails"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" PlaceHolder="Unit Cost" CssClass="form-control" ID="logUnitCost"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" PlaceHolder="Total Cost" CssClass="form-control" ID="logTotalCost"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <label style="font-size: large">Sustenance Fees  </label>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" PlaceHolder="Detail" CssClass="form-control" ID="sustFeesDetail"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" PlaceHolder="Unit Cost" CssClass="form-control" ID="sustFeesUnitCost"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-3">
                                                            <asp:TextBox runat="server" PlaceHolder="Total Cost" CssClass="form-control" ID="sustFeesTotalCost"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <br />
                                        <asp:Button runat="server" ID="saveLoggedInfo" OnClick="saveLoggedInfo_OnClick" Text="Save Work Log" CssClass="btn btn-app btn-block" />
                                        <asp:Button runat="server" ID="backBtn" Text="Go Back" CssClass="btn btn-danger btn-block" OnClick="backBtn_OnClick" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-12">
        <div class="panel" id="membersPanel" hidden="">
            <div class="panel-group">
                <div class="panel panel-info">
                    <a class="panel-info" data-toggle="collapse" data-parent="#accordion1" href="#collapseThree">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="color: brown">Add Members </h3>
                        </div>
                    </a>
                    <div id="collapseThree" class="">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <label for="userList" style="font-size: x-large"><span class="fa fa-users"></span> Select User (s)</label>
                                    <br />
                                    <asp:ListBox runat="server" Width="400" CssClass="select2" ID="userList" SelectionMode="Multiple" DataValueField="id" DataTextField="name" />
                                </div>
                                <div class="col-lg-6">
                                    <label style="font-size: x-large"><span class="fa fa-user"></span> Non System User</label><br/>
                                    <asp:TextBox runat="server" CssClass="form-control" PlaceHolder="Non System User Member" ID="nonSystemUser"></asp:TextBox><br/>
                                    <label style="font-size: x-large"><span class="fa fa-binoculars"></span> Role</label><br/>
                                    <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="memberDuty"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <br />
                                    <asp:Button runat="server" ID="btnAddUsers" Text="Add Member(s)" CssClass="btn btn-app btn-block" OnClick="btnAddUsers_OnClick" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <div class="col-lg-12">
        <div class="panel" id="documentsPanel" hidden="">
            <div class="panel-group">
                <div class="panel panel-info">
                    <a class="panel-info" data-toggle="collapse" data-parent="#accordion1" href="#collapseTwo">
                        <div class="panel-heading">
                            <h3 class="panel-title" style="color: lightsalmon">Upload Supporting Documents </h3>
                        </div>
                    </a>
                    <div id="collapseTwo" class="">
                        <div class="panel-body">
                            <br />
                            <asp:FileUpload runat="server" ID="uploadDocs" AllowMultiple="True" CssClass="fa-upload" />

                            <br />
                            <br />

                            <asp:Button runat="server" ID="attachDocs" OnClick="attachDocs_OnClick" CssClass="btn btn-success" Text="Attach Document(s)" />
                            <br />
                            <br />
                            <label class="label-success" runat="server" id="success"></label>
                            <%--<ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" AllowedFileTypes="doc,docx,pdf" OnUploadComplete="AjaxFileUpload1_OnUploadComplete" runat="server" />--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
