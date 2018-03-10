<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="AddLog.aspx.cs" Inherits="Insendlu.AddLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Logging Work</h1>
    <hr />

    <div class="container-fluid" id="newWork" runat="server" visible="True">
        <div class="row-fluid">
            <div class="span12">
                <div class="grid simple ">
                    <div class="grid-body ">

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="form-group">
                                    <br />
                                    <label class="form-label"><span class="text-error" style="color: red">*</span> Name</label>
                                    <div class="input-with-icon  right">
                                        <input type="text" id="logName" runat="server" required="required" class="form-control" />
                                    </div>
                                    <br />
                                    <label class="form-label"><span class="text-error" style="color: red">*</span> Sector</label>
                                    <div class="input-with-icon  right">
                                        <asp:DropDownList runat="server" ID="drpSector" Required="Required" DataValueField="id" DataTextField="name" Width="200" CssClass="select2 dropdown-caret-right dropdown-100" />
                                    </div>
                                    <br />
                                    <label class="form-label"><span class="text-error" style="color: red">*</span> Duration</label>
                                    <div class="input-with-icon  right">
                                        <table>
                                            <tr>
                                                <td>
                                                    <input type="number" id="logduration" runat="server" required="required" class="form-control" /></td>
                                                <td>
                                                    <select id="durationType" datavaluefield="id" datatextfield="name" style="width: 250px" runat="server" required="required" class="dropdown-caret-right"></select></td>
                                            </tr>
                                        </table>

                                    </div>
                                    <br />
                                    <label class="form-label"><span class="text-error" style="color: red">*</span> Project Administrator</label>
                                    <div class="input-with-icon  right">
                                        <select id="logadmin" datavaluefield="id" datatextfield="name" style="width: 250px" runat="server" required="required" class="dropdown-caret-right"></select>
                                        <ajaxToolkit:DropDownExtender ID="DropDownExtender1" TargetControlID="logadmin" runat="server"></ajaxToolkit:DropDownExtender>
                                    </div>
                                    <br />
                                    <div class="input-with-icon  right">
                                        <asp:LinkButton runat="server" ID="cancel" Text=" Cancel" CssClass="fa fa-backward" OnClick="cancel_OnClick"></asp:LinkButton>
                                        <asp:Button runat="server" Text="Save" ID="logSave" OnClick="logSave_OnClick" CssClass="btn btn-sm btn-success" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container" id="existingproject" runat="server" visible="false">
        <div class="row">
            <div class="col-lg-11">
                <br />
                <asp:GridView runat="server" Visible="True" ID="datagridview" CssClass="table table-bordered table-hover" AllowPaging="True"
                    CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#003300" BorderStyle="Solid"
                    BorderWidth="1px" Font-Size="11pt" PageSize="10" Font-Names="Century" OnPageIndexChanging="datagridview_PageIndexChanging"
                    OnRowCommand="datagridview_RowCommand" AutoGenerateColumns="False" OnRowEditing="datagridview_OnRowEditing" DataKeyNames="id">
                    <RowStyle BackColor="#EFF3FB" BorderColor="Black" BorderWidth="1px" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <EditRowStyle BackColor="#2461BF" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblId" Text='<%# Eval("id") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Project Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblProjName" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Created Date">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDate" Text='<%# Eval("created_at","{0:D}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:ButtonField ButtonType="Button" Text="Log Work" CommandName="action"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />

                    </Columns>
                </asp:GridView>
                <br />

                <label class="label-default" runat="server" id="propStatus"></label>

            </div>
        </div>
    </div>

</asp:Content>
