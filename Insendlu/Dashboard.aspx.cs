using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using Insendu.Services;
using java.util;
using Novacode;

namespace Insendlu
{
    public partial class Profile : System.Web.UI.Page
    {
        //private readonly insedluEntities _insedlu;
        private readonly InsendluEntities _insedlu;
        private readonly ImageService _imageService;
        private readonly ProjectService _projectService;
        private readonly EmailService _emailService;
        private long _id;
        public bool dateDueChecker = false;

        public Profile()
        {
            _insedlu = new InsendluEntities();
            _projectService = new ProjectService();
            _imageService = new ImageService();
            _emailService = new EmailService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var id = new long();
            var test = GetPostBackControlId(Page);
            if (Session["ID"] == null)
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                id = Convert.ToInt64(Session["ID"]);
                _id = id;
                ProfileUpdate(id);

            }

            if (!IsPostBack)
            {
                id = Convert.ToInt64(Session["ID"]);
                var userAddCheck = Convert.ToBoolean(Session["UserAdded"]) == true ? userSuccess.Visible = true : userSuccess.Visible = false;
                //SetUpSlide();
                LoggingsBinding();
                SetTasks(id);


                SetTasksForUpdate(_id);
                var statuses = Enum.GetValues(typeof(TaskStatus)).Cast<TaskStatus>().ToList();

                statusDropdown.DataSource = statuses;
                statusDropdown.DataBind();

                if (userAddCheck)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('User Added Successfully')", true);
                }

                ProfilePictureUpdate(id);

