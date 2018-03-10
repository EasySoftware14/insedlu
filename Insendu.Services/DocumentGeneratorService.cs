using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Insendlu.Entities.Connection;
using SautinSoft.Document;
using SautinSoft.Document.Tables;
using Paragraph = SautinSoft.Document.Paragraph;
using Section = SautinSoft.Document.Section;

namespace Insendu.Services
{
    public class DocumentGeneratorService
    {
        private readonly ProjectService _projectService;
        private readonly InsendluEntities _insendluEntities;
        public DocumentGeneratorService()
        {
            _projectService = new ProjectService();
            _insendluEntities = new InsendluEntities();
        }
        public void GenerateWordDocument(string path, Project project, string imagePath, string docTempPath)
        {

            var id = project.id;

            var execSumarry = _projectService.GetExecSummary(id);
            var company = _insendluEntities.Companies.Single();
            var dpwProperty = _projectService.RiskAnalysis(id);
            var methodology = _projectService.GetProjMethodolgy(id);
            var cosPlan = _projectService.GetCostPlan(id);
            var coverPage = _projectService.GetProjectCoverPage(id);
            var jvCompany = _projectService.GetProjectJvCompany(id);
            var policyOverview = _projectService.GetProjectPolicy(id);
            var scope = _projectService.GetProjectScopeOfWork(id);
            var implementation = _projectService.GetProjectImplementationTime(id);
            var team = _projectService.GetProjectTeam(id);
            var refernces = _projectService.GetProjectReference(id);
            var beeStatus = _projectService.GetProjectBeeStatus(id);
            var whyChoose = _projectService.GetProjectWhyChooseBizStandard();
            var confidencialityState = _insendluEntities.ConfidentialityStatements.Single();
            var coverPageStandard = _projectService.GetCoverpageStandard();
            var confidence = confidencialityState.statement;

            var executive = execSumarry != null ? execSumarry.content : String.Empty;
            var companyMssionStatement = company != null ? company.mission_statement : String.Empty;
            var companyBackGround = company != null ? company.background : String.Empty;
            var companyService = company != null ? company.service_offering : String.Empty;
            var headOffice = company != null ? company.headoffice : String.Empty;

            var dpw = dpwProperty != null ? dpwProperty.risk_analysis : String.Empty;
            var methodologyContent = methodology != null ? methodology.content : String.Empty;
            var planCost = cosPlan != null ? cosPlan.deliverable : String.Empty;
            //Coverpage objects *************************************************************
            var preparedFor = coverPage != null ? coverPage.prepared_for : String.Empty;
            var reasonprop = coverPage != null ? coverPage.reason_for_proposal : String.Empty;
            var preparedBy = string.Empty;
            var address = string.Empty;

            preparedFor = preparedFor ?? String.Empty;

            if (coverPageStandard != null)
            {
                preparedBy = coverPageStandard.prepared_by;
                address = coverPageStandard.address;
            }
            //*******************************************************************************
            var jvCompanyContent = jvCompany != null ? jvCompany.content : String.Empty;
            var overview = policyOverview != null ? policyOverview.content : String.Empty;
            var aim = scope != null ? scope.aim : String.Empty;
            var purpose = scope != null ? scope.purpose : String.Empty;
            var deliverables = scope != null ? scope.deliverables : String.Empty;
            var implement = implementation != null ? implementation.content : String.Empty;
            var teamCheck = team != null ? team.content : String.Empty;
            //var refree = refernces != null ? refernces.content : String.Empty;
            var bee = beeStatus != null ? beeStatus.content : String.Empty;
            var why = whyChoose != null ? whyChoose.heading : String.Empty;
            var whyBullets = whyChoose != null ? whyChoose.bullet : String.Empty;

            var compServiceList = companyService.Split(',');
            var officeHead = headOffice.Split(',');
            var addressList = address.Split(',');

            var cvsList = new List<CV>();
            var refList = new List<Reference>();

            if (refernces != null)
            {
                var cvTemp = refernces.cvs.Split(',');
                var refTemp = refernces.references.Split(',');

                for (var i = 0; i < cvTemp.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(cvTemp[i]))
                        cvsList.Add(GetCv(Convert.ToInt32(cvTemp[i])));
                }
                for (var i = 0; i < refTemp.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(refTemp[i]))
                        refList.Add(GetReference(Convert.ToInt32(refTemp[i])));
                }
            }
            var templatePath = docTempPath;
            var documentName = project.name;
            var tablePath = path + documentName + "_table.docx";
            var docxPath = documentName + ".docx";
            var resultsPath = Path.GetDirectoryName(templatePath) + @"\" + documentName.ToUpper() + @"\" + docxPath;

