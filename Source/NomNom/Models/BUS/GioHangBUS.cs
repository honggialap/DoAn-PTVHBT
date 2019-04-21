using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Models.BUS
{
    [Authorize]
    public class GioHangBUS
    {
        public static IEnumerable<GioHang> DanhSach(string taikhoan_id)
        {
            var db = new NomNomConnectionDB();
            return db.Query<GioHang>("Select * from GioHang where taikhoan_id=@0",taikhoan_id);
        }        
        public static void Them(string taikhoan_id,string sanpham_id,int soluong)
        {
            var db = new NomNomConnectionDB();
            var x = db.Query<GioHang>("Select * from GioHang where taikhoan_id=@0 and sanpham_id=@1", taikhoan_id, sanpham_id);
            if (x.Count() > 0)
            {
                int a = (int)x.ElementAt(0).soluong + soluong;
                CapNhat(taikhoan_id, sanpham_id, a);
            }
            else
            {
                var temp = new GioHang();
                temp.taikhoan_id = taikhoan_id;
                temp.sanpham_id = sanpham_id;
                temp.soluong = soluong;
                db.Insert(temp);
            }
        }
        public static void CapNhat(string taikhoan_id,string sanpham_id,int soluong)
        {
            var db = new NomNomConnectionDB();
            var temp = new GioHang();
            temp.taikhoan_id = taikhoan_id;
            temp.sanpham_id = sanpham_id;
            temp.soluong = soluong;
            db.Update(temp);
        }
        public static void Xoa(string taikhoan_id, string sanpham_id)
        {
            var db = new NomNomConnectionDB();
            var obj = db.Query<GioHang>("Select * from GioHang where taikhoan_id=@0 and sanpham_id=@1", taikhoan_id, sanpham_id);
            db.Delete(obj);
        }

    }
}