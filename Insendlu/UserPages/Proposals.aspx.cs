using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using Insendu.Services;

namespace Insendlu.UserPages
{
    public partial class Proposals : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly UserService _userService;
        private long _userId;

        public Proposals()
        {
            _insendluEntities = new InsendluEntities();
            _userService = new UserService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                _userId = Convert.ToInt64(Session["ID"]);
            }
        }

        protected void datagridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var userType = _userService.GetUserById(_userId).user_type_id;

            if (e.CommandName == "action")
            {
                var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

                var row = datagridview.Rows[rowno];  // logical 0,1,2,3,4,5
                var label = (Label)row.FindControl("lblId");
                var id = Convert.ToInt32(label.Text);
                var status = GetProjectStatus(id);

                switch (status)
                {
                    case "Approved": Response.Redirect("ViewProposal.aspx?id=" + id);
                        break;
                    case "Pending": Response.Redirect("EditProject.aspx?id=" + id);
                        break;
                    case "Submitted": Response.Redirect("Submitted.aspx?id=" + id);
                        break;
                }

            }
            if (e.CommandName == "Download")
            {
                Download(sender, e);
            }
            if (e.CommandName == "Edit")
            {

            }
            if (e.CommandName == "Status")
            {
                if (userType == 2)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Sorry, You are not allowed to access this request')", true);
                }
                else
                {
                    ChangeStatus(sender, e);
                }
               
            }
        }

        private string GetProjectStatus(int id)
        {
            var proje = (from pro in _insendluEntities.Projects
                         where pro.id == id
                         select new { Status = pro.status }).SingleOrDefault();

            return GetStatus(proje.Status);
        }

        private void Download(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = datagridview.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var projects = (from proj in _insendluEntities.Projects
                            where proj.id == id
                            select proj).Single();

            var projName = projects.name + projects.id;

            ReadIT(projName);

            //ProvideContent(projects);
            //lblDownload.Text = "This functionality of downloading still to be added :)" + projects.name;
            //lblDownload.Visible = true;
        }
        private void ReadIT(string projName)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + projName + ".pdf");
            Response.TransmitFile(Server.MapPath("~/PDF's/" + projName + ".pdf"));
            Response.End();
        }

        private void ChangeStatus(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());

            var row = datagridview.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var projects = (from proj in _insendluEntities.Projects
                            where proj.id == id
                            select proj).Single();

            if (projects != null)
            {
                Session["Project"] = projects;
                Response.Redirect("StatusUpdate.aspx?id=" + id);
            }
        }
        private string GetStatus(int? status)
        {
            var newStatus = "Pending";
            switch (status)
            {
                case 0:
                    newStatus = "Pending";
                    break;
                case 1:
                    newStatus = "Submitted";
                    break;
                case 2:
                    newStatus = "Approved";
                    break;
                case 3:
                    newStatus = "Declined";
                    break;
                case 4:
                    newStatus = "Done";
                    break;
            }

            return newStatus;
        }

        protected void datagridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void datagridview_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void approved_OnClick(object sender, EventArgs e)
        {
            var project = (from pro in _insendluEntities.Projects
                           where pro.status == (int)ProjectStatus.Approved
                           select pro).ToList();

            if (project.Count > 0)
            {
                datagridview.DataSource = project;
                datagridview.DataBind();

                datagridview.Visible = true;
                propStatus.InnerText = "Approved Proposal(s)";

            }
            else
            {
                datagridview.Visible = false;
                propStatus.InnerText = "There are no Approved proposals currently";
            }
        }

        protected void submitted_OnClick(object sender, EventArgs e)
        {
            var project = (from pro in _insendluEntities.Projects
                           where pro.status == (int)ProjectStatus.Submitted
                           select pro).ToList();

            if (project.Count > 0)
            {
                datagridview.DataSource = project;
                datagridview.DataBind();

                datagridview.Visible = true;
                propStatus.InnerText = "Submitted Proposal(s)";

            }
            else
            {
                datagridview.Visible = false;
                propStatus.InnerText = "There are no Submitted proposals currently";
            }
        }

        protected void pending_OnClick(object sender, EventArgs e)
        {
            var project = (from pro in _insendluEntities.Projects
                           where pro.status == (int)ProjectStatus.Pending
                           select pro).ToList();

            if (project.Count > 0)
            {
                datagridview.DataSource = project;
                datagridview.DataBind();

                datagridview.Visible = true;
                propStatus.InnerText = "Pending Proposal(s)";

            }
            else
            {
                datagridview.Visible = false;
                propStatus.InnerText = "There are no Pending proposals currently";
            }
        }


    }
}