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
    public partial class ViewProposal : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private long _id;

        public ViewProposal()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    var query = Request.QueryString;
                    _id = Convert.ToInt64(query.Get("id"));

                    var pro = (from proj in _insendluEntities.Projects
                        where proj.id == _id
                        select proj).SingleOrDefault();

                    var sectId = Convert.ToInt32(pro.sector_id);
                    LoadSector();

                    var sector = drpSector.SelectedValue = sectId == 1 ? "Public" : "Private";

                    if (pro != null)
                    {
                        projectName.Text = pro.name;
                        nameOfProject.Value = pro.name;
                        drpSector.SelectedValue = sector;
                        if (pro.start_date != null) durationStartDate.Text = pro.start_date.Value.ToShortDateString();
                        if (pro.end_date != null) durationEndDate.Text = pro.end_date.Value.ToShortDateString();
                    }
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                var query = Request.QueryString;
                _id = Convert.ToInt64(query.Get("id"));
            }
            
        }
        private void LoadSector()
        {
            var sector = (from env in _insendluEntities.Sectors
                          select env).ToList();

            if (sector.Count > 0)
            {
                drpSector.DataSource = sector;
                drpSector.DataBind();

            }
        }
        private Project GetProject()
        {
            var query = Request.QueryString;
            var id = Convert.ToInt64(query.Get("id"));

            var pro = (from proj in _insendluEntities.Projects
                       where proj.id == id
                       select proj).SingleOrDefault();

            return pro;
        }

        protected void attachDocs_OnClick(object sender, EventArgs e)
        {
           

        }

        protected void schedule_OnClick(object sender, EventArgs e)
        {
            var sectorId = drpSector.SelectedIndex;
            var projDurationStart = Convert.ToDateTime(durationStartDate.Text);
            var projDurationend = Convert.ToDateTime(durationEndDate.Text);

            var project = GetProject();

            project.sector_id = sectorId;
            project.start_date = projDurationStart;
            project.end_date = projDurationend;

            var check = _insendluEntities.SaveChanges();

            Response.Redirect("Approved.aspx?id=" + project.id);

        }

        protected void btnScheduling_OnClick(object sender, EventArgs e)
        {
            scheduling.Visible = true;
            projectionSetup.Visible = false;
            
        }

        protected void btnProjection_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Projection.aspx?id=" + _id);
            scheduling.Visible = false;
        }
    }
}