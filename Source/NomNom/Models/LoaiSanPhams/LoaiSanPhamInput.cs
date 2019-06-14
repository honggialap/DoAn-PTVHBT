using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.LoaiSanPhams
{
    public class LoaiSanPhamInput: Entity<int>
    {
        [Required(ErrorMessage = "Vui lòng nhập loại sản phẩm")]
        [Display(Name="Loại sản phẩm")]
        public string Ten { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }
}