using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities;
using Insendlu.Entities.Connection;

using Insendu.Services;

namespace Insendlu
{
    public partial class AddUser : System.Web.UI.Page
    {
        private readonly ProjectService _projectService;
        private readonly InsendluEntities _insendluEntities;
        //private readonly insedluEntities _insendluEntities;
        private readonly UserService _userService;
       
        public AddUser()
        {
            _projectService = new ProjectService();
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

                    if (userType == 2)
                    {
                        Response.Redirect("~/Dashboard.aspx");
                    }

                }
            }
            //if (IsPostBack)
            //{
            //    var button = (Button) sender;

            //    if (button.ID == "")
            //    {
            //        Response.Redirect("Dashboard.aspx");
            //        return;
            //    }
                
            //}
        }

        protected void addUser_OnClick(object sender, EventArgs e)
        {

            var emailAddres = emailAddress.Text;
            var firstName = userName.Text;
            var lastNames = lastName.Text;
            var user_type = userType.SelectedIndex;

            var id = _projectService.AddUser(firstName, lastNames, emailAddres, user_type, Server.MapPath("~/Templates/emailtemplate.txt"));

            if (id == 1)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('User added successfully')", true);

                ClearControls();
            }
            else
            {
                ClearControls();

                Page.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('User with the same Email already exists')", true);

            }

        }

        private void ClearControls()
        {
            emailAddress.Text = string.Empty;
            userName.Text = string.Empty;
            lastName.Text = string.Empty;
            userType.SelectedIndex = 0;
        }

        protected void addNewUser_OnClick(object sender, EventArgs e)
        {
            var emailAddres = emailAddress.Text;
            var firstName = userName.Text;
            var lastNames = lastName.Text;
            var user_type = userType.SelectedIndex;

            var id = _projectService.AddUser(firstName, lastNames, emailAddres, user_type, Server.MapPath("~/Templates/templateemail.html"));

            if (id == 1)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('User added successfully')", true);
                Session["UserAdded"] = true;
                ClearControls();
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                ClearControls();

                Page.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('User with the same Email already exists')", true);

            }

        }

        protected void OnServerClick(object sender, EventArgs e)
        {
           Response.Redirect("Dashboard.aspx");
        }

        protected void btnClose_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }
    }
}