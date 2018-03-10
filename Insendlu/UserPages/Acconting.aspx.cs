using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Insendu.Services;
using System.IO;

namespace Insendlu.UserPages
{
    public partial class Acconting : System.Web.UI.Page
    {
        private readonly ProjectService _projectService;

        public Acconting()
        {
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cancel_OnClick(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Dashboard.aspx");
        }
     
        protected void accountingFiles_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            var filename = Page.Server.MapPath("~/Uploads/Accounting/" + Path.GetFileName(e.FileName));
            
            accountingFiles.SaveAs(filename);
        }
    }
}