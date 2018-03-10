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
    public partial class Declined : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly UserService _userService;
        private long _userId;

        public Declined()
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
            if(!IsPostBack)
            {
                _userId = Convert.ToInt64(Session["ID"]);
                GetDeclinedProposals();
            }
        }

        private void GetDeclinedProposals()
        {
            var declinedGrid = (from decline in _insendluEntities.Projects
                where decline.status == (int) ProjectStatus.Declined
                select decline).ToList();

            if (declinedGrid.Count > 0)
            {
                declined.DataSource = declinedGrid;
                declined.DataBind();
            }
        }
        protected void declined_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void declined_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }

        protected void declined_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            
        }
    }
}