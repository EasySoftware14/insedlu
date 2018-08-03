<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Projection.aspx.cs" Inherits="Insendlu.Projection" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h2>Assets Projections</h2>
        <hr />
        <div class="col-lg-6">
            <label>Accommodation</label>
            <asp:TextBox runat="server" ID="accomodation" CausesValidation="True" CssClass="form-control"></asp:TextBox>
            <label>Vehicle</label>
            <asp:TextBox runat="server" ID="vehicle" CssClass="form-control"></asp:TextBox>
            <label>Employees</label>
            <asp:TextBox runat="server" ID="employees" CssClass="form-control"></asp:TextBox>
            <label>Telephone</label>
            <asp:TextBox runat="server" ID="telephone" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="col-lg-6">
             <label>Data / WIFI</label>
            <asp:TextBox runat="server" ID="data" CssClass="form-control"></asp:TextBox>
            <label>Refreshments</label>
            <asp:TextBox runat="server" ID="refreshment" CssClass="form-control"></asp:TextBox>
            <label>Print Material</label>
            <asp:TextBox runat="server" ID="printmaterial" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-6">
            <br />
           <table>
               <tr>
                   <td> <asp:Button runat="server" ID="btnBack" Text="Back" CssClass="btn btn-danger" Visible="False" OnClick="btnBack_OnClick" /></td>
                   <td></td>
                   <td> <asp:Button runat="server" ID="cancel" CssClass="btn btn-danger" Text="Cancel" OnClick="cancel_OnClick" /></td>
                   <td></td>
                   <td> <asp:Button runat="server" ID="projection" Text="Save Projections" CssClass="btn btn-block btn-success" OnClick="projection_OnClick" /></td>
               </tr>
           </table>
               
               
               
            


        </div>
    </div>




</asp:Content>