            // Let's create a simple DOCX document.
            var docx = new DocumentCore();
            var dc = DocumentCore.Load(templatePath);

#region Project Reference 
            var section2 = new Section(docx);
            section2.PageSetup.PaperType = PaperType.A4;
            section2.PageSetup.Orientation = Orientation.Portrait;
            section2.PageSetup.PageWidth = LengthUnitConverter.Convert(8.5, LengthUnit.Inch, LengthUnit.Point);
            section2.PageSetup.PageHeight = LengthUnitConverter.Convert(11.0, LengthUnit.Inch, LengthUnit.Point);

            section2.PageSetup.PageMargins = new PageMargins()
            {
                Top = LengthUnitConverter.Convert(10, LengthUnit.Millimeter, LengthUnit.Point),
                Right = LengthUnitConverter.Convert(20, LengthUnit.Millimeter, LengthUnit.Point),
                Bottom = LengthUnitConverter.Convert(10, LengthUnit.Millimeter, LengthUnit.Point),
                Left = LengthUnitConverter.Convert(20, LengthUnit.Millimeter, LengthUnit.Point)
            };

            docx.Sections.Add(section2);
           
            section2.Blocks.Add(new Paragraph(docx, "RELEVANT PROJECT REFERENCES"));
            var heading = new Table(docx);
            var twid2 = LengthUnitConverter.Convert(200, LengthUnit.Millimeter, LengthUnit.Point);
            heading.TableFormat.PreferredWidth = new TableWidth(twid2, TableWidthUnit.Point);
            heading.TableFormat.Alignment = HorizontalAlignment.Center;

            string [] colectin=  new string[]{" Client"," Project Details"," Date Started"," Project Value"," Contacts"};
            var countz = 0;
            for (int i = 0; i < 1; i++)
            {
                TableRow row = new TableRow(docx);

                for (int j = 0; j < colectin.Length; j++)
                {
                    TableCell cell = new TableCell(docx);

                   
                    cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.Outside, BorderStyle.Single, Color.Cyan, 1.0);
                    
                    cell.CellFormat.BackgroundColor = new Color(0xCCCCCC);

                    row.Cells.Add(cell);

                    
                    Paragraph p = new Paragraph(docx);
                    p.ParagraphFormat.Alignment = HorizontalAlignment.Center;
                    p.ParagraphFormat.SpaceBefore = LengthUnitConverter.Convert(3, LengthUnit.Millimeter, LengthUnit.Point);
                    p.ParagraphFormat.SpaceAfter = LengthUnitConverter.Convert(3, LengthUnit.Millimeter, LengthUnit.Point);

                    p.Content.End.Insert(colectin[j], new CharacterFormat() { FontName = "Cambria", FontColor = Color.Black, Size = 11.0, Bold = true});
                    cell.Blocks.Add(p);
                    countz++;
                }
                heading.Rows.Add(row);
                
            }
            section2.Blocks.Add(heading);
            var t2 = new Table(docx);

            var twid = LengthUnitConverter.Convert(200, LengthUnit.Millimeter, LengthUnit.Point);
            t2.TableFormat.PreferredWidth = new TableWidth(twid, TableWidthUnit.Point);
            t2.TableFormat.Alignment = HorizontalAlignment.Center;

            var counter2 = 0;

            for (int r = 0; r < refList.Count; r++)
            {
                TableRow row = new TableRow(docx);

                for (int c = 0; c < 5; c++)
                {
                    TableCell cell = new TableCell(docx);
                    cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.Outside, BorderStyle.Single, Color.Cyan, 1.0);

                    if (counter2 % 2 == 1)
                        cell.CellFormat.BackgroundColor = new Color(0xCCCCCC);

                    row.Cells.Add(cell);
                   
                    Paragraph p = new Paragraph(docx);
                    p.ParagraphFormat.Alignment = HorizontalAlignment.Justify;
                    p.ParagraphFormat.SpaceBefore = LengthUnitConverter.Convert(5, LengthUnit.Millimeter, LengthUnit.Point);
                    p.ParagraphFormat.SpaceAfter = LengthUnitConverter.Convert(5, LengthUnit.Millimeter, LengthUnit.Point);
                    
                    if (c == 0)
                    {
                        p.Content.Start.Insert(refList[r].client_name, new CharacterFormat
                        {
                            FontName = "Cambria",
                            FontColor = Color.Black,
                            Size = 11.0,
                            Bold = true

                        });

                    }
                    else if (c == 1)
                    {
                        p.Content.Start.Insert(refList[r].project_details, new CharacterFormat
                        {
                            FontName = "Cambria",
                            FontColor = Color.Black,
                            Size = 11.0

                        });
                    }
                    else if (c == 2)
                    {
                        p.Content.Start.Insert(refList[r].date_undertaken, new CharacterFormat
                        {
                            FontName = "Cambria",
                            FontColor = Color.Black,
                            Size = 11.0

                        });
                    }
                    else if (c == 3)
                    {
                        p.Content.Start.Insert(refList[r].project_value, new CharacterFormat
                        {
                            FontName = "Cambria",
                            FontColor = Color.Black,
                            Size = 11.0

                        });
                    }
                    else
                    {
                        var contactL = refList[r].contact_id;
                        var contactList = new string[] {};

                        if(contactL != null)
                            contactList = refList[r].contact_id.Split(',');
                        
                        foreach (var contact in contactList)
                        {
                            p.Content.End.Insert("- " + RemoveSpecialCharacters(contact) , new CharacterFormat
                            {
                                FontName = "Cambria",
                                FontColor = Color.Black,
                                Size = 11.0

                            });
                        }
                    }

                    cell.Blocks.Add(p);

                    counter2++;
                }
                t2.Rows.Add(row);
            }
            section2.Blocks.Add(t2);
