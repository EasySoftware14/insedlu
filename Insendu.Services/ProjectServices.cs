using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insendlu.Encryptor;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
////using Insendlu.Entities.Domain;
using Insendlu.Entities.MySqlConnection;
//using Task = Insendlu.Entities.Domain.Task;


namespace Insendu.Services
{
    public class ProjectService
    {
        private readonly Connect _connect;
       // private readonly insedluEntities _insendluEntities;
        private readonly InsendluEntities _insendluEntities;
        private readonly Encryptor _encryptor;
        private readonly EmailService _emailService;

        public ProjectService()
        {
            _connect = new Connect();
            _insendluEntities = _connect.GetConnection();
            _encryptor = new Encryptor();
            _emailService = new EmailService();
        }

        public Connect Connect
        {
            get
            {
                return _connect;
            }
        }

        public int AddNewProject(Project proj)
        {
            var project = new Project
            {
                created_at = proj.created_at,
                modified_at = proj.modified_at,
                description = proj.description,
                status = proj.status,
                proj_cat_id = proj.proj_cat_id,
                name = proj.name
            };

            _insendluEntities.Projects.Add(project);

            return _insendluEntities.SaveChanges();
        }
        public Project AddProject(Project proj)
        {
            var project = new Project
            {
                created_at = proj.created_at,
                modified_at = proj.modified_at,
                description = proj.description,
                status = (int) ProjectStatus.Pending,
                duration = proj.duration,
                proj_cat_id = proj.proj_cat_id,
                name = proj.name,
                sector_id = proj.sector_id
            };

            _insendluEntities.Projects.Add(project);
            _insendluEntities.SaveChanges();

            return project;
        }
        public int AddProjectCategory(ProjectCategory projectCategory)
        {
            var cat = _insendluEntities.ProjectCategories.Add(projectCategory);
            var id = _insendluEntities.SaveChanges();
            return id;
        }
        public void RemoveProject(long id)
        {
            var projectToRemove = (from pro in _insendluEntities.Projects
                                   where pro.id == id
                                   select pro).SingleOrDefault();

            _insendluEntities.Projects.Remove(projectToRemove);

        }

        public void UpdateProject(Project project)
        {
            var projectToUpdate = (from pro in _insendluEntities.Projects
                                   where pro.id == project.id
                                   select pro).SingleOrDefault();

            if (projectToUpdate != null)
            {
                projectToUpdate.description = project.description;
                projectToUpdate.modified_at = DateTime.Now;
                projectToUpdate.proj_cat_id = project.proj_cat_id;
                projectToUpdate.name = project.name;

            }

            _insendluEntities.SaveChanges();
        }

        public int SaveLog(Logging logging)
        {
            _insendluEntities.Loggings.Add(logging);

            return _insendluEntities.SaveChanges();
        }
        public Company GetCompanyById(long id)
        {
            var company = (from comp in _insendluEntities.Companies
                where comp.proj_id == id
                select comp).SingleOrDefault();

            return company;
        }
        public ExecutiveSummary GetExecSummary(long id)
        {
            var exec = (from p in _insendluEntities.ExecutiveSummaries
                        where p.proj_id == id
                        select p).SingleOrDefault();
            return exec;
        }
        public ProjectPolicy GetProjectPolicy(long id)
        {
            var projPolicy = (from p in _insendluEntities.ProjectPolicies
                              where p.proj_id == id
                        select p).SingleOrDefault();
            return projPolicy;
        }
        public RiskAnalysi RiskAnalysis(long id)
        {
            var riskAnalysis = (from p in _insendluEntities.RiskAnalysis
                                  where p.proj_id == id
                                  select p).SingleOrDefault();
            return riskAnalysis;
        }
        public ProjectMethodology GetProjMethodolgy(long id)
        {
            var projMeth = (from proj in _insendluEntities.ProjectMethodologies
                            where proj.proj_id == id
                select proj).SingleOrDefault();

            return projMeth;
        }
        public int SaveWorkLog(WorkLog workLog)
        {
            _insendluEntities.WorkLogs.Add(workLog);

            return _insendluEntities.SaveChanges();
        }

