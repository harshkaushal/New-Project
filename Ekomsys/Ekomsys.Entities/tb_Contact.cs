//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ekomsys.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Contact
    {
        public int Contact_Id { get; set; }
        public string Name { get; set; }
        public string Email_Address { get; set; }
        public string Website { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<System.DateTime> Modify_Date { get; set; }
        public Nullable<int> Modify_By { get; set; }
        public string Subject { get; set; }
    }
}