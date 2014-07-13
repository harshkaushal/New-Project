using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ekomsys.Web.Models
{
    public  class NewsModel
    {
        public int News_Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Nullable<System.DateTime> Posted_Date { get; set; }
        public bool Is_Active { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public Nullable<int> Created_By { get; set; }
        public Nullable<System.DateTime> Modify_Date { get; set; }
        public Nullable<int> Modify_By { get; set; }
    }
}