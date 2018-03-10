using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
////using Insendlu.Entities.Domain;
using Insendu.Services;

namespace Insendlu
{
    public partial class Projection : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;

        public Projection()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var query = Request.QueryString;
                var id = Convert.ToInt32(query.Get("id"));

                var projectProjection = _projectService.ProjectProjection(id);

                if (projectProjection.proj_id == id)
                {
                    accomodation.Text = projectProjection.accomodation;
                    vehicle.Text = projectProjection.vehicle;
                    employees.Text = projectProjection.employees;
                    telephone.Text = projectProjection.telephone;
                    data.Text = projectProjection.wifi_data;
                    refreshment.Text = projectProjection.refreshments;
                    printmaterial.Text = projectProjection.print_material;


                    SetUpReadOnly();
                    projection.Visible = false;
                    cancel.Visible = false;
                    btnBack.Visible = true;
                }

            }
        }

        private void SetUpReadOnly()
        {
            accomodation.ReadOnly = true;
            vehicle.ReadOnly = true;
            employees.ReadOnly = true;
            telephone.ReadOnly = true;
            data.ReadOnly = true;
            refreshment.ReadOnly = true;
            printmaterial.ReadOnly = true;

        }

        protected void projection_OnClick(object sender, EventArgs e)
        {
            var query = Request.QueryString;
            var id = Convert.ToInt32(query.Get("id"));

            var userId = Convert.ToInt32(Session["ID"]);
            var projId = id;
           //save project projection
            var accomo = accomodation.Text;
            var vehCle = vehicle.Text;
            var empl = employees.Text;
            var tel = telephone.Text;
            var dataWifi = data.Text;
            var refresh = refreshment.Text;
            var printM = printmaterial.Text;

            var projections = new ProjectProjection();

            if (!string.IsNullOrEmpty(accomo))
            {
                projections.accomodation = accomo;
            }
            if (!string.IsNullOrEmpty(vehCle))
            {
                projections.vehicle = vehCle;
            }
            if (!string.IsNullOrEmpty(empl))
            {
                projections.employees = empl;
            }
            if (!string.IsNullOrEmpty(tel))
            {
                projections.telephone = tel;

            }
            if (!string.IsNullOrEmpty(dataWifi))
            {
                projections.wifi_data = dataWifi;
            }
            if (!string.IsNullOrEmpty(refresh))
            {
                projections.refreshments = refresh;
            }
            if (!string.IsNullOrEmpty(printM))
            {
                projections.print_material = printM;
            }

            projections.created_at = DateTime.Today;
            projections.modified_at = DateTime.Today;
            projections.proj_id = projId;
            projections.user_id = userId;

            _insendluEntities.ProjectProjections.Add(projections);
            _insendluEntities.SaveChanges();

        }

        protected void cancel_OnClick(object sender, EventArgs e)
        {
             accomodation.Text = String.Empty;
             vehicle.Text = String.Empty;
             employees.Text = String.Empty;
             telephone.Text = String.Empty;
             data.Text = String.Empty;
             refreshment.Text = String.Empty;
             printmaterial.Text = String.Empty;
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}