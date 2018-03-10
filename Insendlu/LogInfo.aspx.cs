using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ikvm.extensions;
using Insendlu.Entities.Connection;
using Insendlu.Entities.MySqlConnection;
using Insendu.Services;

namespace Insendlu
{
    public partial class LogInfo : System.Web.UI.Page
    {
        private readonly ProjectService _projectService;
        private readonly InsendluEntities _insendluEntities;

        public LogInfo()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var query = Request.QueryString;
                var projId = Convert.ToInt64(query.Get("id"));
                var id = Convert.ToInt64(Session["ID"]);

                var act = (from active in _insendluEntities.Activities
                           where active.worklog_id == projId
                           select new { Asset = active.asset }).ToList();

                LoadFieldTypes();

                if (act.Count > 0)
                {

                }
            }
            else
            {
                var textbox = GetControlPostBack(sender as Page);
                if (textbox != null)
                {
                    var textboxText = textbox.Text;
                    var isDigit = IsDigitsOnly(textboxText);
                    if (isDigit)
                    {
                        return;
                    }
                    else
                    {
                        if (textboxText.StartsWith("R"))
                        {
                            var test = textboxText.Replace("R", "").Replace(",", "").Trim();
                            var check = test.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray();
                            accCost.Text = BuildString(check);
                            textboxText = check.ToString();
                            var finalState = test.Replace(" ", string.Empty);
                            var final = finalState;
                        }
                    }
                }
            }
        }
        private TextBox GetControlPostBack(Page page)
        {
            Control control = null;

            var controlName = page.Request.Params.Get("_EVENTTARGET");
            if (!string.IsNullOrEmpty(controlName))
            {
                control = page.FindControl(controlName);
            }
            else
            {
                
            }

            return control as TextBox;
        }

        private string BuildString(char[] check)
        {
            var s = new StringBuilder(check.Length);
            for (int i = 0; i < check.Length; i++)
            {
                s.Append(check[i]);
            }
            return s.ToString();
        }

        private void LoadFieldTypes()
        {
            var fieldTypes = _insendluEntities.FieldWorkTypes.ToList();

            fieldWorkDrop.DataSource = fieldTypes;
            fieldWorkDrop.DataBind();
        }

        protected void saveLoggedInfo_OnClick(object sender, EventArgs e)
        {
            var query = Request.QueryString;
            var projId = Convert.ToInt64(query.Get("id"));
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

        private DateTime CovertToDateTime(string date)
        {
            var removing = date.Replace('/', ',').Split(',');
            var month = Convert.ToInt32(removing[0]);
            var day = Convert.ToInt32(removing[1]);
            var year = Convert.ToInt32(removing[2]);

            return new DateTime(year, month, day).Add(DateTime.Today.TimeOfDay);

        }

        private int? CreateProject()
        {
            var proj = new Project
            {
                created_at = DateTime.Today,
                modified_at = DateTime.Today,
                status = 1

            };

            _insendluEntities.Projects.Add(proj);
            _insendluEntities.SaveChanges();

            return (int)proj.id;
        }

        // var activity = GetActivity(workLog, 1 );

        //    if (Employees.Visible)
        //    {
        //        var activity = GetActivity(workLog, 1);

        //    }
        //    if (telephone.Visible)
        //    {
        //        var activity = GetActivity(workLog, 6);
        //        activity.cost = telCost.Text;

        //        _insendluEntities.SaveChanges();
        //    }
        //    if (print.Visible)
        //    {
        //        var activity = GetActivity(workLog, 4);
        //        activity.material_name = materialName.Text;
        //        activity.material_quantity = matQuantity.Text;
        //        activity.cost = matCost.Text;

        //        _insendluEntities.SaveChanges();

        //    }
        //    if (Accomodation.Visible)
        //    {
        //        var activity = GetActivity(workLog, 3);
        //        activity.location_name = accLocation.Text;
        //        activity.cost = accCost.Text;

        //        _insendluEntities.SaveChanges();

        //    }
        //    if (wifi.Visible)
        //    {
        //        var activity = GetActivity(workLog, 7);
        //        activity.cost = wifiCost.Text;

        //        _insendluEntities.SaveChanges();

        //    }
        //    if (refresh.Visible)
        //    {
        //        var activity = GetActivity(workLog, 5);
        //        activity.cost = refCost.Text;

        //        _insendluEntities.SaveChanges();

        //    }
        //    if (Vehicle.Visible)
        //    {
        //        var activity = GetActivity(workLog, 2);

        //    }

        //    Page.ClientScript.RegisterClientScriptBlock(GetType(),"alert","alert('Information saved Successfully')", true);
        //    Reset();

        //    Response.Redirect("ViewLogs.aspx?id=" + workLog);
        //}

        //private void Reset()
        //{
        //    wifiCost.Text = String.Empty;
        //    refCost.Text = String.Empty;
        //    wifiCost.Text = String.Empty;
        //    telCost.Text = String.Empty;
        //    refCost.Text = String.Empty;
        //    materialName.Text = String.Empty;
        //    matCost.Text = String.Empty;
        //    matQuantity.Text = String.Empty;
        //    accCost.Text = String.Empty;
        //    accLocation.Text = String.Empty;
        //}

        private Activity GetActivity(long workLog, int id)
        {
            var activity = (from act in _insendluEntities.Activities
                            where act.worklog_id == workLog && act.asset_id == id
                            select act).SingleOrDefault();

            return activity;
        }

        protected void backBtn_OnClick(object sender, EventArgs e)
        {
            var name = Session["proName"];
            var id = Convert.ToInt64(Session["ID"]);
            var query = Request.QueryString;
            var projId = Convert.ToInt64(query.Get("id"));

            Response.Redirect(string.Format("TrackLog.aspx?name={0}&usId={1}&projId={2}", name, id, projId));
        }

        protected void accCost_OnTextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(accCost.Text))
            {
                accCost.Text = string.Format("R {0:##,###,0.00}", double.Parse(accCost.Text));

            }
            else
            {

            }
        }

        //protected void textbox_OnTextChanged(object sender, EventArgs e)
        //{
        //    var textbox = (TextBox) sender;

        //    if (!string.IsNullOrEmpty(textbox.Text))
        //    {
        //        textbox.Text = string.Format("R {0:##,###,0.00}", double.Parse(textbox.Text));

        //    }
        //}
        private bool IsDigitsOnly(string str)
        {
            foreach (var c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}