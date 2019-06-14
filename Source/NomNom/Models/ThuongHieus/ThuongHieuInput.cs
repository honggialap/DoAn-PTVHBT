using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.ThuongHieus
{
    public class ThuongHieuInput: Entity<int>
    {
        [Display(Name="Tên thương hiệu")]
        public string Ten { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }
}