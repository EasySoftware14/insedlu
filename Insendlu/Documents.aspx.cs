using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Insendlu.Entities.Connection;
//using Insendlu.Entities.Domain;
using Insendlu.Entities.MySqlConnection;
using Insendu.Services;

namespace Insendlu
{
    public partial class Documents : Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private readonly ImageService _imageService;
        private int _proId;

        public Documents()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
            _imageService = new ImageService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _proId = Convert.ToInt32(Request.QueryString["projId"]);
                var projectDosc = GetProjectDocuments(_proId);

                datagridview.DataSource = projectDosc;
                datagridview.DataBind();
                success.InnerText = String.Empty;
            }
            else
            {
                _proId = Convert.ToInt32(Request.QueryString["projId"]);
            }
        }

        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            _proId = Convert.ToInt32(Request.QueryString["projId"]);

            var filePath = _proId + "," + Path.GetFileName(e.FileName);
            var fileName = Page.Server.MapPath("~/Uploads/ProjectDocs/" + filePath);
            //AjaxFileUpload1.SaveAs(fileName);
            var fileByte = new byte[]{};

            //using (FileStream fs = File.OpenRead(filePath))
            //{
            //      fileByte = _imageService.ReadToEnd(e.);
            //}
           

            var upload = new ProjectDocument
            {
                name = filePath,
                proj_id = _proId,
                doc_type = e.ContentType,
                file = fileByte,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                location = fileName
            };

            _projectService.SaveProjectDocuments(upload);

           // ReadFile(filePath);
        }

        private void ReadFile(string fileName)
        {
            var split = fileName.Split(',');
        }

        protected void ViewDocs_OnClick(object sender, EventArgs e)
        {
            // read project documents
            var projectDosc = GetProjectDocuments(_proId);
            
            datagridview.DataSource = projectDosc;
            datagridview.DataBind();
           
        }
        private List<ProjectDocument> GetProjectDocuments(long projId)
        {
            var projectDoc = (from pro in _insendluEntities.ProjectDocuments
                              where pro.proj_id == projId
                              select pro).ToList();

            return projectDoc;
        }
        protected void datagridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                DownloadDocument(sender, e);

            }
            if (e.CommandName == "Delete")
            {
                DeleteDocument(sender, e);
            }
        }
        private void DeleteDocument(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = datagridview.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var upload = (from up in _insendluEntities.ProjectDocuments
                          where up.id == id
                          select up).Single();

            var docName = upload.name;
            Remove(docName);

            _insendluEntities.ProjectDocuments.Remove(upload);
            _insendluEntities.SaveChanges();
        }

        private void Remove(string docName)
        {
            var file = Server.MapPath("~/Uploads/ProjectDocs/" + docName);

        }
        private void DownloadDocument(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = datagridview.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);


            var upload = (from up in _insendluEntities.ProjectDocuments
                          where up.id == id
                          select up).Single();

            var docName = upload.name;
            var contentType = upload.doc_type;

            ReadDocument(docName, contentType);
        }

        private void ReadDocument(string docName, string contentType)
        {
            Response.ContentType = contentType.ToLower();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + docName);
            Response.TransmitFile(Server.MapPath("~/Uploads/ProjectDocs/" + docName));
            Response.End();
        }
        protected void datagridview_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
           
        }
        protected void datagridview_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var projDoc = GetProjectDocuments(_proId);
            datagridview.DataSource = projDoc;
            datagridview.DataBind();

            var ex = e.RowIndex;

        }

        protected void datagridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void attachDocs_OnClick(object sender, EventArgs e)
        {
             _proId = Convert.ToInt32(Request.QueryString["projId"]);
             var projDocs = _projectService.ProjectDocuments(_proId).Select(x => x.name);

            if (uploadDocs.HasFiles)
            {
                var files = uploadDocs.PostedFiles;
                var count = 0;

                foreach (var file in files)
                {
              
                    if (!projDocs.Contains(file.FileName))
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
                            proj_id = _proId,
                            file = fileByte

                        };

                        var check = _projectService.SaveProjectDocuments(projDoc);
                        if (check == 1)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Document with the same name already exists !')", true);
                        success.InnerText = "File already exists with the same name";
                    }

                    
                  
                }
                success.InnerText = String.Format("{0} out of {1} document(s) uploaded successfully", count, files.Count);
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert(''" + count + "document (s) uploaded successfully)", true);
            }
            var projDocument = GetProjectDocuments(_proId);
            datagridview.DataSource = projDocument;
            datagridview.DataBind();
        }
    }
}