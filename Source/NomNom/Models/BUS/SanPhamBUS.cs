using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.BUS
{
    public class SanPhamBUS
    {
        public static IEnumerable<SanPham> DanhSach()
        {
            var db = new NomNomConnectionDB();
            return db.Query<SanPham>("Select * from SanPham where tinhtrang != 0");
        }
        public static IEnumerable<SanPham> DanhSachbyloaisanpham(string loai_id)
        {
            var db = new NomNomConnectionDB();
            return db.Query<SanPham>("Select * from SanPham where tinhtrang != 0 and loai_id=@0", loai_id);
        }
        public static SanPham ChiTiet(string id)
        {
            var db = new NomNomConnectionDB();
            return db.SingleOrDefault<SanPham>("Select * from SanPham where id = @0", id);
        }
        public static IEnumerable<SanPham> Top10LuotView()
        {
            var db = new NomNomConnectionDB();
            return db.Query<SanPham>("select * from SanPham s where 10 > (Select count(soview) from SanPham where s.soview < soview )");
        }
        public static void Tang1View(string id)
        {
            var db = new NomNomConnectionDB();
            var a = db.SingleOrDefault<SanPham>("SELECT * FROM SanPham WHERE id=@0", id);
            a.soview = a.soview + 1;
            db.Update("SanPham", "id", a);
        }
    }
}