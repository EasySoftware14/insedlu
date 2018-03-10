using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendlu.Entities.Connection;
////using Insendlu.Entities.Domain;
using Insendu.Services;

namespace Insendlu
{
    public partial class ViewLogs : System.Web.UI.Page
    {
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private long _logId = 0;
        public ViewLogs()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var query = Request.QueryString;
                var workLogId = Convert.ToInt64(query.Get("id"));
                var date = Convert.ToDateTime(query.Get("date"));

                GetWorkLog(workLogId, date);
            }
        }
        private string GetProjectName(long id)
        {
            var proj = (from pro in _insendluEntities.Projects
                        where pro.id == id
                        select pro).SingleOrDefault();

            return proj.name;
        }
        private void GetWorkLog(long workLogId, DateTime date)
        {
            var log = (from logs in _insendluEntities.WorkLogs
                       where logs.id == workLogId && logs.date_logged == date
                       select logs).FirstOrDefault();

            if (log != null)
            {
                FillControls(log);
            }
        }
        private WorkLog GetWorkLogForEdit(long workLogId, DateTime date)
        {
            var work = new WorkLog();

            var log = (from logs in _insendluEntities.WorkLogs
                       where logs.id == workLogId && logs.date_logged == date
                       select logs).FirstOrDefault();

            if (log != null)
            {
                work = log;
            }

            return work;
        }
        private void FillControls(WorkLog log)
        {
            var workLogId = log.id;

            var accom = (from acc in _insendluEntities.Accommodations
                where acc.worklog_id == workLogId
                select acc).SingleOrDefault();

            if (accom != null)
            {
                accCost.Text = accom.cost.ToString();
                accLocation.Text = accom.location;
                start_period.Text = accom.start_date.Value.Date.ToShortDateString();
                end_period.Text = accom.end_start.Value.Date.ToShortDateString();
            }

            var vehicle = (from acc in _insendluEntities.Vehicles
                           where acc.worklog_id == workLogId
                           select acc).SingleOrDefault();

            if (vehicle != null)
            {
                vCost.Text = vehicle.cost.ToString();
                vStartDate.Text = vehicle.start_date.Value.Date.ToShortDateString();
                vEndDate.Text = vehicle.end_start.Value.Date.ToShortDateString();
                vMilage.Text = vehicle.mileage;
                vType.Text = vehicle.type;
            }
            var refreshments = (from acc in _insendluEntities.Refreshments
                                where acc.worklog_id == workLogId
                                select acc).SingleOrDefault();
            if (refreshments != null)
            {
                refCost.Text = refreshments.cost.ToString();
                refStartDate.Text = refreshments.start_date.Value.Date.ToShortDateString();
                refEndDate.Text = refreshments.end_start.Value.Date.ToShortDateString();
            }

            var employees = (from acc in _insendluEntities.Employees
                             where acc.worklog_id == workLogId
                             select acc).SingleOrDefault();
            if (employees != null)
            {
                empCostPerDay.Text = employees.cost.ToString();
                empEndDate.Text = employees.end_start.Value.Date.ToShortDateString();
                empNumber.Text = employees.no_of_employees;
                empStart.Text = employees.start_date.Value.Date.ToShortDateString();
                empType.Text = employees.employee_type;
            }

            var printMaterial = (from acc in _insendluEntities.PrintMaterials
                                 where acc.worklog_id == workLogId
                                 select acc).SingleOrDefault();
            if (printMaterial != null)
            {
                matCost.Text = printMaterial.cost.ToString();
                matEndDate.Text = printMaterial.end_start.Value.Date.ToShortDateString();
                matStartDate.Text = printMaterial.start_date.Value.Date.ToShortDateString();
                matQuantity.Text = printMaterial.quantity;
                materialName.Text = printMaterial.name;
            }

            var telephone = (from acc in _insendluEntities.Telephones
                             where acc.worklog_id == workLogId
                             select acc).SingleOrDefault();

            if(telephone != null)
            {
                telCost.Text = telephone.cost.ToString();
                telEndDate.Text = telephone.end_start.Value.Date.ToShortDateString();
                telStartDate.Text = telephone.start_date.Value.Date.ToShortDateString();

            }

            var wifi = (from acc in _insendluEntities.Wifis
                        where acc.worklog_id == workLogId
                        select acc).SingleOrDefault();
            if (wifi != null)
            {
                wifiCost.Text = wifi.cost.ToString();
                wifiEndDate.Text = wifi.end_start.Value.Date.ToShortDateString();
                wifiStartDate.Text = wifi.start_date.Value.Date.ToShortDateString();
            }
        }

        private List<Activity> GetActivities(long id)
        {
            var acts = (from act in _insendluEntities.Activities
                        where act.worklog_id == id
                        select act).ToList();

            return acts;
        }

        private WorkLog RetrieveLog(long workLog)
        {
            var worklog = (from log in _insendluEntities.WorkLogs
                           where log.id == workLog
                           select log).SingleOrDefault();

            return worklog;
        }

        private Activity GetActivity(long workLog, int i)
        {
            var activity = (from act in _insendluEntities.Activities
                            where act.worklog_id == workLog && act.asset_id == i
                            select act).SingleOrDefault();

            return activity;
        }

        protected void saveLoggedInfo_OnClick(object sender, EventArgs e)
        {
            var query = Request.QueryString;
            var workLogId = Convert.ToInt64(query.Get("id"));
            var date = Convert.ToDateTime(query.Get("date"));

            var accom = (from acc in _insendluEntities.Accommodations
                         where acc.worklog_id == workLogId
                         select acc).SingleOrDefault();

            if (accom != null)
            {
                 accom.cost = Convert.ToInt32(accCost.Text);
                 accom.location = accLocation.Text;
                 accom.start_date = Convert.ToDateTime(Request.Form[start_period.UniqueID]);
                 accom.end_start = Convert.ToDateTime(Request.Form[end_period.UniqueID]);
               
                _insendluEntities.SaveChanges();
            }

            var vehicle = (from acc in _insendluEntities.Vehicles
                           where acc.worklog_id == workLogId
                           select acc).SingleOrDefault();

            if (vehicle != null)
            {
                vehicle.cost = Convert.ToInt32(vCost.Text);
                vehicle.start_date = Convert.ToDateTime(Request.Form[vStartDate.UniqueID]);
                vehicle.end_start = Convert.ToDateTime(Request.Form[vEndDate.UniqueID]);
                vehicle.mileage = vMilage.Text;
                vehicle.type = vType.Text;

                _insendluEntities.SaveChanges();
            }
            var refreshments = (from acc in _insendluEntities.Refreshments
                                where acc.worklog_id == workLogId
                                select acc).SingleOrDefault();
            if (refreshments != null)
            {
                refreshments.cost = Convert.ToInt32(refCost.Text);
                refreshments.start_date = Convert.ToDateTime(Request.Form[refStartDate.UniqueID]);
                refreshments.end_start = Convert.ToDateTime(Request.Form[refEndDate.UniqueID]);

                _insendluEntities.SaveChanges();
            }

            var employees = (from acc in _insendluEntities.Employees
                             where acc.worklog_id == workLogId
                             select acc).SingleOrDefault();

            if (employees != null)
            {
                employees.cost = Convert.ToInt32(empCostPerDay.Text);
                employees.end_start = Convert.ToDateTime(Request.Form[empEndDate.UniqueID]);
                employees.no_of_employees = empNumber.Text;
                employees.start_date = Convert.ToDateTime(Request.Form[empStart.UniqueID]);
                employees.employee_type = empType.Text;

                _insendluEntities.SaveChanges();
            }

            var printMaterial = (from acc in _insendluEntities.PrintMaterials
                                 where acc.worklog_id == workLogId
                                 select acc).SingleOrDefault();

            if (printMaterial != null)
            {
                printMaterial.cost = Convert.ToInt32(matCost.Text);
                printMaterial.end_start = Convert.ToDateTime(Request.Form[matEndDate.UniqueID]);
                printMaterial.start_date = Convert.ToDateTime(Request.Form[matStartDate.UniqueID]);
                printMaterial.quantity = matQuantity.Text;
                printMaterial.name = materialName.Text;

                _insendluEntities.SaveChanges();
            }

            var telephone = (from acc in _insendluEntities.Telephones
                             where acc.worklog_id == workLogId
                             select acc).SingleOrDefault();

            if (telephone != null)
            {
                telephone.cost = Convert.ToInt32(telCost.Text);
                telephone.end_start = Convert.ToDateTime(Request.Form[telEndDate.UniqueID]);
                telephone.start_date = Convert.ToDateTime(Request.Form[telStartDate.UniqueID]);

                _insendluEntities.SaveChanges();

            }

            var wifi = (from acc in _insendluEntities.Wifis
                        where acc.worklog_id == workLogId
                        select acc).SingleOrDefault();

            if (wifi != null)
            {
                wifi.cost = Convert.ToInt32(wifiCost.Text);
                wifi.end_start = Convert.ToDateTime(Request.Form[wifiEndDate.UniqueID]);
                wifi.start_date = Convert.ToDateTime(Request.Form[wifiStartDate.UniqueID]);

                _insendluEntities.SaveChanges();
            }

            Page.ClientScript.RegisterClientScriptBlock(GetType(),"alert","alert('Work log updated successfully')", true);
            Response.Redirect("Report.aspx" );
        }

        protected void datagridview_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            var edit = e.NewEditIndex;
        }
    }
}