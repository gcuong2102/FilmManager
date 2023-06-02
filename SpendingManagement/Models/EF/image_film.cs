using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("image_film")]
    public class image_film
    {
        public long id { get; set; }
        public long filmid { get; set; }
        public long imageid { get; set; }
        public int order { get; set; }
        public bool main { get; set; }
    }
}