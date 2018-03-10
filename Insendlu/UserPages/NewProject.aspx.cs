using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Insendlu.Entities.Domain;
using Insendlu.Entities.MySqlConnection;
using Insendu.Services;

namespace Insendlu.UserPages
{
    public partial class NewProject : System.Web.UI.Page
    {
        //private readonly insedluEntities _insendluEntities;
        private readonly InsendluEntities _insendluEntities;
        private readonly ProjectService _projectService;
        private readonly DocumentGeneratorService _documentGeneratorService;
        public NewProject()
        {
            _insendluEntities = new InsendluEntities();
            _projectService = new ProjectService();
            _documentGeneratorService = new DocumentGeneratorService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {

                LoadProjectTypes();

            }
            else
            {
                var select = Convert.ToInt32(Request.Form[proposalType.UniqueID]);
                var name =  GetProposalName(select);
                type.Value = name;

            }
        }

        private string GetProposalName(int index)
        {
            var proposal = "";

            switch (index)
            {
                case 1:
                    proposal = "Academic";
                    break;
                case 2:
                    proposal = "Satisfaction Survey";
                    break;
                case 3:
                   proposal = "Consultancy";
                    break;
                case 4:
                    proposal = "Exec / Management Training";
                    break;
                case 5:
                    proposal = "RFG's";
                    break;
                case 6:
                    proposal = "Other";
                    break;
            }
            return proposal;
        }

        private void LoadProjectTypes()
        {
            var types = (from protype in _insendluEntities.ProjectCategories
                         select protype).ToList();
            
            if (types.Count > 0)
            {
                //projectType.DataSource = types;
                //projectType.DataBind();

                proposalType.DataSource = types;
                proposalType.DataBind();

            }
        }

        private string RemoveHtml(string html)
        {
            var content = string.Empty;
            content = Regex.Replace(html, "<.*?>", string.Empty).Trim();
            content = Regex.Replace(content, @"<[^>]+>|&nbsp;", "").Trim();

            return content;
        }
        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            var createdDate = DateTime.Now;
            var modifiedAt = DateTime.Now;
            //var projecType = Convert.ToInt32(type);
            //var type = _projectService.GetTypeById(projecType);
            var conclution = RemoveHtml(conclusion.Content);

            var newProj = new Project
            {
                created_at = createdDate,
                modified_at = modifiedAt,
                description = descriptionPro.Text,
                name = ProjName.Value,
                status = ProjectStatus.Pending.GetHashCode(),
                conclusion = conclution,
                user_id = Convert.ToInt32(Session["ID"]),
                department_name = txtDepartment.Text,
                project_type = type.Value
            };

            _insendluEntities.Projects.Add(newProj);
            var projId = _insendluEntities.SaveChanges();

            if (projId == 1)
            {
                var newId = newProj.id;

                //exec
                var executiveSummary = RemoveHtml(execSummary.Content);
                var id = Executive(executiveSummary, newId);

                //company jv
                var company = RemoveHtml(companyBackground.Content);
                var companyId = GetCompany(company, newId);

                //coverpage
                var coverpage = RemoveHtml(coverPage.Content);
                var coverId = GetCoverpage(coverpage, newId);

                //methodology
                var methodology = RemoveHtml(propMethodology.Content);
                var methodoId = GetMethodology(methodology, newId);

                //cost plan
                var costPlanV = RemoveHtml(costPlan.Content);
                var costPlanId = GetProjectCostPlan(costPlanV, newId);

                //BBBEE
                var bee = RemoveHtml(whyChoose.Content);
                var bbeeId = GetBBEE(bee, newId);

                //analysis
                var projAnalysis = RemoveHtml(riskanalysis.Content);
                var analysisId = GetProjectAnalysis(projAnalysis, newId);

                //scope of work
                var scope = RemoveHtml(projScope.Content);
                var scopeId = GetProjectScope(scope, newId);

                //jv company
                var jv = RemoveHtml(jvcompany.Content);
                var jvId = GetJVCompany(jv, newId);

                //team
                var team = RemoveHtml(projTeam.Content);
                var teamId = GetProjectTeam(team, newId);

                //implementation
                var implement = RemoveHtml(implemantation.Content);
                var implId = GetProjectImplementation(implement, newId);

                //reference
                var reference = RemoveHtml(projReference.Content);
                var refId = GetProjectReference(reference, newId);

                //why choose
                var why = RemoveHtml(whyChoose.Content);
                var whyId = GetProjectWhyChoose(why, newId);

                //policy
                var policy = RemoveHtml(policyNum.Content);
                var policyId = GetProjectPolicy(policy, newId);


                var updateProject = (from pr in _insendluEntities.Projects
                                     where pr.id == newId
                                     select pr).Single();

                if (updateProject != null)
                {
                    updateProject.cost_plan_id = costPlanId;
                    updateProject.company_id = companyId;
                    updateProject.exec_summary_id = id;
                    updateProject.methodology_id = methodoId;
                    updateProject.risk_id = analysisId;
                    updateProject.policy_id = policyId;
                    updateProject.coverpage_id = coverId;
                    updateProject.bee_id = bbeeId;
                    updateProject.scope_id = scopeId;
                    updateProject.jvCompany_id = jvId;
                    updateProject.projectTeam_id = teamId;
                    updateProject.implement_id = implId;
                    updateProject.proj_reference = refId;
                    updateProject.whyChoose_id = whyId;

                    int x = _insendluEntities.SaveChanges();

                    if (x == 1)
                    {
                        var url = string.Format("");
                        Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Proposal saved successfully, to view click here')", true);

                        SaveProject(updateProject);

                        Response.Redirect("SupportingDocs.aspx?id=" + newId);
                    }

                }
            }

        }

