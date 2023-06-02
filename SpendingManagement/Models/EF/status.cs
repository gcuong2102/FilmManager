using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("status")]
    public class status
    {
        public long id { get; set; }
        public string name { get; set; }
        public bool effection { get; set; }
    }
}