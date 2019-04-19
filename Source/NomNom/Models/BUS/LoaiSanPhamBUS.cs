using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.BUS
{
    public class LoaiSanPhamBUS
    {
        public static IEnumerable<LoaiSanPham> DanhSach()
        {
            var db = new NomNomConnectionDB();
            return db.Query<LoaiSanPham>("Select * from LoaiSanPham where tinhtrang != 0");
        }
        public static IEnumerable<LoaiSanPham> DanhSachAdmin()
        {
            var db = new NomNomConnectionDB();
            return db.Query<LoaiSanPham>("Select * from LoaiSanPham");
        }
        public static LoaiSanPham ChiTiet(string id)
        {
            var db = new NomNomConnectionDB();
            return db.SingleOrDefault<LoaiSanPham>("Select * from LoaiSanPham where id = @0", id);
        }
        public static void Them(LoaiSanPham lsp)
        {
            var db = new NomNomConnectionDB();
            db.Insert(lsp);
        }
        public static void CapNhat(LoaiSanPham lsp)
        {
            var db = new NomNomConnectionDB();
            db.Update(lsp);
        }
            
    }
}