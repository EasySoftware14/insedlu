//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class User
{
    public long id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public Nullable<long> recovery_question { get; set; }
    public string recovery_answer { get; set; }
    public System.DateTime created_at { get; set; }
    public System.DateTime modified_at { get; set; }
    public string temporary_password { get; set; }
    public Nullable<int> status { get; set; }
    public string contact_number { get; set; }
    public Nullable<long> project_id { get; set; }
    public Nullable<int> user_type_id { get; set; }
}
