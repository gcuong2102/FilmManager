using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("settingadmin")]
    public class settingadmin
    {
        public long id { get; set; }
        public string userid { get; set; }
        public int defaultPage { get; set; }
    }
}