using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("image")]
    public class image
    {
        public long id { get; set; }
        public string url { get; set; }
        public DateTime last_update { get; set; }
        public string name { get; set; }
    }
}