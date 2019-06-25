using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.GioHangs
{
    [Table("GioHangs")]
    public class GioHang : BaseModel
    {
        public int TaiKhoanID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
    }
}