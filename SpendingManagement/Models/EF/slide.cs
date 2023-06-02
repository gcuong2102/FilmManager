using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("slide")]
    public class slide
    {
        public long id { get; set; }
        public string filmname {get;set;}
        public string detail { get; set; }
        public bool status { get; set; }
        public DateTime release_date { get; set; }
        public string url_img { get; set; }
        public DateTime date_from { get; set; }
        public DateTime date_to { get; set; }
        public string linkfilm { get; set; }
        public int order { get; set; }
    }
}