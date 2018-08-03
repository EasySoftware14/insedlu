using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
//using Insendlu.Entities.Domain;

using Insendu.Services;

namespace Insendlu
{
    public partial class SupportingDocs : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private readonly ImageService _imageService;
        private long _propId;
        public SupportingDocs()
        {
            _insendluEntities = new InsendluEntities();
            _imageService = new ImageService();
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null)
            {
                if (!IsPostBack)
                {
                    var query = Request.QueryString;
                    var projId = Convert.ToInt64(query.Get("id"));
                    var id = Convert.ToInt64(Session["ID"]);
                    _propId = projId;

                    if (projId != 0 && projId != null)
                    {
                        var prop = _projectService.GetProjectById(projId);
                        propposalName.InnerText = prop.name;
                    }

                    GetUserList();

                }
                else
                {
                    var query = Request.QueryString;
                    var projId = Convert.ToInt64(query.Get("id"));
                    _propId = projId;
                }
            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
        private void GetUserList()
        {
            var registeredUsers = _insendluEntities.Users.Where(x => x.status != (int) EntityStatus.InActive).ToList();

            userList.DataSource = registeredUsers;
            userList.DataBind();
        }

        protected void comments_OnClick(object sender, EventArgs e)
        {
            var comment = propComment.Text;
            var proposalId = (int) _propId;

            var x = _projectService.SaveComment(comment, proposalId);
            if (x == 1)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(),"alert","alert('Comment added successfully')");

                propComment.Text = String.Empty;
            }
        }

        protected void tagging_OnClick(object sender, EventArgs e)
        {
            var userLis = Request.Form[userList.UniqueID];
            var proposalId = (int) _propId;

            var test = _projectService.SaveProposalUser(userLis, proposalId);

            GetUserList();
        }

        //protected void attachments_OnClick(object sender, EventArgs e)
        //{
        //    var proposalId = (int) _propId;

        //    if (upload.HasFiles)
        //    {
        //        var files = upload.PostedFiles;
        //        var count = 0;

        //        foreach (var file in files)
        //        {
        //            var fileName = Page.Server.MapPath("~/Uploads/ProjectDocs/" + Path.GetFileName(file.FileName));
        //            file.SaveAs(fileName);

        //            var fileByte = _imageService.ReadToEnd(file.InputStream);

        //            var projDoc = new ProjectDocument
        //            {
        //                created_at = DateTime.Now,
        //                modified_at = DateTime.Now,
        //                doc_type = file.ContentType,
        //                name = file.FileName,
        //                proj_id = proposalId,
        //                file = fileByte

        //            };

        //            var check = _projectService.SaveProjectDocuments(projDoc);

        //            if (check == 1)
        //            {
        //                count++;
        //            }
        //        }
        //    }
        //}

        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            var filename = Page.Server.MapPath("~/Uploads/ProjectDocs/" + Path.GetFileName(e.FileName));
            // Proposal Document
            AjaxFileUpload1.SaveAs(filename);
        }
    }
}