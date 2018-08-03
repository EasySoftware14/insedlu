using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ikvm.extensions;
using Insendlu.Entities.Connection;
//using Insendlu.Entities.Domain;

using Insendu.Services;
using java.lang;

namespace Insendlu
{
    public partial class Parameter : System.Web.UI.Page
    {
        private readonly InsendluEntities _insedlu;
        private readonly ProjectService _projectService;
        private long _projId;
        private int _userId;
        public Parameter()
        {
            _insedlu = new InsendluEntities();
            _projectService = new ProjectService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Convert.ToInt64(Request.QueryString["id"]);
                _projId = id;
                lblProjLog.Text = _projectService.GetProjectById(id).name;
                lblProjLog.Font.Bold = true;
                _userId = Convert.ToInt32(Session["ID"]);

                if (_projectService.GetProjectProjectionById((int) _projId))
                {
                    var projectionTotal = 0;

                    var projProjection = _projectService.GetProjectProjection(_projId);
                    projectionTotal += Convert.ToInt32(projProjection.accomodation);
                    accommodation.Text = projProjection.accomodation;
                    accProjCost.Text = "R " + projProjection.accomodation;

                    telephone.Text = projProjection.telephone;
                    projectionTotal += Convert.ToInt32(projProjection.telephone);
                    telProjCost.Text = "R " + projProjection.telephone;

                    vehicle.Text = projProjection.vehicle;
                    projectionTotal += Convert.ToInt32(projProjection.telephone);
                    vProjecCost.Text = "R " + projProjection.vehicle;

                    material.Text = projProjection.print_material;
                    projectionTotal += Convert.ToInt32(projProjection.print_material);
                    printProjCost.Text = "R " + projProjection.print_material;

                    employees.Text = projProjection.employees;
                    projectionTotal += Convert.ToInt32(projProjection.employees);
                    empProjecCost.Text = "R " + projProjection.employees;

                    refreshment.Text = projProjection.refreshments;
                    projectionTotal += Convert.ToInt32(projProjection.refreshments);
                    refreshProjCost.Text = "R " + projProjection.refreshments;

                    fieldwork.Text = projProjection.wifi_data;
                    projectionTotal += Convert.ToInt32(projProjection.wifi_data);
                    wifiProjCost.Text = "R " + projProjection.wifi_data;

                    MakeReadOnly();
                    lblProjTotal.Text = "R " + projectionTotal;
                    SetUpParameters(_projId);
                }
                
            }
            else
            {
                var id = Convert.ToInt64(Request.QueryString["id"]);
                _projId = id;
                _userId = Convert.ToInt32(Session["ID"]);
            }
        }

        private void MakeReadOnly()
        {
            accommodation.ReadOnly = true;
            telephone.ReadOnly = true;
            vehicle.ReadOnly = true;
            material.ReadOnly = true;
            employees.ReadOnly = true;
            refreshment.ReadOnly = true;
            fieldwork.ReadOnly = true;
            btnSaveEstimation.Enabled = false;
            accProjCost.ReadOnly = true;
            wifiProjCost.ReadOnly = true;
            vProjecCost.ReadOnly = true;
            accProjCost.ReadOnly = true;
            empProjecCost.ReadOnly = true;
            refreshProjCost.ReadOnly = true;
            
        }

