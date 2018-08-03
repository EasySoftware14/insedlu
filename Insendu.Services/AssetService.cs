using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insendlu.Encryptor;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
////using Insendlu.Entities.Domain;

namespace Insendu.Services
{
    public class AssetService
    {
        private readonly Connect _connect;
        private readonly InsendluEntities _insendluEntities;
        private readonly Encryptor _encryptor;
        private readonly EmailService _emailService;

        public AssetService()
        {
            _connect = new Connect();
            _insendluEntities = _connect.GetConnection();
            _encryptor = new Encryptor();
            _emailService = new EmailService();
        }

        public IList<Accommodation> GetAccommodation(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var accomodation = new List<Accommodation>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var acc =
                        _insendluEntities.Accommodations.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);
                    accomodation.Add(acc);
                }
            }

            return accomodation;
        }
        public IList<Telephone> GetTelephone(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var telephone = new List<Telephone>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var telepho =
                        _insendluEntities.Telephones.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date.Value == newDate);

                    telephone.Add(telepho);
                }
            }

            

            return telephone;
        }
        public IList<Refreshment> GetRefreshment(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var refereshment = new List<Refreshment>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var refresh =
                        _insendluEntities.Refreshments.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date.Value == newDate);
                    refereshment.Add(refresh);
                }
            }

            return refereshment;
        }
        public IList<PrintMaterial> GetPrintMaterial(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var printMaterial = new List<PrintMaterial>();

            foreach (var log in workLog)
            {
                if (log != null)
                {

                    var print =
                        _insendluEntities.PrintMaterials.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);

                    printMaterial.Add(print);
                }
            
            }

            return printMaterial;
        }
        public IList<Vehicle> GetVehicle(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var vehicle = new List<Vehicle>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var veh =
                    _insendluEntities.Vehicles.SingleOrDefault(
                        x => x.worklog_id == log.id && x.start_date.Value == newDate);

                    vehicle.Add(veh);
                }
           
            }
            
            return vehicle;
        }
        public IList<Wifi> GetWifi(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var wifi = new List<Wifi>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var internet =
                        _insendluEntities.Wifis.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);
                    wifi.Add(internet);
                } 
            }

            return wifi;
        }
        public IList<Employee> GetEmployees(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var employees = new List<Employee>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var employ =
                        _insendluEntities.Employees.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);

                    employees.Add(employ);
                }
            }

            
            
            return employees;
        }

        public IList<ProjectManagementFee> GetManagementFees(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var projectManagement = new List<ProjectManagementFee>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var employ =
                        _insendluEntities.ProjectManagementFees.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);

                    projectManagement.Add(employ);
                }
            }

            return projectManagement;
        }

        public IList<SustenenceFee> GetSustenenceFees(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var sustenenceFees = new List<SustenenceFee>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var employ =
                        _insendluEntities.SustenenceFees.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);

                    sustenenceFees.Add(employ);
                }
            }

            return sustenenceFees;
        }

        public IList<ContigencyFee> GetContigencyFees(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var contigencyFees = new List<ContigencyFee>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var employ =
                        _insendluEntities.ContigencyFees.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);

                    contigencyFees.Add(employ);
                }
            }

            return contigencyFees;
        }

        public IList<Logistic> GetLogistics(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var logistics = new List<Logistic>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var employ =
                        _insendluEntities.Logistics.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);

                    logistics.Add(employ);
                }
            }

            return logistics;
        }

        public IList<DataAnalyst> GetDataAnalysts(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var dataAnalysts = new List<DataAnalyst>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var employ =
                        _insendluEntities.DataAnalysts.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);

                    dataAnalysts.Add(employ);
                }
            }

            return dataAnalysts;
        }

        public IList<SurveyMonkey> GetSurveyMonkeys(string date, long projId)
        {
            var newDate = Convert.ToDateTime(date);
            var workLog = GetWorkLogging(projId, newDate);
            var surveyMonkeys = new List<SurveyMonkey>();

            foreach (var log in workLog)
            {
                if (log != null)
                {
                    var employ =
                        _insendluEntities.SurveyMonkeys.SingleOrDefault(
                            x => x.worklog_id == log.id && x.start_date == newDate);

                    surveyMonkeys.Add(employ);
                }
            }

            return surveyMonkeys;
        }

        private IList<WorkLog> GetWorkLogging(long projId, DateTime date)
        {
            var newDate = date.Date;
            return _insendluEntities.WorkLogs.Where(x => x.proj_id == projId && x.date_logged == newDate).ToList();
        }
        private WorkLog GetWorkLog(long projId, DateTime date)
        {
            var newDate = date.Date;
            return _insendluEntities.WorkLogs.SingleOrDefault(x => x.proj_id == projId && x.date_logged == newDate);
        }
    }
}
