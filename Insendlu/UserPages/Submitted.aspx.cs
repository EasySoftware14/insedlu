using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
using Insendu.Services;
using System.IO;
using Insendlu.Entities.Domain;
using Insendlu.Entities.MySqlConnection;

namespace Insendlu.UserPages
{
    public partial class Submitted : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private readonly ImageService _imageService;

        public Submitted()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
            _imageService = new ImageService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void attachDocs_OnClick(object sender, EventArgs e)
        {
            var query = Request.QueryString;
            var id = Convert.ToInt64(query.Get("id"));
          
            if (uploadDocs.HasFiles)
            {
                var files = uploadDocs.PostedFiles;
                var count = 0;
                
                foreach (var file in files)
                {
                    var fileName = Page.Server.MapPath("~/Uploads/ProjectDocs/" + Path.GetFileName(file.FileName));
                    file.SaveAs(fileName);
                    
                    var fileByte = _imageService.ReadToEnd(file.InputStream);

                    var projDoc = new ProjectDocument
                    {
                        created_at = DateTime.Now,
                        modified_at = DateTime.Now,
                        doc_type = file.ContentType,
                        name = file.FileName,
                        proj_id = (int) id,
                        file = fileByte

                    };

                    var check = _projectService.SaveProjectDocuments(projDoc);
                    if (check == 1)
                    {
                        count++;
                    }
                }
                success.InnerText = String.Format("{0} out of {1} document(s) uploaded successfully", count, files.Count);
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert(''"+count+"document (s) uploaded successfully)", true);

            }

        }

        protected void back_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Proposals.aspx");
        }
    }
}