using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("category")]
    public class category
    {
        public long id { get; set; }
        public string name { get; set; }
        public DateTime last_update { get; set; }
        public string meta { get; set; }
        public string link { get; set; }
        public string usercreatedid { get; set; }
        public string userupdatedid { get; set; }
    }
}