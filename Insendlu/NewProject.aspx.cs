using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Insendlu.Entities;
using Insendlu.Entities.Connection;
using iTextSharp.text;
using iTextSharp.text.pdf;
////using Insendlu.Entities.Domain;
using Insendlu.Entities.MySqlConnection;
using Insendu.Services;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace Insendlu
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
                LoadProjectCategories();
                LoadProjectTypes();
                LoadProjectEnvelop();
                LoadSector();
                LoadCvs();
                LoadRefrences();
                editRefPopUp.Hide();
                LoadCompany();
                LoadCoverpageStandard();
                LoadWhyChooseStandard();
                LoadConfidentialityStatement();
                LoadConclusionStandard();
            }

           
        }
        private void LoadWhyChooseStandard()
        {
            var whyStandard = (from why in _insendluEntities.WhyChooseStandards
                                select why).SingleOrDefault();

            if (whyStandard != null)
            {
                heading.Text = whyStandard.heading;
                bulletedPoints.Text = whyStandard.bullet;
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
        private void LoadProjectEnvelop()
        {
            var envelop = (from env in _insendluEntities.ProjectEnvelops
                           select env).ToList();

            if (envelop.Count > 0)
            {
                projectEnvelope.DataSource = envelop;
                projectEnvelope.DataBind();

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
        private void LoadCompany()
        {
            var company = _projectService.GetCompanyBackground();
                
            missionStatement.Text = company.mission_statement;
            backgroundStatement.Text = company.background;

            var services = company.service_offering.Split(',');
            List<ListItem> items = new List<ListItem>(); 

            foreach (var s in services)
            {
                serviceOffering.Items.Add(s);
            }
            foreach (var item in serviceOffering.Items)
            {
                var selected = (ListItem) item;
                selected.Selected = true;

                items.Add(selected);
            }

            serviceOffering.Items.Clear();
            serviceOffering.Items.AddRange(items.ToArray());
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
        private void LoadProjectCategories()
        {
            var categories = (from protype in _insendluEntities.ProjectCategories
                         select protype).ToList();
            
            if (categories.Count > 0)
            {
                //projectType.DataSource = types;
                //projectType.DataBind();

                proposalType.DataSource = categories;
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
        private string RemoveSpecialCharacters(string confidence)
        {
            var sb = new StringBuilder();
            foreach (var c in confidence)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == ' ' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        protected void SubmitButton_OnClick(object sender, EventArgs e)
        {
            var createdDate = DateTime.Now;
            var modifiedAt = DateTime.Now;
            var projecType = typeEnvelop.SelectedIndex;
            //var type = _projectService.GetTypeById(projecType);
            var completed = Convert.ToInt32(isComplete.Value) == 1 ? true : false;
            var conclution = RemoveHtml(conclusion.Content);
            var cName = clientName.Text;

            var selectedCvs = lstBoxCV.Items;
            var selectReferences = refList.Items;
            var cvList = new List<string>();
            var referenceList = new List<string>();

            foreach (var cv in selectedCvs)
            {

                var cvItem = cv as ListItem;
                cvList.Add(cvItem.Text.Split(',')[0]);

            }
            foreach (var reference in selectReferences)
            {

                var referenceItem = reference as ListItem;
                referenceList.Add(referenceItem.Text.Split(',')[0]);

            }
            var client = new Client
            {
                name = cName, 
                created_at = DateTime.Now, 
                modified_at = DateTime.Now, 
                status = (int) EntityStatus.Active
            };

            _insendluEntities.Clients.Add(client);
            _insendluEntities.SaveChanges();

            var newProj = new Project
            {
                created_at = createdDate,
                modified_at = modifiedAt,
                description = descriptionPro.Text,
                name = ProjName.Value,
                status = ProjectStatus.Active.GetHashCode(),
                conclusion = conclution,
                user_id = Convert.ToInt32(Session["ID"]),
                sector_id = drpSector.SelectedIndex,
                project_type = type.SelectedValue,
                proj_envelop = projecType,
                client_id = client.id,
                is_completed = completed
            };

            _insendluEntities.Projects.Add(newProj);
            var projId = _insendluEntities.SaveChanges();

            if (projId == 1)
            {
                var newId = newProj.id;

                // Project CV and REFERENCES
                var projCvReference =  new ProjectCvsAndReference
                {
                    created_at = DateTime.Now,
                    modified_at = DateTime.Now,
                    cvs = string.Join(",",cvList),
                    references = string.Join(",", referenceList),
                    project_id = (int) newId 
                };

                _insendluEntities.ProjectCvsAndReferences.Add(projCvReference);
                _insendluEntities.SaveChanges();

                var allowedDocTypes = new string[] {".doc",".docx",".png",".jpeg",".jpg"};
                //Project Cost Document(s)
                foreach (var file in fileUpload.PostedFiles)
                {
                    if (allowedDocTypes.Contains(file.ContentType))
                    {
                        var fileName = Page.Server.MapPath("~/Uploads/ProjectDocs/ProjectCosts/" + newId + "," + Path.GetFileName(file.FileName));
                        file.SaveAs(fileName);
                    }
                   
                }
                
                //exec
                var executiveSummary = RemoveSpecialCharacters(RemoveHtml(execSummary.Content));
                var id = Executive(executiveSummary, newId);

                //company 
                var missionState = missionStatement.Text;
                var serviceOfer = serviceOffering.Items;
                var backgroundCheck = backgroundStatement.Text;

                var selectedServices = new List<string>(serviceOfer.Count);

                foreach (var service in serviceOfer)
                {
                    var serve = (ListItem) service;

                    if(serve.Selected)
                        selectedServices.Add(serve.Value);
                }
         
                UpdateCompanyBackground(missionState, backgroundCheck, selectedServices);

                //coverpage
                var prepared = preparedFor.Text;
                var reasonProposal = reasonForProposal.Text;

                var coverId = GetCoverpage(prepared, reasonProposal, newId);

                //methodology
                var methodology = RemoveSpecialCharacters(RemoveHtml(propMethodology.Content));
                var methodoId = GetMethodology(methodology, newId);

                //cost plan
                //var costPlanV = RemoveHtml(costPlan.Content);
                //var costPlanId = GetProjectCostPlan(costPlanV, newId);

                //BBBEE
                var bee = RemoveSpecialCharacters(RemoveHtml(whyChoose.Content));
                var bbeeId = GetBBEE(bee, newId);

                //analysis
                var projAnalysis = RemoveSpecialCharacters(RemoveHtml(riskanalysis.Content));
                var analysisId = GetProjectAnalysis(projAnalysis, newId);

                //scope of work
                var scopeId = GetProjectScope(projScopeAim.Text, purpose.Text, deliverables.Text, newId);

                //jv company
                //var jv = RemoveHtml(jvcompany.Content);
                //var jvId = GetJVCompany(jv, newId);

                //team
                var team = RemoveSpecialCharacters(RemoveHtml(projTeam.Content));
                var teamId = GetProjectTeam(team, newId);

                //implementation
                var implement = RemoveSpecialCharacters(RemoveHtml(implemantation.Content));
                var implId = GetProjectImplementation(implement, newId);

                //reference
                //var reference = RemoveHtml(projReference.Content);
                //var refId = GetProjectReference(reference, newId);

                //why choose
                var why = RemoveSpecialCharacters(RemoveHtml(whyChoose.Content));
                var whyId = GetProjectWhyChoose(why, newId);

                //policy
                //var policy = RemoveHtml(policyNum.Content);
                //var policyId = GetProjectPolicy(policy, newId);


                var updateProject = (from pr in _insendluEntities.Projects
                                     where pr.id == newId
                                     select pr).Single();

                if (updateProject != null)
                {
                    //updateProject.cost_plan_id = costPlanId;
                    updateProject.exec_summary_id = id;
                    updateProject.methodology_id = methodoId;
                    updateProject.risk_id = analysisId;
                    //updateProject.policy_id = policyId;
                    updateProject.coverpage_id = coverId;
                    updateProject.bee_id = bbeeId;
                    updateProject.scope_id = scopeId;
                    //updateProject.jvCompany_id = jvId;
                    updateProject.projectTeam_id = teamId;
                    updateProject.implement_id = implId;
                   // updateProject.proj_reference = refId;
                    updateProject.whyChoose_id = whyId;

                    int x = _insendluEntities.SaveChanges();

                    if (x == 1)
                    {

                        SaveProject(updateProject);

                        if(completed)
                            Response.Redirect("SupportingDocs.aspx?id=" + newId);
                        else 
                            Response.Redirect("Proposals.aspx");
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
        private int GetProjectScope(string aim, string scopePurpose, string scopeDeliverables, long newId)
        {
            var scopeOfWork = new ProjectScopeOfWork
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                aim = aim,
                purpose = scopePurpose,
                deliverables = scopeDeliverables,
                proj_id = (int) newId
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
                proj_id = (int) newId
            };

            _insendluEntities.BEEStatus.Add(bbEE);
            TryCatch();

            return (int) bbEE.id;
        }
        private void SaveProject(Project project)
        {
            var path = Server.MapPath("PDF's");

            if (!File.Exists(path + "/"  + project.id + "," + project.name + ".pdf"))
            {
                //_documentGeneratorService.GeneratePdf(project, path);
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
                proj_id = (int) newId
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
                proj_id = (int) projId
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
                deliverable = projRef,
                proj_id = (int) newId
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
                proj_id = (int) projId

            };

            _insendluEntities.ExecutiveSummaries.Add(exec);
            TryCatch();

            return (int) exec.id;

        }

        private void UpdateCompanyBackground(string missionState, string backgound, List<string> services)
        {
            var company = _projectService.GetCompanyBackground();

            //company.mission_statement = missionState;
            //company.background = backgound;
            //company.service_offering = string.Join(",", services);

            //_insendluEntities.Entry(company).State = EntityState.Modified;
            //_insendluEntities.SaveChanges();

        }

        private int GetCoverpage(string preparedFor, string reason, long projId)
        {
            var coverpage = new ProjectCoverPage
            {
                created_at = DateTime.Now,
                modified_at = DateTime.Now,
                prepared_for = preparedFor,
                reason_for_proposal = reason,
                proj_id = (int) projId
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
                proj_id = (int) projId
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
            var team = new ProjectTeam
            {
                content = content,
                createdAt = DateTime.Now,
                modifiedAt = DateTime.Now,
                proj_id = (int) projId
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
                proj_id = (int) projId
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
                proj_id = (int) projId
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
                proj_id = (int) projId
            };

            _insendluEntities.WhyChooseBizs.Add(why);
            TryCatch();

            return (int) why.id;
        }

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

        protected void btnAddCv_OnCommand(object sender, CommandEventArgs e){var chosen = cvs.SelectedItem.Text;}

        protected void save_OnCommand(object sender, CommandEventArgs e){SubmitButton_OnClick(sender, e);}

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

        protected void references_OnCommand(object sender, CommandEventArgs e){var chosen = refDrpList.SelectedItem.Text;}

        protected void AjaxFileUpload1_OnUploadComplete(object sender, AjaxFileUploadEventArgs e)
        {
            var filename = Page.Server.MapPath("~/Uploads/ProjectDocs/" + Path.GetFileName(e.FileName));
            // Proposal Document
            AjaxFileUpload1.SaveAs(filename);
        }

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

        protected void editReference_OnCommand(object sender, CommandEventArgs e){}

        protected void editCV_OnClick(object sender, EventArgs e)
        {
            var selectedCV = Convert.ToInt32(refList.SelectedItem.Text.Split(',')[0]);
            var refereToEdit = RetrieveCV(selectedCV);
            qualification.Text = refereToEdit.qualification;
            responsibility.Text = refereToEdit.responsibilities;
            name.Text = refereToEdit.name + " " + refereToEdit.surname;

            editCvPopUp.Show();
        }

        protected void editCV_OnCommand(object sender, CommandEventArgs e){}

        protected void removeReference_OnCommand(object sender, CommandEventArgs e){}

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

        protected void refCV_OnCommand(object sender, CommandEventArgs e){}

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
            var show = showValue.Checked;
            if (referee != null)
            {
                referee.client_name = client_Name.Text;
                referee.project_details = projectDetails.Text;
                referee.project_value = projValue.Text;
                referee.show_value = show;

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
                txtDuration.Text = refereToEdit.date_undertaken;
                contactPerson.Text = refereToEdit.contact_id;
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

        protected void uploadFile_OnClick(object sender, EventArgs e)
        {
            foreach (var file in fileUpload.PostedFiles)
            {
                var fileName = Page.Server.MapPath("~/Uploads/ProjectDocs/ProjectCosts/" + Path.GetFileName(file.FileName));
                file.SaveAs(fileName);
            }
        }
    }
}