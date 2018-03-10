<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" MasterPageFile="Site.Master" Inherits="Insendlu.AdminPage" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="col-sm-12">
                <br />
                <h2 style="text-align: justify">Dashboard</h2>
                <hr/>
                <br />
                <br />
               
                <div class="col-lg-3">
                    <div class="form-group" style="text-align: justify">
                        <asp:Button runat="server" Enabled="False" ID="proposal" CausesValidation="False" Width="200" Height="250" CssClass="btn btn-success" Text="PROPOSALS" />
                        <div class="form-group">
                            <br />
                            <asp:Button runat="server" ID="References" CssClass="btn btn-primary" Text="Reference" OnClick="References_OnClick"/>
                            <asp:Button runat="server" ID="proposalWrite" CssClass="btn btn-danger" Width="100" Text="Write" OnClientClick="window.open('NewProject.aspx')" />
                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group" style="text-align: center">
                        <asp:Button runat="server" Enabled="False" ID="accounting" Width="200" Height="250" Text="ACCOUNTING" CssClass="btn btn-danger"  />
                        <div class="form-group">
                            <br />
                            <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary" Text="Accounting" OnClick="accounting_OnClick" />

                        </div>
                    </div>

                </div>
                <div class="col-lg-3">
                    <div class="form-group" style="text-align: center">
                        <asp:Button runat="server" Enabled="False" ID="consultancy" Width="200" Height="250" Text="CONSULTANCY" CssClass="btn btn-primary"  />
                        <div class="form-group">
                            <br />
                            <asp:Button runat="server" ID="Button2" CssClass="btn btn-danger" Text="Consultancy" OnClick="consultancy_OnClick" />

                        </div>
                    </div>
                </div>
                <div class="col-lg-3">
                    <div class="form-group" style="text-align: center">
                        <asp:Button runat="server" Enabled="False" ID="read" Width="200" Height="250" Text="RESEARCH" CssClass="btn btn-grey"  />
                        <div class="form-group">
                            <br />
                            <asp:Button runat="server" ID="research" CssClass="btn btn-primary" Text="Enter Research" OnClick="research_OnClick" />

                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