        private void TryCatch()
        {
            try
            {
                _insendluEntities.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);

            }
        }
        private int GetProjectScope(string scope, long newId)
        {
            var scopeOfWork = new ProjectScopeOfWork
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                content = scope,
                proj_id = (int)newId
            };

            _insendluEntities.ProjectScopeOfWorks.Add(scopeOfWork);
            TryCatch();

            return (int) scopeOfWork.id;
        }

        private int GetBBEE(string bee, long newId)
        {
            var bbEE = new BEEStatu
            {
                content = bee,
                createdAt = DateTime.Now,
                modifiedAt = DateTime.Now,
                proj_id = (int)newId
            };

            _insendluEntities.BEEStatus.Add(bbEE);
            TryCatch();

            return (int) bbEE.id;
        }

        private void SaveProject(Project projects)
        {
            var path = Server.MapPath("PDF's");

            if (!File.Exists(path + "/" + projects.name + projects.id + ".pdf"))
            {
                _documentGeneratorService.GeneratePdf(projects, path);
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Proposal saved successfully, to edit go to proposals/write ups and click on Pending Proposals')", true);

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Proposal with the same name already exists, please choose different name')", true);
            }

        }

        private int GetProjectAnalysis(string projAnalysis, long newId)
        {
            var riskAnalysis = new RiskAnalysi
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                risk_analysis = projAnalysis,
                proj_id = (int)newId
            };

            _insendluEntities.RiskAnalysis.Add(riskAnalysis);
            TryCatch();

            return (int) riskAnalysis.id;
        }
        private int GetProjectPolicy(string content, long projId)
        {
            var policy = new ProjectPolicy
            {
                content = content,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                proj_id = (int)projId
            };

            _insendluEntities.ProjectPolicies.Add(policy);
            TryCatch();

            return (int) policy.id;
        }

        private int GetProjectCostPlan(string projRef, long newId)
        {
            var proReference = new ProjectCostPlan
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                details = projRef,
                proj_id = (int)newId
            };

            _insendluEntities.ProjectCostPlans.Add(proReference);

            TryCatch();

            return (int) proReference.id;
        }

        private int Executive(string execsum, long projId)
        {
            var exec = new ExecutiveSummary
            {
                content = execsum,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                proj_id = (int)projId

            };

            _insendluEntities.ExecutiveSummaries.Add(exec);
            TryCatch();

            return (int) exec.id;

        }

        private int GetCompany(string content, long projId)
        {
            var company = new Company
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                mission_statement = content,
                proj_id = (int)projId

            };

            _insendluEntities.Companies.Add(company);

            TryCatch();

            return (int) company.id;
        }

        private int GetCoverpage(string content, long projId)
        {
            var coverpage = new ProjectCoverPage
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                content = content,
                proj_id = (int)projId
            };

            _insendluEntities.ProjectCoverPages.Add(coverpage);
            TryCatch();

            return (int) coverpage.id;
        }

        private int GetMethodology(string content, long projId)
        {
            var methodology = new ProjectMethodology
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                content = content,
                proj_id = (int)projId
            };

            _insendluEntities.ProjectMethodologies.Add(methodology);
            TryCatch();

            return (int)methodology.id;
        }

        private int GetJVCompany(string content, long projId)
        {
            var jv = new projectJVCompany
            {
                content = content,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                proj_id = (int) projId
            };

            _insendluEntities.projectJVCompanies.Add(jv);
            TryCatch();

            return (int) jv.id;
        }
        private int GetProjectTeam(string content, long projId)
        {
            var team = new ProjectTeam()
            {
                content = content,
                createdAt = DateTime.Now,
                modifiedAt = DateTime.Now,
                proj_id = (int)projId
            };

            _insendluEntities.ProjectTeams.Add(team);
            TryCatch();

            return (int) team.id;
        }
        private int GetProjectImplementation(string content, long projId)
        {
            var implement = new ProjectImplementationTime
            {
                content = content,
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                proj_id = (int)projId
            };

            _insendluEntities.ProjectImplementationTimes.Add(implement);
            TryCatch();

            return (int) implement.id;
        }
        private int GetProjectReference(string content, long projId)
        {
            var reference = new ProjectReference
            {
                content = content,
                createdAt = DateTime.Now,
                modifiedAt = DateTime.Now,
                proj_id = (int)projId
            };

            _insendluEntities.ProjectReferences.Add(reference);
            TryCatch();

            return (int) reference.id;
        }
        private int GetProjectWhyChoose(string content, long projId)
        {
            var why = new WhyChooseBiz
            {
                content = content,
                createdAt = DateTime.Now,
                modifiedAt = DateTime.Now,
                proj_id = (int)projId
            };

            _insendluEntities.WhyChooseBizs.Add(why);
            TryCatch();

            return (int) why.id;
        }
    }
}