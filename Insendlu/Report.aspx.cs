using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using Insendu.Services;

namespace Insendlu.UserPages
{
    public partial class Report : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;

        public Report()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetActiveProposals();
                LoadLogs();
            }
        }

        private void LoadLogs()
        {
            var logs = (from worklog in _insendluEntities.WorkLogs
                        select worklog).ToList();

            if (logs.Count > 0)
            {
                
                datagridview.DataSource = logs;
                datagridview.DataBind();
            }
        }
        protected void datagridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var ch = e.CommandName;
            if (ch == "viewedit")
            {
                var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

                var row = datagridview.Rows[rowno];
                var label = (Label)row.FindControl("lblId");
                var date = (Label)row.FindControl("lblDate");
                var dateCheck = Convert.ToDateTime(date.Text);
                var id = Convert.ToInt32(label.Text);
                var url = string.Format("ViewLogs.aspx?id={0}&date={1}", id, dateCheck.ToString("d"));
                Response.Redirect(url);
            }
           
        }

        protected void datagridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            datagridview.PageIndex = e.NewPageIndex;
            LoadLogs();
        }

        protected void datagridview_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            var index = e.NewEditIndex;
            LoadLogs();
        }

        protected void search_OnTextChanged(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(Request.Form[search.UniqueID]))
            {
                var date = Convert.ToDateTime(Request.Form[search.UniqueID]);

                var logs = (from worklog in _insendluEntities.WorkLogs
                            where worklog.date_logged == date
                            select worklog).ToList();

                if (logs.Count > 0)
                {
                    datagridview.DataSource = logs;
                    datagridview.DataBind();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(),"alert","alert('No record found')", true);
                }
            }
            else
            {
                LoadLogs();
            }
           
        }

        protected void reset_OnClick(object sender, EventArgs e)
        {
            search.Text = string.Empty;
            LoadLogs();
        }
        private void GetActiveProposals()
        {
            var projList = _insendluEntities.Projects.Where(x => x.status != (int)ProjectStatus.Pending && x.status != (int)ProjectStatus.Declined).ToList();

            projectList.DataSource = projList;
            projectList.DataBind();

        }

        protected void projectList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var project = projectList.SelectedItem.Text;

            var proj = _projectService.GetProjectByName(project);
            LoadLogsPerProposal(proj.id);
        }
        private void LoadLogsPerProposal(long id)
        {
            var logs = (from worklog in _insendluEntities.WorkLogs
                        where worklog.proj_id == id
                        select worklog).ToList();

            if (logs.Count > 0)
            {
                
                datagridview.DataSource = logs;
                datagridview.DataBind();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('No record found')", true);
                
            }
        }
    }
}