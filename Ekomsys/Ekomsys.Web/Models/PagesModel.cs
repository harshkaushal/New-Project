using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ekomsys.Entities;

namespace Ekomsys.Web.Models
{
    public class PagesModel
    {
        public int Page_Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Html)]
        [AllowHtml]
        public string Page_Content { get; set; }
        public int Parent_Page_Id { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Created_Date { get; set; }
        public int Created_By { get; set; }
        public DateTime Modify_Date { get; set; }
        public int Modify_By { get; set; }
        public List<tb_Page> Pages { get; set; }
    
    }

   
}