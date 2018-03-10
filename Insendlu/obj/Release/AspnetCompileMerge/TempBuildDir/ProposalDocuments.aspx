<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProposalDocuments.aspx.cs" Inherits="Insendlu.ProposalDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
             <h1 class="item-blue">Proposal Document</h1>
            <hr/>
            <div class="col-lg-4">
                <asp:FileUpload runat="server" ID="uploadDocs" AllowMultiple="True" CssClass="fa-upload" />

                <br />
                <br />

                <asp:Button runat="server" ID="attachDocs" OnClick="attachDocs_OnClick" CssClass="btn btn-success" Text="Attach Document(s)" />
            </div>
            <div class="col-lg-8">
                <div class="panel-group">
                    <div class="panel panel-default">
                        <a class="panel-default" data-toggle="collapse" data-parent="#accordion1" href="#collapseThree">
                            <div class="panel-heading">
                                <h3 class="panel-title" style="color: lightblue">Proposal Document</h3>
                            </div>
                        </a>
                        <div id="collapseThree" class="">
                            <div class="panel-body">
                                <br />
                                <asp:GridView runat="server" Visible="True" ID="datagridview" CssClass="table table-bordered table-hover" AllowPaging="True"
                                    CellPadding="4" ForeColor="#333333" GridLines="None" BorderColor="#003300" BorderStyle="Solid"
                                    BorderWidth="1px" Font-Size="11pt" PageSize="10" Font-Names="Century" OnPageIndexChanging="datagridview_PageIndexChanging"
                                    OnRowCommand="datagridview_RowCommand" AutoGenerateColumns="False" OnRowDeleting="datagridview_OnRowDeleting" OnRowEditing="datagridview_OnRowEditing" DataKeyNames="id">
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

                                        <asp:TemplateField HeaderText="Proposal Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblProjName" Text='<%# Eval("name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Created Date">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblDate" Text='<%# Eval("created_at","{0:D}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:ButtonField ButtonType="Button" Text="Download" CommandName="Download"
                                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />
                                        <asp:ButtonField ButtonType="Button" Text="Delete" CommandName="Delete"
                                            ControlStyle-BackColor="#507CD1" ControlStyle-ForeColor="White" ControlStyle-Font-Size="15px" />

                                    </Columns>
                                </asp:GridView>
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>


</asp:Content>
