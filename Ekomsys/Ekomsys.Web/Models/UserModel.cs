using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Ekomsys.Web.Models
{
    public class UserModel
    {

        public int User_Id { get; set; }
        [Required]
        [Display(Name = "User name")]
        public string User_Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email_Address { get; set; }
        public string Phone { get; set; }
        public Nullable<bool> Is_Active { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<System.DateTime> Modify_Date { get; set; }
        public Nullable<int> Modify_By { get; set; }

    }
}