using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using Insendlu.Entities.MySqlConnection;
using Insendu.Services;

namespace Insendlu.UserPages
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        private readonly insedluEntities _insendluEntities;
        private readonly ImageService _imageService;
        private readonly ProjectService _projectService;

        //public UserDashboard()
        //{
        //    _insendluEntities = new insedluEntities();
        //    _projectService = new ProjectService();
        //    _imageService = new ImageService();
        //}
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    var id = new long();

        //    if (Session["ID"] == null)
        //    {
        //        Response.Redirect("Index.aspx");
        //    }
        //    else
        //    {
        //        id = Convert.ToInt64(Session["ID"]);
        //        ProfileUpdate(id);

        //    }

        //    if (!IsPostBack)
        //    {
        //        id = Convert.ToInt64(Session["ID"]);

        //        ProfilePictureUpdate(id);

        //        DataGridBind();
        //        ResearchProject();
        //        GuideDataGridBind();
        //        TasksDataGridBind(id);
        //        MyStoryCheck();
        //    }
        //    else
        //    {
        //        DataGridBind();
        //        GuideDataGridBind();
        //        view.Content = String.Empty;
        //    }
        //}

        //private void ProfilePictureUpdate(long id)
        //{
        //    var profile = (from userProf in _insendluEntities.userprofiles
        //                   where userProf.user_id == (int)id
        //                   select userProf).FirstOrDefault();

        //    if (profile != null)
        //    {
        //        var imgBytes = profile.profile_pic;
        //        var imgString = "data: Image/png;base64," + Convert.ToBase64String(imgBytes);

        //        image.Src = imgString;
        //    }

        //}
        //private void ProfileUpdate(long id)
        //{
        //    var users = (from user in _insendluEntities.users

        //                 where user.id == id

        //                 select user).SingleOrDefault();

        //    if (users != null)
        //    {
        //        lblName.InnerText = users.name + " " + users.surname;
        //        lblContact.InnerText = users.contact_number;
        //        lblEmail.InnerText = users.email;

        //        txtName.Value = users.name;
        //        txtSurname.Value = users.surname;

        //        if (!string.IsNullOrEmpty(users.contact_number))
        //        {
        //            txtContact.Text = users.contact_number;
        //        }

        //    }

        //}
        //private void ResearchProject()
        //{
        //    var projects = (from proj in _insendluEntities.projects
        //                    where proj.status == (int)ProjectStatus.Approved
        //                    select proj).ToList();

        //    if (projects.Count != 0)
        //    {
        //        addResearch.Visible = false;
        //        researchGrid.DataSource = projects;
        //        researchGrid.DataBind();
        //        GridView2.DataSource = projects;
        //        GridView2.DataBind();
        //    }
        //    else
        //    {
        //        addResearch.Visible = true;
        //    }
        //}

        //private void MyStoryCheck()
        //{
        //    var id = Convert.ToInt64(Session["ID"]);
        //    var viewUserStory = _projectService.ViewMyStory(id);

        //    if (viewUserStory != null)
        //    {
        //        viewstoryEditor.Visible = true;
        //        viewstoryEditor.Content = viewUserStory.story;
        //    }
        //    else
        //    {
        //        viewstoryEditor.Visible = false;
        //        viewStoryError.InnerText = "No Story recorded currently";
        //    }

        //}
        //private void TasksDataGridBind(long id)
        //{
        //    var task = _projectService.MyTasks(id);

        //    if (task != null)
        //    {
        //        view.Content = task.body;
        //        view.Visible = true;
        //    }
        //    else
        //    {
        //        view.Visible = false;
        //        errorMessage.InnerText = "You currently don't have task(s)";
        //    }
        //}
        //protected void resetPassword_OnClick(object sender, EventArgs e)
        //{

        //}
        //protected void changeProfilePic_OnClick(object sender, EventArgs e)
        //{
        //    var name = txtName.Value;
        //    var surname = txtSurname.Value;
        //    var contact = txtContact.Text;
        //    var id = Convert.ToInt64(Session["ID"]);
        //    var file = FileUpload.HasFile;

        //    if (file && (FileUpload.PostedFile.ContentType == "image/jpeg"))
        //    {
        //        var byteArray = _imageService.ReadToEnd(FileUpload.PostedFile.InputStream);


        //        var getProfile = (from prof in _insendluEntities.UserProfiles
        //                          where prof.user_id == id
        //                          select prof).SingleOrDefault();

        //        var user = (from prof in _insendluEntities.Users
        //                    where prof.id == id
        //                    select prof).SingleOrDefault();
        //        if (user != null)
        //        {
        //            user.contact_number = contact;

        //            _insendluEntities.SaveChanges();
        //        }

        //        if (getProfile != null)
        //        {
        //            getProfile.contact_number = contact;
        //            getProfile.profile_pic = byteArray;
        //            try
        //            {
        //                _insendluEntities.SaveChanges();
        //            }
        //            catch (DbEntityValidationException validation)
        //            {

        //                var error = validation.EntityValidationErrors;
        //            }

        //        }
        //        else
        //        {

        //            var profile = new UserProfile
        //            {
        //                contact_number = contact,
        //                profile_pic = byteArray,
        //                user_id = (int)id
        //            };

        //            _insendluEntities.UserProfiles.Add(profile);

        //            _insendluEntities.SaveChanges();
        //        }

        //    }
        //    else
        //    {
        //        var getProfile = (from prof in _insendluEntities.UserProfiles
        //                          where prof.user_id == id
        //                          select prof).SingleOrDefault();

        //        var user = (from prof in _insendluEntities.Users
        //                    where prof.id == id
        //                    select prof).SingleOrDefault();

        //        if (user != null)
        //        {
        //            user.contact_number = contact;

        //            _insendluEntities.SaveChanges();
        //        }

        //        if (getProfile != null)
        //        {
        //            getProfile.contact_number = contact;

        //            _insendluEntities.SaveChanges();
        //        }
        //        else
        //        {
        //            var profile = new UserProfile
        //            {
        //                contact_number = contact,
        //                user_id = (int)id
        //            };

        //            _insendluEntities.UserProfiles.Add(profile);

        //            _insendluEntities.SaveChanges();
        //        }
        //    }

        //    ProfilePictureUpdate(id);
        //    ProfileUpdate(id);
        //}
        //protected void cancel_OnClick(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Dashboard.aspx");
        //}
        //protected void ButtonBind_Click(object sender, EventArgs e)
        //{
        //    GridView1.DataSource = GetVideoInfo();
        //    GridView1.DataBind();
        //}
        //private object GetVideoInfo()
        //{
        //    var uploads = (from upload in _insendluEntities.Uploads
        //                   where upload.content_type != "application/pdf" || upload.content_type != "application/text"
        //                   select upload).ToList();



        //    return uploads;
        //}
        //private object GetSpecificVideo(object i)
        //{
        //    var id = Convert.ToInt64(i);
        //    var uploads = (from upload in _insendluEntities.Uploads
        //                   where upload.id == id
        //                   select upload).ToList();

        //    return uploads;
        //}
        //protected void ButtonShowVideo_Click(object sender, EventArgs e)
        //{
        //    Repeater1.DataSource = GetSpecificVideo(1);
        //    Repeater1.DataBind();
        //}
        //protected void UploadGuide_OnClick(object sender, EventArgs e)
        //{
        //    var id = Convert.ToInt64(Session["ID"]);
        //    var files = GuideUpload.PostedFiles;
        //    var fileFormats = new[] { "pdf", "doc", "docx", "xls" };
        //    var fil = Path.GetExtension(files[0].FileName);
        //    var path = Page.Server.MapPath("~/Uploads/Guides/");
        //    if (!string.IsNullOrEmpty(files[0].FileName))
        //    {
        //        for (int i = 0; i < files.Count; i++)
        //        {
        //            var file = files[i];
        //            var exist = File.Exists(path + Path.GetFileName(file.FileName));

        //            if (!fileFormats.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.') + 1).ToLower()))
        //            {
        //                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Please only upload .pdf, .doc/.docx')", true);
        //            }
        //            else if (!exist)
        //            {
        //                var filename = Page.Server.MapPath("~/Uploads/Guides/" + Path.GetFileName(file.FileName));
        //                file.SaveAs(filename);

        //                var uploadDoc = new Upload()
        //                {
        //                    created_at = DateTime.Now,
        //                    name = file.FileName,
        //                    content_type = file.ContentType,
        //                    modified_at = DateTime.Now,
        //                    file_location = filename,
        //                    user_id = (int)id

        //                };

        //                var check = _projectService.SaveDocuments(uploadDoc);

        //                if (check == 1)
        //                {
        //                    DataGridBind();
        //                }

        //            }

        //        }

        //    }
        //    else
        //    {
        //        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Please upload at least one file')", true);
        //    }
        //}
        //protected void GuideView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GuideView.PageIndex = e.NewPageIndex;
        //    DataGridBind();
        //}
        //private void GuideDataGridBind()
        //{
        //    var upload = (from up in _insendluEntities.Uploads
        //                  where up.content_type == "application/pdf" || up.content_type == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
        //                  select up).ToList();

        //    if (upload.Count != 0)
        //    {
        //        GuideView.DataSource = upload;
        //        GuideView.DataBind();

        //    }

        //    else
        //    {
        //        lblGuideError.InnerText = "No Guides loaded currently";
        //    }
        //}
        //private void DataGridBind()
        //{
        //    var upload = (from up in _insendluEntities.Uploads
        //                  where up.content_type != "application/pdf" && up.content_type != "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
        //                  select up).ToList();

        //    if (upload.Count != 0)
        //    {

        //        GridView1.DataSource = upload;
        //        GridView1.DataBind();

        //    }
        //}
        //protected void GuideView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    var command = e.CommandName;

        //    if (command == "Download")
        //    {
        //        DownloadGuide(sender, e);
        //    }
        //    if (command == "Delete")
        //    {
        //        DeleteGuide(sender, e);
        //    }
        //}

        //private void DeleteGuide(object sender, GridViewCommandEventArgs e)
        //{
        //    var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

        //    var row = GuideView.Rows[rowno];
        //    var label = (Label)row.FindControl("lblId");
        //    var id = Convert.ToInt32(label.Text);

        //    var upload = (from up in _insendluEntities.Uploads
        //                  where up.id == id
        //                  select up).Single();

        //    if (upload != null)
        //    {
        //        _insendluEntities.Uploads.Remove(upload);

        //        _insendluEntities.SaveChanges();
        //        GuideDataGridBind();
        //    }
        //}

        //private void DownloadGuide(object sender, GridViewCommandEventArgs e)
        //{
        //    var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

        //    var row = GuideView.Rows[rowno];
        //    var label = (Label)row.FindControl("lblId");
        //    var id = Convert.ToInt32(label.Text);

        //    var upload = (from up in _insendluEntities.Uploads
        //                  where up.id == id
        //                  select up).Single();

        //    var projName = upload.name;
        //    var contentType = upload.content_type;

        //    ReadGuides(projName, contentType);
        //}
        //private void Download(object sender, GridViewCommandEventArgs e)
        //{
        //    var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

        //    var row = GridView1.Rows[rowno];
        //    var label = (Label)row.FindControl("lblId");
        //    var id = Convert.ToInt32(label.Text);

        //    var upload = (from up in _insendluEntities.Uploads
        //                  where up.id == id
        //                  select up).Single();

        //    var projName = upload.name;
        //    var contentType = upload.content_type;

        //    ReadTutorials(projName, contentType);

        //}
        //private void ReadTutorials(string projName, string contentType)
        //{
        //    Response.ContentType = contentType.ToLower();
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + projName);
        //    Response.TransmitFile(Server.MapPath("~/Uploads/Tutorials/" + projName));
        //    Response.End();
        //}
        //private void ReadGuides(string projName, string contentType)
        //{
        //    Response.ContentType = contentType.ToLower();
        //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + projName);
        //    Response.TransmitFile(Server.MapPath("~/Uploads/Guides/" + projName));
        //    Response.End();
        //}
        //protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    var command = e.CommandName;

        //    if (command == "Download")
        //    {
        //        Download(sender, e);
        //    }
        //}

        //protected void btnMyTasks_OnClick(object sender, EventArgs e)
        //{
        //    errorMessage.InnerText = string.Empty;
        //    var id = Convert.ToInt64(Session["ID"]);

        //    if (!string.IsNullOrEmpty(myTasksEditor.Content))
        //    {
        //        var body = myTasksEditor.Content;

        //        var task = new task()
        //        {
        //            created_at = DateTime.Now,
        //            body = body,
        //            modified_at = DateTime.Now,
        //            user_id = (int)id
        //        };
        //        var myTask = _projectService.MyTasks(id);
        //        if (myTask != null)
        //        {
        //            _insendluEntities.Tasks.Attach(myTask);
        //            _insendluEntities.Tasks.Remove(myTask);
        //            _insendluEntities.SaveChanges();
        //        }

        //        var check = _projectService.SaveTask(task);

        //        if (check == 1)
        //        {
        //            TasksDataGridBind(id);
        //        }
        //    }
        //}

        //protected void saveStory_OnClick(object sender, EventArgs e)
        //{
        //    var id = Convert.ToInt64(Session["ID"]);

        //    if (!string.IsNullOrEmpty(editor.Content))
        //    {
        //        var body = editor.Content;

        //        var story = new MyStory()
        //        {
        //            created_at = DateTime.Now,
        //            modified_at = DateTime.Now,
        //            story = body,
        //            user_id = (int)id
        //        };

        //        var save = _projectService.SaveStory(story, id);

        //        if (save == 1)
        //        {
        //            MyStoryCheck();
        //        }

        //    }
        //}

        //protected void viewTask_OnClick(object sender, EventArgs e)
        //{
        //    errorMessage.InnerText = string.Empty;
        //    var id = Convert.ToInt64(Session["ID"]);

        //    var task = _projectService.MyTasks(id);

        //    if (task != null)
        //    {
        //        view.Content = task.body;
        //        view.Visible = true;
        //    }
        //    else
        //    {
        //        view.Visible = false;
        //        errorMessage.InnerText = "You currently don't have task(s)";
        //    }
        //}

        //protected void viewStory_OnClick(object sender, EventArgs e)
        //{
        //    var id = Convert.ToInt64(Session["ID"]);

        //    var viewUserStory = _projectService.ViewMyStory(id);

        //    if (!string.IsNullOrEmpty(viewUserStory.story))
        //    {
        //        editor.Content = viewUserStory.story;
        //    }
        //    else
        //    {

        //    }

        //}

        //protected void GuideView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    var indes = e.RowIndex;

        //}

        //protected void submit_OnClick(object sender, EventArgs e)
        //{
        //    var content = Editor1.Content.TrimEnd('<');
        //    //var id = _projectService.SaveResearch(content, "Test Research",id);
        //}

        //protected void btnConsultancy_OnClick(object sender, EventArgs e)
        //{
        //    var content = Editor1.Content.TrimEnd('<');
        //    //var id = _projectService.SaveConsulatancy(content);
        //}

        //protected void research_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //}

        //protected void research_OnRowEditing(object sender, GridViewEditEventArgs e)
        //{
        //}

        //protected void research_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Research")
        //    {
        //        var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

        //        var row = researchGrid.Rows[rowno];
        //        var label = (Label)row.FindControl("lblId");
        //        var id = Convert.ToInt32(label.Text);

        //        Response.Redirect("Research.aspx?id=" + id);
        //    }
        //    if (e.CommandName == "Consult")
        //    {
        //        var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

        //        var row = researchGrid.Rows[rowno];
        //        var label = (Label)row.FindControl("lblId");
        //        var id = Convert.ToInt32(label.Text);

        //        Response.Redirect("Consultancy.aspx?id=" + id);
        //    }
        //}
    }
}