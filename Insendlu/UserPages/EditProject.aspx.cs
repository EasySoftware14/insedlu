using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Insendlu.Entities.Connection;
using Insendlu.Entities.Domain;
using Insendlu.Entities.MySqlConnection;
using Insendu.Services;

namespace Insendlu.UserPages
{
    public partial class EditProject : System.Web.UI.Page
    {
        private readonly ProjectService _projectService;
        private readonly InsendluEntities _insendluEntities;
        private readonly DocumentGeneratorService _documentGeneratorService;
        public EditProject()
        {
            _projectService = new ProjectService();
            _insendluEntities = new InsendluEntities();
            _documentGeneratorService = new DocumentGeneratorService();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var query = Request.QueryString;
                var proposalID = Convert.ToInt64(query.Get("id"));
                var id = Convert.ToInt64(Session["ID"]);
               
                var exec    = _projectService.GetExecSummary(proposalID).content;
                var company = _projectService.GetCompanyById(proposalID).mission_statement;
                var projName = _projectService.GetProjectById(proposalID).name;
                var description = _projectService.GetProjectById(proposalID).description;
                var conclu = _projectService.GetProjectById(proposalID).conclusion;
                var costplan = _projectService.GetCostPlan(proposalID).details;
                var methodology = _projectService.GetProjMethodolgy(proposalID).content;
                var risk = _projectService.RiskAnalysis(proposalID).risk_analysis;
                var bee = _projectService.GetProjectBeeStatus(proposalID).content;
                var reference = _projectService.GetProjectReference(proposalID).content;
                var implement = _projectService.GetProjectImplementationTime(proposalID).content;
                var why = _projectService.GetProjectWhyChooseBiz(proposalID).content;
                var scope = _projectService.GetProjectScopeOfWork(proposalID).content;
                var jvComp = _projectService.GetProjectJvCompany(proposalID).content;
                var team = _projectService.GetProjectTeam(proposalID).content;
                var policy = _projectService.GetProjectPolicy(proposalID).content;
                var department = _projectService.GetProjectById(proposalID).department_name;
                var proType = _projectService.GetProjectById(proposalID).project_type;
                var coverpage = _projectService.GetProjectCoverPage(proposalID).content;

                type.Value = proType;
                policyNum.Content = policy;
                projTeam.Content = team;
                txtDepartment.Text = department;
                execSummary.Content = exec.ToString();  
                companyBackground.Content = company.ToString();
                conclusion.Content = conclu.ToString();
                descriptionPro.Text = description.ToString();
                ProjName.Value = projName.ToString();
                coverPage.Content = coverpage.ToString();
                projReference.Content = reference.ToString();
                costPlan.Content = costplan.ToString();
                propMethodology.Content = methodology.ToString();
                riskanalysis.Content = risk.ToString();
                implemantation.Content = implement.ToString();
                whyChoose.Content = why.ToString();
                projScope.Content = scope.ToString();
                //jvcompany.Content = jvComp.ToString();
                BBEstatus.Content = bee.ToString();
                ProjName.Value = projName.ToString();
                costPlan.Content = costplan.ToString();
                propMethodology.Content = methodology.ToString();

            }
        }
        private string RemoveHtml(string html)
        {
            var content = string.Empty;
            content = Regex.Replace(html, "<.*?>", string.Empty).Trim();

            return content;
        }