        public void SetUpParameters(long projId)
        {
            var accomoTotalCost = 0;
            var vehiTotalCost = 0;
            var telTotalCost = 0;
            var matTotalCost = 0;
            var emplTotalCost = 0;
            var wifiTotalCost = 0;
            var refreshTotalCost = 0;

            var totalVariance = 0;

            var refreshCost = (from refrsh in _insedlu.Refreshments
                where refrsh.project_id == projId
                select refrsh).ToList();

            refreshTotalCost = GetTotalCosts(refreshCost);
            totalVariance += SetupRefreshment(refreshTotalCost);
           

            var accomCosts = (from accom in _insedlu.Accommodations
                where accom.project_id.Value == projId
                select accom).ToList();

            accomoTotalCost = GetTotalCosts(accomCosts);
            totalVariance += SetUpAccommodation(accomoTotalCost);

            var wifiCost = (from field in _insedlu.Wifis
                            where field.project_id == projId
                            select field).ToList();

            wifiTotalCost = GetTotalCosts(wifiCost);
            totalVariance += SetUpWifi(wifiTotalCost);

            var vehicleCost = (from field in _insedlu.Vehicles
                            where field.project_id == projId
                            select field).ToList();

            vehiTotalCost = GetTotalCosts(vehicleCost);
            totalVariance += SetUpVehicle(vehiTotalCost);

            var telephoneCost = (from field in _insedlu.Telephones
                               where field.project_id == projId
                               select field).ToList();

            telTotalCost = GetTotalCosts(telephoneCost);
            totalVariance += SetUpTelephone(telTotalCost);

            var matPrintMatCost = (from field in _insedlu.PrintMaterials
                                 where field.project_id == projId
                                 select field).ToList();

            matTotalCost = GetTotalCosts(matPrintMatCost);
            totalVariance += SetUpMaterial(matTotalCost);

            var employeeCost = (from field in _insedlu.Employees
                                   where field.project_id == projId
                                   select field).ToList();

            emplTotalCost = GetTotalCosts(employeeCost);
            totalVariance += SetUpEmployee(emplTotalCost);

            lblActualCost.Text = "R " + (accomoTotalCost + vehiTotalCost + telTotalCost + matTotalCost + emplTotalCost + wifiTotalCost +
                                 refreshTotalCost).toString();
            lblVariance.Text = "R " + totalVariance.toString();
        }

        private int SetUpEmployee(int emplTotalCost)
        {
            employeeTotalCost.Text = "R " + emplTotalCost.ToString();
            var empVariance = (Convert.ToInt32(employees.Text) - emplTotalCost);

            if (empVariance < 0)
            {
                employeeVariance.Text = "R " + empVariance.ToString();
                employeeVariance.ForeColor = Color.Red;
            }
            else
            {
                employeeVariance.Text = "R " + empVariance.ToString();
                employeeVariance.ForeColor = Color.Blue;
            }

            return empVariance;
        }

        private int SetUpMaterial(int matTotalCost)
        {
            materialTotalCost.Text = "R " + matTotalCost.ToString();
            var matVariance = (Convert.ToInt32(material.Text) - matTotalCost);

            if (matVariance < 0)
            {
                printVariance.Text = "R " + matVariance.ToString();
                printVariance.ForeColor = Color.Red;
            }
            else
            {
                printVariance.Text = "R " + matVariance.ToString();
                printVariance.ForeColor = Color.Blue;
            }

            return matVariance;
        }

        private int SetUpTelephone(int telephoneCost)
        {
            telephoneTotalCost.Text = "R " + telephoneCost;
            var teleVariance = (Convert.ToInt32(telephone.Text) - telephoneCost);

            if (teleVariance < 0)
            {
                telVariance.Text = "R " + teleVariance;
                telVariance.ForeColor = Color.Red;
            }
            else
            {
                telVariance.Text = "R " + teleVariance;
                telVariance.ForeColor = Color.Blue;
            }

            return teleVariance;
        }

        private int SetUpVehicle(int vehiTotalCost)
        {
            vehicleTotalCost.Text = "R " + vehiTotalCost;
            var vehiVariance = (Convert.ToInt32(vehicle.Text) - vehiTotalCost);

            if (vehiVariance < 0)
            {
                vehicleVariance.Text = "R " + vehiVariance;
                vehicleVariance.ForeColor = Color.Red;
            }
            else
            {
                vehicleVariance.Text = "R " + vehiVariance;
                vehicleVariance.ForeColor = Color.Blue;
            }

            return vehiVariance;
        }

        private int SetUpWifi(int wifiTotalCost)
        {
            materialTotalCost.Text = "R " + wifiTotalCost;
            var wifiVariance = (Convert.ToInt32(material.Text) - wifiTotalCost);

            if (wifiVariance < 0)
            {
                materialVariance.Text = "R " + wifiVariance;
                materialVariance.ForeColor = Color.Red;
            }
            else
            {
                materialVariance.Text = "R " + wifiVariance;
                materialVariance.ForeColor = Color.Blue;
            }

            return wifiVariance;
        }

