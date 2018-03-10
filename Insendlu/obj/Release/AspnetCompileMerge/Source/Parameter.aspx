<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Parameter.aspx.cs" Inherits="Insendlu.Parameter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row-fluid">
            <h1 class="">Parameter Trace / Tracking</h1>
            <hr />
            <h3></h3>
            <%-- <div class="col-md-12">
                <asp:RadioButtonList ID="logreport" AutoPostBack="True" OnSelectedIndexChanged="logreport_OnSelectedIndexChanged" CssClass="radio radio-inline" runat="server">
                    <asp:ListItem Text="Day" Value="day" />
                    <asp:ListItem Text="Weekly" Value="week" />
                    <asp:ListItem Text="Monthly" Value="monthly"></asp:ListItem>
                </asp:RadioButtonList>
            </div>--%>
        </div>
        <br />
        <div class="row">
            <div class="col-md-6">

                <div class="panel-group">
                    <div class="panel panel-default" visible="True" id="panel" runat="server">
                        <a class="panel-default" data-toggle="collapse" data-parent="#accordion1" href="#collapseOne">
                            <div class="panel-heading">
                                <h3 class="panel-title" style="">Projected Expenditure for the
                                    <asp:Label runat="server" ID="lblProjLog"></asp:Label>
                                    project</h3>
                            </div>
                        </a>
                        <div id="collapseOne" class="panel-collapse collapse">
                            <div class="panel-body">
                                <br />
                                <h3>Estimated Costs</h3>
                               
                                <table class="table table-hover">
                                    <tr>
                                       <th style="font-size: large">Variable</th>
                                       <th></th>
                                       <th style="padding-left: 50px; font-size: large">Cost Estimate</th>

                                   </tr>
                                    <tr>
                                        <td>Accommodation</td>
                                        <td></td>
                                        <td style="padding-left: 50px">
                                            <asp:TextBox TextMode="Number" AccessKey="a" required="required" runat="server" ID="accommodation" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Employees</td>
                                        <td></td>
                                        <td style="padding-left: 50px">
                                            <asp:TextBox AccessKey="b" TextMode="Number" runat="server" required="required" ID="employees" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Vehicle</td>
                                        <td></td>
                                        <td style="padding-left: 50px">
                                            <asp:TextBox TextMode="Number" AccessKey="c" required="required" runat="server" ID="vehicle" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Telephone</td>
                                        <td>
                                            <label></label>
                                        </td>
                                        <td style="padding-left: 50px">
                                            <asp:TextBox AccessKey="d" TextMode="Number" required="required" runat="server" ID="telephone" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Refreshment</td>
                                        <td></td>
                                        <td style="padding-left: 50px">
                                            <asp:TextBox AccessKey="e" TextMode="Number" required="required" runat="server" ID="refreshment" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Print Material</td>
                                        <td></td>
                                        <td style="padding-left: 50px">
                                            <asp:TextBox AccessKey="f" TextMode="Number" required="required" runat="server" ID="material" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>WIFI / Data</td>
                                        <td></td>
                                        <td style="padding-left: 50px">
                                            <asp:TextBox AccessKey="g" TextMode="Number" required="required" runat="server" ID="fieldwork" CssClass="form-control"></asp:TextBox></td>
                                    </tr>

                                </table>
                                <br />
                                <table>
                                    <tr>
                                        <td style="padding-left: 155px">
                                            <asp:Button runat="server" ID="btnSaveEstimation" OnClick="btnSaveEstimation_OnClick" CssClass="btn-flat" Text="Save Estimation" /></td>
                                    </tr>
                                </table>
                                <br />
                                <%-- <asp:GridView runat="server" ID="logGrid" CssClass="table table-bordered table-hover" AllowPaging="True"
                                    CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#003300" BorderStyle="Solid"
                                    BorderWidth="1px" Font-Size="11pt" PageSize="10" Font-Names="Century">
                                    <RowStyle BackColor="#EFF3FB" BorderColor="Black" BorderWidth="1px" />
                                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#2461BF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                    
                                    <Columns>
                                        
                                        <%--<asp:Label runat="server" ID="assetName" Text="Here"></asp:Label>
                                         <asp:Label runat="server" ID="expenditure" Text="Here"></asp:Label>
                                         <asp:Label runat="server" ID="usage" Text="Here" ></asp:Label>
                                        <asp:Label runat="server" ID="result" Text="Here" ></asp:Label>--%>
                                <%-- <asp:TemplateField HeaderText="Asset Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="assetName" Text="Here"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                <%--<asp:TemplateField HeaderText="Projected Expenditure">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="expenditure" Text="Here"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Actual Usage">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="usage" Text="Here" ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Result">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="result" Text="Here" ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                <%--     </Columns>

                                </asp:GridView>--%>

                                <br />
                            </div>
                        </div>

                    </div>

                    
                </div>
            </div>
            <div class="col-lg-6">
                <div class="panel panel-default" visible="True" id="Div1" runat="server">
                        <a class="panel-default" data-toggle="collapse" style="background-color: green" data-parent="#accordion1" href="#collapseTwo">
                            <div class="panel-heading">
                                <h3 class="panel-title" style="">Parameters</h3>
                            </div>
                        </a>
                        <div id="collapseTwo" class="panel-collapse collapse">
                            <div class="panel-body">
                                <br />
                   
                                <h3>Parameters</h3>
                               <table class="table table-hover">
                                   <tr>
                                       <th style="font-size: large">Variable</th>
                                        <th style="font-size: large">Projected Cost</th>
                                       <th style="font-size: large">Actual Cost</th>
                                       <th style="font-size: large">Variance</th>

                                   </tr>
                                    <tr>
                                        <td>Accommodation</td>
                                        <td><asp:TextBox runat="server" ReadOnly="True" ID="accProjCost" CssClass="form-control"></asp:TextBox></td>
                                        <td><asp:TextBox ReadOnly="True" runat="server" ID="accomTotalCost" CssClass="form-control"></asp:TextBox></td>
                                        <td >
                                            <asp:TextBox ReadOnly="True" required="required" runat="server" ID="accomVariance" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Employees</td>
                                         <td><asp:TextBox runat="server" ReadOnly="True" ID="empProjecCost" CssClass="form-control"></asp:TextBox></td>
                                         <td><asp:TextBox runat="server" ReadOnly="True" ID="employeeTotalCost" CssClass="form-control"></asp:TextBox></td>
                                        <td >
                                            <asp:TextBox ReadOnly="True" runat="server" required="required" ID="employeeVariance" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Vehicle</td>
                                         <td><asp:TextBox runat="server" ReadOnly="True" ID="vProjecCost" CssClass="form-control"></asp:TextBox></td>
                                         <td><asp:TextBox ReadOnly="True" runat="server" ID="vehicleTotalCost" CssClass="form-control"></asp:TextBox></td>
                                        <td >
                                            <asp:TextBox ReadOnly="True" required="required" runat="server" ID="vehicleVariance" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Telephone</td>
                                         <td><asp:TextBox runat="server" ReadOnly="True" ID="telProjCost" CssClass="form-control"></asp:TextBox></td>
                                         <td><asp:TextBox runat="server" ID="telephoneTotalCost" ReadOnly="True" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox ReadOnly="True" required="required" runat="server" ID="telVariance" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Refreshment</td>
                                         <td><asp:TextBox runat="server" ID="refreshProjCost" ReadOnly="True" CssClass="form-control"></asp:TextBox></td>
                                        <td><asp:TextBox runat="server" ID="refreshmentCost" ReadOnly="True" CssClass="form-control"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox  required="required" runat="server" ReadOnly="True" ID="refreshVariance" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>Print Material</td>
                                         <td><asp:TextBox runat="server" ReadOnly="True" ID="printProjCost" CssClass="form-control"></asp:TextBox></td>
                                         <td><asp:TextBox runat="server" ID="printingTotalCost" ReadOnly="True" CssClass="form-control"></asp:TextBox></td>
                                        <td >
                                            <asp:TextBox required="required" runat="server" ReadOnly="True" ID="printVariance" CssClass="form-control"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>WIFI / Data</td>
                                         <td><asp:TextBox runat="server" ReadOnly="True" ID="wifiProjCost" CssClass="form-control"></asp:TextBox></td>
                                        <td><asp:TextBox runat="server" ID="materialTotalCost" CssClass="form-control" ReadOnly="True"></asp:TextBox></td>
                                        <td>
                                            <asp:TextBox  required="required" runat="server" ReadOnly="True" ID="materialVariance" CssClass="form-control"></asp:TextBox></td>
                                    </tr>

                                </table>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
    </div>

</asp:Content>