        public bool GetWorkLogByProjIdAndDate(long projId, DateTime date)
        {
            var newDate = date.Date;

            var logFound = (from workLog in _insendluEntities.WorkLogs
                where workLog.date_logged == newDate && workLog.proj_id == projId
                select workLog).SingleOrDefault();

            if (logFound != null)
            {
                return true;
            }

            return false;
        }
        public ProjectCostPlan GetCostPlan(long id)
        {
            var costPlan = (from cost in _insendluEntities.ProjectCostPlans
                            where cost.proj_id == id
                            select cost).SingleOrDefault();

            return costPlan;
        }

        public ProjectCoverPage GetProjectCoverPage(long id)
        {
            var coverpage = (from cost in _insendluEntities.ProjectCoverPages
                            where cost.proj_id == id
                            select cost).SingleOrDefault();

            return coverpage;
        }
        public projectJVCompany GetProjectJvCompany(long id)
        {
            var jvCompany = (from cost in _insendluEntities.projectJVCompanies
                             where cost.proj_id == id
                             select cost).SingleOrDefault();

            return jvCompany;
        }
        public ProjectScopeOfWork GetProjectScopeOfWork(long id)
        {
            var scope = (from cost in _insendluEntities.ProjectScopeOfWorks
                             where cost.proj_id == id
                             select cost).SingleOrDefault();

            return scope;
        }
        public ProjectImplementationTime GetProjectImplementationTime(long id)
        {
            var implement = (from cost in _insendluEntities.ProjectImplementationTimes
                             where cost.proj_id == id
                             select cost).SingleOrDefault();

            return implement;
        }
        public ProjectTeam GetProjectTeam(long id)
        {
            var team = (from cost in _insendluEntities.ProjectTeams
                             where cost.proj_id == id
                             select cost).SingleOrDefault();

            return team;
        }
        public ProjectCvsAndReference GetProjectReference(long id)
        {
            var references = (from cost in _insendluEntities.ProjectCvsAndReferences
                             where cost.project_id == id
                             select cost).SingleOrDefault();

            return references;
        }
        public BEEStatu GetProjectBeeStatus(long id)
        {
            var bee = (from cost in _insendluEntities.BEEStatus
                              where cost.proj_id == id
                              select cost).SingleOrDefault();

            return bee;
        }
        public WhyChooseBiz GetProjectWhyChooseBiz(long id)
        {
            var why = (from cost in _insendluEntities.WhyChooseBizs
                              where cost.proj_id == id
                              select cost).SingleOrDefault();

            return why;
        }
        public WhyChooseStandard GetProjectWhyChooseBizStandard()
        {
            var whyChoose = (from cost in _insendluEntities.WhyChooseStandards
                       select cost).SingleOrDefault();

            return whyChoose;
        }
        public Project GetProjectById(long id)
        {
            var project = (from proj in _insendluEntities.Projects
                            where proj.id == id
                            select proj).SingleOrDefault();

            return project;
        }

        public Variable GetVariable(string letter)
        {
            var variable = (from var in _insendluEntities.Variables
                where var.access_key == letter
                select var).Single();

            return variable;
        }

        public bool GetProjectProjectionById(int projId)
        {
            var found = false;

            var projProjection = (from proj in _insendluEntities.ProjectProjections
                where proj.proj_id == projId
                select proj).SingleOrDefault();

            if (projProjection != null)
            {
                found = true;
            }

            return found;
        }

        public Company GetCompanyBackground()
        {
            return _insendluEntities.Companies.Single();
        }

