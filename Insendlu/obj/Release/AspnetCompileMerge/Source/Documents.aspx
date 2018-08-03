<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Documents.aspx.cs" Inherits="Insendlu.Documents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row-fluid">
            <br/>
            <label style="font-size: x-large">Documents Related to Project</label>
            <hr />
            
            <br/>
            <div class="col-lg-12">
                <asp:Button runat="server" ID="backToTrack" Text="Back to TrackWork" CssClass="btn btn-primary" OnClick="backToTrack_OnClick"/>
                <br/>
                <br/>
                <div class="panel-group">
                    <div class="panel panel-default">
                        <a class="panel-default" data-toggle="collapse" data-parent="#accordion1" href="#collapseOne">
                            <div class="panel-heading">
                                <h3 class="panel-title" style="color: lightblue">View Supporting Documents</h3>
                            </div>
                        </a>
                        <div id="collapseOne" class="panel-collapse collapse">
                            <div class="panel-body">
                                <br />
                                <label class="label-success" runat="server" id="success"></label>
                                <asp:Button runat="server" Height="80" ForeColor="green" Text="View Documents" CssClass="btn btn-sm btn-block btn-success" ID="ViewDocs" OnClick="ViewDocs_OnClick" />
                                <br />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="col-sm-12 col-md-12">
                    <div class="panel-group">
                        <div class="panel panel-default">
                            <a class="panel-default" data-toggle="collapse" data-parent="#accordion1" href="#collapseThree">
                                <div class="panel-heading">
                                    <h3 class="panel-title" style="color: lightblue">Documents</h3>
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

                                            <asp:TemplateField HeaderText="Document Name">
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
    </div>


</asp:Content>
