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
    
    public partial class logging
    {
        public int id { get; set; }
        public Nullable<int> duration { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public Nullable<System.DateTime> modified_at { get; set; }
        public Nullable<int> project_id { get; set; }
        public Nullable<int> duration_type_id { get; set; }
        public Nullable<int> logger { get; set; }
    }
}