using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("country")]
    public class country
    {
        public long id { get; set; }
        public string name { get; set; }
    }
}