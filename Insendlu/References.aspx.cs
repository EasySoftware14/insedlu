using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
////using Insendlu.Entities.Domain;
using Insendlu.Entities.MySqlConnection;
using Insendu.Services;

namespace Insendlu
{
    public partial class References : System.Web.UI.Page
    {
        private readonly ProjectService _projectService;
        public References()
        {
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AjaxFileUpload1_OnUploadStart(object sender, AjaxFileUploadStartEventArgs e)
        {
            //var hence = e.f;
            
        }

        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            var name = e.FileName;
        }

        protected void upload_OnClick(object sender, EventArgs e)
        {
            var files = fileUpload.PostedFiles;
            if (files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    var filename = Page.Server.MapPath("~/Uploads/" + System.IO.Path.GetFileName(file.FileName));
                    file.SaveAs(filename);

                    var uploadDoc = new Upload()
                    {
                        created_at = DateTime.Now,
                        name = file.FileName,
                        content_type = file.ContentType,
                        modified_at = DateTime.Now,
                        file_location = filename

                    };

                    var check = _projectService.SaveDocuments(uploadDoc);
                }
                
            }

        }
    }
}