using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.SanPhams
{
    public class SanPhamInput:Entity<int>
    {
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string Ten { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public int LoaiID { get; set; }
        [Display(Name = "Thương hiệu")]
        public int ThuongHieuID { get; set; }
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }
        [Display(Name = "Thông tin chi tiết")]
        public string ThongTin { get; set; }
        [Display(Name = "Giá bán")]
        public double GiaBan { get; set; }

        public SanPhamInput()
        {
            this.LoaiID = 1;
            this.ThuongHieuID = 1;
        }
    }
}