using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("category_film")]
    public class category_film
    {
        public long id { get; set; }
        public long filmid { get; set; }
        public long categoryid { get; set; }
    }
}