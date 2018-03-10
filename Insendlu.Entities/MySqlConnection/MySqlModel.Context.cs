﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insendlu.Entities.MySqlConnection
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class insedluEntities : DbContext
    {
        public insedluEntities()
            : base("name=insedluEntities")
        {
        }
    
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    throw new UnintentionalCodeFirstException();
        //}
    
        public virtual DbSet<accounting> accountings { get; set; }
        public virtual DbSet<activity> activities { get; set; }
        public virtual DbSet<asset> assets { get; set; }
        public virtual DbSet<beestatu> beestatus { get; set; }
        public virtual DbSet<businessplan> businessplans { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<companyservice> companyservices { get; set; }
        public virtual DbSet<consultancy> consultancies { get; set; }
        public virtual DbSet<department> departments { get; set; }
        public virtual DbSet<developmentplan> developmentplans { get; set; }
        public virtual DbSet<documenttype> documenttypes { get; set; }
        public virtual DbSet<durationtype> durationtypes { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<executivesummary> executivesummaries { get; set; }
        public virtual DbSet<fieldworkstatistic> fieldworkstatistics { get; set; }
        public virtual DbSet<fieldworktype> fieldworktypes { get; set; }
        public virtual DbSet<logging> loggings { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<mystory> mystories { get; set; }
        public virtual DbSet<notification> notifications { get; set; }
        public virtual DbSet<printmaterial> printmaterials { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<projectcategory> projectcategories { get; set; }
        public virtual DbSet<projectcostplan> projectcostplans { get; set; }
        public virtual DbSet<projectcoverpage> projectcoverpages { get; set; }
        public virtual DbSet<projectdocument> projectdocuments { get; set; }
        public virtual DbSet<projectimplementationtime> projectimplementationtimes { get; set; }
        public virtual DbSet<projectjvcompany> projectjvcompanies { get; set; }
        public virtual DbSet<projectmethodology> projectmethodologies { get; set; }
        public virtual DbSet<projectparameter> projectparameters { get; set; }
        public virtual DbSet<projectpolicy> projectpolicies { get; set; }
        public virtual DbSet<projectprojection> projectprojections { get; set; }
        public virtual DbSet<projectproposal> projectproposals { get; set; }
        public virtual DbSet<projectreference> projectreferences { get; set; }
        public virtual DbSet<projectscopeofwork> projectscopeofworks { get; set; }
        public virtual DbSet<projectstatu> projectstatus { get; set; }
        public virtual DbSet<projectteam> projectteams { get; set; }
        public virtual DbSet<proposaluser> proposalusers { get; set; }
        public virtual DbSet<refreshment> refreshments { get; set; }
        public virtual DbSet<research> researches { get; set; }
        public virtual DbSet<riskanalysi> riskanalysis { get; set; }
        public virtual DbSet<smallproject> smallprojects { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<telephone> telephones { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<user_project> user_project { get; set; }
        public virtual DbSet<usertype> usertypes { get; set; }
        public virtual DbSet<variable> variables { get; set; }
        public virtual DbSet<vehicle> vehicles { get; set; }
        public virtual DbSet<whychoosebiz> whychoosebizs { get; set; }
        public virtual DbSet<wifi> wifis { get; set; }
        public virtual DbSet<worklog> worklogs { get; set; }
        public virtual DbSet<upload> uploads { get; set; }
        public virtual DbSet<accommodation> accommodations { get; set; }
        public virtual DbSet<userprofile> userprofiles { get; set; }
        public virtual DbSet<proposaltype> proposaltypes { get; set; }
        public virtual DbSet<client> clients { get; set; }
    
        public virtual ObjectResult<get_assets_total_Result> get_assets_total(Nullable<int> projId)
        {
            var projIdParameter = projId.HasValue ?
                new ObjectParameter("projId", projId) :
                new ObjectParameter("projId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_assets_total_Result>("get_assets_total", projIdParameter);
        }
    }
}
