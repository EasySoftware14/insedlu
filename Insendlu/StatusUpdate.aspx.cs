using System;
using System.Collections.Generic;
using System.Drawing;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
//using Insendlu.Entities.Domain;
using Insendu.Services;

namespace Insendlu
{
    public partial class StatusUpdate : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly UserService _userService;
        private long _projId;

        public StatusUpdate()
        {
            _insendluEntities = new InsendluEntities();
            _userService = new UserService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    var userId = Convert.ToInt64(Session["ID"]);
                    var userType = _userService.GetUserById(userId).user_type_id;

                    if (userType != 2)
                    {
                        if (Session["project"] != null)
                        {

                            var project = Session["project"] as Project;
                            var query = Request.QueryString;
                            _projId = Convert.ToInt64(query.Get("id"));

                            if (project != null)
                            {
                                proposal.Text = project.name;

                            }
                            GetStatuses();
                            //var statuses = Enum.GetValues(typeof(ProjectStatus)).Cast<ProjectStatus>().ToList();

                            //statusDropdown.DataSource = statuses;
                            //statusDropdown.DataBind();

                            //statusDropdown.DataTextField = statuses.ToString();

                        }
                    }
                    else
                    {
                        Response.Redirect("Proposals.aspx");
                    }
                }
            }
            else
            {
                var query = Request.QueryString;
                _projId = Convert.ToInt64(query.Get("id"));
            }
        }

        private void GetStatuses()
        {
            var status = (from pr in _insendluEntities.ProjectStatus
                select pr).ToList();

            statusDropdown.DataSource = status;
            statusDropdown.DataBind(); 
        }

        protected void changeStatus_OnClick(object sender, EventArgs e)
        {
            var id = _projId;
            var stats = 0;
            var selected = String.Empty;

            foreach (ListItem item in statusDropdown.Items)
            {
                if (item.Selected)
                {
                    selected = item.Value;
                    stats = Status(selected);
                    break;
                }
            }

            var project = (from pro in _insendluEntities.Projects
                where pro.id == id
                select pro).SingleOrDefault();

            if (project != null)
            {
                project.status = stats;

                var check = _insendluEntities.SaveChanges();

                if (check == 1)
                {
                    statusLabel.Text = string.Format("Project {0}'s status has successfully been updated to '{1}' ", project.name, selected);
                    statusLabel.Visible = true;
                    statusLabel.ForeColor = Color.Chartreuse;
                }
            }
        }

        private int Status(string status)
        {
            var defaultStatus = 0;

            switch (status)
            {
                case "Pending":
                     defaultStatus = 0;
                    break;
                case "Approved":
                     defaultStatus = 2;
                    break;
                case "Declined":
                     defaultStatus = 3;
                    break;
                case "Submitted":
                     defaultStatus = 1;
                    break;
                default:
                     defaultStatus = 4;
                    break;
            }

            return defaultStatus;
        }

        protected void back_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Proposals.aspx");
        }
    }
}