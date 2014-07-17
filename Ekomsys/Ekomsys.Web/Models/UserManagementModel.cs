using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ekomsys.Web.Models
{
    public class UserManagementModel
    {
        public int User_Id { get; set; }
        [Required]
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [Required]
        public string Email_Address { get; set; }
        public string Phone { get; set; }
        public bool Is_Active { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<System.DateTime> Modify_Date { get; set; }
        public Nullable<int> Modify_By { get; set; }
        public string UserType { get; set; }
        public int UserType_Id {get;set;}
        public IList<UserTypeModel> userTypeList { get; set; }

        public List<UserTypeUserMapModel> UserTypeUserMapList { get; set; }

        public IEnumerable<SelectListItem> UserTypeItems { get; set; }
    }

    public class UserTypeModel
    {
        public int UserType_Id { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<System.DateTime> Modify_Date { get; set; }
        public Nullable<int> Modify_By { get; set; }
    }

    public class UserTypeUserMapModel
    {
        public int User_UserType_Mapping_Id { get; set; }
        public Nullable<int> User_Id { get; set; }
        public Nullable<int> UserType_Id { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<System.DateTime> Modify_Date { get; set; }
        public Nullable<int> Modify_By { get; set; }
    }
}