using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ekomsys.Web.Models
{
    public class PagesModel
    {
        public int Page_Id { get; set; }
        public string Name { get; set; }
        public int Parent_Page_Id { get; set; }
        public string Page_Content { get; set; }
        public string Child_Pages { get; set; }
    }
}