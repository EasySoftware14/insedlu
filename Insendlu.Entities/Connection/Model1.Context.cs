﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insendlu.Entities.Connection
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InsendluEntities : DbContext
    {
        public InsendluEntities()
            : base("name=InsendluEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CompanyService> CompanyServices { get; set; }
        public virtual DbSet<ExecutiveSummary> ExecutiveSummaries { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectCategory> ProjectCategories { get; set; }
        public virtual DbSet<ProjectCostPlan> ProjectCostPlans { get; set; }
        public virtual DbSet<ProjectPolicy> ProjectPolicies { get; set; }
        public virtual DbSet<Upload> Uploads { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
        public virtual DbSet<ProjectMethodology> ProjectMethodologies { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<User_Project> User_Project { get; set; }
        public virtual DbSet<Accounting> Accountings { get; set; }
        public virtual DbSet<Consultancy> Consultancies { get; set; }
        public virtual DbSet<ProjectDocument> ProjectDocuments { get; set; }
        public virtual DbSet<Research> Researches { get; set; }
        public virtual DbSet<RiskAnalysi> RiskAnalysis { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<MyStory> MyStories { get; set; }
        public virtual DbSet<ProjectStatu> ProjectStatus { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<WorkLog> WorkLogs { get; set; }
        public virtual DbSet<Asset> Assets { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<PrintMaterial> PrintMaterials { get; set; }
        public virtual DbSet<Refreshment> Refreshments { get; set; }
        public virtual DbSet<Telephone> Telephones { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Wifi> Wifis { get; set; }
        public virtual DbSet<BEEStatu> BEEStatus { get; set; }
        public virtual DbSet<ProjectCoverPage> ProjectCoverPages { get; set; }
        public virtual DbSet<ProjectImplementationTime> ProjectImplementationTimes { get; set; }
        public virtual DbSet<projectJVCompany> projectJVCompanies { get; set; }
        public virtual DbSet<ProjectReference> ProjectReferences { get; set; }
        public virtual DbSet<ProjectScopeOfWork> ProjectScopeOfWorks { get; set; }
        public virtual DbSet<ProjectTeam> ProjectTeams { get; set; }
        public virtual DbSet<WhyChooseBiz> WhyChooseBizs { get; set; }
        public virtual DbSet<BusinessPlan> BusinessPlans { get; set; }
        public virtual DbSet<DevelopmentPlan> DevelopmentPlans { get; set; }
        public virtual DbSet<FieldWorkStatistic> FieldWorkStatistics { get; set; }
        public virtual DbSet<FieldWorkType> FieldWorkTypes { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ProposalUser> ProposalUsers { get; set; }
        public virtual DbSet<Logging> Loggings { get; set; }
        public virtual DbSet<SmallProject> SmallProjects { get; set; }
        public virtual DbSet<ProjectProjection> ProjectProjections { get; set; }
        public virtual DbSet<ProjectProposal> ProjectProposals { get; set; }
        public virtual DbSet<ProjectParameter> ProjectParameters { get; set; }
        public virtual DbSet<Variable> Variables { get; set; }
        public virtual DbSet<DurationType> DurationTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ProposalType> ProposalTypes { get; set; }
        public virtual DbSet<ProjectEnvelop> ProjectEnvelops { get; set; }
        public virtual DbSet<Accommodation> Accommodations { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }
        public virtual DbSet<CV> CVS { get; set; }
        public virtual DbSet<ReferenceContact> ReferenceContacts { get; set; }
        public virtual DbSet<Reference> References { get; set; }
        public virtual DbSet<ProjectCvsAndReference> ProjectCvsAndReferences { get; set; }
        public virtual DbSet<ConfidentialityStatement> ConfidentialityStatements { get; set; }
        public virtual DbSet<CoverpageStandard> CoverpageStandards { get; set; }
        public virtual DbSet<WhyChooseStandard> WhyChooseStandards { get; set; }
        public virtual DbSet<ConclusionStandard> ConclusionStandards { get; set; }
        public virtual DbSet<TaskDocument> TaskDocuments { get; set; }
    
        public virtual ObjectResult<Nullable<int>> GetAssetTotal(Nullable<int> projId, string asset)
        {
            var projIdParameter = projId.HasValue ?
                new ObjectParameter("projId", projId) :
                new ObjectParameter("projId", typeof(int));
    
            var assetParameter = asset != null ?
                new ObjectParameter("asset", asset) :
                new ObjectParameter("asset", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GetAssetTotal", projIdParameter, assetParameter);
        }
    }
}