using System;
using System.Collections.Generic;
using System.Linq;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
////using Insendlu.Entities.Domain;
using Insendlu.Entities.MySqlConnection;
using Insendu.Services;

namespace Insendlu
{
    public partial class AssignUserToProject : System.Web.UI.Page
    {
        private readonly ProjectService _projectService;
        private readonly InsendluEntities _insendluEntities;

        public AssignUserToProject()
        {
            _insendluEntities = new InsendluEntities();
            _projectService     = new ProjectService();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            if (!IsPostBack)
            {
                
                GetActiveProposals();
                GetUserList();

            }
            

        }

        private void GetUserList()
        {
            var registeredUsers = _insendluEntities.Users.Where(x => x.status != (int) EntityStatus.InActive).ToList();

            userList.DataSource = registeredUsers;
            userList.DataBind();
        }

        private void GetActiveProposals()
        {
            var projList = _insendluEntities.Projects.Where(x => x.status != (int) ProjectStatus.Pending && x.status != (int) ProjectStatus.Declined).ToList();

            projectList.DataSource = projList;
            projectList.DataBind();
           
        }
        protected void Assign_OnClick(object sender, EventArgs e)
        {
            var project = projectList.SelectedItem.Text;

            var userLis = Request.Form[userList.UniqueID];
            var list = new List<string>();

            if (!string.IsNullOrEmpty(userLis))
            {
                list = userLis.Split(',').ToList();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(),"alert","alert('Please select user to assign to project')",true);
                return;
            }
            var usList = new List<int>(list.Count);
            var report = string.Empty;

            for (var i = 0; i < list.Count; i++)
            {
                usList.Add(Convert.ToInt32(list[i]));
            }

            var proj = _projectService.GetProjectByName(project);
            foreach (var selectedUser in usList)
            {
                var userProj = new User_Project
                {
                    created_at = DateTime.Now,
                    modified_at = DateTime.Now,
                    proj_id = (int)proj.id,
                    user_id = selectedUser
                };

                var userSelected = _projectService.GetUserById(selectedUser);
                _insendluEntities.User_Project.Add(userProj);
                var hidd = _insendluEntities.SaveChanges();

                report += string.Format("{0}, ", userSelected.name);

            }

            report += string.Format(" has / have been added to proposal {0}", project);

            GetActiveProposals();
            GetUserList();

            Page.ClientScript.RegisterClientScriptBlock(GetType(),"alert","alert('"+ report +"')", true);
        }

        protected void OnClick(object sender, EventArgs e)
        {
            Page_Load(sender, e);
        }

        
    }
}