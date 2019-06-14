using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.SanPhams
{
    public class SanPhamFilter
    {
        public string Ten { get; set; }
        public int LoaiID { get; set; }
        public int ThuongHieuID { get; set; }
        public double GiaBanMin { get; set; }
        public double GiaBanMax { get; set; }
    }
}