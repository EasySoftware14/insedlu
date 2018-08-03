using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendu.Services;

namespace Insendlu
{
    public partial class TaskCalender : System.Web.UI.Page
    {
        private ProjectService _projectService;
        private readonly AssetService _assetService;
        private long _projectId;

        public TaskCalender()
        {
            _projectService = new ProjectService();
            _assetService = new AssetService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void taskCalender_OnDayRender(object sender, DayRenderEventArgs e)
        {

            var dater = e.Day.Date.ToShortDateString();

            var tasks = _projectService.GetAllTasks();

            foreach (var task in tasks)
            {
                if (task.due_date != null)
                {
                    var dueDate = task.due_date.Value.ToShortDateString();
                    if (dater == dueDate)
                    {
                        var breaker = new Literal();
                        breaker.Text = "<br/>";

                        var acc = new Label();
                        acc.Text = task.body;
                        e.Cell.Controls.Add(breaker);
                        e.Cell.Controls.Add(acc);
                        e.Cell.HorizontalAlign = HorizontalAlign.Justify;
                    }
                }
            }

        }

        protected void taskCalender_OnSelectionChanged(object sender, EventArgs e)
        {
            var selectedDate = taskCalender.SelectedDate.ToShortDateString();
            var accomodation = _assetService.GetAccommodation(selectedDate, _projectId).FirstOrDefault();
            var telephone = _assetService.GetTelephone(selectedDate, _projectId).FirstOrDefault();
            var wifi = _assetService.GetWifi(selectedDate, _projectId).FirstOrDefault();
            var vehicle = _assetService.GetVehicle(selectedDate, _projectId).FirstOrDefault();
            var printMaterial = _assetService.GetPrintMaterial(selectedDate, _projectId).FirstOrDefault();
            var refereshment = _assetService.GetRefreshment(selectedDate, _projectId).FirstOrDefault();
            var employees = _assetService.GetEmployees(selectedDate, _projectId).FirstOrDefault();

            var build = "";
            var count = 0;

            if (accomodation != null && accomodation.start_date != null)
            {
                build += string.Format("Accommodation Cost: \tR {0} \t Location : {1} \\n", accomodation.cost, accomodation.location);
                count++;
            }
            if (telephone != null && telephone.start_date != null)
            {
                build += string.Format("Telephone Cost: \tR {0} \t \\n", telephone.cost);
                count++;
            }
            if (wifi != null && wifi.start_date != null)
            {
                build += string.Format("Wifi / Data Cost: \tR {0} \t \\n", wifi.cost);
                count++;
            }
            if (vehicle != null && vehicle.start_date != null)
            {
                build += string.Format("Vehicle Cost: \tR {0} \t Mileage : {1}\\n", vehicle.cost, vehicle.mileage);
                count++;
            }
            if (printMaterial != null && printMaterial.start_date != null)
            {
                build += string.Format("Print Material Cost: \tR {0} \t Name : {1} \t Quantity : {2}\\n", printMaterial.cost, printMaterial.name, printMaterial.quantity);
                count++;
            }
            if (refereshment != null && refereshment.start_date != null)
            {
                build += string.Format("Refereshment Cost: \tR {0} \t \\n", refereshment.cost);
                count++;
            }
            if (employees != null && employees.start_date != null)
            {
                build += string.Format("Employees: \tR {0} \t Number Of employees : {1}\\n", employees.cost, employees.no_of_employees);
                count++;
            }

            var title = "Asset Summary used on the day \\n\\n";
            var label = new Label();
            label.Text = title;
            label.Font.Bold = true;
            label.ForeColor = Color.DarkGreen;

            if (count > 0)
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('" + label.Text + build + "')", true);
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('No Work Log found on the " + selectedDate + "')", true);
            }
        }
    }
}