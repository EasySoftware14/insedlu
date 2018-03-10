using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using ICSharpCode.SharpZipLib.Zip;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using Insendu.Services;

namespace Insendlu
{
    public partial class Proposals : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly UserService _userService;
        private readonly ProjectService _projectService;
        private readonly DocumentGeneratorService _documentGeneratorService;
        private long _userId;

        public Proposals()
        {
            _insendluEntities = new InsendluEntities();
            _userService = new UserService();
            _projectService = new ProjectService();
            _documentGeneratorService = new DocumentGeneratorService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                _userId = Convert.ToInt64(Session["ID"]);
            }
        }

        protected void datagridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var userType = _userService.GetUserById(_userId).user_type_id;

            if (e.CommandName == "action")
            {
                var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

                var row = datagridview.Rows[rowno];  // logical 0,1,2,3,4,5
                var label = (Label)row.FindControl("lblId");
                var id = Convert.ToInt32(label.Text);
                var status = GetProjectStatus(id);
                var isCompleted = _projectService.GetProjectById(id).is_completed;
                var projectComplete = isCompleted != null && isCompleted.Value;

                switch (status)
                {
                    case "Approved":
                        if (!projectComplete)
                        {
                            Response.Redirect("EditProject.aspx?id=" + id);
                        }
                        else
                        {
                            Response.Redirect("ViewProposal.aspx?id=" + id);
                        }
                        break;
                    case "Pending": Response.Redirect("EditProject.aspx?id=" + id);
                        break;
                    case "Submitted": Response.Redirect("Submitted.aspx?id=" + id);
                        break;
                    case "Declined": Response.Redirect("Declined.aspx?id=" + id);
                        break;
                }

            }
            if (e.CommandName == "Download")
            {
                Download(sender, e);
            }
            if (e.CommandName == "Edit")
            {

            }
            if (e.CommandName == "Status")
            {
                if (userType == 2)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Sorry, You are not allowed to access this request')", true);
                }
                else
                {
                    ChangeStatus(sender, e);
                }
               
            }
        }

        private string GetProjectStatus(int id)
        {
            var proje = (from pro in _insendluEntities.Projects
                         where pro.id == id
                         select new { Status = pro.status }).SingleOrDefault();

            return GetStatus(proje.Status);
        }

        private void Download(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked
            
            var docTempPath = Server.MapPath("~/Uploads/ProjectDocs/Insedlu-template2.docx");
            var imagePath = Server.MapPath("~/Images/");
            var row = datagridview.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);   

            var projects = (from proj in _insendluEntities.Projects
                            where proj.id == id
                            select proj).Single();

            var path = Server.MapPath("~/Uploads/ProjectDocs/" + projects.name.ToUpper() + "/");

            if (!Directory.Exists(path))
            {
                //If Directory (Folder) does not exists. Create it.
                Directory.CreateDirectory(path);
            }

            if(projects.name != null)
            {
                _documentGeneratorService.GenerateWordDocument(path, projects, imagePath, docTempPath);
                
                DownloadZip(path, projects.name);
               
            }
            
        }
        private void DownloadZip(string folderPath, string projectName)
        {
            var zipFileName = "Proposal_" + projectName + ".zip";

            Response.ContentType = "application/zip";
            Response.AddHeader("content-disposition","filename=" + zipFileName);
            byte[] buffer = new byte[4096];
            var zipOutputStream = new ZipOutputStream(Response.OutputStream);
            zipOutputStream.SetLevel(3);

            try
            {
                var DI = new DirectoryInfo(folderPath);

                foreach (var i in DI.GetFiles())
                {
                    var fs = File.OpenRead(i.FullName);
                    var zipEntry = new ZipEntry(ZipEntry.CleanName(i.Name));
                    zipEntry.Size = fs.Length;
                    zipOutputStream.PutNextEntry(zipEntry);
                    int count = fs.Read(buffer, 0, buffer.Length);

                    while (count > 0)
                    {
                        zipOutputStream.Write(buffer, 0, count);
                        count = fs.Read(buffer, 0, buffer.Length);
                        if (!Response.IsClientConnected)
                        {
                            break;
                        }
                        Response.Flush();
                    }
                    fs.Close();
                }
                zipOutputStream.Close();
                Response.Flush();
                Response.End();
            }
            catch (Exception e)
            {
                Response.Write(e.Message);
            }
        }
        private void ReadIT(string projName, string path)
        {
            Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + projName + ".docx");
            Response.TransmitFile((path + projName + ".docx"));
            Response.End();
        }
        private void ChangeStatus(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());

            var row = datagridview.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var projects = (from proj in _insendluEntities.Projects
                            where proj.id == id
                            select proj).Single();

            if (projects != null)
            {
                Session["Project"] = projects;
                Response.Redirect("StatusUpdate.aspx?id=" + id);
            }
        }
        private string GetStatus(int? status)
        {
            var newStatus = "Pending";
            switch (status)
            {
                case 0:
                    newStatus = "Pending";
                    break;
                case 1:
                    newStatus = "Submitted";
                    break;
                case 2:
                    newStatus = "Approved";
                    break;
                case 3:
                    newStatus = "Declined";
                    break;
                case 4:
                    newStatus = "Done";
                    break;
            }

            return newStatus;
        }
        protected void datagridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            datagridview.PageIndex = e.NewPageIndex;
            var source = new List<Project>();

            switch (propStatus.InnerHtml.ToLower())
            {
                case "active":
                    source = GetActiveProposals().ToList();
                    break;
                case "pending":
                    source = GetPendingProposals().ToList();
                    break;
                case "declined":
                    source = GetDeclinedProposalsList().ToList();
                    break;
                case "submitted":
                    source = GetSecuredProposals().ToList();
                    break;
            }

            datagridview.DataSource = source;
            datagridview.DataBind();
        }
        private IList<Project> GetActiveProposals()
        {
            var project = (from pro in _insendluEntities.Projects
                           where pro.status == (int) ProjectStatus.Active
                           select pro).OrderByDescending(x=>x.created_at).ToList();

            return project;
        }
        private IList<Project> GetSecuredProposals()
        {
            var project = (from pro in _insendluEntities.Projects
                           where pro.status == (int) ProjectStatus.Secured
                           select pro).OrderByDescending(x => x.created_at).ToList().ToList();

            return project;
        }
        private IList<Project> GetPendingProposals()
        {
            var project = (from pro in _insendluEntities.Projects
                           where pro.status == (int)ProjectStatus.Pending
                           select pro).OrderByDescending(x => x.created_at).ToList().ToList();

            return project;
        }
        private IList<Project> GetDeclinedProposalsList()
        {
            var project = (from decline in _insendluEntities.Projects
                           where decline.status == (int)ProjectStatus.Declined
                           select decline).OrderByDescending(x => x.created_at).ToList().ToList();

            return project;
        } 
        protected void datagridview_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void approved_OnClick(object sender, EventArgs e)
        {
            var project = GetActiveProposals();

            if (project.Count > 0)
            {
                datagridview.DataSource = project;
                datagridview.DataBind();

                datagridview.Visible = true;
                propStatus.InnerText = "Active";

            }
            else
            {
                datagridview.Visible = false;
                propStatus.InnerText = "There are no Active proposals currently";
            }
        }
        protected void submitted_OnClick(object sender, EventArgs e)
        {
            var project = GetSecuredProposals();

            if (project.Count > 0)
            {
                datagridview.DataSource = project;
                datagridview.DataBind();

                datagridview.Visible = true;
                propStatus.InnerText = "Submitted";

            }
            else
            {
                datagridview.Visible = false;
                propStatus.InnerText = "There are no Submitted proposals currently";
            }
        }
        protected void pending_OnClick(object sender, EventArgs e)
        {
            var project = GetPendingProposals();

            if (project.Count > 0)
            {
                datagridview.DataSource = project;
                datagridview.DataBind();

                datagridview.Visible = true;
                propStatus.InnerText = "Pending";

            }
            else
            {
                datagridview.Visible = false;
                propStatus.InnerText = "There are no Pending proposals currently";
            }
        }
        protected void declined_OnClick(object sender, EventArgs e)
        {
            GetDeclinedProposals();
        }
        private void GetDeclinedProposals()
        {
            var declinedGrid = GetDeclinedProposalsList();

            if (declinedGrid.Count > 0)
            {
                datagridview.DataSource = declinedGrid;
                datagridview.DataBind();

                 datagridview.Visible = true;
                propStatus.InnerText = "Declined";

            }
            else
            {
                datagridview.Visible = false;
                propStatus.InnerText = "There are no Decline proposals currently";
            }
            
        }
        protected void datagridview_OnPageIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}