using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.NhaCungCaps
{
    public class NhaCungCapInput: Entity<int>
    {
        [Required(ErrorMessage = "Vui lòng nhập tên nhà cung cấp")]
        [Display(Name="Tên nhà cung cấp")]
        public string Ten { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }
}