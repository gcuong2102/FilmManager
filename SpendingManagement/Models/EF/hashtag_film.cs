using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("hashtag_film")]
    public class hashtag_film
    {
        public long id { get; set; }
        public long filmid { get; set; }
        public long hashtagid { get; set; }
    }
}