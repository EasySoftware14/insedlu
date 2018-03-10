using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using Insendlu.Entities.MySqlConnection;

namespace Insendlu
{
    public partial class ViewUsers : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;

        public ViewUsers()
        {
            _insendluEntities = new InsendluEntities();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserList();
               
            }

        }

        private void UserList()
        {
            var users = (from user in _insendluEntities.Users
                         where user.status == (int) EntityStatus.Active
                         select user).ToList();

            if (users.Count > 0)
            {
                usergrid.DataSource = users;
                usergrid.DataBind();
            }
        }
        protected void usergrid_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void usergrid_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = usergrid.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var command = e.CommandName;

            if (command == "delete")
            {
                UserUpdate(id);
            }
        }

        private void UserUpdate(int id)
        {
            var user = (from users in _insendluEntities.Users
                where users.id == id
                select users).SingleOrDefault();

            if (user != null)
            {
                var stats = (int) EntityStatus.InActive;
                user.status = stats;

                _insendluEntities.SaveChanges();
            }
        }

        protected void usergrid_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var index = e.RowIndex;
            UserList();
        }

        protected void viewAll_OnClick(object sender, EventArgs e)
        {
            var users = (from user in _insendluEntities.Users
                         select user).ToList();

            if (users.Count > 0)
            {
                usergrid.DataSource = users;
                usergrid.DataBind();
            }
        }
    }
}