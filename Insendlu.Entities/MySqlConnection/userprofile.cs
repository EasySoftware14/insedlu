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
    
    public partial class userprofile
    {
        public long id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> task_id { get; set; }
        public byte[] profile_pic { get; set; }
        public string job_title { get; set; }
        public Nullable<int> department_id { get; set; }
        public string contact_number { get; set; }
        public string position { get; set; }
        public string biography { get; set; }
        public byte[] cv { get; set; }
        public string past_experience { get; set; }
    }
}