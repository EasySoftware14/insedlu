//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class project
    {
        public int id { get; set; }
        public Nullable<int> duration { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string name { get; set; }
        public string team { get; set; }
        public string department_name { get; set; }
        public string conclusion { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public Nullable<int> proj_cat_id { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> upload_id { get; set; }
        public Nullable<int> exec_summary_id { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> policy_id { get; set; }
        public Nullable<int> methodology_id { get; set; }
        public Nullable<int> proj_reference { get; set; }
        public Nullable<int> cost_plan_id { get; set; }
        public Nullable<int> risk_id { get; set; }
        public Nullable<int> coverpage_id { get; set; }
        public Nullable<int> jvCompany_id { get; set; }
        public Nullable<int> scope_id { get; set; }
        public Nullable<int> projectTeam_id { get; set; }
        public Nullable<int> implement_id { get; set; }
        public Nullable<int> whyChoose_id { get; set; }
        public Nullable<int> bee_id { get; set; }
        public Nullable<int> duration_type_id { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> end_date { get; set; }
        public string project_type { get; set; }
        public Nullable<int> client_id { get; set; }
    }
}