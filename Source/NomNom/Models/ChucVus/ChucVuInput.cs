using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.ChucVus
{
    public class ChucVuInput: Entity<int>
    {
        [Required(ErrorMessage = "Vui lòng nhập tên chức vụ")]
        [Display(Name= "Chức vụ")]
        public string Ten { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
    }
}