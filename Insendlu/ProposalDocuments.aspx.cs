using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
////using Insendlu.Entities.Domain;

using Insendu.Services;

namespace Insendlu
{
    public partial class ProposalDocuments : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private readonly UserService _userService;
        private readonly ImageService _imageService;
        private long _proId;

        public ProposalDocuments()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
            _userService = new UserService();
            _imageService = new ImageService();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _proId = Convert.ToInt32(Request.QueryString["id"]);
                var projectDosc = GetProjectProposal(_proId);

                datagridview.DataSource = projectDosc;
                datagridview.DataBind();

            }
            else
            {
                _proId = Convert.ToInt32(Request.QueryString["id"]);
            }
        }

        private IList<ProjectProposal> GetProjectProposal(long proId)
        {
            return _insendluEntities.ProjectProposals.Where(x => x.proj_id == proId).ToList();
        }

        protected void datagridview_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void datagridview_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var projDoc = GetProjectProposal(_proId);
            datagridview.DataSource = projDoc;
            datagridview.DataBind();

            var ex = e.RowIndex;
        }

        protected void datagridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            throw new NotImplementedException();
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

            var upload = (from up in _insendluEntities.ProjectProposals
                          where up.id == id
                          select up).Single();

            var docName = upload.name;
            Remove(docName);

            _insendluEntities.ProjectProposals.Remove(upload);
            _insendluEntities.SaveChanges();
        }
        private void Remove(string docName)
        {
            var file = Server.MapPath("~/Uploads/ProposalDocuments/" + docName);

        }
        private void DownloadDocument(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = datagridview.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);


            var upload = (from up in _insendluEntities.ProjectProposals
                          where up.id == id
                          select up).Single();

            var docName = upload.name;
            var contentType = upload.document_type;

            ReadDocument(docName, contentType);
        }

        private void ReadDocument(string docName, string contentType)
        {
            Response.ContentType = contentType.ToLower();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + docName);
            Response.TransmitFile(Server.MapPath("~/Uploads/ProposalDocuments/" + docName));
            Response.End();
        }
        protected void datagridview_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void attachDocs_OnClick(object sender, EventArgs e)
        {
            _proId = Convert.ToInt32(Request.QueryString["id"]);

            var count = 0;
            if (uploadDocs.HasFiles)
            {
                var files = uploadDocs.PostedFiles;


                foreach (var file in files)
                {

                    var fileName = Page.Server.MapPath("~/Uploads/ProposalDocuments/" + Path.GetFileName(file.FileName));
                    file.SaveAs(fileName);

                    var fileByte = _imageService.ReadToEnd(file.InputStream);

                    var projDoc = new ProjectDocument
                    {
                        created_at = DateTime.Now,
                        modified_at = DateTime.Now,
                        doc_type = file.ContentType,
                        name = file.FileName,
                        proj_id = (int)_proId,
                        file = fileByte

                    };

                    var check = _projectService.SaveProposalDocument(projDoc);
                    if (check == 1)
                    {
                        count++;

                    }
                }

            }
            var projectDosc = GetProjectProposal(_proId);

            datagridview.DataSource = projectDosc;
            datagridview.DataBind();
            //success.InnerText = String.Format("{0} out of {1} document(s) uploaded successfully", count, files.Count);
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert(''" + count + "document (s) uploaded successfully)", true);
        }

    }
}
