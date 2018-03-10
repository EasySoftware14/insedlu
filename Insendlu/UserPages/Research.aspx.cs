using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendu.Services;

namespace Insendlu
{
    public partial class Research : System.Web.UI.Page
    {
        private readonly ProjectService _projectService;
        private int _researchId;

        public Research()
        {
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/Index.aspx");
            }
            if (!IsPostBack)
            {
                var query = Request.QueryString;
                var id = query.Get("id");
                _researchId = Convert.ToInt32(id);
                lblSuccess.Visible = false;
            }
            else
            {
                var query = Request.QueryString;
                var id = query.Get("id");
                _researchId = Convert.ToInt32(id);
            }
            
        }

        protected void cancel_OnClick(object sender, EventArgs e)
        {
             research.Content = String.Empty;
             Response.Redirect("~/Proposals.aspx");
            
        }
        private string RemoveHtml(string html)
        {
            var content = string.Empty;
            content = Regex.Replace(html, "<.*?>", string.Empty).Trim();
            content = Regex.Replace(content, @"<[^>]+>|&nbsp;", "").Trim();

            return content;
        }
        protected void submit_OnClick(object sender, EventArgs e)
        {
            var id = _researchId;
            var data = research.Content;
            var content = RemoveHtml(data);
            var success = _projectService.SaveResearch(content, "Test Research", id);
            lblSuccess.Visible = false;

            if (success == 1)
            {
                lblSuccess.Text = "Research Saved Successfully";
                lblSuccess.Visible = true;
                lblSuccess.ForeColor = Color.Chartreuse;

                research.Content = String.Empty;
            }
            else
            {
                lblSuccess.Text = "Research didn't save successfully, please try again";
                lblSuccess.Visible = true;
                lblSuccess.ForeColor = Color.Red;
            }
        }
    }
}