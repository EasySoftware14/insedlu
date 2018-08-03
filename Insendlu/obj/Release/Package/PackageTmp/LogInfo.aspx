<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LogInfo.aspx.cs" Inherits="Insendlu.LogInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <label><span class="" style="font-size: xx-large"> Project Variables</span></label>
            <hr />
        </div>
        <br />
        <div class="row">
            <div class="col-lg-12">
                <table>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" Width="825" required="required" Wrap="True" ID="start_period" ReadOnly="True" Placeholder="Select Date" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-11">
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Animated="True" TodaysDateFormat="dd/mm/yyyy" TargetControlID="start_period" runat="server" />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ForeColor="red" ControlToValidate="wifiCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ForeColor="red" ControlToValidate="telCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ForeColor="red" ControlToValidate="refCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ForeColor="red" ControlToValidate="vCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ForeColor="red" ControlToValidate="vUnitCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="red" ControlToValidate="matCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ForeColor="red" ControlToValidate="matUnitCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="red" ControlToValidate="empCostPerDay" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="red" ControlToValidate="empUnitCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="accCost" runat="server" ForeColor="red" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator11"  ControlToValidate="accUnitCost" runat="server" ForeColor="red" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>

            </div>
        </div>
        <div class="row">
            <div class="col-md-12 ">
                <br />
                <table id="logWork">
                    <tr>
                        <th>
                            <label class="">Accommodation  </label>
                            &nbsp;&nbsp;</th>
                        <td>
                            
                            <asp:TextBox runat="server" ID="accLocation" ToolTip="Location" Placeholder="Location" CssClass="form-control"></asp:TextBox>
                        </td>
                        
                        <td>
                            <asp:TextBox runat="server" ToolTip="Total Cost" ID="accUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>
                        </td>
                      <td>
                            <asp:TextBox runat="server" ToolTip="Total Cost" ID="accCost" Placeholder="Total Cost" CssClass="form-control"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <label class="label-danger  align-right">Employees  </label>
                            &nbsp;&nbsp;</th>
                        <td>
                            <asp:TextBox runat="server" ToolTip="Employee Type" ID="empType" Placeholder="Employee Type" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ToolTip="Number Of employees" ID="empNumber" Placeholder="Number Of Employees" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ToolTip="Employee Cost a day" ID="empUnitCost" Placeholder="Unit Cost a day" CssClass="form-control"></asp:TextBox>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ToolTip="Employee Cost a day" ID="empCostPerDay" Placeholder="Employee Cost a day" CssClass="form-control"></asp:TextBox>

                        </td>
                        <td><acUc:Accounting  ID="acc" runat="server"></acUc:Accounting></td>
                    </tr>

                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <label class="">Print Material  </label>
                            &nbsp;&nbsp;</th>

                        <td>
                            <asp:TextBox runat="server" ID="materialName" Placeholder="Material Name" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="matQuantity" Placeholder="Material Quantity" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="matUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="matCost" Placeholder="Material Cost" CssClass="form-control"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <label class="label-danger  align-right">Vehicle</label>
                            &nbsp;&nbsp;</th>

                        <td>
                            <asp:TextBox runat="server" ID="vType" Placeholder="Vehicle Type" CssClass="form-control"></asp:TextBox></td>

                        <td>
                            <asp:TextBox runat="server" ID="vMilage" Placeholder="Vehicle Mileage" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="vUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="vCost" Placeholder="Vehicle Cost" CssClass="form-control"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <label class="">Refreshments </label>
                            &nbsp;&nbsp;</th>

                        <td>
                            <asp:TextBox runat="server" ID="RefUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="refCost" Placeholder="Refreshment Cost" CssClass="form-control"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <label class="label-danger  align-right">Telephone  </label>
                            &nbsp;&nbsp;</th>

                        <td>
                            <asp:TextBox runat="server" ID="telephoneUnitCost" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="telCost" Placeholder="Telephone Cost" CssClass="form-control"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <th>
                            <label class="">WIFI / Data  </label>
                            &nbsp;&nbsp;</th>

                        <td>
                            <asp:TextBox runat="server" ID="wifiCosteach" Placeholder="Unit Cost" CssClass="form-control"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="wifiCost" Placeholder="WIFI Cost" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            <label class="label-danger  align-right">Field Work Statistics  </label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                        <td>
                            <asp:TextBox runat="server" ID="pulseUnitCost" Placeholder="Unit Cost" ToolTip="Pulse Count" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="pulseCount" TextMode="Number" Placeholder="Pulse Count" ToolTip="Pulse Count" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <select runat="server" datavaluefield="id" datatextfield="name" class="select2 dropdown-caret-right dropdown-100" id="fieldWorkDrop"></select>
                            <%--                                <asp:DropDownList runat="server" ID="fieldWorkDrop" DataTextField="name" DataValueField="id" Placeholder="Field Work Type" CssClass="form-control dropdown"></asp:DropDownList>--%>
                        </td>
                    </tr>
                </table>
                <br />
                
                <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender3" Animated="True"  TodaysDateFormat="dd/mm/yyyy" TargetControlID="matStartDate" runat="server" />
                
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Animated="True"  TodaysDateFormat="dd/mm/yyyy" TargetControlID="vStartDate" runat="server" />
             
                <ajaxToolkit:CalendarExtender ID="CalendarExtender7" Animated="True"  TodaysDateFormat="dd/mm/yyyy" TargetControlID="wifiStartDate" runat="server" />
             
                <ajaxToolkit:CalendarExtender ID="CalendarExtender9" Animated="True"  TodaysDateFormat="dd/mm/yyyy" TargetControlID="refStartDate" runat="server" />
             
                <ajaxToolkit:CalendarExtender ID="CalendarExtender11" Animated="True"  TodaysDateFormat="dd/mm/yyyy" TargetControlID="telStartDate" runat="server" />
             
                <ajaxToolkit:CalendarExtender ID="CalendarExtender13" Animated="True"  TodaysDateFormat="dd/mm/yyyy" TargetControlID="empStart" runat="server" />
             
                <ajaxToolkit:CalendarExtender ID="CalendarExtender15" Animated="True"  TodaysDateFormat="dd/mm/yyyy" TargetControlID="fieldStartDate" runat="server" />--%>
            </div>
            <br />
        </div>
        <div class="row">
            <div class="col-md-offset-4">
                <asp:Button runat="server" ID="backBtn" Text="Go Back" CssClass="btn-flat" OnClick="backBtn_OnClick" />
                | 
                    <asp:Button runat="server" ID="saveLoggedInfo" OnClick="saveLoggedInfo_OnClick" Text="Save Work Log" CssClass="btn btn-success" />
            </div>
        </div>
    </div>

</asp:Content>
