using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.DonHangs
{
    public class DonHangFilter
    {
        public DonHangFilter()
        {
            KhachHangID = 0;
            TinhTrangID = 0;
            Ngay = null;
            NgayHoanTat = null;
        }
        public int KhachHangID { get; set; }
        public int TinhTrangID { get; set; }
        public DateTime? Ngay { get; set; }
        public DateTime? NgayHoanTat { get; set; }

    }
}