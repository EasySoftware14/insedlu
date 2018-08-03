using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
using Insendu.Services;

namespace Insendlu
{
    public partial class Approved : System.Web.UI.Page
    {
        private readonly ProjectService _projectService;
        private readonly InsendluEntities _insendluEntities;
        private readonly ImageService _imageService;
        private long _logId = 0;

        public Approved()
        {
            _projectService = new ProjectService();
            _insendluEntities = new InsendluEntities();
            _imageService = new ImageService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                var query = Request.QueryString;
                var projId = Convert.ToInt64(query.Get("id"));
                var projectDosc = GetProjectDocuments(projId);
                var check = CheckActivities(projId);

                if (check)
                {
                    btnView.Visible = true;
                }

                if (projectDosc.Count > 0)
                {
                    datagridview.DataSource = projectDosc;
                    datagridview.DataBind();
                    propName.InnerText = "Proposal Name: " + GetProjectName(projId);
                }

            }
        }

        private bool CheckActivities(long log)
        {
            var check = false;

            var act = (from acts in _insendluEntities.WorkLogs
                       where acts.proj_id == log
                       select acts).ToList();

            if (act.Count > 0)
            {
                check = true;
            }
            
            return check;
        }
        private string GetProjectName(long id)
        {
            var proj = (from pro in _insendluEntities.Projects
                        where pro.id == id
                        select pro).SingleOrDefault();

            return proj.name;
        }
        private List<ProjectDocument> GetProjectDocuments(long projId)
        {
            var projectDoc = (from pro in _insendluEntities.ProjectDocuments
                              where pro.proj_id == projId
                              select pro).ToList();

            return projectDoc;
        }

        protected void work_OnClick(object sender, EventArgs e)
        {
            var query = Request.QueryString;
            var projId = Convert.ToInt64(query.Get("id"));
            var id = Convert.ToInt64(Session["ID"]);
            var logId = 0;
            var test = Request.Form[cal.UniqueID];
            var date = new DateTime();
            var chek = false;

            if (!string.IsNullOrEmpty(test))
            {
                date = Convert.ToDateTime(test).Date;
                chek = CheckWorkLog(projId, date);
            }
             
            if (string.IsNullOrEmpty(test) || chek)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Error, date cannot be empty or there's already a log for the specified date.')",
                    true);

                if (chek)
                {
                    lblError.Text = string.Format("Error, date cannot be empty or there's already a log for the specified date. <b/><a href='http://localhost:62379/ViewLogs.aspx?id={0}'>Click here to view / edit</a>", _logId);

                }
                else
                {
                    lblError.Text = string.Format("Error, date cannot be empty or there's already a log for the specified date.");

                }

            }
            else
            {
                var employ = employees.Checked;
                var accom = accomodation.Checked;
                var vehcle = vehicle.Checked;
                var wifiData = wifi.Checked;
                var refresh = refreshment.Checked;
                var tel = telephone.Checked;
                var printing = printMaterial.Checked;

                var log = new WorkLog
                {
                    date_logged = date,
                    proj_id = (int)projId,
                    user_id = (int)id
                };

                var check = _projectService.SaveWorkLog(log);

                if (check == 1)
                {
                    logId = (int)log.id;

                    if (employ)
                    {
                        var activity = new Activity
                        {
                            asset_id = 1,
                            worklog_id = logId
                        };

                        _insendluEntities.Activities.Add(activity);

                        _insendluEntities.SaveChanges();
                    }
                    if (vehcle)
                    {
                        var activity = new Activity
                        {
                            asset_id = 2,
                            worklog_id = logId
                        };

                        _insendluEntities.Activities.Add(activity);

                        _insendluEntities.SaveChanges();
                    }
                    if (accom)
                    {
                        var activity = new Activity
                        {
                            asset_id = 3,
                            worklog_id = logId
                        };

                        _insendluEntities.Activities.Add(activity);

                        _insendluEntities.SaveChanges();
                    }
                    if (printing)
                    {
                        var activity = new Activity
                        {
                            asset_id = 4,
                            worklog_id = logId
                        };

                        _insendluEntities.Activities.Add(activity);

                        _insendluEntities.SaveChanges();
                    }
                    if (refresh)
                    {
                        var activity = new Activity
                        {
                            asset_id = 5,
                            worklog_id = logId
                        };

                        _insendluEntities.Activities.Add(activity);

                        _insendluEntities.SaveChanges();
                    }
                    if (tel)
                    {
                        var activity = new Activity
                        {
                            asset_id = 6,
                            worklog_id = logId
                        };

                        _insendluEntities.Activities.Add(activity);

                        _insendluEntities.SaveChanges();
                    }
                    if (wifiData)
                    {
                        var activity = new Activity
                        {
                            asset_id = 7,
                            worklog_id = logId
                        };

                        _insendluEntities.Activities.Add(activity);

                        _insendluEntities.SaveChanges();
                    }
                }

                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Work logged successfully for the day')", true);
                Response.Redirect("LogInfo.aspx?id=" + logId);
                lblError.Text = String.Empty;
            }

            employees.Checked = false;
            accomodation.Checked = false;
            vehicle.Checked = false;
            wifi.Checked = false;
            refreshment.Checked = false;
            telephone.Checked = false;
            printMaterial.Checked = false;
        }

        private bool CheckWorkLog(long projId, DateTime date)
        {
            var chek = true;

            var log = (from logs in _insendluEntities.WorkLogs
                        where logs.proj_id == projId && logs.date_logged == date.Date
                        select logs).SingleOrDefault();

            if (log == null)
            {
                chek = false;
            }
            else
            {
                _logId = log.id;

            }

            return chek;
        }

        protected void back_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Proposals.aspx");
        }

        protected void datagridview_OnRowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void datagridview_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var query = Request.QueryString;
            var projId = Convert.ToInt64(query.Get("id"));

            var projDoc = GetProjectDocuments(projId);
            datagridview.DataSource = projDoc;
            datagridview.DataBind();

            var ex = e.RowIndex;


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
                        proj_id = (int)id,
                        file = fileByte

                    };

                    var check = _projectService.SaveProjectDocuments(projDoc);
                    if (check == 1)
                    {
                        count++;
                    }
                }
                success.InnerText = String.Format("{0} out of {1} document(s) uploaded successfully", count, files.Count);
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert(''" + count + "document (s) uploaded successfully)", true);

            }

            var projDocument = GetProjectDocuments(id);
            datagridview.DataSource = projDocument;
            datagridview.DataBind();
        }

        protected void btnView_OnClick(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('For future Implementation, loading... :)')", true);

        }
        protected void research_OnClick(object sender, EventArgs e)
        {
            var query = Request.QueryString;
            var projId = Convert.ToInt64(query.Get("id"));

            Response.Redirect("Research.aspx?id=" + projId);
        }
        protected void consultancy_OnClick(object sender, EventArgs e)
        {
            var query = Request.QueryString;
            var projId = Convert.ToInt64(query.Get("id"));

            Response.Redirect("Consultancy.aspx?id=" + projId);
        }
    }
}