<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewLogs.aspx.cs" Inherits="Insendlu.UserPages.ViewLogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <h1 class="">Logging View / Edit
                <br />
                
               </h1>
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
                            <asp:TextBox runat="server" ID="start_period" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="end_period" ReadOnly="True" ToolTip="End Period Date" Placeholder="End Period" CssClass="form-control"></asp:TextBox></td>

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
                            <asp:TextBox runat="server" ID="empStart" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="empEndDate" ReadOnly="True" ToolTip="End Period Date" Placeholder="End Period" CssClass="form-control"></asp:TextBox></td>
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
                            <asp:TextBox runat="server" ID="matStartDate" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="matEndDate" ReadOnly="True" ToolTip="End Period Date" Placeholder="End Period" CssClass="form-control"></asp:TextBox></td>

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
                            <asp:TextBox runat="server" ID="vStartDate" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="vEndDate" ReadOnly="True" Placeholder="End Period" ToolTip="End Period Date" CssClass="form-control"></asp:TextBox></td>
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
                            <asp:TextBox runat="server" ID="refEndDate" ReadOnly="True" Placeholder="Start Period" ToolTip="End Period Date" CssClass="form-control"></asp:TextBox></td>
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
                            <asp:TextBox runat="server" ID="telStartDate" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="telEndDate" ReadOnly="True" Placeholder="Start Period" ToolTip="End Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="telCost" Placeholder="Telephone Cost" CssClass="form-control"></asp:TextBox></td>

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
                            <asp:TextBox runat="server" ID="wifiStartDate" ReadOnly="True" Placeholder="Start Period" ToolTip="Start Period Date" CssClass="form-control"></asp:TextBox></td>
                        <td>
                            <asp:TextBox runat="server" ID="wifiEndDate" ReadOnly="True" Placeholder="Start Period" ToolTip="End Period Date" CssClass="form-control"></asp:TextBox></td>

                        <td>
                            <asp:TextBox runat="server" ID="wifiCost" Placeholder="WIFI Cost" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="Start_period" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="end_period" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender3" TargetControlID="matStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender4" TargetControlID="matEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender5" TargetControlID="vStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender6" TargetControlID="vEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender7" TargetControlID="wifiStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender8" TargetControlID="wifiEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender9" TargetControlID="refStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender10" TargetControlID="refEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender11" TargetControlID="telStartDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender12" TargetControlID="telEndDate" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender13" TargetControlID="empStart" runat="server" />
                <ajaxToolkit:CalendarExtender ID="CalendarExtender14" TargetControlID="empEndDate" runat="server" />
            </div>
            <br />

            <div class="row">
                <div class="col-md-offset-4">
                    <a href="#" id="exitLogged" class="btn-link-2">Back</a> |
                    <asp:Button runat="server" ID="Button1" OnClick="saveLoggedInfo_OnClick" Text="Update Logged Info" CssClass="btn btn-success" />
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