#endregion
#region CV
            var section4 = new Section(docx);
            section4.PageSetup.PaperType = PaperType.A4;
            section4.PageSetup.Orientation = Orientation.Portrait;
            section4.PageSetup.PageWidth = LengthUnitConverter.Convert(8.5, LengthUnit.Inch, LengthUnit.Point);
            section4.PageSetup.PageHeight = LengthUnitConverter.Convert(11.0, LengthUnit.Inch, LengthUnit.Point);

            section4.PageSetup.PageMargins = new PageMargins
            {
                Top = LengthUnitConverter.Convert(10, LengthUnit.Millimeter, LengthUnit.Point),
                Right = LengthUnitConverter.Convert(20, LengthUnit.Millimeter, LengthUnit.Point),
                Bottom = LengthUnitConverter.Convert(10, LengthUnit.Millimeter, LengthUnit.Point),
                Left = LengthUnitConverter.Convert(20, LengthUnit.Millimeter, LengthUnit.Point)
            };

            docx.Sections.Add(section4);
            section4.Blocks.Add(new Paragraph(docx, "PROJECT TEAM AND RESEARCH TEAM MEMBERS"));

            var researchMemberHead = new Table(docx);
            var res = LengthUnitConverter.Convert(200, LengthUnit.Millimeter, LengthUnit.Point);
            researchMemberHead.TableFormat.PreferredWidth = new TableWidth(res, TableWidthUnit.Point);
            researchMemberHead.TableFormat.Alignment = HorizontalAlignment.Center;

            string [] researchCollection = new string[]{"NAME AND CREDENTIALS","POSITION","RESPONSIBILITIES"};
            countz = 0;
            for (int i = 0; i < 1; i++)
            {
                TableRow row = new TableRow(docx);

                for (int j = 0; j < researchCollection.Length; j++)
                {
                    TableCell cell = new TableCell(docx);

                  
                    cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.Outside, BorderStyle.Single, Color.Black, 1.0);
                   
                    row.Cells.Add(cell);

                   
                    Paragraph p = new Paragraph(docx);
                    p.ParagraphFormat.Alignment = HorizontalAlignment.Center;
                    p.ParagraphFormat.SpaceBefore = LengthUnitConverter.Convert(5, LengthUnit.Millimeter, LengthUnit.Point);
                    p.ParagraphFormat.SpaceAfter = LengthUnitConverter.Convert(5, LengthUnit.Millimeter, LengthUnit.Point);

                    p.Content.End.Insert(researchCollection[j], new CharacterFormat() { FontName = "Cambria", FontColor = Color.Black, Size = 11.0, Bold = true});
                    cell.Blocks.Add(p);
                    countz++;
                }
                researchMemberHead.Rows.Add(row);

            }
            section4.Blocks.Add(researchMemberHead);

            var tTable = new Table(docx);

            var tw = LengthUnitConverter.Convert(200, LengthUnit.Millimeter, LengthUnit.Point);
            tTable.TableFormat.PreferredWidth = new TableWidth(tw, TableWidthUnit.Point);
            tTable.TableFormat.Alignment = HorizontalAlignment.Center;
          
            countz = 0;

            for (int r = 0; r < cvsList.Count; r++)
            {
                TableRow row = new TableRow(docx);
       
                for (int c = 0; c < 3; c++)
                {
                    TableCell cell = new TableCell(docx);
                 
                    cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.Outside, BorderStyle.Single, Color.Black, 1.0);
                    
                    row.Cells.Add(cell);


                    Paragraph p = new Paragraph(docx);
                    p.ParagraphFormat.Alignment = HorizontalAlignment.Justify;
                    p.ParagraphFormat.SpaceBefore = LengthUnitConverter.Convert(5, LengthUnit.Millimeter, LengthUnit.Point);
                    p.ParagraphFormat.SpaceAfter = LengthUnitConverter.Convert(5, LengthUnit.Millimeter, LengthUnit.Point);

                    if (c == 0)
                    {
                        
                        p.Content.Start.Insert(cvsList[r].credentials, new CharacterFormat
                        {
                            FontName = "Cambria",
                            FontColor = Color.Black,
                            Size = 11.0,
                            Bold = false

                        });

                        p.Content.Start.Insert(cvsList[r].name + cvsList[r].surname + " ( " + cvsList[r].qualification + " )", new CharacterFormat
                        {
                            FontName = "Cambria",
                            FontColor = Color.Black,
                            Size = 11.0,
                            Bold = true

                        });

                    }
                    else if (c == 1)
                    {
                        p.Content.Start.Insert(cvsList[r].position, new CharacterFormat
                        {
                            FontName = "Cambria",
                            FontColor = Color.Black,
                            Size = 11.0

                        });
                    }
                    else
                    {
                        var responsibity = cvsList[r].responsibilities.Split('#');

                        foreach (var response in responsibity)
                        {
                            p.Content.End.Insert("- " + response, new CharacterFormat
                            {
                                FontName = "Cambria",
                                FontColor = Color.Black,
                                Size = 11.0

                            });

                        }
                        
                    }
                    cell.Blocks.Add(p);

                    countz++;
                }
                tTable.Rows.Add(row);
            }
            section4.Blocks.Add(tTable);
#endregion
#region DataSource

            var datasource = new []
            {
                new {
                        CONFIDENTIALITY = RemoveSpecialCharacters(confidence),
                        EXECUTIVESUMMARY = executive,
                        COMPANYBACKGROUND = companyBackGround,
                        PURPOSE = purpose,
                        DELIVERABLES = deliverables,
                        WHYCHOOSE = RemoveSpecialCharacters(why),
                        WHYCHOOSEBULLET = RemoveSpecialCharacters(whyBullets),
                        BBBEE = bee
                    }
                
            };
#endregion

            // Cover page Section
            //*************************************************

            // 4. Why Choose Insedlu Business Companion

            // 5. Black Economic Empowerment
            // 6. Project Risk Analysis
            // 7. Isedlu Resourse Capabilities
            // 8. Conclusion

            dc.MailMerge.Execute(datasource);
            
            // Save DOCX to a file            
            dc.Save(resultsPath);
            docx.Save(tablePath);
            
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
        private CV GetCv(int id)
        {
            var cv = _insendluEntities.CVS.Single(x => x.id == id);

            return cv;
        }
        private Reference GetReference(int id)
        {
            var reference = _insendluEntities.References.Single(x => x.id == id);

            return reference;
        }
    }
}