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
    public partial class Consultancy : Page
    {
        private readonly ProjectService _projectService;
        private static int _consultId;

        public Consultancy()
        {
            _projectService = new ProjectService();
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    var query = Request.QueryString;
                    var id = query.Get("id");
                    lblSuccess.Visible = false;
                    _consultId = Convert.ToInt32(id);
                }
                else
                {
                    var query = Request.QueryString;
                    var id = query.Get("id");
                    _consultId = Convert.ToInt32(id);
                }
            }

        }

        protected void submit_OnClick(object sender, EventArgs e)
        {
            var id = _consultId;
            var data = consultancy.Content;
            var content = RemoveHtml(data);
            var success = _projectService.SaveConsulatancy(content, "", id);
            lblSuccess.Visible = false;

            if (success == 1)
            {
                lblSuccess.Text = "Consultancy Saved Successfully";
                lblSuccess.Visible = true;
                lblSuccess.ForeColor = Color.Chartreuse;

                consultancy.Content = String.Empty;
            }
            else
            {
                lblSuccess.Text = "Consultancy didn't save successfully, please try again";
                lblSuccess.Visible = true;
                lblSuccess.ForeColor = Color.Red;
            }

        }
        private string RemoveHtml(string html)
        {
            var content = string.Empty;
            content = Regex.Replace(html, "<.*?>", string.Empty).Trim();
            content = Regex.Replace(content, @"<[^>]+>|&nbsp;", "").Trim();

            return content;
        }
        protected void cancel_OnClick(object sender, EventArgs e)
        {
            consultancy.Content = String.Empty;
            Response.Redirect("~/Proposals.aspx");
        }
    }
}