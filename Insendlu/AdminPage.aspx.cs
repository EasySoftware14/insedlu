using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Insendlu
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["ID"].ToString()))
            {
                Response.Redirect("index.aspx");
            }

            else if (!IsPostBack)
            {
                
                
            }
        }

        protected void proposal_OnClick(object sender, EventArgs e)
        {
            
        }

        protected void accounting_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Acconting.aspx");
        }

        protected void consultancy_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Consultancy.aspx");
        }

        protected void research_OnClick(object sender, EventArgs e)
        {
           
        }

        protected void proposalWrite_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/NewProject.aspx", true);
        }

        protected void References_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("References.aspx");
        }
    }
}