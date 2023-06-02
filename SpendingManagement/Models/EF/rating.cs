using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("rating")]
    public class rating
    {
        public long id { get; set; }
        public string userid { get; set; }
        public long filmid { get; set; }
        public int score { get; set; }
        public string comment { get; set; }
    }
}