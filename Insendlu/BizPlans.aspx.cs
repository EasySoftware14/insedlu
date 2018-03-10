using System;
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
    public partial class BizPlans : System.Web.UI.Page
    {
        private readonly insedluEntities _insendluEntities;
        private readonly ProjectService _projectService;

        public BizPlans()
        {
            _insendluEntities = new insedluEntities();
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("index.aspx");
            }
        }

        protected void cancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void submit_OnClick(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(Session["ID"]);

            if (!string.IsNullOrWhiteSpace(bizplan.Content))
            {
                var content = bizplan.Content;
                var check = _projectService.SaveBusinessPlan(content, id);

                if (check == 1)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(),"alert","alert('Business Plan saved successfully')", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Business Plan cannot be empty')", true);
            }
        }
    }
}