using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using Insendu.Services;

namespace Insendlu
{
    public partial class TaskUpdate : Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly UserService _userService;
        private readonly ProjectService _projectService;
        private long _user;

        public TaskUpdate()
        {
            _insendluEntities = new InsendluEntities();
            _userService = new UserService();
            _projectService = new ProjectService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ID"] != null)
                {
                    var userId = Convert.ToInt64(Session["ID"]);
                    _user = userId;

                    SetTasks(userId);
                    var statuses = Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>().ToList();

                    statusDropdown.DataSource = statuses;
                    statusDropdown.DataBind();
                    
                }
            }
        }
        
        protected void back_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard.aspx");
        }
        private int Status(string status)
        {
            var defaultStatus = 0;

            switch (status)
            {
                case "NotAssigned":
                    defaultStatus = 1;
                    break;
                case "Assigned":
                    defaultStatus = 2;
                    break;
                case "Confirmed":
                    defaultStatus = 3;
                    break;
                case "InProgress":
                    defaultStatus = 4;
                    break;
                default:
                    defaultStatus = 5;
                    break;
            }

            return defaultStatus;
        }
        private void SetTasks(long id)
        {
            var myTasks = _projectService.MyTasks(id).OrderByDescending(x => x.created_at);

            if (myTasks.Any())
            {
                tasks.DataSource = myTasks;
                tasks.DataBind();
            }
            
        }
        protected void changeStatus_OnClick(object sender, EventArgs e)
        {
            //var id = _projId;
            var stats = 0;
            var selected = String.Empty;
            var taskId = Convert.ToInt32(tasks.SelectedValue);

            foreach (ListItem item in statusDropdown.Items)
            {
                if (item.Selected)
                {
                    selected = item.Value;
                    stats = Status(selected);
                    break;
                }
            }
            var taskStatus = Convert.ToInt32(stats);
            var task = _insendluEntities.Tasks.Single(x => x.id == taskId);

            task.status = taskStatus;
            _insendluEntities.Entry(task).State = EntityState.Modified;
            _insendluEntities.SaveChanges();

            SetTasks(_user);
        }

        protected void tasks_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var shotsFired = sender as DropDownList;

            foreach (var item in shotsFired.Items)
            {
                var casting = item as ListItem;

                if (casting.Selected)
                {
                    var id = Convert.ToInt32(casting.Value);
                    var itemValue =  _insendluEntities.Tasks.Single(x => x.id == id).body;
                    var stringBuild = "Task: " + itemValue;
                    Page.ClientScript.RegisterClientScriptBlock(GetType(),"alert","alert('"+ stringBuild +"')", true);
                    break;
                    
                }
            }
        }
    }
}