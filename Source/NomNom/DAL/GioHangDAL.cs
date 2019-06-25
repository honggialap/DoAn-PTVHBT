using AutoMapper;
using NomNom.Models;
using NomNom.Models.ThuongHieus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NomNom.Common;
using PagedList.Mvc;
using PagedList;
using NomNom.Models.GioHangs;

namespace NomNom.DAL
{
    public class GioHangDAL
    {
        private NomNomDbContext db = null;
        public GioHangDAL()
        {
            db = new NomNomDbContext();
        }
        public int SoLuong(int TaiKhoanID)
        {
            return db.GioHangs.Count(x => x.TaiKhoanID == TaiKhoanID);
        }
        public List<GioHangDTO> GetGioHang(int TaiKhoanID)
        {
            var rs = db.GioHangs.Where(x => x.TaiKhoanID == TaiKhoanID);
            var list = new List<GioHangDTO>();
            foreach (var gh in rs){
                var obj = Mapper.Map<GioHangDTO>(gh);
                list.Add(obj);
            }
            foreach(var item in list)
            {
                var sp = db.SanPhams.Find(item.SanPhamID);
                if (sp != null)
                {
                    item.SanPhamTen = sp.Ten;
                    item.SanPhamHinhAnh = sp.HinhAnh;
                    item.SanPhamGiaBan = sp.GiaBan;
                }
            }
            return list;
        }
        public int Add(GioHang input)
        {
            input.Id = 0;
            if (db.GioHangs.Where(x => x.SanPhamID == input.SanPhamID && x.TaiKhoanID == input.TaiKhoanID).Count() > 0)
                return CommonConstants.GIO_HANG_SAN_PHAM_DA_CO;
            db.GioHangs.Add(input);
            try
            {
                db.SaveChanges();
                return CommonConstants.GIO_HANG_THEM_THANH_CONG;
            }
            catch
            {
                return CommonConstants.GIO_HANG_THEM_THAT_BAI;
            }
        }
        public int Add(List<GioHang> input)
        {
            foreach(var giohang in input)
            {
                giohang.Id = 0;
                db.GioHangs.Add(giohang);
            }
            try
            {
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Remove(int TaiKhoanID,int SanPhamID)
        {
            var rs = db.GioHangs.Where(x => x.TaiKhoanID == TaiKhoanID&&x.SanPhamID==SanPhamID);
            if (rs.Count() > 0)
            {
                var gh = rs.First();
                db.GioHangs.Remove(gh);
                try
                {
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            return 1;
        }

        public int UpdateSoLuong(GioHang input)
        {
            var rs = db.GioHangs.Where(x => x.TaiKhoanID == input.TaiKhoanID && x.SanPhamID == input.SanPhamID);
            if (rs.Count() > 0)
            {
                var gh = rs.First();
                gh.SoLuong = input.SoLuong;
                try
                {
                    db.SaveChanges();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}