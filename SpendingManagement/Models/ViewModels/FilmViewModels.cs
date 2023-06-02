using SpendingManagement.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpendingManagement.Models.ViewModels
{
    public class FilmViewModels
    {
        public long film_id { get; set; }
        [DisplayName("Các thể loại")]
        [Required(ErrorMessage = "Vui lòng chọn các thể loại")]
        public IEnumerable<long> category_id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên phim")]
        [MaxLength(100, ErrorMessage = "Độ dài tên phim tối đa tối đa 100")]
        [DisplayName("Tên phim")]
        public string filmname { get; set; }
        [DisplayName("Mô tả")]
        public string description { get; set; }
        [DisplayName("Ngày ra mắt")]
        [Required(ErrorMessage = "Vui lòng chọn ngày ra mắt")]
        public DateTime release_date { get; set; }
        [DisplayName("Ngôn ngữ phụ")]
        [Required(ErrorMessage = "Vui lòng chọn các ngôn ngữ")]
        public IEnumerable<long> language_id { get; set; }
        [DisplayName("Nước sản xuất")]
        [Required(ErrorMessage = "Vui lòng chọn nước sản xuất")]
        public long country_id { get; set; }
        [DisplayName("Thời gian chiếu (phút)")]
        [Required(ErrorMessage = "Vui lòng nhập thời gian phim")]
        [LengthFilm(ErrorMessage = "Vui lòng nhập độ dài phim lớn hơn 1 phút")]
        public long time { get; set; }
        [DisplayName("Ngôn ngữ mặc định")]
        [Required(ErrorMessage = "Vui lòng chọn ngôn ngữ mặc định")]
        public long orginal_language_id { get; set; }
        [DisplayName("Chất lượng")]
        [Required(ErrorMessage = "Vui lòng chọn chất lượng phim")]
        public long quality_id { get; set; }
        [DisplayName("Trạng thái")]
        [Required(ErrorMessage = "Vui lòng chọn trạng thái")]
        public long status_id { get; set; } 
        public List<long> image_id {get;set;}
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh")]
        [DisplayName("Hình ảnh (Hình đầu tiên sẽ mặc định làm hình chính)")]
        public string getIds { get; set; }
        public long view { get; set; }
    }
}