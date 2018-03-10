<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Approved.aspx.cs" Inherits="Insendlu.UserPages.Approved" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <div class="col-lg-6">
                <h1 class="">Work Logging</h1>
                <br />
                <asp:Button runat="server" ID="btnView" CssClass="btn-corner" OnClick="btnView_OnClick" Visible="False" Text="View Previous Logs" />
                |
                <asp:Button runat="server" ID="research"  Text="Research" CssClass="btn-corner" OnClick="research_OnClick" />
                |
                                <asp:Button runat="server" ID="consultancy" Text="Consultancy" CssClass="btn-corner" OnClick="consultancy_OnClick" />

            </div>
            
        </div>
        <div class="row" id="calenId">
            <div class="col-lg-4">
                <hr />
                <label for="cal" class="label-pink">Choose Date</label><br />
                <asp:TextBox runat="server" ID="cal" ReadOnly="True" TextMode="Date" CausesValidation="True"></asp:TextBox>
                <br />
                <br />
                <label for="" class="label-pink">Please Select Assets used</label>
                <br />
                <asp:CheckBox runat="server" Checked="False" CssClass="checkbox-inline" ID="employees" Text=" Employees" /><br />
                <asp:CheckBox runat="server" Checked="False" CssClass="checkbox-inline" ID="vehicle" Text=" Vehicle" /><br />
                <asp:CheckBox runat="server" Checked="False" CssClass="checkbox-inline" ID="accomodation" Text=" Accommodation" /><br />
                <asp:CheckBox runat="server" Checked="False" CssClass="checkbox-inline" ID="printMaterial" Text=" Print Material" /><br />
                <asp:CheckBox runat="server" Checked="False" CssClass="checkbox-inline" ID="refreshment" Text=" Refreshments" /><br />
                <asp:CheckBox runat="server" Checked="False" CssClass="checkbox-inline" ID="telephone" Text=" Telephone" /><br />
                <asp:CheckBox runat="server" Checked="False" CssClass="checkbox-inline" ID="wifi" Text=" WiFi / Data Allowance" /><br />
                <asp:CheckBox runat="server" Checked="False" CssClass="checkbox-inline" ID="fieldwork" Text=" Field Work Statistics" /><br />
                <br />
                <asp:Label runat="server" ID="lblError" ForeColor="red"></asp:Label>
                <br />
                <ajaxToolkit:CalendarExtender ID="startWork" Animated="True" Format="dd/MM/yyyy" TodaysDateFormat="dd/mm/yyyy" TargetControlID="cal" DefaultView="Days" runat="server" />
                <br />
                <br />
                <asp:LinkButton runat="server" ID="back" CssClass="fa-backward" OnClick="back_OnClick" Text=" Back"></asp:LinkButton>
                | 
                <asp:Button runat="server" ID="work" Text="Log Work" CssClass="bg-success" OnClick="work_OnClick" />
            </div>
            <div class="col-lg-6 col-lg-offset-1">
                <hr />
                <br />
                <h2 id="propName" runat="server" class="label-danger"></h2>
                
                <br />
                <asp:GridView runat="server" ID="datagridview" CssClass="table table-bordered table-hover" AllowPaging="True"
                    CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#003300" BorderStyle="Solid"
                    BorderWidth="1px" Font-Size="11pt" PageSize="10" Font-Names="Century"
                    AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="datagridview_OnRowCommand" OnRowDeleting="datagridview_OnRowDeleting">
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

                        <asp:TemplateField HeaderText="Document Name">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblProjName" Text='<%# Eval("name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:ButtonField ButtonType="Button" Text="Download" CommandName="Download"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                        <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="Delete"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />

                    </Columns>
                </asp:GridView>

                <h2 class="label-danger">Attach More Documents?</h2>
                <br />
                <asp:FileUpload runat="server" ID="uploadDocs" AllowMultiple="True" CssClass="fa-upload" />
                <br />
                <br />

                <asp:Button runat="server" ID="attachDocs" OnClick="attachDocs_OnClick" CssClass="btn btn-success" Text="Attach Document(s)" />
                <br />
                <br />
                <label class="label-success" runat="server" id="success"></label>

            </div>
        </div>
    </div>
</asp:Content>