        public CoverpageStandard GetCoverpageStandard()
        {
            return _insendluEntities.CoverpageStandards.SingleOrDefault();
        }
        public ConfidentialityStatement GetConfidentialityStatement()
        {
            return _insendluEntities.ConfidentialityStatements.SingleOrDefault();
        }
        public ProjectProjection GetProjectProjection(long projId)
        {
            var projProjection = (from proj in _insendluEntities.ProjectProjections
                                  where proj.proj_id == projId
                                  select proj).First();
            return projProjection;
        }
        public int AddUser(string name, string surname, string email, int usertype, string path)
        {
            var tempPass = name + surname + "$";
            var encryptedPass = _encryptor.Encrypt(tempPass);
            var verify = CheckeEmailDuplication(email);

            if (verify > 0)
            {
                var user = new User
                {
                    name = name,
                    surname = surname,
                    email = email,
                    temporary_password = encryptedPass,
                    created_at = DateTime.Now,
                    modified_at = DateTime.Now,
                    user_type_id = usertype,
                    status = 0

                };

                _insendluEntities.Users.Add(user);
                var saved = 0;
                try
                {
                    saved = _insendluEntities.SaveChanges();
                }
                catch (DbEntityValidationException  exception)
                {
                    Console.WriteLine(exception.EntityValidationErrors);
                    throw;
                }
                
                if (saved == 1)
                {
                    _emailService.SendEmail(email, encryptedPass, path, name + " "+ surname);
                }

                return saved;
            }

            return -1;
        }
        public int AddUser(string name, string surname, string email, int usertype)
        {
            var tempPass = name + surname + "$";
            var encryptedPass = _encryptor.Encrypt(tempPass);
            var verify = CheckeEmailDuplication(email);

            if (verify > 0)
            {
                var user = new User
                {
                    name = name,
                    surname = surname,
                    email = email,
                    temporary_password = encryptedPass,
                    created_at = DateTime.Now,
                    modified_at = DateTime.Now,
                    user_type_id = usertype,
                    status = 0

                };

                _insendluEntities.Users.Add(user);
                var saved = _insendluEntities.SaveChanges();

                if (saved == 1)
                {
                    _emailService.SendEmail(email, encryptedPass);
                }

                return saved;
            }

            return -1;
        }
        private int CheckeEmailDuplication(string email)
        {
            var check = 1;
            var checkUser = (from users in _insendluEntities.Users
                             where users.email == email
                             select users).ToList();

            if (checkUser.Count > 0)
            {
                check = -1;
            }

            return check;
        }

        public Project GetProjectByName(string name, int sector)
        {
            var pro = (from p in _insendluEntities.Projects
                       where p.name.Contains(name) && p.sector_id == sector
                       select p).FirstOrDefault();

            return pro;
        }
        public Project GetProjectByName(string name)
        {
            var pro = (from p in _insendluEntities.Projects
                       where p.name == name 
                       select p).FirstOrDefault();

            return pro;
           
        }
        public User GetUserById(int id)
        {
            var users = (from user in _insendluEntities.Users
                        where user.id == id
                        select user).Single();

            return users;
        }

        public int SaveUserProject(Project pro, User user)
        {
            var userProj = new User_Project
            {
                created_at = DateTime.Today,
                modified_at = DateTime.Today,
                proj_id = (int) pro.id,
                user_id = (int) user.id
            };

            _insendluEntities.User_Project.Add(userProj);

            return _insendluEntities.SaveChanges();
        }
        public int SaveProjectDocuments(ProjectDocument projectDocument)
        {
            var x = 0;

            _insendluEntities.ProjectDocuments.Add(projectDocument);

            try
            {
                 x = _insendluEntities.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {

                var error = ex.EntityValidationErrors;
            }

            return x;
        }

        public int SaveResearch(string content, string name, int id)
        {
            var research = new Research
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                data = content,
                name = name,
                proj_id = id
            };

            _insendluEntities.Researches.Add(research);

            return _insendluEntities.SaveChanges();
        }
        public int SaveAccounting(string content)
        {
            var accounting = new Accounting
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                data = content
                
            };

            _insendluEntities.Accountings.Add(accounting);

            return _insendluEntities.SaveChanges();
        }
        public int SaveConsulatancy(string content, string name, int id)
        {
            var consultancy = new Consultancy
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                data = content,
                proj_id = id,
                name = name
            };

            _insendluEntities.Consultancies.Add(consultancy);

