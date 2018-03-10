using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
using Insendlu.Entities.Domain;
using Insendu.Services;

namespace Insendlu.UserPages
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
                           select new { Asset = active.asset_id }).ToList();

                LoadFieldTypes();

                if (act.Count > 0)
                {

                }
            }
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
            var workLog = Convert.ToInt64(query.Get("id"));
            var id = Convert.ToInt64(Session["ID"]);

            //Accommodation
            if (!string.IsNullOrEmpty(Request.Form[start_period.UniqueID]) && !string.IsNullOrEmpty(Request.Form[end_period.UniqueID]))
            {
                var startP = Convert.ToDateTime(Request.Form[start_period.UniqueID]).Date;
                var endP = Convert.ToDateTime(Request.Form[end_period.UniqueID]).Date;
                var accomCost = Convert.ToInt32(accCost.Text);
                var accomLocation = accLocation.Text;

                var accommodation = new Accommodation()
                {
                    cost = accomCost,
                    end_start = endP,
                    start_date = startP,
                    location = accomLocation,
                    worklog_id = (int) workLog
                };

                _insendluEntities.Accommodations.Add(accommodation);

                _insendluEntities.SaveChanges();
            }
            //Vehicle Details
            if (!string.IsNullOrEmpty(Request.Form[vStartDate.UniqueID]) && !string.IsNullOrEmpty(Request.Form[vEndDate.UniqueID]))
            {
                var vStartDat = Convert.ToDateTime(Request.Form[vStartDate.UniqueID]).Date;
                var vEndDat = Convert.ToDateTime(Request.Form[vEndDate.UniqueID]).Date;
                var vDetails = vType.Text;
                var vMill = vMilage.Text;
                var vCos = Convert.ToInt32(vCost.Text);

                var vehicle = new Vehicle()
                {
                    cost = vCos,
                    end_start = vEndDat,
                    start_date = vStartDat,
                    mileage = vMill,
                    type = vDetails,
                    worklog_id = (int)workLog

                };

                _insendluEntities.Vehicles.Add(vehicle);
                _insendluEntities.SaveChanges();
            }

            if (!string.IsNullOrEmpty(Request.Form[empStart.UniqueID]) && !string.IsNullOrEmpty(Request.Form[empEndDate.UniqueID]))
            {
                //Employees
                var empStartDate = Convert.ToDateTime(Request.Form[empStart.UniqueID]).Date;
                var empEnd = Convert.ToDateTime(Request.Form[empEndDate.UniqueID]).Date;
                var emploType = empType.Text;
                var numOfEmp = empNumber.Text;
                var empCost = Convert.ToInt32(empCostPerDay.Text);

                var employees = new Employee()
                {
                    cost = empCost,
                    employee_type = emploType,
                    end_start = empEnd,
                    no_of_employees = numOfEmp,
                    start_date = empStartDate,
                    worklog_id = (int) workLog
                };

                _insendluEntities.Employees.Add(employees);
                _insendluEntities.SaveChanges();
            }

            if (!string.IsNullOrEmpty(Request.Form[matStartDate.UniqueID]) && !string.IsNullOrEmpty(Request.Form[matEndDate.UniqueID]))
            {
                //Print Material
                var matStart = Convert.ToDateTime(Request.Form[matStartDate.UniqueID]).Date;
                var matEnd = Convert.ToDateTime(Request.Form[matEndDate.UniqueID]).Date;
                var matQua = matQuantity.Text;
                var matName = materialName.Text;
                var matCos = Convert.ToInt32(matCost.Text);

                var material = new PrintMaterial()
                {
                    worklog_id = (int)workLog,
                    cost = matCos,
                    start_date = matStart,
                    end_start = matEnd,
                    name = matName,
                    quantity = matQua
                    
                };

                _insendluEntities.PrintMaterials.Add(material);
                _insendluEntities.SaveChanges();
            }
            if (!string.IsNullOrEmpty(Request.Form[refStartDate.UniqueID]) && !string.IsNullOrEmpty(Request.Form[refEndDate.UniqueID]))
            {
                //Refreshments
                var refStart = Convert.ToDateTime(Request.Form[refStartDate.UniqueID]).Date;
                var refEnd = Convert.ToDateTime(Request.Form[refEndDate.UniqueID]).Date;
                var refCostAmount = Convert.ToInt32(refCost.Text);

                var refreshments = new Refreshment()
                {
                    cost = refCostAmount,
                    end_start = refEnd,
                    start_date = refStart,
                    worklog_id = (int) workLog
                };

                _insendluEntities.Refreshments.Add(refreshments);
                _insendluEntities.SaveChanges();
            }
            if (!string.IsNullOrEmpty(Request.Form[telStartDate.UniqueID]) && !string.IsNullOrEmpty(Request.Form[telEndDate.UniqueID]))
            {
                //Telephone
                var telStart = Convert.ToDateTime(Request.Form[telStartDate.UniqueID]).Date;
                var telEndDat = Convert.ToDateTime(Request.Form[telEndDate.UniqueID]).Date;
                var telCostAmount = Convert.ToInt32(telCost.Text);

                var telephone = new Telephone()
                {
                    cost = telCostAmount,
                    end_start = telEndDat,
                    start_date = telStart,
                    worklog_id = (int) workLog
                };

                _insendluEntities.Telephones.Add(telephone);
                _insendluEntities.SaveChanges();
            }
            if (!string.IsNullOrEmpty(Request.Form[wifiStartDate.UniqueID]) && !string.IsNullOrEmpty(Request.Form[wifiEndDate.UniqueID]))
            {
                //WIFI
                var wifiStart = Convert.ToDateTime(Request.Form[wifiStartDate.UniqueID]).Date;
                var wifiEnd = Convert.ToDateTime(Request.Form[wifiEndDate.UniqueID]).Date;
                var wifiTotalCost = Convert.ToInt32(wifiCost.Text);

                var wifi = new Wifi()
                {
                    cost = wifiTotalCost,
                    worklog_id = (int) workLog,
                    start_date = wifiStart,
                    end_start = wifiEnd
                };

                _insendluEntities.Wifis.Add(wifi);
                _insendluEntities.SaveChanges();
            }
            if (!string.IsNullOrEmpty(Request.Form[fieldStartDate.UniqueID]) && !string.IsNullOrEmpty(Request.Form[fieldEndDate.UniqueID]))
            {
                //FIELD WORK STATISTICS
                var fieldStart = Convert.ToDateTime(Request.Form[fieldStartDate.UniqueID]).Date;
                var fieldEnd = Convert.ToDateTime(Request.Form[fieldEndDate.UniqueID]).Date;
                var fieldWork = fieldWorkDrop.Value;

                var fieldWorkStarts = new FieldWorkStatistic()
                {
                    name = fieldWork,
                    worklog_id = (int) workLog,
                    start_date = fieldStart,
                    end_date = fieldEnd
                };

                _insendluEntities.FieldWorkStatistics.Add(fieldWorkStarts);
                _insendluEntities.SaveChanges();
            }

            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Information saved Successfully')", true);

            Response.Redirect("Proposals.aspx");
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
    }
}