                DataGridBind();
                ResearchProject();
                GuideDataGridBind();
                TasksDataGridBind(id);
                MyStoryCheck();
                GetUserList();
                GetTaskList();
            }
            else
            {
                DataGridBind();
                LoggingsBinding();
                GuideDataGridBind();
                view.Content = string.Empty;
                SetTasks(id);
            }
        }
        public static string GetPostBackControlId(Page page)
        {
            if (!page.IsPostBack)
                return string.Empty;

            Control control = null;
            // first we will check the "__EVENTTARGET" because if post back made by the controls
            // which used "_doPostBack" function also available in Request.Form collection.
            string controlName = page.Request.Params["__EVENTTARGET"];
            if (!String.IsNullOrEmpty(controlName))
            {
                control = page.FindControl(controlName);
            }
            else
            {
                // if __EVENTTARGET is null, the control is a button type and we need to
                // iterate over the form collection to find it

                // ReSharper disable TooWideLocalVariableScope
                string controlId;
                Control foundControl;
                // ReSharper restore TooWideLocalVariableScope

                foreach (string ctl in page.Request.Form)
                {
                    // handle ImageButton they having an additional "quasi-property" 
                    // in their Id which identifies mouse x and y coordinates
                    if (ctl.EndsWith(".x") || ctl.EndsWith(".y"))
                    {
                        controlId = ctl.Substring(0, ctl.Length - 2);
                        foundControl = page.FindControl(controlId);
                    }
                    else
                    {
                        foundControl = page.FindControl(ctl);
                    }

                    if (!(foundControl is IButtonControl)) continue;

                    control = foundControl;
                    break;
                }
            }

            return control == null ? String.Empty : control.ID;
        }
        private void SetTasksForUpdate(long id)
        {
            var myTasks = _projectService.MyTasks(id).OrderByDescending(x => x.created_at);

            if (myTasks.Any())
            {
                tasksToUpdate.DataSource = myTasks;
                tasksToUpdate.DataBind();
            }
        }
        private void LoggingsBinding()
        {
            var projects = _insedlu.Loggings.ToList();
            datagridview.DataSource = projects;
            datagridview.DataBind();
        }
        private void SetTasks(long id)
        {
            var myTasks = _projectService.MyTasks(id);
            var todaysDate = DateTime.Today.Date;
            if (myTasks != null)
            {
                var completedItems = new List<ListItem>();

                // completed tasks
                var completedId = (int)TaskStatus.Done;
                var completedTasksList = myTasks.Where(x => x.status == completedId).ToList();
                if (completedTasksList.Count > 0)
                {

                    foreach (var task in completedTasksList)
                    {
                        var due = DateTime.Today;

                        if (task?.due_date != null) due = task.due_date.Value.Date;

                        var days = GetRemainingDays(due, todaysDate);

                        if (task != null)
                        {
                            if (days >= 0)
                            {
                                completedItems.Add(new ListItem(task.body));
                            }
                        }

                        completedTasks.Visible = true;
                    }
                }
                else
                {
                    noComplete.Visible = true;
                }
                // In-progress
                var inProgressTasks = myTasks.Where(x => x.status != (int)TaskStatus.Done).ToList();
                if (inProgressTasks.Count > 0)
                {
                    var inprogressItems = new List<ListItem>();

                    foreach (var task in inProgressTasks)
                    {
                        var due = DateTime.Today;

                        if (task?.due_date != null) due = task.due_date.Value.Date;

                        var days = GetRemainingDays(due, todaysDate);

                        if (task != null)
                        {
                            if (days < 0)
                            {
                                var listItem = new ListItem();
                                listItem.Text = "NB: " + task.body.PadLeft(20).ToUpper() + " # " + (days * -1).ToString().ToUpper() + " DAYS OVERDUE.";
                                listItem.Attributes.Add("style","color:red;");

                                completedItems.Add(listItem);

                            }
                            else
                                inprogressItems.Add(new ListItem(task.body.PadLeft(20) + " #                    " + days + " days left."));
                        }
                    }
                    completedTasks.DataSource = completedItems; ;
                    completedTasks.DataBind();

                    inProgress.DataSource = inprogressItems;
                    inProgress.DataBind();
                    inProgress.Visible = true;

                }
                else
                {
                    lblNoTask.Visible = true;
                }
                // Assigned Tasks
                var statsId = (int)TaskStatus.Assigned;
                var assigned = myTasks.Select(x => x).Where(x => x.status == statsId).ToList();
                if (assigned.Count > 0)
                {
                    var items = new List<ListItem>();

                    foreach (var task in assigned)
                    {
                        var userAssigned = new global::User();
                        if (task.assigned_to != null)
                            userAssigned = _projectService.GetUserById(task.assigned_to.Value);

                        if (userAssigned.id != 0)
                        {
                            items.Add(new ListItem(task.body + "                 # Assignee: " + userAssigned.name + " " + userAssigned.surname, task.id.ToString()));
                        }
                        else
                        {
                            items.Add(new ListItem(task.body + "                    # Not Assigned"));
                        }
                    }

                    lstAssignedTasks.DataSource = items;
                    lstAssignedTasks.DataBind();
                    lstAssignedTasks.Visible = true;
                }
                else
                {
                    lblWarning.Visible = true;
                }

                myTasksList.Visible = true;
                var tasksList = myTasks.Where(x => x.status == (int)TaskStatus.Assigned || x.status == (int)TaskStatus.NotAssigned).OrderByDescending(x => x.created_at).Select(y => y.body).ToList();
                var stringbuild = new StringBuilder();
                var count = 0;

                if (tasksList.Count < 1)
                {
                    myTasksList.Visible = false;
                    taskError.Visible = true;
                }
                else
                {
                    foreach (var task in tasksList)
                    {
                        count++;
                        stringbuild.Append(count + ". " + task + Environment.NewLine);
                    }

                    myTasksList.Text = Convert.ToString(stringbuild);
                }

                //SetTaskProcess(inProgressTasks);
                //inProgress.DataBind();
            }

        }
        private void SetTaskProcess(List<Task> taskes)
        {
            var todaysDate = DateTime.Today.Date;

            foreach (var task in taskes)
            {
                var due = DateTime.Today;
                var daysLeft = 0;
                if (task != null)
                {
                    if (task.due_date != null) due = task.due_date.Value.Date;
                }

                var days = GetRemainingDays(due, todaysDate);
                var completion = _projectService.GeTaskCompletion(task.id);

                if (days < 0)
                    task.body = task.body + " \t" + "This task is " + Convert.ToInt32(completion.completion) * -1 + " days overdue.";
                else
                    task.body = task.body + " \t" + completion.completion + " days left to complete.";

            }
        }

        private int GetTaskCompletionPercent()
        {
            return 4;
        }
        private void ProfilePictureUpdate(long id)
        {
            var profile = (from userProf in _insedlu.UserProfiles
                           where userProf.user_id == (int)id
                           select userProf).FirstOrDefault();

            if (profile != null)
            {
                textBio.Text = profile.biography;
                txtPosition.Value = profile.position;

                var imgBytes = profile.profile_pic;

                if (imgBytes != null)
                {
                    var imgString = "data: Image/png;base64," + Convert.ToBase64String(imgBytes);
                    image.ImageUrl = imgString;
                }

            }

        }
        private void ProfileUpdate(long id)
        {
            var users = (from user in _insedlu.Users

                         where user.id == id

                         select user).SingleOrDefault();

            if (users != null)
            {
                lblName.Text = users.name + " " + users.surname;
                //lblContact.InnerText = users.contact_number;
                //lblEmail.InnerText = users.email;

                txtName.Value = users.name;
                txtSurname.Value = users.surname;

                if (!string.IsNullOrEmpty(users.contact_number))
                {
                    txtContact.Text = users.contact_number;
                }

            }

        }
        private void ResearchProject()
        {
            var projects = (from proj in _insedlu.Projects
                            where proj.status == (int)ProjectStatus.Active
                            select proj).ToList();

            if (projects.Count != 0)
            {
                addResearch.Visible = false;
                researchGrid.DataSource = projects;
                researchGrid.DataBind();
                GridView2.DataSource = projects;
                GridView2.DataBind();
            }
            else
            {
                addResearch.Visible = true;
            }
        }
        private void MyStoryCheck()
        {
            var id = Convert.ToInt64(Session["ID"]);
            var viewUserStory = _projectService.ViewMyStory(id);

            if (viewUserStory != null)
            {
                viewstoryEditor.Visible = true;
                viewstoryEditor.Content = viewUserStory.story;
            }
            else
            {
                viewstoryEditor.Visible = false;
                viewStoryError.InnerText = "No Story recorded currently";
            }

        }
        private void GetUserList()
        {
            var registeredUsers = _insedlu.Users.Where(x => x.status != (int)EntityStatus.InActive).ToList();

            userList.DataSource = registeredUsers;
            userList.DataBind();
        }
        private void GetTaskList()
        {
            var registeredUsers = _insedlu.Tasks.Where(x => x.status != (int)TaskStatus.Done).ToList();

            tasks.DataSource = registeredUsers;
            tasks.DataBind();
        }
        private void TasksDataGridBind(long id)
        {
            var task = _projectService.MyTasks(id);

            if (task != null)
            {
                view.Content = task.SingleOrDefault(x => x.created_at == DateTime.Today)?.body;
                view.Visible = true;
            }
            else
            {
                view.Visible = false;
                errorMessage.InnerText = "You currently don't have task(s)";
            }
        }
        protected void resetPassword_OnClick(object sender, EventArgs e)
        {

        }
        protected void changeProfilePic_OnClick(object sender, EventArgs e)
        {
            var name = txtName.Value;
            var surname = txtSurname.Value;
            var contact = txtContact.Text;
            var biography = textBio.Text;

            var id = Convert.ToInt64(Session["ID"]);
            var file = FileUpload.HasFile;

            if (file && (FileUpload.PostedFile.ContentType == "image/jpeg"))
            {
                var byteArray = _imageService.ReadToEnd(FileUpload.PostedFile.InputStream);


                var getProfile = (from prof in _insedlu.UserProfiles
                                  where prof.user_id == id
                                  select prof).SingleOrDefault();

                var user = (from prof in _insedlu.Users
                            where prof.id == id
                            select prof).SingleOrDefault();

                if (user != null)
                {
                    user.contact_number = contact;

                    _insedlu.SaveChanges();
                }

                if (getProfile != null)
                {
                    getProfile.contact_number = contact;
                    getProfile.profile_pic = byteArray;
                    getProfile.biography = biography;
                    getProfile.position = txtPosition.Value;

                    try
                    {
                        _insedlu.SaveChanges();
                        ProfilePictureUpdate(id);
                    }
                    catch (DbEntityValidationException validation)
                    {

                        var error = validation.EntityValidationErrors;
                    }

                }
                else
                {

                    var profile = new UserProfile
                    {
                        contact_number = contact,
                        profile_pic = byteArray,
                        user_id = (int)id,
                        biography = biography,
                        position = txtPosition.Value

                    };

                    _insedlu.UserProfiles.Add(profile);

                    _insedlu.SaveChanges();
                }

            }
            else
            {
                var getProfile = (from prof in _insedlu.UserProfiles
                                  where prof.user_id == id
                                  select prof).SingleOrDefault();

                var user = (from prof in _insedlu.Users
                            where prof.id == id
                            select prof).SingleOrDefault();

                if (user != null)
                {
                    user.contact_number = contact;

                    _insedlu.SaveChanges();
                }

                if (getProfile != null)
                {
                    getProfile.contact_number = contact;

                    _insedlu.SaveChanges();
                }
                else
                {
                    var profile = new UserProfile
                    {
                        contact_number = contact,
                        user_id = (int)id
                    };

                    _insedlu.UserProfiles.Add(profile);

                    _insedlu.SaveChanges();
                }
            }

            ProfilePictureUpdate(id);
            ProfileUpdate(id);
        }
        protected void cancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard.aspx");
        }
        protected void ButtonBind_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = GetVideoInfo();
            GridView1.DataBind();
        }
        private object GetVideoInfo()
        {
            var uploads = (from upload in _insedlu.Uploads
                           where upload.content_type != "application/pdf" || upload.content_type != "application/text"
                           select upload).ToList();



            return uploads;
        }
        private object GetSpecificVideo(object i)
        {
            var id = Convert.ToInt64(i);
            var uploads = (from upload in _insedlu.Uploads
                           where upload.id == id
                           select upload).ToList();

            return uploads;
        }
        protected void ButtonShowVideo_Click(object sender, EventArgs e)
        {
            Repeater1.DataSource = GetSpecificVideo(1);
            Repeater1.DataBind();
        }
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

        //                var uploadDoc = new Upload
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
        protected void GuideView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GuideView.PageIndex = e.NewPageIndex;
            DataGridBind();
        }
        private void GuideDataGridBind()
        {
            var upload = (from up in _insedlu.Uploads
                          where up.content_type == "application/pdf" || up.content_type == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                          select up).ToList();

            if (upload.Count != 0)
            {
                GuideView.DataSource = upload;
                GuideView.DataBind();

            }

            else
            {
                lblGuideError.InnerText = "No Guides loaded currently";
            }
        }
        private void DataGridBind()
        {
            var upload = (from up in _insedlu.Uploads
                          where up.content_type != "application/pdf" && up.data != null && up.content_type != "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                          select up).ToList();

            if (upload.Count != 0)
            {

                GridView1.DataSource = upload;
                GridView1.DataBind();

            }
        }
        protected void GuideView_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var command = e.CommandName;

            if (command == "Download")
            {
                DownloadGuide(sender, e);
            }
            if (command == "Delete")
            {
                DeleteGuide(sender, e);
            }
        }

        private void DeleteGuide(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = GuideView.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var upload = (from up in _insedlu.Uploads
                          where up.id == id
                          select up).Single();

            if (upload != null)
            {
                _insedlu.Uploads.Remove(upload);

                _insedlu.SaveChanges();
                GuideDataGridBind();
            }
        }

        private void DownloadGuide(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = GuideView.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var upload = (from up in _insedlu.Uploads
                          where up.id == id
                          select up).Single();

            var projName = upload.name;
            var contentType = upload.content_type;

            ReadGuides(projName, contentType);
        }
        private void Download(object sender, GridViewCommandEventArgs e)
        {
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = GridView1.Rows[rowno];
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var upload = (from up in _insedlu.Uploads
                          where up.id == id
                          select up).Single();

            var projName = upload.name;
            var contentType = upload.content_type;

            ReadTutorials(projName, contentType);

        }
        private void ReadTutorials(string projName, string contentType)
        {
            Response.ContentType = contentType.ToLower();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + projName);
            Response.TransmitFile(Server.MapPath("~/Uploads/Tutorials/" + projName));
            Response.End();
        }
        private void ReadGuides(string projName, string contentType)
        {
            Response.ContentType = contentType.ToLower();
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + projName);
            Response.TransmitFile(Server.MapPath("~/Uploads/Guides/" + projName));
            Response.End();
        }
        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            var command = e.CommandName;

            if (command == "Download")
            {
                Download(sender, e);
            }
        }

        protected void btnMyTasks_OnClick(object sender, EventArgs e)
        {
            errorMessage.InnerText = string.Empty;
            var id = Convert.ToInt64(Session["ID"]);

            if (!string.IsNullOrEmpty(myTasksEditor.Content))
            {
                var body = myTasksEditor.Content;

                var task = new Task
                {
                    created_at = DateTime.Now,
                    body = body,
                    modified_at = DateTime.Now,
                    user_id = (int)id
                };
                var myTask = _projectService.MyTasks(id);
                if (myTask != null)
                {
                    _insedlu.Tasks.Attach(myTask.Single(x => x.created_at == DateTime.Today));
                    _insedlu.Tasks.Remove(myTask.Single(x => x.created_at == DateTime.Today));
                    _insedlu.SaveChanges();
                }

                var check = _projectService.SaveTask(task);

                if (check == 1)
                {
                    TasksDataGridBind(id);
                }
            }
        }

        protected void saveStory_OnClick(object sender, EventArgs e)
        {
            var id = Convert.ToInt64(Session["ID"]);

            if (!string.IsNullOrEmpty(editor.Content))
            {
                var body = editor.Content;

                var story = new MyStory
                {
                    created_at = DateTime.Now,
                    modified_at = DateTime.Now,
                    story = body,
                    user_id = (int)id
                };

                var save = _projectService.SaveStory(story, id);

                if (save == 1)
                {
                    MyStoryCheck();
                }

            }
        }

        protected void viewTask_OnClick(object sender, EventArgs e)
        {
            errorMessage.InnerText = string.Empty;
            var id = Convert.ToInt64(Session["ID"]);

            var task = _projectService.MyTasks(id);

            if (task != null)
            {
                view.Content = task.SingleOrDefault(x => x.created_at == DateTime.Today)?.body;
                view.Visible = true;
            }
            else
            {
                view.Visible = false;
                errorMessage.InnerText = "You currently don't have task(s)";
            }
        }

        protected void viewStory_OnClick(object sender, EventArgs e)
        {
            var id = Convert.ToInt64(Session["ID"]);

            var viewUserStory = _projectService.ViewMyStory(id);

            if (!string.IsNullOrEmpty(viewUserStory.story))
            {
                editor.Content = viewUserStory.story;
            }
            else
            {

            }

        }

        protected void GuideView_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var indes = e.RowIndex;

        }

        protected void submit_OnClick(object sender, EventArgs e)
        {
            var content = Editor1.Content.TrimEnd('<');
            //var id = _projectService.SaveResearch(content, "Test Research",id);
        }

        protected void btnConsultancy_OnClick(object sender, EventArgs e)
        {
            var content = Editor1.Content.TrimEnd('<');
            //var id = _projectService.SaveConsulatancy(content);
        }

        protected void research_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        protected void research_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void research_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Research")
            {
                var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

                var row = researchGrid.Rows[rowno];
                var label = (Label)row.FindControl("lblId");
                var id = Convert.ToInt32(label.Text);

                Response.Redirect("Research.aspx?id=" + id);
            }
            if (e.CommandName == "Consult")
            {
                var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

                var row = researchGrid.Rows[rowno];
                var label = (Label)row.FindControl("lblId");
                var id = Convert.ToInt32(label.Text);

                Response.Redirect("Consultancy.aspx?id=" + id);
            }
        }

        protected void btnMySpace_OnClick(object sender, EventArgs e)
        {
            var id = Convert.ToInt64(Session["ID"]);
            var files = mySpaceUpload.PostedFiles;
            var fileFormats = new[] { "pdf", "doc", "docx", "xls" };
            var fil = Path.GetExtension(files[0].FileName);
            var path = Page.Server.MapPath("~/Uploads/MySpace/");

            if (!string.IsNullOrEmpty(files[0].FileName))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    var exist = File.Exists(path + Path.GetFileName(file.FileName));

                    if (!fileFormats.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.') + 1).ToLower()))
                    {
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Please only upload .pdf, .doc/.docx')", true);
                    }
                    else if (!exist)
                    {
                        var filename = Page.Server.MapPath("~/Uploads/MySpace/" + Path.GetFileName(file.FileName));
                        file.SaveAs(filename);

                        var uploadDoc = new Upload
                        {
                            created_at = DateTime.Now,
                            name = file.FileName,
                            content_type = file.ContentType,
                            modified_at = DateTime.Now,
                            file_location = filename,
                            user_id = (int)id

                        };

                        var check = _projectService.SaveDocuments(uploadDoc);

                        if (check == 1)
                        {
                            DataGridBind();
                        }

                    }

                }

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Please upload at least one file')", true);
            }
        }

        protected void addTask_OnClick(object sender, EventArgs e)
        {
            //var checkDate = CheckPreviousDate(dueDate.Text);


            //if (checkDate)
            //{
            //    lblError.Visible = true;
            //    return;
            //}

            //lblError.Visible = false;
            var taskDescription = taskDesciption.Text;
            var id = Convert.ToInt64(Session["ID"]);
            var taskDoc = new TaskDocument();
            var stats = 0;
            var selectedUserId = Convert.ToInt32(userList.SelectedValue);


            if (attachments.HasFile)
            {
                var files = attachments.PostedFiles;

                foreach (var file in files)
                {
                    var fileName = Page.Server.MapPath("~/Uploads/TaskDocuments/" + Path.GetFileName(file.FileName));

                    file.SaveAs(fileName);

                    var fileByte = _imageService.ReadToEnd(file.InputStream);

                    taskDoc = _insedlu.TaskDocuments.Add(
                       new TaskDocument
                       {
                           name = fileName,
                           created_at = DateTime.Today,
                           file = fileByte
                       });

                    try
                    {
                        _insedlu.SaveChanges();
                    }
                    catch (DbEntityValidationException exception)
                    {
                        Console.WriteLine(exception.EntityValidationErrors);
                        throw;
                    }

                }

            }

            if (!string.IsNullOrEmpty(taskDescription))
            {

                var date = DateTime.ParseExact(dueDate.Text, "dd/MM/yyyy", null);
                var todaysDate = DateTime.Today;

                var numberOfDays = GetRemainingDays(date, todaysDate);

                var task = new Task
                {
                    created_at = DateTime.Now,
                    body = taskDescription,
                    modified_at = DateTime.Now,
                    due_date = date,
                    user_id = (int)id,
                    status = (int)TaskStatus.Assigned,
                    task_document_id = taskDoc.id,
                    number_of_days_left = numberOfDays
                };

                myTasksList.Text = task.body;
                var check = _projectService.SaveTask(task);

                var taskComplete = new TaskCompletion { completion = numberOfDays.ToString(), task_id = (int)task.id };
                _insedlu.TaskCompletions.Add(taskComplete);
                _insedlu.SaveChanges();

                stats = Status("Assigned");
                var taskStatus = Convert.ToInt32(stats);
                //var task = _insedlu.Tasks.Single(x => x.id == taskId);

                task.status = taskStatus;
                task.assigned_to = selectedUserId;

                _insedlu.Entry(task).State = EntityState.Modified;
                _insedlu.SaveChanges();

                if (check == 1)
                {
                    Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Task saved successfully')", true);
                }

            }

            SetTasks(_id);
        }

        private int GetRemainingDays(DateTime duedate, DateTime todaysDate)
        {
            return Convert.ToInt32((duedate - todaysDate).TotalDays);
        }
        protected void myTask_OnClick(object sender, EventArgs e)
        {
            var id = Convert.ToInt64(Session["ID"]);
            var currentTask = _projectService.MyTasks(id);

            myTasksList.Text = currentTask.SingleOrDefault(x => x.created_at == DateTime.Today)?.body;
            //tasksModalPopup.Visible = true;
        }

        protected void datagridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            datagridview.PageIndex = e.NewPageIndex;
            LoggingsBinding();

        }

        protected void datagridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var command = e.CommandName;
            var rowno = int.Parse(e.CommandArgument.ToString());  // It is the rowno of which the user as clicked

            var row = datagridview.Rows[rowno];  // logical 0,1,2,3,4,5
            var label = (Label)row.FindControl("lblId");
            var id = Convert.ToInt32(label.Text);

            var proposal = _insedlu.Loggings.Single(x => x.id == id);

            var timeline = proposal.duration;

            switch (command)
            {
                case "asset":
                    GetAssetUsage(proposal);
                    break;
                case "timeline":
                    var timer = DisplayTimeline(proposal.duration, proposal.duration_type_id, proposal.created_at);
                    switch (proposal.duration_type_id)
                    {
                        case 1:
                            if (timer < 0)
                                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Warning, you have went beyond time frame by " + timer + " year(s)')", true);
                            else if (1 < timer && timer < 2)
                                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Almost there with " + timer + " year (s) left')", true);
                            else
                                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Everything looks good " + timer + "')", true);
                            break;

                        case 2:
                            if (timer < 0)
                                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Warning, you have went beyond time frame by " + timer + " Months')", true);
                            else if (1 < timer && timer < 2)
                                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Almost there with " + timer + " Months (s) left')", true);
                            else
                                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Everything looks good " + timer + "')", true);
                            break;
                        case 3:
                            if (timer < 0)
                                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Warning, you have went beyond time frame by " + timer + " Weeks')", true);
                            else if (1 < timer && timer < 2)
                                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Almost there with " + timer + " Weeks (s) left')", true);
                            else
                                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Everything looks good " + timer + "')", true);
                            break;
                    }

                    PnlMain.Visible = true;
                    break;
            }
        }

        private void GetAssetUsage(Logging logging)
        {
            var projId = logging.project_id;

            var accomoTotalCost = _insedlu.GetAssetTotal(projId, "accommodation").First();
            var vehiTotalCost = _insedlu.GetAssetTotal(projId, "vehicle").First();
            var telTotalCost = _insedlu.GetAssetTotal(projId, "telephone").First();
            var matTotalCost = _insedlu.GetAssetTotal(projId, "print").First();
            var emplTotalCost = _insedlu.GetAssetTotal(projId, "employee").First();
            var wifiTotalCost = _insedlu.GetAssetTotal(projId, "wifi").First();
            var refreshTotalCost = _insedlu.GetAssetTotal(projId, "refreshment").First();

            var breaker = new Literal();
            breaker.Text = "<br/>";
            var assetSummary = string.Format("Accommodation : R {0} \\n\\Vehicle : R {1} \\n\\Telephone : R {2} \\n\\Print Material : R {3}\\n\\Employee : R {4}\\n\\WIFI : R {5}\\n\\Refreshment : R {6}", accomoTotalCost, vehiTotalCost, telTotalCost, matTotalCost, emplTotalCost, wifiTotalCost, refreshTotalCost);

            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + assetSummary + "')", true);
        }

        private int DisplayTimeline(int? duration, int? durationType, DateTime? dateCreated)
        {
            var dateNow = DateTime.Now;
            var difference = 0;

            switch (durationType)
            {
                case 1:
                    difference = dateNow.Year - (dateCreated.Value.Year + duration.Value);
                    break;
                case 2:
                    difference = dateNow.Month - (dateCreated.Value.Month + duration.Value);
                    break;
                case 3:
                    difference = dateNow.Year - (dateCreated.Value.Year + duration.Value);
                    break;

            }

            return difference;

        }

        protected void datagridview_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void Timer1_OnTick(object sender, EventArgs e)
        {
            //SetUpSlide();
        }

        //private void SetUpSlide()
        //{
        //    var rand = new Random();
        //    var next = rand.Next(1, 8);

        //    imageSlide.ImageUrl = "~/Images/Slideshow/" + next.ToString() + ".png";
        //}

        protected void assignTask_OnClick(object sender, EventArgs e)
        {
            var stats = 0;

            if (userList.SelectedValue == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Please select User to assign to')", true);

            }
            if (tasks.SelectedValue == null)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Please select task to assign')", true);

            }

            var selectedUserId = Convert.ToInt32(userList.SelectedValue);
            var taskId = Convert.ToInt32(tasks.SelectedValue);

            stats = Status("Assigned");
            var taskStatus = Convert.ToInt32(stats);
            var task = _insedlu.Tasks.Single(x => x.id == taskId);
            var assignee = _projectService.GetUserById(selectedUserId);
            var assigner = _projectService.GetUserById(Convert.ToInt32(_id));
            var dueOnDate = task.due_date;

            task.status = taskStatus;
            task.assigned_to = selectedUserId;

            _insedlu.Entry(task).State = EntityState.Modified;
            _insedlu.SaveChanges();

            SetTasks(_id);
        }
        private int Status(string status)
        {
            var defaultStatus = 0;

            switch (status)
            {
                case "NotAssigned":
                    defaultStatus = 1;
                    break;
                case "Assigned":
                    defaultStatus = 2;
                    break;
                case "Confirmed":
                    defaultStatus = 3;
                    break;
                case "InProgress":
                    defaultStatus = 4;
                    break;
                default:
                    defaultStatus = 5;
                    break;
            }

            return defaultStatus;
        }
        private bool CheckPreviousDate(string dueDateCheck)
        {
            //var dt1 = Convert.ToDateTime(dueDateCheck);
            //var dt2 = DateTime.Now;

            //return dt1 < dt2;
            return true;
        }
        protected void changeStatusUpdate_OnClick(object sender, EventArgs e)
        {
            var stats = 0;
            var selected = String.Empty;
            var taskId = Convert.ToInt32(tasksToUpdate.SelectedValue);

            foreach (ListItem item in statusDropdown.Items)
            {
                if (item.Selected)
                {
                    selected = item.Value;
                    stats = Status(selected);
                    break;
                }
            }
            var taskStatus = Convert.ToInt32(stats);
            var task = _insedlu.Tasks.Single(x => x.id == taskId);

            task.status = taskStatus;
            _insedlu.Entry(task).State = EntityState.Modified;
            _insedlu.SaveChanges();

            SetTasks(_id);
        }

        protected void completedTasks_OnPreRender(object sender, EventArgs e)
        {
            var id = Convert.ToInt64(Session["ID"]);
            SetTasks(id);
        }
    }
}