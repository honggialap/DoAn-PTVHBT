using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.BUS
{
    public class NhaCungCapBUS
    {
        public static IEnumerable<NhaCungCap> DanhSach()
        {
            var db = new NomNomConnectionDB();
            return db.Query<NhaCungCap>("Select * from NhaCungCap where tinhtrang != 0");
        }
        public static IEnumerable<NhaCungCap> DanhSachAdmin()
        {
            var db = new NomNomConnectionDB();
            return db.Query<NhaCungCap>("Select * from NhaCungCap");
        }
        public static NhaCungCap ChiTiet(string id)
        {
            var db = new NomNomConnectionDB();
            return db.SingleOrDefault<NhaCungCap>("Select * from NhaCungCap where id = @0", id);
        }
        public static void Them(NhaCungCap ncc)
        {
            var db = new NomNomConnectionDB();
            db.Insert(ncc);
        }
        public static void CapNhat(NhaCungCap ncc)
        {
            var db = new NomNomConnectionDB();
            db.Update(ncc);
        }
            
    }
}