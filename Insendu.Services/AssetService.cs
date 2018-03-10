using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insendlu.Encryptor;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
////using Insendlu.Entities.Domain;
using Insendlu.Entities.MySqlConnection;

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
