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
    
    public partial class user_project
    {
        public long id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<System.DateTime> start_date { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public Nullable<int> proj_id { get; set; }
    }
}