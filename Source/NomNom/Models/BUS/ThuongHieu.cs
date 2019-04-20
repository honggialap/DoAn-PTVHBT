using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.BUS
{
    public class ThuongHieuBUS
    {
        public static IEnumerable<ThuongHieu> DanhSach()
        {
            var db = new NomNomConnectionDB();
            return db.Query<ThuongHieu>("Select * from ThuongHieu where tinhtrang != 0");
        }
        public static IEnumerable<ThuongHieu> DanhSachAdmin()
        {
            var db = new NomNomConnectionDB();
            return db.Query<ThuongHieu>("Select * from ThuongHieu");
        }
        public static ThuongHieu ChiTiet(string id)
        {
            var db = new NomNomConnectionDB();
            return db.SingleOrDefault<ThuongHieu>("Select * from ThuongHieu where id = @0", id);
        }
        public static void Them(ThuongHieu th)
        {
            var db = new NomNomConnectionDB();
            db.Insert(th);
        }
        public static void CapNhat(ThuongHieu th)
        {
            var db = new NomNomConnectionDB();
            db.Update(th);
        }
            
    }
}