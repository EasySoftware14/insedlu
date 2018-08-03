using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using Insendu.Services;

namespace Insendlu
{
    public partial class AddLog : Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private readonly UserService _userService;
        private long _userId;

        public AddLog()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
            _userService = new UserService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                _userId = Convert.ToInt64(Session["ID"]);
                GetApprovedProposals();
                GetActiveUsers();
                GetDurationTypes();
                LoadSector();
            }
            else
            {
                _userId = Convert.ToInt64(Session["ID"]);
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
        private void GetDurationTypes()
        {
            var durationTypes = (from types in _insendluEntities.DurationTypes
                select types).ToList();

            durationType.DataSource = durationTypes;
            durationType.DataBind();
        }

        private void GetActiveUsers()
        {
            var users = (from usr in _insendluEntities.Users
                         where usr.status == 1
                         select usr).ToList();

            if (users.Count > 0)
            {
                logadmin.DataSource = users;
                logadmin.DataBind();
            }
        }

        private void GetApprovedProposals()
        {
            var project = (from pro in _insendluEntities.Projects
                           where pro.status == (int)ProjectStatus.Active
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
        protected void logSave_OnClick(object sender, EventArgs e)
        {
            var name = logName.Value;
            var sector = drpSector.SelectedIndex;
            var duration = Convert.ToInt32(logduration.Value);
            var admin = Convert.ToInt32(logadmin.Value);
            var durationTyp = Convert.ToInt32(durationType.Value);

            var project = _projectService.GetProjectByName(name, sector);
            //var sectorId = Convert.ToInt32(project.sector_id);
            //LoadSector();

            var depart = drpSector.SelectedValue == "1" ? "Public" : "Private";

            if (project != null)
            {
                // need to change
                Session["Small"] = false;
                var logging = new Logging
                {
                    name = name,
                    department = depart,
                    duration = duration,
                    duration_type_id = durationTyp,
                    members = admin.ToString(),
                    created_at = DateTime.Now,
                    modified_at = DateTime.Now,
                    project_id = Convert.ToInt32(project.id)
                };

                var result = _projectService.SaveLog(logging);

                if (result == 1)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Successfully added Work Log, You can proceed by clicking Track work log')", true);
                    var link = string.Format("TrackLog.aspx?name={0}&usId={1}&projId={2}", logging.name, admin, project.id);
                    Response.Redirect(link);
                }
            }
            else
            {
                
                var newproject = new Project
                {
                    name = name,
                    sector_id = sector,
                    created_at = DateTime.Now,
                    modified_at = DateTime.Now,
                    duration = duration,
                    duration_type_id = durationTyp,
                    user_id = Convert.ToInt32(_userId)
                };
                var pro = _projectService.AddProject(newproject);

                var logging = new Logging
                {
                    name = name,
                    department = depart,
                    duration = duration,
                    duration_type_id = durationTyp,
                    members = admin.ToString(),
                    created_at = DateTime.Now,
                    modified_at = DateTime.Now,
                    project_id = Convert.ToInt32(pro.id)
                };

               _projectService.SaveLog(logging);

                if (pro.id != 0)
                {
                    //Session["Small"] = true;
                    var durType = "";

                    switch (durationTyp)
                    {
                        case 1:
                            durType = DurationType.Year.ToString();
                            break;
                        case 2:
                            durType = DurationType.Months.ToString();
                            break;
                        case 3:
                            durType = DurationType.Weeks.ToString();
                            break;

                    }

                    Session["department"] = drpSector.SelectedValue;
                    Session["duration"] = duration + " " + durType;
                    Session["supervisor"] = _projectService.GetUserById(admin).name;

                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Successfully added Work Log, You can proceed by clicking Track work log')", true);
                    var link = string.Format("TrackLog.aspx?name={0}&usId={1}&projId={2}", name, admin, pro.id);
                    Response.Redirect(link);
                }

            }
            
        }

        protected void cancel_OnClick(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void ResetControls()
        {
            logName.Value = string.Empty;
            LoadSector();
            logduration.Value = string.Empty;
            logadmin.Value = string.Empty;
        }

        protected void datagridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void datagridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = datagridview.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            if (e.CommandName == "action")
            {
                Response.Redirect("ViewProposal.aspx?id=" + id);
            }
        }

        protected void datagridview_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            throw new NotImplementedException();
        }
       
    }
}