            return _insendluEntities.SaveChanges();
        }
        public int SaveTask(Task task)
        {
            _insendluEntities.Tasks.Add(task);

            return _insendluEntities.SaveChanges();
        }
        public int SaveStory(MyStory story, long id)
        {
            var check = (from ch in _insendluEntities.MyStories
                             where ch.user_id == id
                             select ch).SingleOrDefault();

            if (check != null)
            {
                check.story = story.story;
            }
            else
            {
                _insendluEntities.MyStories.Add(story);
            }

            return _insendluEntities.SaveChanges();
        }
        public int SaveDocuments(Upload projectDocument)
        {
             _insendluEntities.Uploads.Add(projectDocument);

            return _insendluEntities.SaveChanges();
        }
        public MyStory ViewMyStory(long id)
        {
            var story = (from tas in _insendluEntities.MyStories
                        where tas.user_id == id && tas.created_at >= DateTime.Today
                        select tas).SingleOrDefault();

            return story;
        }
        public IList<Task> MyTasks(long id)
        {
            var task = (from tas in _insendluEntities.Tasks
                        where tas.user_id == id && tas.status != null
                select tas).ToList();

            return task;
        }
        public IList<Task> GetAllTasks()
        {
            var tasks = (from tas in _insendluEntities.Tasks
                         select tas).ToList();

            return tasks;
        }
        public string GetTypeById(int projecType)
        {
            var name = (from cat in _insendluEntities.ProjectCategories
                            where cat.id == projecType
                            select cat).SingleOrDefault();

            if (name != null)
            {
                return name.name;
            }

            return "";

        }

        public int SaveBusinessPlan(string content, int id)
        {
            var biz = new BusinessPlan
            {
                content = content,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                user_id = id
            };

            _insendluEntities.BusinessPlans.Add(biz);

            return _insendluEntities.SaveChanges();
        }
        public int SaveDevelopmentPlan(string content, int id)
        {
            var devPlans = new DevelopmentPlan
            {
                content = content,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                user_id = id
            };

            _insendluEntities.DevelopmentPlans.Add(devPlans);

            return _insendluEntities.SaveChanges();
        }

        public int SaveComment(string comment, int id)
        {
            var comm = new Comment
            {
                comment1 = comment,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                proj_id = (int) id
            };

            _insendluEntities.Comments.Add(comm);

            return _insendluEntities.SaveChanges();
        }
        public int SaveProposalUser(string users, int id)
        {
            var propUser = new ProposalUser
            {
                users = users,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                proj_id = id
            };

            _insendluEntities.ProposalUsers.Add(propUser);

            return _insendluEntities.SaveChanges();
        }

        public int SaveProposalDocument(ProjectDocument projectdocument)
        {
            _insendluEntities.ProjectDocuments.Add(projectdocument);

            return _insendluEntities.SaveChanges();
        }

        public Logging GetWorkLogByName(string name)
        {
            var logging = (from log in _insendluEntities.Loggings
                where log.name.StartsWith(name)
                select log).FirstOrDefault();

            return logging;
        }

        public int SaveSmallProject(SmallProject small)
        {
            _insendluEntities.SmallProjects.Add(small);

            return _insendluEntities.SaveChanges();
        }
        public SmallProject GetSmallProjectLogByName(string name)
        {
            var logging = (from log in _insendluEntities.SmallProjects
                           where log.name.StartsWith(name)
                           select log).FirstOrDefault();

            return logging;
        }

        public ProjectProjection ProjectProjection(int projId)
        {
            var projectProject = new ProjectProjection();

            var pp = (from projP in _insendluEntities.ProjectProjections
                        where projP.proj_id == projId
                        select projP).FirstOrDefault();

            if (pp != null)
            {
                return pp;
            }

            return projectProject;
        }

        public IList<ProjectDocument> ProjectDocuments(int projId)
        {
            return _insendluEntities.ProjectDocuments.Where(x => x.proj_id == projId).ToList();
        }

        public IList<ProjectEnvelop> GetProjectEnvelops()
        {
            return _insendluEntities.ProjectEnvelops.ToList();
        }
    }
}
