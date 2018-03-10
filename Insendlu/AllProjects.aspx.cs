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
    public partial class AllProjects : System.Web.UI.Page
    {
        private readonly insedluEntities _insendluEntities;

        public AllProjects()
        {
            _insendluEntities = new insedluEntities();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindBind();
            }
        }

        private void DataBindBind()
        {
            var projects = (from proj in _insendluEntities.projects
                           select proj).ToList();

            if (projects.Count != 0)
            {
                datagridview.DataSource = projects.ToList();
                datagridview.DataBind();

            }
            else
            {
                Response.Redirect("AdminPage.aspx");
            }
        }

        protected void datagridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {

                var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

                var row = datagridview.Rows[rowno];  // logical 0,1,2,3,4,5
                var label = (Label)row.FindControl("lblId");
                var id = Convert.ToInt32(label.Text);

                var projects = (from proj in _insendluEntities.projects
                                where proj.id == id
                                select proj).Single();

                lblname.Text = "Project name : " + projects.name;
                if (projects.created_at != null) lbldesc.Text = "Date Created : " + projects.created_at.Value.Date.ToShortDateString();
                lblstore.Text = "Project Status : " + projects.status;

                //var productPrice = datagridview.Rows[rowno].Cells[3].Text.ToString();
                //lblprice.Text = "Product Price : " + productPrice;

            }
            if (e.CommandName == "Download")
            {
                Download(sender, e);
            }
        }
        private void Download(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = datagridview.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var projects = (from proj in _insendluEntities.projects
                            where proj.id == id
                            select proj).Single();

            //viewModal.Visible = true;
        }
        protected void datagridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            datagridview.PageIndex = e.NewPageIndex;
            DataBindBind();
        }

    }
}