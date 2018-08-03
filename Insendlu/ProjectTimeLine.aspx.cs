using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using Insendu.Services;

namespace Insendlu
{
    public partial class ProjectTimeLine : System.Web.UI.Page
    {
        private readonly AssetService _assetService;
        private long _projectId;

        public ProjectTimeLine()
        {
            _assetService = new AssetService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                _projectId = Convert.ToInt64(Request.QueryString["id"]);
            }
            _projectId = Convert.ToInt64(Request.QueryString["id"]);
        }

        protected void timeline_OnDayRender(object sender, DayRenderEventArgs e)
        {
            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            var days = DateTime.Now.Day;//DateTime.DaysInMonth(year, month) -

            var timezone = TimeZone.CurrentTimeZone;

            var day = days;
            var date = new DateTime(year, month, day);
            var selectedDate = e.Day.Date.ToShortDateString();

            var accomodation = _assetService.GetAccommodation(selectedDate, _projectId);
            var telephone = _assetService.GetTelephone(selectedDate, _projectId);
            var wifi = _assetService.GetWifi(selectedDate, _projectId);
            var vehicle = _assetService.GetVehicle(selectedDate, _projectId);
            var printMaterial = _assetService.GetPrintMaterial(selectedDate, _projectId);
            var refereshment = _assetService.GetRefreshment(selectedDate, _projectId);
            var employees = _assetService.GetEmployees(selectedDate, _projectId);
            var projManagementFees = _assetService.GetManagementFees(selectedDate, _projectId);
            var contigencyFees = _assetService.GetContigencyFees(selectedDate, _projectId);
            var sustenenceFees = _assetService.GetSustenenceFees(selectedDate, _projectId);
            var dataAnalysts = _assetService.GetDataAnalysts(selectedDate, _projectId);
            var logistics = _assetService.GetLogistics(selectedDate, _projectId);
            var surveyMonkeys = _assetService.GetSurveyMonkeys(selectedDate, _projectId);

            var dater = e.Day.Date;
            var te = dater;

            foreach (var survey in surveyMonkeys)
            {
                if (survey != null)
                {
                    if (survey.start_date != null)
                    {
                        var accomDay = survey.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Survey Monkeys";
                            acc.BackColor = Color.MediumSeaGreen;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }

            foreach (var logistic in logistics)
            {
                if (logistic != null)
                {
                    if (logistic.start_date != null)
                    {
                        var accomDay = logistic.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Logistics";
                            acc.BackColor = Color.LightGoldenrodYellow;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }

            foreach (var dataAnalyst in dataAnalysts)
            {
                if (dataAnalyst != null)
                {
                    if (dataAnalyst.start_date != null)
                    {
                        var accomDay = dataAnalyst.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Data Analyst";
                            acc.BackColor = Color.DarkOrange;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }

            foreach (var sustenenceFee in sustenenceFees)
            {
                if (sustenenceFee != null)
                {
                    if (sustenenceFee.start_date != null)
                    {
                        var accomDay = sustenenceFee.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Sustenance Fees";
                            acc.BackColor = Color.YellowGreen;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }

            foreach (var contigencyFee in contigencyFees)
            {
                if (contigencyFee != null)
                {
                    if (contigencyFee.start_date != null)
                    {
                        var accomDay = contigencyFee.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Contingency Fees";
                            acc.BackColor = Color.LightSlateGray;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }

            foreach (var managementFee in projManagementFees)
            {
                if (managementFee != null)
                {
                    if (managementFee.start_date != null)
                    {
                        var accomDay = managementFee.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Management Fees";
                            acc.BackColor = Color.Green;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }

            foreach (var accom in accomodation)
            {
                if (accom != null)
                {
                    if (accom.start_date != null)
                    {
                        var accomDay = accom.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Accommodation";
                            acc.BackColor = Color.Aqua;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }
            foreach (var tel in telephone)
            {
                if (tel != null)
                {
                    if (tel.start_date != null)
                    {
                        var accomDay = tel.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Telephone";
                            acc.BackColor = Color.DarkGoldenrod;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }
            foreach (var wi in wifi)
            {
                if (wi != null)
                {
                    if (wi.start_date != null)
                    {
                        var accomDay = wi.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Internet or Wifi";
                            acc.BackColor = Color.Aquamarine;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }
            foreach (var veh in vehicle)
            {
                if (veh != null)
                {
                    if (veh.start_date != null)
                    {
                        var accomDay = veh.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Vehicle";
                            acc.BackColor = Color.IndianRed;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }
            foreach (var print in printMaterial)
            {
                if (print != null)
                {
                    if (print.start_date != null)
                    {
                        var accomDay = print.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Print Material";
                            acc.BackColor = Color.LawnGreen;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }
            foreach (var refresh in refereshment)
            {
                if (refresh != null)
                {
                    if (refresh.start_date != null)
                    {
                        var accomDay = refresh.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Refreshments";
                            acc.BackColor = Color.LightBlue;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }
            foreach (var employ in employees)
            {
                if (employ != null)
                {
                    if (employ.start_date != null)
                    {
                        var accomDay = employ.start_date;
                        if (accomDay == e.Day.Date)
                        {
                            var breaker = new Literal();
                            breaker.Text = "<br/>";

                            var acc = new Label();
                            acc.Text = "Employees";
                            acc.BackColor = Color.Chocolate;
                            e.Cell.Controls.Add(breaker);
                            e.Cell.Controls.Add(acc);
                            e.Cell.HorizontalAlign = HorizontalAlign.Justify;

                        }
                    }
                }
            }
          
            var finish = "";

        }

        protected void timeline_OnSelectionChanged(object sender, EventArgs e)
        {

            var selectedDate = timeline.SelectedDate.ToShortDateString();
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

        protected void modalDismiss_OnClick(object sender, EventArgs e)
        {
            //Panel1.Visible = false;
        }

        protected void backToTrack_OnClick(object sender, EventArgs e)
        {
            var link = Session["TrackWorkLog"].ToString();

            Response.Redirect(link);
        }
    }
}