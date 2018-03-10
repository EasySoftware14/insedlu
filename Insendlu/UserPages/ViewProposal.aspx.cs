using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
using Insendlu.Entities.Domain;
using Insendu.Services;

namespace Insendlu.UserPages
{
    public partial class ViewProposal : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;

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
                    var id = Convert.ToInt64(query.Get("id"));

                    var pro = (from proj in _insendluEntities.Projects
                        where proj.id == id
                        select proj).SingleOrDefault();

                    if (pro != null)
                    {
                        projectName.Text = pro.name;
                        nameOfProject.Value = pro.name;
                        department.Value = pro.department_name;
                        duration.Value = pro.duration.ToString();
                    }
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
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
            var departmentName = department.Value;
            var projDuration = Convert.ToInt32(duration.Value);

            var project = GetProject();

            project.department_name = departmentName;
            project.duration = projDuration;

            var check = _insendluEntities.SaveChanges();

            Response.Redirect("Approved.aspx?id=" + project.id);

        }
    }
}