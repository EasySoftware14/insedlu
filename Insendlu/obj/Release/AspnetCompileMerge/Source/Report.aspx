<%@ Page Title="" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Insendlu.UserPages.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-11">
                <h1 class="label-large">Still to come...</h1>
                <br />
                <span class="input-icon">
                    <asp:TextBox runat="server" ID="search" TextMode="Date" CausesValidation="True" OnTextChanged="search_OnTextChanged" CssClass="fa-search-plus" Placeholder="Search By Date"></asp:TextBox>

                    <i class="ace-icon fa fa-search nav-search-icon"></i>
                </span>
                <asp:DropDownList runat="server" ID="projectList" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="projectList_OnSelectedIndexChanged" DataTextField="name" DataValueField="id" ToolTip="Choose Proposal Name" CssClass="dropdown" />
                <button class="btn-corner" id="searchCr">Search</button>
                |
                <asp:Button ID="reset" runat="server" OnClick="reset_OnClick" CssClass="btn-back-message-list" Text="Reset" />
                <br />
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

                        <asp:TemplateField HeaderText="Logged Date">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblDate" Text='<%# Eval("date_logged","{0:d}") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       
                        <asp:ButtonField ButtonType="Button" Text="View / Edit" CommandName="viewedit"
                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />

                    </Columns>
                </asp:GridView>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="search" Animated="True" Format="dd/MM/yyyy" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