        protected void Update_OnClick(object sender, EventArgs e)
        {
            var id = Convert.ToInt64(Session["ID"]);
            var modification = DateTime.Now;

            var comp = RemoveHtml(companyBackground.Content);
            var execSumm = RemoveHtml(execSummary.Content);
            var costP = RemoveHtml(costPlan.Content);
            var methodol = RemoveHtml(propMethodology.Content);
            var poli = RemoveHtml(policyNum.Content);
            var projDesc = RemoveHtml(descriptionPro.Text);
            var projName = ProjName.Value;
            var conlusion = RemoveHtml(conclusion.Content);
            var bee = RemoveHtml(BBEstatus.Content);
            var coverpage = RemoveHtml(coverPage.Content);
            var implement = RemoveHtml(implemantation.Content);
            var jvCompany = RemoveHtml(jvcompany.Content);
            var scope = RemoveHtml(projScope.Content);
            var projRef = RemoveHtml(projReference.Content);
            var team = RemoveHtml(projTeam.Content);
            var riskAnalysis = RemoveHtml(riskanalysis.Content);
            var whyC = RemoveHtml(whyChoose.Content);


            var proj = _projectService.GetProjectById(id);
            proj.description = projDesc;
            proj.name = projName;
            proj.project_type = type.Value;
            proj.conclusion = conlusion;
            proj.modified_at = modification;

            _insendluEntities.Entry(proj).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();

            var execSummar = (from exec in _insendluEntities.ExecutiveSummaries
                              where exec.proj_id == id
                              select exec).SingleOrDefault();

            UpdateExecSummary(execSumm, execSummar, modification);

            var cover = (from exec in _insendluEntities.ProjectCoverPages
                              where exec.proj_id == id
                              select exec).SingleOrDefault();
            UpdateCoverpage(coverpage,cover,modification);

            var beeStats = (from exec in _insendluEntities.BEEStatus
                              where exec.proj_id == id
                              select exec).SingleOrDefault();
            UpdateBeeStatus(bee, beeStats, modification);

            var implementation = (from exec in _insendluEntities.ProjectImplementationTimes
                              where exec.proj_id == id
                              select exec).SingleOrDefault();
            UpdateImplementation(implement, implementation, modification);

            var jv = (from exec in _insendluEntities.projectJVCompanies
                              where exec.proj_id == id
                              select exec).SingleOrDefault();

            UpdateJVCompany(jvCompany, jv, modification);

            var scopOfwork = (from exec in _insendluEntities.ProjectScopeOfWorks
                              where exec.proj_id == id
                              select exec).SingleOrDefault();

            UpdateScopeOfWork(scope, scopOfwork, modification);


            var reference = (from exec in _insendluEntities.ProjectReferences
                              where exec.proj_id == id
                              select exec).SingleOrDefault();

            UpdateReference(projRef, reference, modification);

            var risk = (from exec in _insendluEntities.RiskAnalysis
                              where exec.proj_id == id
                              select exec).SingleOrDefault();

           UpdateRiskAnalysis(riskAnalysis, risk, modification);

           var proTeam = (from exec in _insendluEntities.ProjectTeams
                             where exec.proj_id == id
                             select exec).SingleOrDefault();

            UpdateProjectTeam(team, proTeam, modification);

            var whyChoze = (from exec in _insendluEntities.WhyChooseBizs
                              where exec.proj_id == id
                              select exec).SingleOrDefault();

            UpdateWhyChoose(whyC, whyChoze, modification);


            var plan = (from cost in _insendluEntities.ProjectCostPlans
                        where cost.proj_id == id
                        select cost).SingleOrDefault();

            UpdateCostPlan(costP, plan, modification);

            var company = (from compan in _insendluEntities.Companies
                           where compan.proj_id == id
                           select compan).SingleOrDefault();

            UpdateCompany(comp, company, modification);

            var methodology = (from meth in _insendluEntities.ProjectMethodologies
                               where meth.proj_id == id
                               select meth).SingleOrDefault();

            UpdateProjectMethodology(methodol, methodology, modification);

            var policy = (from polic in _insendluEntities.ProjectPolicies
                          where polic.proj_id == id
                          select polic).SingleOrDefault();

            UpdateprojectPolicy(poli, policy, modification);


            SaveProject(proj);

            Response.Redirect("~/Proposals.aspx");
        }
        private void UpdateBeeStatus(string poli, BEEStatu bee, DateTime date)
        {
            bee.content = poli;
            bee.modifiedAt = date;

            _insendluEntities.Entry(bee).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }
        private void UpdateCoverpage(string poli, ProjectCoverPage cover, DateTime date)
        {
            cover.content = poli;
            cover.modified_at = date;

            _insendluEntities.Entry(cover).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }
        private void UpdateImplementation(string poli, ProjectImplementationTime implementation, DateTime date)
        {
            implementation.content = poli;
            implementation.modified_at = date;

            _insendluEntities.Entry(implementation).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }
        private void UpdateJVCompany(string poli, projectJVCompany jvCompany, DateTime date)
        {
            jvCompany.content = poli;
            jvCompany.modified_at = date;

            _insendluEntities.Entry(jvCompany).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }
        private void UpdateRiskAnalysis(string poli, RiskAnalysi riskAnalysi, DateTime date)
        {
            riskAnalysi.risk_analysis = poli;
            riskAnalysi.modified_at = date;

            _insendluEntities.Entry(riskAnalysi).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }
        private void UpdateReference(string poli, ProjectReference reference, DateTime date)
        {
            reference.content = poli;
            reference.modifiedAt = date;

            _insendluEntities.Entry(reference).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }
        private void UpdateScopeOfWork(string poli, ProjectScopeOfWork scopeOfWork, DateTime date)
        {
            scopeOfWork.content = poli;
            scopeOfWork.modified_at = date;

            _insendluEntities.Entry(scopeOfWork).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }
        private void UpdateProjectTeam(string poli, ProjectTeam team, DateTime date)
        {
            team.content = poli;
            team.modifiedAt = date;

            _insendluEntities.Entry(team).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }
        private void UpdateWhyChoose(string poli, WhyChooseBiz why, DateTime date)
        {
            why.content = poli;
            why.modifiedAt = date;

            _insendluEntities.Entry(why).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }

        private void UpdateprojectPolicy(string poli, ProjectPolicy policy, DateTime date)
        {
            policy.content = poli;
            policy.modified_at = date;

            _insendluEntities.Entry(policy).State = System.Data.Entity.EntityState.Modified; 
            _insendluEntities.SaveChanges();
        }

        private void UpdateProjectMethodology(string methodol, ProjectMethodology methodology, DateTime date)
        {
            methodology.content = methodol;
            methodology.modified_at = date;

            _insendluEntities.Entry(methodology).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }

        private void UpdateCompany(string comp, Company company, DateTime date)
        {
            company.mission_statement = comp;
            company.modified_at = date;

            _insendluEntities.Entry(company).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }

        private void UpdateCostPlan(string costP, ProjectCostPlan plan, DateTime date)
        {
            plan.details = costP;
            plan.modified_at = date;

            _insendluEntities.Entry(plan).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();

        }

        private void UpdateExecSummary(string execSumm, ExecutiveSummary execSummar, DateTime date)
        {
            execSummar.content = execSumm;
            execSummar.modified_at = date;

            _insendluEntities.Entry(execSummar).State = System.Data.Entity.EntityState.Modified;
            _insendluEntities.SaveChanges();
        }
        private void SaveProject(Project project)
        {
           
            var path = Server.MapPath("PDF's");
            _documentGeneratorService.UpdatePdf(project, path);

        }
    }
}