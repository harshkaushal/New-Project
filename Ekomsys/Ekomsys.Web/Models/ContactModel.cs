using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekomsys.Web.Models
{
    public class ContactModel
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
        public OfficeDetailModel OfficeDetail { get; set; }
    }

    public class OfficeDetailModel
    {
        public int Office_Detail_Id { get; set; }
        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public Nullable<int> Country_Id { get; set; }
        public Nullable<int> City_Id { get; set; }
        public string Email_Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}