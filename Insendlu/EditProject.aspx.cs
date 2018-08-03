using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using AjaxControlToolkit;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Insendlu.Entities.Connection;
////using Insendlu.Entities.Domain;

using Insendu.Services;
using SautinSoft.Document;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace Insendlu
{
    public partial class EditProject : System.Web.UI.Page
    {
        private readonly ProjectService _projectService;
        private readonly InsendluEntities _insendluEntities;
        private readonly DocumentGeneratorService _documentGeneratorService;
        private int _projectId;
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
                _projectId = (int)proposalID;
                var id = Convert.ToInt64(Session["ID"]);


                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Uploads/ProjectDocs/ProjectCosts/"));
                List<ListItem> files = new List<ListItem>();
                foreach (string filePath in filePaths)
                {
                    var check = Convert.ToInt32(Path.GetFileName(filePath.Split(',')[0]));

                    if (check == proposalID)
                    {
                        files.Add(new ListItem(Path.GetFileName(filePath), filePath));
                    }

                }
                costPlanGrid.DataSource = files;
                costPlanGrid.DataBind();

                LoadCvAndReferences(_projectId);
                LoadCompany();
                LoadConfidentialityStatement();
                LoadConclusionStandard();
                LoadCoverpageStandard();

                var project = _projectService.GetProjectById(proposalID);
                var exec = _projectService.GetExecSummary(proposalID);
                var company = _projectService.GetCompanyBackground();

                var description = _projectService.GetProjectById(proposalID);
                var conclu = _projectService.GetProjectById(proposalID);
                var costplan = _projectService.GetCostPlan(proposalID);
                var methodology = _projectService.GetProjMethodolgy(proposalID);
                var risk = _projectService.RiskAnalysis(proposalID);
                var bee = _projectService.GetProjectBeeStatus(proposalID);
                var reference = _projectService.GetProjectReference(proposalID);
                var implement = _projectService.GetProjectImplementationTime(proposalID);
                var why = _projectService.GetProjectWhyChooseBiz(proposalID);
                var scope = _projectService.GetProjectScopeOfWork(proposalID);
                var jvComp = _projectService.GetProjectJvCompany(proposalID);
                var team = _projectService.GetProjectTeam(proposalID);
                var policy = _projectService.GetProjectPolicy(proposalID);
                var department = _projectService.GetProjectById(proposalID);
                var proType = _projectService.GetProjectById(proposalID);
                var coverpage = _projectService.GetProjectCoverPage(proposalID);
                var projectEnvelopes = _projectService.GetProjectEnvelops();

                projectEnvelope.DataSource = projectEnvelopes;

                foreach (var item in projectEnvelope.Items)
                {
                    var chosen = (SelectListItem) item;
                    if (chosen.Value == project.proj_envelop.ToString())
                    {
                        
                    }
                }


                //var propType = project.project_type ?? String.Empty;
                if (project.client_id != null)
                {
                    var client = _insendluEntities.Clients.Single(x => x.id == project.client_id);
                    clientName.Text = client != null ? client.name : String.Empty;
                    preparedFor.Text = clientName.Text;
                }
                else
                {
                    clientName.Text = String.Empty;
                }

                var sector = Convert.ToInt32(project.sector_id);
                LoadSector();

                drpSector.SelectedValue = sector == 1 ? "Public" : "Private";

                type.Text = proType != null ? proType.project_type : String.Empty;
                //policyNum.Content = policy != null ? policy.content : string.Empty;
                projTeam.Content = team != null ? team.content : string.Empty;

                execSummary.Content = exec != null ? exec.content : String.Empty;
                backgroundStatement.Text = company != null ? company.background : String.Empty;
                backgroundStatement.Enabled = false;
                missionStatement.Enabled = false;

                missionStatement.Text = company != null ? company.mission_statement : String.Empty;
                conclusion.Content = conclu != null ? conclu.conclusion : String.Empty;
                descriptionPro.Text = description != null ? description.description : String.Empty;
                ProjName.Value = project != null ? project.name : String.Empty;
               
                //projReference.Content = reference != null ? reference.content : String.Empty;
                //costPlan.Content = costplan != null ? costplan.details : String.Empty;
                propMethodology.Content = methodology != null ? methodology.content : String.Empty;
                riskanalysis.Content = risk != null ? risk.risk_analysis : String.Empty;
                implemantation.Content = implement != null ? implement.content : String.Empty;
                whyChoose.Content = why != null ? why.content : string.Empty;
                projScopeAim.Text = scope != null ? scope.aim : String.Empty;
                purpose.Text = scope != null ? scope.purpose : String.Empty;
                deliverables.Text = scope != null ? scope.deliverables : String.Empty;
                //jvcompany.Content = jvComp != null ? jvComp.content : String.Empty;
                BBEstatus.Content = bee != null ? bee.content : String.Empty;
                ProjName.Value = project != null ? project.name : String.Empty;
                // costPlan.Content = costplan != null ? costPlan.Content : String.Empty;
                propMethodology.Content = methodology != null ? propMethodology.Content : String.Empty;

                var projType = Convert.ToInt32(project.project_type);
                LoadProjectTypes();
                LoadCvs();
                LoadRefrences();
                switch (projType)
                {
                    case 1:
                        type.SelectedValue = "Business Proposal";
                        break;
                    case 2:
                        type.SelectedValue = "Request For Quotation";
                        break;
                    default:
                        type.SelectedValue = "Mini Proposal";
                        break;
                }
            }
            else
            {
                Update_OnClick(sender, e);
            }
        }
        private void LoadCoverpageStandard()
        {
            var coverpage = _projectService.GetCoverpageStandard();

            if (coverpage != null)
            {
                var address = coverpage.address.Split(',');
                preparedBy.Text = coverpage.prepared_by;
                preparedBy.Enabled = false;

                for (var i = 0; i < address.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            line1.Text = address[0];
                            break;
                        case 1:
                            line2.Text = address[1];
                            break;
                        case 2:
                            surburb.Text = address[2];
                            break;
                        case 3:
                            postalCode.Text = address[3];
                            break;
                        case 4:
                            telNumber.Text = address[4];
                            break;
                        case 5:
                            fax.Text = address[5];
                            break;
                        case 6:
                            emailAddress.Text = address[6];
                            break;
                        case 7:
                            cc.Text = address[7];
                            break;

                    }
                }
            }

        }
        private void LoadConclusionStandard()
        {
            var conclusionSTD = (from std in _insendluEntities.ConclusionStandards
                                 select std).SingleOrDefault();

            if (conclusionSTD != null)
            {
                conclusion.Content = conclusionSTD.conclusion;
            }
        }
        private void LoadRefrences()
        {
            var refrences = (from env in _insendluEntities.References
                             select env).ToList();

            if (refrences.Count > 0)
            {
                refDrpList.DataSource = refrences;
                refDrpList.DataTextField = "client_name";
                refDrpList.DataValueField = "id";
                refDrpList.DataBind();

            }
        }
        private void LoadCvs()
        {
            var cv = (from env in _insendluEntities.CVS
                      select env).ToList();

            if (cv.Count > 0)
            {
                cvs.DataSource = cv;
                cvs.DataTextField = "name";
                cvs.DataValueField = "id";
                cvs.DataBind();

            }
        }
        private void LoadProjectTypes()
        {
            var types = (from protype in _insendluEntities.ProposalTypes
                         select protype).ToList();

            if (types.Count > 0)
            {
                type.DataSource = types;
                type.DataBind();
            }
        }
        private void LoadSector()
        {
            var sector = (from env in _insendluEntities.Sectors
                          select env).ToList();

            if (sector.Count > 0)
            {
                drpSector.DataSource = sector;
                drpSector.DataBind();

            }
        }
        private void LoadCompany()
        {
            var company = _projectService.GetCompanyBackground().service_offering.Split(',');

            foreach (var s in company)
            {
                serviceOffering.Items.Add(s);
            }

        }
        private void LoadCvAndReferences(int projId)
        {
            var projCvAndRef = (from projRef in _insendluEntities.ProjectCvsAndReferences
                                where projRef.project_id == projId
                                select projRef).SingleOrDefault();

            if (projCvAndRef != null)
            {
                var cvTemp = projCvAndRef.cvs.Split(',');
                var refTemp = projCvAndRef.references.Split(',');

                for (var i = 0; i < cvTemp.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(cvTemp[i]))
                    {
                        lstBoxCV.Items.Add(GetCv(Convert.ToInt32(cvTemp[i])));
                        editCV.Enabled = true;
                        editCV.Visible = true;
                        removeCV.Enabled = true;
                        removeCV.Visible = true;
                        lstBoxCV.Visible = true;
                    }

                }
                for (var i = 0; i < refTemp.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(refTemp[i]))
                    {

                        refList.Items.Add(GetReference(Convert.ToInt32(refTemp[i])));
                        editReference.Enabled = true;
                        editReference.Visible = true;
                        removeReference.Enabled = true;
                        removeReference.Visible = true;
                        refList.Visible = true;

                    }
                }
            }

        }
        private string GetCv(int id)
        {
            var cv = _insendluEntities.CVS.Single(x => x.id == id);

            return cv.id + "," + cv.name;
        }
        private string GetReference(int id)
        {
            var reference = _insendluEntities.References.Single(x => x.id == id);

            return reference.id + "," + reference.client_name;
        }
        private void LoadConfidentialityStatement()
        {
            var company = _projectService.GetConfidentialityStatement();

            if (company != null)
            {
                confidentialStatement.Text = company.statement;
                confidentialStatement.Enabled = false;
            }
        }
        private void LoadProjectCategories()
        {
            var categories = (from protype in _insendluEntities.ProjectCategories
                              select protype).ToList();

            if (categories.Count > 0)
            {
                //projectType.DataSource = types;
                //projectType.DataBind();

                //proposalType.DataSource = categories;
                //proposalType.DataBind();

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
            var query = Request.QueryString;
            var id = Convert.ToInt64(query.Get("id"));
            var modification = DateTime.Now;

            foreach (var file in uploadfile.PostedFiles)
            {
                var fileName = Page.Server.MapPath("~/Uploads/ProjectDocs/ProjectCosts/" + id + "," + Path.GetFileName(file.FileName));
                file.SaveAs(fileName);
            }

            //var comp = RemoveHtml(companyBackground.Content);
            var execSumm = RemoveHtml(execSummary.Content);
            //var costP = RemoveHtml(costPlan.Content);
            var methodol = RemoveHtml(propMethodology.Content);
            //var poli = RemoveHtml(policyNum.Content);
            var projDesc = RemoveHtml(descriptionPro.Text);
            var projName = ProjName.Value;
            var conlusion = RemoveHtml(conclusion.Content);
            var bee = RemoveHtml(BBEstatus.Content);
           
            var implement = RemoveHtml(implemantation.Content);
            //var jvCompany = RemoveHtml(jvcompany.Content);
            //var scope = RemoveHtml(projScope.Content);
            //var projRef = RemoveHtml(projReference.Content);
            var team = RemoveHtml(projTeam.Content);
            var riskAnalysis = RemoveHtml(riskanalysis.Content);
            var whyC = RemoveHtml(whyChoose.Content);

            var proj = _projectService.GetProjectById(id);
            proj.description = projDesc;
            proj.name = projName;
            //proj.project_type = type.Value;
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

            //UpdateJVCompany(jvCompany, jv, modification);

            var scopOfwork = (from exec in _insendluEntities.ProjectScopeOfWorks
                              where exec.proj_id == id
                              select exec).SingleOrDefault();

            //UpdateScopeOfWork(scopOfwork, modification);



            //var reference = (from exec in _insendluEntities.ProjectReferences
            //                  where exec.proj_id == id
            //                  select exec).SingleOrDefault();

            //UpdateReference(projRef, reference, modification);

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

            //UpdateCostPlan(costP, plan, modification);

            var company = (from compan in _insendluEntities.Companies
                           where compan.proj_id == id
                           select compan).SingleOrDefault();

            //UpdateCompany(comp, company, modification);

            var methodology = (from meth in _insendluEntities.ProjectMethodologies
                               where meth.proj_id == id
                               select meth).SingleOrDefault();

            UpdateProjectMethodology(methodol, methodology, modification);

            var policy = (from polic in _insendluEntities.ProjectPolicies
                          where polic.proj_id == id
                          select polic).SingleOrDefault();

            //UpdateprojectPolicy(poli, policy, modification);

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
        private void UpdateScopeOfWork(ProjectScopeOfWork scopeOfWork, DateTime date)
        {
            scopeOfWork.aim = projScopeAim.Text;
            scopeOfWork.purpose = purpose.Text;
            scopeOfWork.deliverables = deliverables.Text;
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
            plan.deliverable = costP;
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

            var path = Server.MapPath("PDF");
            //_documentGeneratorService.UpdatePdf(project, path);

        }
        protected void lnkDownload_OnClick(object sender, EventArgs e)
        {
            var filePath = (sender as Button).CommandArgument;
            var file = Path.GetExtension(filePath);

            Response.ContentType = file;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

        protected void lnkDelete_OnClick(object sender, EventArgs e)
        {
            var filePath = (sender as Button).CommandArgument;
            File.Delete(filePath);
            //Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void lnkDownload_OnCommand(object sender, CommandEventArgs e) { }

        protected void lnkDelete_OnCommand(object sender, CommandEventArgs e) { }

        protected void btnAddCv_OnClick(object sender, EventArgs e)
        {
            editRefPopUp.Hide();
            editCV.Enabled = true;
            var chosen = cvs.SelectedValue;
            var build = new StringBuilder();
            cvIds.Text = chosen;
            build.Append(cvIds.Text);
            cvIds.Text = build.ToString();
            if (lstBoxCV.Items.FindByText(chosen + "," + cvs.SelectedItem.Text) == null)
            {
                lstBoxCV.Items.Add(chosen + "," + cvs.SelectedItem.Text);
                var itemCount = lstBoxCV.Items.Count;

                if (itemCount == 1)
                    lstBoxCV.Items[0].Selected = true;
                else
                {
                    lstBoxCV.Items[(itemCount - 1) - 1].Selected = false;
                    lstBoxCV.Items[itemCount - 1].Selected = true;
                }

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('CV already added on the list.')", true);
            }

            lstBoxCV.Visible = true;
            lblCV.Visible = true;
            editCV.Visible = true;
            removeCV.Visible = true;

        }

        protected void btnAddCv_OnCommand(object sender, CommandEventArgs e) { var chosen = cvs.SelectedItem.Text; }
        protected void references_OnClick(object sender, EventArgs e)
        {
            editRefPopUp.Hide();
            editReference.Enabled = true;
            var chosen = refDrpList.SelectedValue;
            var buildRef = new StringBuilder();
            lblref.Text = chosen;
            buildRef.Append(lblref.Text);
            lblref.Text = buildRef.ToString();
            if (refList.Items.FindByText(chosen + "," + refDrpList.SelectedItem.Text) == null)
            {
                refList.Items.Add(chosen + "," + refDrpList.SelectedItem.Text);
                var itemCount = refList.Items.Count;

                if (itemCount == 1)
                    refList.Items[0].Selected = true;
                else
                {
                    refList.Items[(itemCount - 1) - 1].Selected = false;
                    refList.Items[itemCount - 1].Selected = true;
                }

            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(GetType(), "alert", "alert('Reference already added on the list')", true);
            }
            refList.Visible = true;
            lblReference.Visible = true;
            editReference.Visible = true;
            removeReference.Visible = true;
        }

        protected void references_OnCommand(object sender, CommandEventArgs e) { var chosen = refDrpList.SelectedItem.Text; }
        protected void editReference_OnClick(object sender, EventArgs e)
        {
            var selectedReference = Convert.ToInt32(refList.SelectedItem.Text.Split(',')[0]);
            var refereToEdit = RetrieveRefernceById(selectedReference);
            client_Name.Text = refereToEdit.client_name;
            projectDetails.Text = refereToEdit.project_details;
            projValue.Text = refereToEdit.project_value;

            editRefPopUp.Show();


            //RetrieveRefernceById(selectedReference);
        }

        private CV RetrieveCV(int cvId)
        {
            var cv = (from cvs in _insendluEntities.CVS
                      where cvs.id == cvId
                      select cvs).Single();
            Session["CV"] = cv;
            return cv;
        }
        private Reference RetrieveRefernceById(int selectedReference)
        {
            var refrence = (from referee in _insendluEntities.References
                            where referee.id == selectedReference
                            select referee).Single();
            Session["Reference"] = refrence;
            return refrence;
        }

        protected void editReference_OnCommand(object sender, CommandEventArgs e) { }

        protected void editCV_OnClick(object sender, EventArgs e)
        {
            var selectedCV = Convert.ToInt32(refList.SelectedItem.Text.Split(',')[0]);
            var refereToEdit = RetrieveCV(selectedCV);
            qualification.Text = refereToEdit.qualification;
            responsibility.Text = refereToEdit.responsibilities;
            name.Text = refereToEdit.name + " " + refereToEdit.surname;

            editCvPopUp.Show();
        }

        protected void editCV_OnCommand(object sender, CommandEventArgs e) { }

        protected void removeReference_OnCommand(object sender, CommandEventArgs e) { }

        protected void removeReference_OnClick(object sender, EventArgs e)
        {
            refList.Items.Remove(refList.SelectedItem);

            if (refList.Items.Count < 1)
            {
                refList.Visible = false;
                editReference.Visible = false;
                lblReference.Visible = false;
            }

        }

        protected void refCV_OnCommand(object sender, CommandEventArgs e) { }

        protected void refCV_OnClick(object sender, EventArgs e)
        {
            lstBoxCV.Items.Remove(lstBoxCV.SelectedItem);

            if (lstBoxCV.Items.Count < 1)
            {
                lstBoxCV.Visible = false;
                editCV.Visible = false;
                lblCV.Visible = false;
            }
        }

        protected void btnEditReference_OnClick(object sender, EventArgs e)
        {
            var referee = Session["Reference"] as Reference;

            if (referee != null)
            {
                referee.client_name = client_Name.Text;
                referee.project_details = projectDetails.Text;
                referee.project_value = projValue.Text;

                _insendluEntities.Entry(referee).State = EntityState.Modified;
                _insendluEntities.SaveChanges();
                editRefPopUp.Hide();

            }
        }

        protected void btnEditReference_OnCommand(object sender, CommandEventArgs e)
        {

        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            editRefPopUp.Hide();
        }
        protected void pnlPopup_OnPreRender(object sender, EventArgs e)
        {
            if (refList.SelectedItem != null)
            {
                var selectedReference = Convert.ToInt32(refList.SelectedItem.Text.Split(',')[0]);
                var refereToEdit = RetrieveRefernceById(selectedReference);
                client_Name.Text = refereToEdit.client_name;
                projectDetails.Text = refereToEdit.project_details;
                projValue.Text = refereToEdit.project_value;
            }

        }

        protected void refList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            editReference.Enabled = true;
        }

        protected void lstBoxCV_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            editCV.Enabled = true;
        }

        protected void lstBoxCV_OnTextChanged(object sender, EventArgs e)
        {
            editCV.Enabled = true;
        }

        protected void refList_OnTextChanged(object sender, EventArgs e)
        {
            editReference.Enabled = true;
        }

        protected void cvPnlPopup_OnPreRender(object sender, EventArgs e)
        {
            if (lstBoxCV.SelectedItem != null)
            {
                var selectedCV = Convert.ToInt32(lstBoxCV.SelectedItem.Text.Split(',')[0]);
                var refereToEdit = RetrieveCV(selectedCV);
                responsibility.Text = refereToEdit.responsibilities;
                qualification.Text = refereToEdit.qualification;
                name.Text = refereToEdit.name + " " + refereToEdit.surname;

            }
        }

        protected void updateCV_OnClick(object sender, EventArgs e)
        {
            var cv = Session["CV"] as CV;

            if (cv != null)
            {
                cv.responsibilities = responsibility.Text;
                cv.qualification = qualification.Text;

                _insendluEntities.Entry(cv).State = EntityState.Modified;
                _insendluEntities.SaveChanges();
                editCvPopUp.Hide();

            }
        }

        protected void updateCV_OnCommand(object sender, CommandEventArgs e)
        {

        }

        protected void cnlCV_OnClick(object sender, EventArgs e)
        {
            editCvPopUp.Hide();
        }
    }
}