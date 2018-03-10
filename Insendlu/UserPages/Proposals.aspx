<%@ Page Title="" Language="C#" MasterPageFile="Site1.Master" AutoEventWireup="true" CodeBehind="Proposals.aspx.cs" Inherits="Insendlu.UserPages.Proposals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <br />
            <h1 class="label-light">Proposals Write Up's</h1>
            <hr />
            <div class="col-lg-4">
                <asp:Button runat="server" ID="approved" OnClick="approved_OnClick" ToolTip="Pulse Proposals" Text="Active Proposals" CssClass="btn btn-sm btn-success" />

            </div>

            <div class="col-lg-4">
                <asp:Button runat="server" ID="submitted" OnClick="submitted_OnClick" Text="Submitted Proposals" CssClass="btn btn-sm btn-default" />

            </div>
           
            <div class="col-lg-4">
                <asp:Button runat="server" ID="pending" OnClick="pending_OnClick" Text="Pending Proposals" CssClass="btn btn-sm btn-danger" />

            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-lg-11">
                <br />
                <asp:GridView runat="server" Visible="False" ID="datagridview" CssClass="table table-bordered table-hover" AllowPaging="True"
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

                        <%--<asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:ButtonField ButtonType="Button" Text="Actions" CommandName="action"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                        <asp:ButtonField ButtonType="Button" Text="Download" CommandName="Download"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                        <asp:ButtonField ButtonType="Button" Text="Update Status" CommandName="Status"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                    </Columns>
                </asp:GridView>
                <br />

                <label class="label-default" runat="server" id="propStatus"></label>

            </div>
        </div>
    </div>
</asp:Content>
