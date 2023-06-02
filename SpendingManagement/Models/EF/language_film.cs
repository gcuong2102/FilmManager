using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("language_film")]
    public class language_film
    {
        public long id { get; set; }
        public long languageid { get; set; }
        public long filmid { get; set; }
    }
}