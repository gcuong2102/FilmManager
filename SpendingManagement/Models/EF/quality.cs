using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("quality")]
    public class quality
    {
        public long id { get; set; }
        public string name { get; set; }
    }
}