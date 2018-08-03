using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
using Insendu.Services;

namespace Insendlu
{
    public partial class TrackLog : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private readonly UserService _userService;
        private string _name;
        private int _userId;
        private int _projectId;
        private int _smallProjectId;
        private string _supervisor = String.Empty;

        public TrackLog()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
            _userService = new UserService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var department = Session["department"];
                var duration = Session["duration"];

                _projectId = Convert.ToInt32(Request.QueryString["projId"]);
                var projLogging = _projectService.GetWorkLogByName(Request.QueryString["name"]);

                var durType = "";

                    switch (projLogging.duration_type_id)
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

                department = projLogging.department;
                duration = projLogging.duration + " " + durType;
                var members = projLogging.members.Split(',').ToList();
                var userList = new List<string>();

                foreach (var member in members)
                {
                    var user = _projectService.GetUserById(Convert.ToInt32(member));
                    userList.Add(user.name);
                }
                _supervisor = string.Join(",", userList);
                membersList.Text = _supervisor;
                //supervisor = _projectService.GetUserById(_userId).name;

                logging.Visible = true;
                var name = Request.QueryString["name"];
               
                var breaker = new Literal();
                breaker.Text = "<br/>";
                var buttonName = string.Format("Name : {0} \\n\\nDepartment : {1} \\n\\nDuration : {2} \\n\\nSupervisor : {3}", name.ToUpper(), department, duration, _supervisor);

                projName.Text = name.ToUpper();
                projectsummary.Text = string.Format("Name : {0} <br/>Department : {1} <br/>Duration : {2} <br/>Members : {3}", name.ToUpper(), department, duration, _supervisor); 

                //Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + buttonName + "')", true);

            }
            else
            {
                var department = Session["department"];
                var duration = Session["duration"];

                _projectId = Convert.ToInt32(Request.QueryString["projId"]);
                var projLogging = _projectService.GetWorkLogByName(Request.QueryString["name"]);

                var durType = "";

                switch (projLogging.duration_type_id)
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
                department = projLogging.department;
                duration = projLogging.duration + " " + durType;

                logging.Visible = true;
                var name = Request.QueryString["name"];
                _name = name;
               
                var breaker = new Literal();
                breaker.Text = "<br/>";
                var buttonName = string.Format("Name : {0} Department : {1} Duration : {2} Supervisor : {3}", name.ToUpper(), department, duration, _supervisor);

                projName.Text = name.ToUpper();

            }
        }
        protected void projName_OnClick(object sender, EventArgs e)
        {
            logging.Visible = true;

        }
        protected void proposal_OnClick(object sender, EventArgs e)
        {
            var id = _projectId;
            Response.Redirect("ProposalDocuments.aspx?id=" + id);
        }

        protected void docs_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Documents.aspx?projId=" + _projectId);
            //ReadAndDisplayDocumentById(" ");
        }
        public void ReadAndDisplayDocumentById(string id)
        {
            Response.ContentType = "Application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + id + ".pdf");
            Response.TransmitFile(Server.MapPath("~/PDF/" + id + ".pdf"));
            Response.End();
        }

        protected void timeline_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/ProjectTimeLine.aspx?id=" + _projectId);
        }

        protected void admin_OnClick(object sender, EventArgs e)
        {
            var workLogger = _projectService.GetWorkLogByName(_name);

            if (workLogger != null)
            {
                membersList.Text = _supervisor;
                ModalPopupExtender1.Show();
                //var id = Convert.ToInt32(workLogger.members);
                //var projectAdmin = _userService.GetUserById(id);

                //Response.Redirect("UserProfilesEdit.aspx?id=" + id);
            }

        }

        protected void parameter_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Parameter.aspx?id=" + _projectId);
        }

        protected void log_OnClick(object sender, EventArgs e)
        {
            var id = _projectId;

            //if(id == 0 ||Convert.ToBoolean(Session["small"]))
            //{
            //    var worklog = new WorkLog
            //    {
            //        date_logged = DateTime.Now,
            //        proj_id = _smallProjectId,
            //        user_id = _userId
            //    };

            //    var result = _projectService.SaveWorkLog(worklog);

            //    if (result == 1)
            //    {
            //        Response.Redirect("LogInfo.aspx?id=" + worklog.id);
            //    }
            //}


            Response.Redirect("LogInfo.aspx?id=" + id);
        }
    }
}