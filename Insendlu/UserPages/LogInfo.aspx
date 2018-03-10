<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="LogInfo.aspx.cs" Inherits="Insendlu.UserPages.LogInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <h1 class="">Logging Information for
                <br />
                <br />
                <span class="label-pink" style="text-align: center">Chosen Assets</span></h1>
            <hr />
        </div>
        <div class="row">
            <div class="col-md-12">
                <br />
                <table id="logWork">
                    <tr>
                        <td>
                            <label class="">Accommodation  </label>
                            &nbsp;&nbsp;</td>

                        <td>
                            <asp:TextBox runat="server" ID="start_period" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="end_period" TextMode="Date" ReadOnly="True" ToolTip="End Period Date" Placeholder="End Period" CssClass="form-control"></asp:TextBox></td>

                        <td>
                            <asp:TextBox runat="server" ID="accLocation" ToolTip="Location" Placeholder="Location" CssClass="form-control"></asp:TextBox></td>

                        <td>
                            <asp:TextBox runat="server" ToolTip="Total Cost" ID="accCost" Placeholder="Total Cost" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <label class="label-danger  align-right">Employees  </label>
                            &nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="empStart" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="empEndDate" TextMode="Date" ReadOnly="True" ToolTip="End Period Date" Placeholder="End Period" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ToolTip="Employee Type" ID="empType" Placeholder="Employee Type" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ToolTip="Number Of employees" ID="empNumber" Placeholder="Number Of Employees" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ToolTip="Employee Cost a day" ID="empCostPerDay" Placeholder="Employee Cost a day" CssClass="form-control"></asp:TextBox></td>



                    </tr>

                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="">Print Material  </label>
                            &nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="matStartDate" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="matEndDate" TextMode="Date" ReadOnly="True" ToolTip="End Period Date" Placeholder="End Period" CssClass="form-control"></asp:TextBox></td>

                        <td>
                            <asp:TextBox runat="server" ID="materialName" Placeholder="Material Name" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="matQuantity" Placeholder="Material Quantity" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="matCost" Placeholder="Material Cost" CssClass="form-control"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <label class="label-danger  align-right">Vehicle  </label>
                            &nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="vStartDate" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="vEndDate" ReadOnly="True" Placeholder="Start Period" ToolTip="End Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="vType" Placeholder="Vehicle Type" CssClass="form-control"></asp:TextBox></td>

                        <td>
                            <asp:TextBox runat="server" ID="vMilage" Placeholder="Vehicle Mileage" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="vCost" Placeholder="Vehicle Cost" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <label class="">Refreshments </label>
                            &nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="refStartDate" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="refEndDate" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="End Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="refCost" Placeholder="Refreshment Cost" CssClass="form-control"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <label class="label-danger  align-right">Telephone  </label>
                            &nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="telStartDate" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="telEndDate" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="End Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="telCost" TextMode="Date" Placeholder="Telephone Cost" CssClass="form-control"></asp:TextBox></td>

                    </tr>
                    <tr>
                        <td>
                            <label></label>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <label class="">WIFI / Data  </label>
                            &nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="wifiStartDate" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="wifiEndDate" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="End Period Date" CssClass="form-control"></asp:TextBox></td>

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
                        <td>
                            <label class="label-danger  align-right">Field Work Statistics  </label>
                            &nbsp;&nbsp;</td>
                        <td>
                            <asp:TextBox runat="server" ID="fieldStartDate" TextMode="Date" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="fieldEndDate" TextMode="Date" ReadOnly="True" Placeholder="End Period" ToolTip="End Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <select runat="server" datavaluefield="id" datatextfield="name" class="select2 dropdown-caret-right dropdown-100" id="fieldWorkDrop"></select>
<%--                                <asp:DropDownList runat="server" ID="fieldWorkDrop" DataTextField="name" DataValueField="id" Placeholder="Field Work Type" CssClass="form-control dropdown"></asp:DropDownList>--%>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="pulseCount" TextMode="Number" Placeholder="Pulse Count" ToolTip="Pulse Count" CssClass="form-control"></asp:TextBox></td>
                    </tr>
                </table>
                <br />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="start_period" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="end_period" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="matStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="matEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="vStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="vEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender7" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="wifiStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender8" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="wifiEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender9" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="refStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender10" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="refEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender11" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="telStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender12" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="telEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender13" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="empStart" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender14" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="empEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender15" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="fieldStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender16" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="fieldEndDate" runat="server" />

            </div>
            <br />

            <div class="row">
                <div class="col-md-offset-4">
                    <asp:Button runat="server" ID="saveLoggedInfo" OnClick="saveLoggedInfo_OnClick" Text="Save Logged Info" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