        private int SetUpAccommodation(int accomoTotalCost)
        {
            accomTotalCost.Text = "R " + accomoTotalCost;
            var varianceAccom = (Convert.ToInt32(accommodation.Text) - accomoTotalCost);

            if (varianceAccom < 0)
            {
                accomVariance.Text = "R " + varianceAccom;
                accomVariance.ForeColor = Color.Red;
            }
            else
            {
                accomVariance.Text = "R " + varianceAccom;
                accomVariance.ForeColor = Color.Blue;
            }

            return varianceAccom;
        }

        private int SetupRefreshment(int refreshTotalCost)
        {
            refreshmentCost.Text = "R " + refreshTotalCost.toString();
            var varianceRefresh = (Convert.ToInt32(refreshment.Text) - refreshTotalCost);

            if (varianceRefresh < 0)
            {
                refreshVariance.Text = "R " + varianceRefresh;
                refreshVariance.ForeColor = Color.Red;
            }
            else
            {
                refreshVariance.Text = "R " + varianceRefresh;
                refreshVariance.ForeColor = Color.Blue;
            }

            return varianceRefresh;
        }

        private int GetTotalCosts<T>(List<T> obj) where T : class
        {
           
            var total = 0;

            if (obj.Count > 0)
            {
                foreach (var count in obj)
                {
                    var value = count.getClass();
                    var name = value.getName().replace('.',',').split(",")[1];
                  
                    switch (name)
                    {
                        case "Accommodation":
                            var accCosts = count as Accommodation ;
                            total += Convert.ToInt32(accCosts.cost);
                            break;
                        case "Vehicle":
                            var vCosts = count as Vehicle;
                            total += Convert.ToInt32(vCosts.cost);
                            break;
                        case "Telephone":
                            var telCosts = count as Telephone;
                            total += Convert.ToInt32(telCosts.cost);
                            break;
                        case "PrintMaterial":
                            var printCost = count as PrintMaterial;
                            total += Convert.ToInt32(printCost.cost);
                            break;
                        case "Refreshment":
                            var refreCost = count as Refreshment;
                            total += Convert.ToInt32(refreCost.cost);
                            break;
                        case "Employee":
                            var empCost = count as Employee;
                            total += Convert.ToInt32(empCost.cost);
                            break;
                        case "FieldWorkStatistics":
                            var fieldCost = count as Wifi;
                            total += Convert.ToInt32(fieldCost.cost);
                            break;
                    }
                    
                }
            }

            return total;
        }
        private long GetVariableId(string letter)
        {
            return _projectService.GetVariable(letter).id;
        }

        protected void btnSaveEstimation_OnClick(object sender, EventArgs e)
        {
            var projectId = _projId;
            var userId = _userId;
            var projectParamater = new ProjectProjection();

            var accomodation = accommodation;
            var vehicleDeatils = vehicle;
            var employ = employees;
            var printMaterial = material;
            var refresh = refreshment;
            var fieldWork = fieldwork;
            var teleph = telephone;

            projectParamater.proj_id = (int) projectId;
            projectParamater.employees = employ.Text;
            projectParamater.vehicle = vehicleDeatils.Text;
            projectParamater.accomodation = accomodation.Text;
            projectParamater.print_material = printMaterial.Text;
            projectParamater.refreshments = refresh.Text;
            projectParamater.telephone = teleph.Text;
            projectParamater.wifi_data = fieldWork.Text;
            projectParamater.user_id = userId;
            projectParamater.created_at = DateTime.Today;
            projectParamater.modified_at = DateTime.Today;

            _insedlu.ProjectProjections.Add(projectParamater);

            _insedlu.SaveChangesAsync();
            MakeReadOnly();

        }

        protected void backToTrack_OnClick(object sender, EventArgs e)
        {
            var link = Session["TrackWorkLog"].ToString();

            Response.Redirect(link);
        }
    }
}