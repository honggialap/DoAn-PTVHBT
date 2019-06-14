using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.SanPhams
{
    public class SanPham:BaseModel
    {
        public string Ten { get; set; }
        public int LoaiID { get; set; }
        public int ThuongHieuID { get; set; }
        public string HinhAnh { get; set; }
        public string ThongTin { get; set; }
        public int SoLuong { get; set; }
        public int SoView { get; set; }
        public double GiaBan { get; set; }
    }
}