using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SpendingManagement.Models.EF
{
    [Table("film")]
    public class film
    {
        public long id { get; set; }
        [DisplayName("Thể loại")]
        [Required(ErrorMessage = "Vui lòng chọn thể loại")]
        public long category_id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên phim")]
        [MaxLength(100,ErrorMessage = "Độ dài tên phim tối đa tối đa 100")]
        [DisplayName("Tên phim")]
        public string filmname { get; set; }
        public string title { get; set; }
        [DisplayName("Mô tả")]
        public string description { get; set; }
        [DisplayName("Ngày ra mắt")]
        [Required(ErrorMessage = "Vui lòng chọn ngày ra mắt")]
        public DateTime release_date { get; set; }
        [DisplayName("Nước sản xuất")]
        public long country_id { get; set; }
        [DisplayName("Ngày sản xuất")]
        [Required(ErrorMessage = "Vui lòng chọn ngày sản xuất")]
        public long time { get; set; }
        [DisplayName("Xếp hạng")]
        public DateTime last_update { get; set; }
        [DisplayName("Ngôn ngữ mặc định")]
        [Required(ErrorMessage = "Vui lòng chọn ngôn ngữ mặc định")]
        public long orginal_language_id { get; set; }
        public long view { get; set; }
        [DisplayName("Chất lượng")]
        public long quality_id { get; set; }
        [DisplayName("Trạng thái")]
        public long status_id { get; set; }
        public string user_id { get; set; }

    }
}