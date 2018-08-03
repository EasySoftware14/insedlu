using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using Insendu.Services;

namespace Insendlu
{
    public partial class Update : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private readonly ImageService _imageService;

        public Update()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
            _imageService = new ImageService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CalendarExtender1.SelectedDate = DateTime.Now;
                GetUserList();
                LoadFieldTypes();
            }
        }
        private DateTime CovertToDateTime(string date)
        {
            var removing = date.Replace('/', ',').Split(',');
            var month = Convert.ToInt32(removing[0]);
            var day = Convert.ToInt32(removing[1]);
            var year = Convert.ToInt32(removing[2]);

            return new DateTime(year, month, day).Add(DateTime.Today.TimeOfDay);

        }
        private void GetUserList()
        {
            var registeredUsers = _insendluEntities.Users.Where(x => x.status != (int)EntityStatus.InActive).ToList();

            userList.DataSource = registeredUsers;
            userList.DataBind();
        }
        protected void saveLoggedInfo_OnClick(object sender, EventArgs e)
        {
            var projId = Convert.ToInt32(Session["ProjectId"]);
            var id = Convert.ToInt64(Session["ID"]);
            var workLogId = 0L;
            var selectedDate = Request.Form[start_period.UniqueID];

            if (!string.IsNullOrEmpty(selectedDate))
            {
                var convertDate = CovertToDateTime(selectedDate);
                var logFound = _projectService.GetWorkLogByProjIdAndDate(projId, convertDate);

                if (!logFound)
                {
                    var log = new WorkLog
                    {
                        date_logged = convertDate,
                        proj_id = (int)projId,
                        user_id = (int)id
                    };

                    _insendluEntities.WorkLogs.Add(log);
                    var check = _insendluEntities.SaveChanges();

                    if (check == 1) { workLogId = log.id; }


                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) &&
                        !string.IsNullOrEmpty(projeManagTotalCost.Text))
                    {
                        var projManagement = Convert.ToInt32(projeManagTotalCost.Text);

                        var projMan = new ProjectManagementFee
                        {
                            start_date = convertDate,
                            project_id = projId,
                            total_cost = projManagement,
                            worklog_id = Convert.ToInt32(workLogId)
                        };

                        _insendluEntities.ProjectManagementFees.Add(projMan);
                        _insendluEntities.SaveChanges();
                    }
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) &&
                        !string.IsNullOrEmpty(contiTotalCost.Text))
                    {
                        var contigence = Convert.ToInt32(contiTotalCost.Text);

                        var conti = new ContigencyFee
                        {
                            start_date = convertDate,
                            project_id = projId,
                            total_cost = contigence,
                            worklog_id = Convert.ToInt32(workLogId)
                        };

                        _insendluEntities.ContigencyFees.Add(conti);
                        _insendluEntities.SaveChanges();
                    }
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) &&
                        !string.IsNullOrEmpty(survTotalCost.Text))
                    {
                        var survey = Convert.ToInt32(survTotalCost.Text);

                        var surveyor = new SurveyMonkey
                        {
                            start_date = convertDate,
                            project_id = projId,
                            total_cost = survey,
                            worklog_id = Convert.ToInt32(workLogId)
                        };

                        _insendluEntities.SurveyMonkeys.Add(surveyor);
                        _insendluEntities.SaveChanges();
                    }
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) &&
                        !string.IsNullOrEmpty(dataTotalCost.Text))
                    {
                        var emplyee = dataEmployee.Text;
                        var dataCost = Convert.ToInt32(dataTotalCost.Text);

                        var dataAnalyst = new DataAnalyst
                        {
                            start_date = convertDate,
                            project_id = projId,
                            total_cost = dataCost,
                            employee = emplyee,
                            worklog_id = Convert.ToInt32(workLogId)
                        };

                        _insendluEntities.DataAnalysts.Add(dataAnalyst);
                        _insendluEntities.SaveChanges();
                    }
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) &&
                        !string.IsNullOrEmpty(logTotalCost.Text))
                    {
                        var details = logDetails.Text;
                        var dataCost = Convert.ToInt32(logTotalCost.Text);
                        var unitCost = Convert.ToInt32(logUnitCost.Text);

                        var logistics = new Logistic
                        {
                            start_date = convertDate,
                            project_id = projId,
                            total_cost = dataCost,
                            details = details,
                            worklog_id = Convert.ToInt32(workLogId),
                            unit_cost = unitCost
                        };

                        _insendluEntities.Logistics.Add(logistics);
                        _insendluEntities.SaveChanges();

                    }
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) &&
                        !string.IsNullOrEmpty(sustFeesDetail.Text))
                    {
                        var details = sustFeesDetail.Text;
                        var dataCost = Convert.ToInt32(sustFeesTotalCost.Text);
                        var unitCost = Convert.ToInt32(sustFeesUnitCost.Text);

                        var logistics = new SustenenceFee
                        {
                            start_date = convertDate,
                            project_id = projId,
                            total_cost = dataCost,
                            detail = details,
                            worklog_id = Convert.ToInt32(workLogId),
                            unit_cost = unitCost
                        };

                        _insendluEntities.SustenenceFees.Add(logistics);
                        _insendluEntities.SaveChanges();
                    }

                    //Accommodation
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) && !string.IsNullOrEmpty(accCost.Text))
                    {
                        var date = Request.Form[start_period.UniqueID];
                        var startP = CovertToDateTime(date);

                        var accomCost = Convert.ToInt32(accCost.Text);
                        var accomLocation = accLocation.Text;

                        var accommodation = new Accommodation
                        {
                            cost = accomCost,
                            start_date = convertDate,
                            location = accomLocation,
                            worklog_id = (int)workLogId,
                            project_id = (int)projId
                        };

                        _insendluEntities.Accommodations.Add(accommodation);

                        _insendluEntities.SaveChanges();
                    }
                    //Vehicle Details
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) && !string.IsNullOrEmpty(vCost.Text))
                    {
                        var date = Request.Form[start_period.UniqueID];
                        var vStartDat = CovertToDateTime(date);

                        var vDetails = vType.Text;
                        var vMill = vMilage.Text;
                        var vCos = Convert.ToInt32(vCost.Text);

                        var vehicle = new Vehicle
                        {
                            cost = vCos,
                            start_date = convertDate,
                            mileage = vMill,
                            type = vDetails,
                            worklog_id = (int)workLogId,
                            project_id = (int)projId

                        };

                        _insendluEntities.Vehicles.Add(vehicle);
                        _insendluEntities.SaveChanges();
                    }

                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) && !string.IsNullOrEmpty(empCostPerDay.Text))
                    {
                        //Employees
                        var date = Request.Form[start_period.UniqueID];
                        var empStartDate = CovertToDateTime(date);

                        var emploType = empType.Text;
                        var numOfEmp = empNumber.Text;
                        var empCost = Convert.ToInt32(empCostPerDay.Text);

                        var employees = new Employee
                        {
                            cost = empCost,
                            employee_type = emploType,

                            no_of_employees = numOfEmp,
                            start_date = convertDate,
                            worklog_id = (int)workLogId,
                            project_id = (int)projId
                        };

                        _insendluEntities.Employees.Add(employees);
                        _insendluEntities.SaveChanges();
                    }

                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) && !string.IsNullOrEmpty(matCost.Text))
                    {
                        //Print Material
                        var date = Request.Form[start_period.UniqueID];
                        var matStart = CovertToDateTime(date);

                        var matQua = matQuantity.Text;
                        var matName = materialName.Text;
                        var matCos = Convert.ToInt32(matCost.Text);

                        var material = new PrintMaterial
                        {
                            worklog_id = (int)workLogId,
                            cost = matCos,
                            start_date = convertDate,
                            project_id = (int)projId,
                            name = matName,
                            quantity = matQua

                        };

                        _insendluEntities.PrintMaterials.Add(material);
                        _insendluEntities.SaveChanges();
                    }
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) && !string.IsNullOrEmpty(refCost.Text))
                    {
                        //Refreshments
                        var date = Request.Form[start_period.UniqueID];
                        var refStart = CovertToDateTime(date);

                        var refCostAmount = Convert.ToInt32(refCost.Text);

                        var refreshments = new Refreshment
                        {
                            cost = refCostAmount,

                            start_date = convertDate,
                            worklog_id = (int)workLogId,
                            project_id = (int)projId
                        };

                        _insendluEntities.Refreshments.Add(refreshments);
                        _insendluEntities.SaveChanges();
                    }
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) && !string.IsNullOrEmpty(telCost.Text))
                    {
                        //Telephone
                        var date = Request.Form[start_period.UniqueID];
                        var telStart = CovertToDateTime(date);

                        var telCostAmount = Convert.ToInt32(telCost.Text);

                        var telephone = new Telephone
                        {
                            cost = telCostAmount,
                            start_date = convertDate,
                            worklog_id = (int)workLogId,
                            project_id = (int)projId
                        };

                        _insendluEntities.Telephones.Add(telephone);
                        _insendluEntities.SaveChanges();
                    }
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) && !string.IsNullOrEmpty(wifiCost.Text))
                    {
                        //WIFI
                        var date = Request.Form[start_period.UniqueID];
                        var wifiStart = CovertToDateTime(date);

                        var wifiTotalCost = Convert.ToInt32(wifiCost.Text);

                        var wifi = new Wifi
                        {
                            cost = wifiTotalCost,
                            worklog_id = (int)workLogId,
                            start_date = convertDate,
                            project_id = (int)projId

                        };

                        _insendluEntities.Wifis.Add(wifi);
                        _insendluEntities.SaveChanges();
                    }
                    if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) && !string.IsNullOrEmpty(fieldWorkDrop.Value))
                    {
                        //FIELD WORK STATISTICS
                        var date = Request.Form[start_period.UniqueID];
                        var fieldStart = CovertToDateTime(date);

                        var fieldWork = fieldWorkDrop.Value;

                        var fieldWorkStarts = new FieldWorkStatistic
                        {
                            name = fieldWork,
                            worklog_id = (int)workLogId,
                            start_date = convertDate,
                            project_id = (int)projId

                        };

                        _insendluEntities.FieldWorkStatistics.Add(fieldWorkStarts);
                        _insendluEntities.SaveChanges();
                    }
                    Response.Redirect("ProjectTimeLine.aspx?id=" + projId);
                }
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Already Logged work for this day')", true);
            }
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Please select a date')", true);
        }
        private void LoadFieldTypes()
        {
            var fieldTypes = _insendluEntities.FieldWorkTypes.ToList();

            fieldWorkDrop.DataSource = fieldTypes;
            fieldWorkDrop.DataBind();
        }
        protected void backBtn_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");
        }

        protected void attachDocs_OnClick(object sender, EventArgs e)
        {
            var projId = Convert.ToInt32(Session["ProjectId"]);
            var projDocs = _projectService.ProjectDocuments(projId).Select(x => x.name);

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
                            proj_id = projId,
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
        }

        protected void btnAddUsers_OnClick(object sender, EventArgs e)
        {
            var nonSystemMember = nonSystemUser.Text ?? string.Empty;
            var userLis = Request.Form[userList.UniqueID];
            var projName = Session["proName"].ToString();
            var role = memberDuty.Text ?? string.Empty;

            if (string.IsNullOrEmpty(userLis) && string.IsNullOrEmpty(nonSystemMember))
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Please select user to assign to project')", true);
                return;
            }
            
            var workLogger = _projectService.GetWorkLogByName(projName);
            if(!string.IsNullOrEmpty(userLis))
                workLogger.members = workLogger.members + "," + userLis;

            if(!string.IsNullOrEmpty(nonSystemMember))
                workLogger.non_system_user = workLogger.non_system_user != null ? workLogger.non_system_user + "," + nonSystemMember : nonSystemMember;

            if (!string.IsNullOrEmpty(role))
                workLogger.duties = role;

            try
            {
                _insendluEntities.Entry(workLogger).State = EntityState.Modified;
                _insendluEntities.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            finally
            {
                memberDuty.Text = string.Empty;
                nonSystemUser.Text = string.Empty;
            }

        }
    }
}