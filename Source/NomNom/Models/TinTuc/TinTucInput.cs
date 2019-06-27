using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Models.TinTucs
{
    public class TinTucInput: Entity<int>
    {
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        [Display(Name="Tiêu đề")]
        public string TieuDe { get; set; } 
        [Display(Name = "Miêu tả")]
        public string MieuTa { get; set; } //miêu tả ngắn gọn về tin tức
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
        [Display(Name = "Nội dung")]
        [AllowHtml]
        public string NoiDung { get; set; } //Nội dung đầy đủ
        [Display(Name = "Ngày tạo")]
        public DateTime Ngay { get; set; } 
        [Display(Name = "Số view")]
        public int SoView { get; set; } 
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }
}