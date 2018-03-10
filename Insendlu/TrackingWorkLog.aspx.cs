﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
using Insendlu.Entities.MySqlConnection;
using Insendu.Services;

namespace Insendlu
{
    public partial class TrackingWorkLog : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private readonly UserService _userService;
        private string _name;
        private int _userId;
        private int _projectId;

        public TrackingWorkLog()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
            _userService = new UserService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            var counter = 0;

            var workLog = (from log in _insendluEntities.Loggings
                           select log).ToList();

            logging.Visible = false;

            var logOnSmallProjects = (from small in _insendluEntities.SmallProjects
                select small).ToList();

            if (logOnSmallProjects.Count >= 1)
            {
                foreach (var small in logOnSmallProjects)
                {
                    counter++;
                    var btn = new Button
                    {
                        Text = small.name,
                        ID = "btn_event" + counter

                    };
                    btn.Click += new EventHandler(btn_event_Click);
                    btn.CssClass = GetRandomClass(counter);
                    btn.Width = new Unit("250");
                    btn.Height = new Unit("100");

                    buttons.Controls.Add(btn);
                }
            }
            if (workLog.Count == 0 && logOnSmallProjects.Count == 0)
            {
                lblInfo.Visible = true;
            }

            if (workLog.Count >= 1)
            {
                foreach (var log in workLog)
                {
                    counter++;
                    var btn = new Button
                    {
                        Text = string.Format("{0}", log.name),
                        ID = "btn_event" + counter

                    };
                    btn.Click += new EventHandler(btn_event_Click);
                    btn.CssClass = GetRandomClass(counter);
                    btn.Width = new Unit("250");
                    btn.Height = new Unit("100");

                    buttons.Controls.Add(btn);
                }

            }

        }

        protected void btn_event_Click(object sender, EventArgs e)
        {
            var btn = (Button) sender;
            _name = btn.Text;
            Session["proName"] = _name;

            var worklog = _projectService.GetWorkLogByName(btn.Text);

            if (worklog == null)
            {
                var smally = _projectService.GetSmallProjectLogByName(btn.Text);
                if (smally.administrator != null) _userId = (int) smally.administrator;

            }
            else
            {
                if (worklog.logger != null) _userId = (int) worklog.logger;
                _projectId = (int)_projectService.GetProjectById(Convert.ToInt64(worklog.project_id)).id;
            }
            
            var link = string.Format("TrackLog.aspx?name={0}&usId={1}&projId={2}", _name, _userId, _projectId);
            Response.Redirect(link);

        }
        private string GetRandomClass(int counter)
        {
            if (counter % 2 == 0)
            {
                return "btn btn-sm btn-success";
            }

            return "btn btn-sm btn-default";
        }

        protected void proposal_OnClick(object sender, EventArgs e)
        {
            var id = _projectId = Convert.ToInt32(Session["proId"]);
            Response.Redirect("ProposalDocuments.aspx?id=" + id);
        }

        protected void docs_OnClick(object sender, EventArgs e)
        {
            _projectId = Convert.ToInt32(Session["proId"]);
            Response.Redirect("Documents.aspx?projId=" + _projectId);
        }

        protected void timeline_OnClick(object sender, EventArgs e)
        {
            _projectId = Convert.ToInt32(Session["proId"]);
            Response.Redirect("~/ProjectTimeLine.aspx?id=" + _projectId);
        }

        protected void admin_OnClick(object sender, EventArgs e)
        {

            _name = Session["proName"].ToString();

            var workLogger = _projectService.GetWorkLogByName(_name);

            if (workLogger != null)
            {
                var id = Convert.ToInt32(workLogger.logger);
                var projectAdmin = _userService.GetUserById(id);

                Response.Redirect("UserProfilesEdit.aspx?id=" + id);
            }
        }

        protected void parameter_OnClick(object sender, EventArgs e)
        {
            _projectId = Convert.ToInt32(Session["proId"]);
            Response.Redirect("~/Parameter.aspx?id=" + _projectId);
        }

        protected void log_OnClick(object sender, EventArgs e)
        {
            var id = _projectId = Convert.ToInt32(Session["proId"]); ;
            Response.Redirect("LogInfo.aspx?id=" + id);
        }
    }
}