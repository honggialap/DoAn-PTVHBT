using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.GioHangs
{
    public class GioHangDTO : Entity<int>
    {
        public int TaiKhoanID { get; set; }
        public int SanPhamID { get; set; }
        public string SanPhamTen { get; set; }
        public string SanPhamHinhAnh { get; set; }
        public double SanPhamGiaBan { get; set; }
        public int SoLuong { get; set; }
    }
}