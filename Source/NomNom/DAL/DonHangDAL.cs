using AutoMapper;
using NomNom.Common;
using NomNom.Models;
using NomNom.Models.DonHangs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.DAL
{
    public class DonHangDAL
    {
        private NomNomDbContext db = null;

        public DonHangDAL()
        {
            db = new NomNomDbContext();
        }
        public int LapDonHang(DonHangInput input)
        {
            var kv = db.KhuVucs.Find(input.KhuVucID);
            if (kv != null||!kv.HoatDong)
            {
                input.TinhTrangID = CommonConstants.TINH_TRANG_CHO_DUYET;
                input.PhiShip = kv.PhiShip;
                input.Ngay = DateTime.Now;
                input.NgayGiaoDuKienMin = input.Ngay.AddDays(kv.ThoiGianShipMin);
                input.NgayGiaoDuKienMax = input.Ngay.AddDays(kv.ThoiGianShipMax);
                var entity = Mapper.Map<DonHang>(input);
                try
                {
                    db.DonHangs.Add(entity);
                    db.SaveChanges();
                }
                catch
                {
                    return 0;
                }
                var list = db.GioHangs.Where(x => x.TaiKhoanID == entity.KhachHangID).ToList();
                double TongTien = 0;
                foreach(var item in list)
                {
                    var obj = new ChiTietDonHang();
                    obj.DonHangID = entity.Id;
                    obj.SanPhamID = item.SanPhamID;
                    obj.SoLuong = item.SoLuong;
                    var sp = db.SanPhams.Find(item.SanPhamID);
                    obj.GiaOrder = sp.GiaBan;
                    TongTien += obj.GiaOrder * obj.SoLuong;
                    db.ChiTietDonHangs.Add(obj);
                    db.GioHangs.Remove(item);
                }
                entity.ThanhTien = TongTien;
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
        public DonHangInput GetForEdit(int Id)
        {
            var entity = db.DonHangs.Find(Id);
            if (entity == null)
                return null;
            else
            {
                var input = Mapper.Map<DonHangInput>(entity);
                input.ChiTiets = new List<ChiTietDonHangInput>();
                //load danh sách chi tiết
                var listChiTiet = db.ChiTietDonHangs.Where(x => !x.IsDeleted && x.DonHangID == input.Id);
                foreach (var chitiet in listChiTiet)
                {
                    var chitietInput = Mapper.Map<ChiTietDonHangInput>(chitiet);
                    input.ChiTiets.Add(chitietInput);
                }
                return input;
            }

        }
        public DonHangDTO GetForView(int Id)
        {
            var result = db.DonHangs.Find(Id);
            if (result != null&&!result.IsDeleted)
            {
                var obj = Mapper.Map<DonHangDTO>(result);
                obj.KhuVucTen = "";
                var khuvuc = db.KhuVucs.Find(obj.KhuVucID);
                if (khuvuc != null)
                {
                    obj.KhuVucTen += khuvuc.Ten;
                    var tinhthanh = db.KhuVucs.Find(khuvuc.ParentID);
                    if (tinhthanh != null)
                    {
                        obj.KhuVucTen += ", " + tinhthanh.Ten;
                    }
                }
                obj.KhachHangTen = "";
                var khachhang = db.TaiKhoans.Find(obj.KhachHangID);
                if (khachhang != null)
                {
                    obj.KhachHangTen += khachhang.Ten;
                }
                obj.TinhTrangTen = "";
                var tinhtrang = db.TinhTrangDonHangs.Find(obj.TinhTrangID);
                if (tinhtrang != null)
                {
                    obj.TinhTrangTen += tinhtrang.Ten;
                }
                return obj;
            }
            return null;
        }
        public List<ChiTietDonHangDTO> GetChiTietsForView(int Id)
        {
            var result = db.ChiTietDonHangs.Where(x => !x.IsDeleted && x.DonHangID == Id);
            var list = new List<ChiTietDonHangDTO>();
            foreach(var item in result)
            {
                var obj = Mapper.Map<ChiTietDonHangDTO>(item);
                list.Add(obj);
            }
            foreach(var obj in list)
            {
                obj.SanPhamTen = "";
                var sp = db.SanPhams.Find(obj.SanPhamID);
                if (sp != null)
                {
                    obj.SanPhamTen = sp.Ten;
                    obj.SanPhamHinhAnh = sp.HinhAnh;
                }
            }
            return list;
        }
        public List<DonHangDTO> GetDonHang(DonHangFilter filter)
        {
            var result = db.DonHangs.Where(x => !x.IsDeleted);
            if (filter != null)
            {
                if (filter.KhachHangID != 0)
                    result = result.Where(x => x.KhachHangID == filter.KhachHangID);
                if (filter.TinhTrangID != 0)
                    result = result.Where(x => x.TinhTrangID == filter.TinhTrangID);
                if (filter.NgayHoanTat != null)               
                    result = result.Where(x => x.NgayHoanTat!=null&&DateTime.Compare(x.NgayHoanTat.Value.Date, filter.NgayHoanTat.Value.Date)==0);
                if (filter.Ngay != null)
                    result = result.Where(x => DateTime.Compare(x.Ngay.Date, filter.Ngay.Value.Date) == 0);

            }
            var list = new List<DonHangDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<DonHangDTO>(item);              
                list.Add(obj);
            }
            foreach(var obj in list)
            {
                obj.KhuVucTen = "";
                var khuvuc = db.KhuVucs.Find(obj.KhuVucID);
                if (khuvuc != null)
                {
                    obj.KhuVucTen += khuvuc.Ten;
                    var tinhthanh = db.KhuVucs.Find(khuvuc.ParentID);
                    if (tinhthanh != null)
                    {
                        obj.KhuVucTen += ", " + tinhthanh.Ten;
                    }
                }
                obj.KhachHangTen = "";
                var khachhang = db.TaiKhoans.Find(obj.KhachHangID);
                if (khachhang != null)
                {
                    obj.KhachHangTen += khachhang.Ten;
                }
            }
            return list;
        }
        public bool Duyet(int Id)
        {
            var entity = db.DonHangs.Find(Id);
            if (entity!=null&&entity.TinhTrangID == CommonConstants.TINH_TRANG_CHO_DUYET)
            {
                var result = db.ChiTietDonHangs.Where(x => !x.IsDeleted && x.DonHangID == entity.Id);
                var listSP = new List<ChiTietDonHangInput>();              
                foreach(var sp in result)
                {
                    var obj = Mapper.Map<ChiTietDonHangInput>(sp);
                    listSP.Add(obj);
                }
                var isEnough = true;
                foreach(var sp in listSP)
                {
                    var obj = db.SanPhams.Find(sp.SanPhamID);
                    if (obj == null||obj.SoLuong<sp.SoLuong)
                        isEnough = false;                  
                }
                if (isEnough)
                {
                    foreach (var sp in listSP)
                    {
                        var obj = db.SanPhams.Find(sp.SanPhamID);
                        obj.SoLuong -= sp.SoLuong;
                    }
                    entity.TinhTrangID = CommonConstants.TINH_TRANG_DA_DUYET;
                    db.SaveChanges();
                    return true;
                }                        
            }
            return false;
        }
        public bool Giao(int Id)
        {
            var entity = db.DonHangs.Find(Id);
            if (entity != null && entity.TinhTrangID == CommonConstants.TINH_TRANG_DA_DUYET)
            {
                entity.TinhTrangID = CommonConstants.TINH_TRANG_DANG_GIAO;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool HoanTat(int Id)
        {
            var entity = db.DonHangs.Find(Id);
            if (entity != null && entity.TinhTrangID == CommonConstants.TINH_TRANG_DANG_GIAO)
            {
                entity.TinhTrangID = CommonConstants.TINH_TRANG_HOAN_TAT;
                entity.NgayHoanTat = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool Huy(int Id)
        {
            var entity = db.DonHangs.Find(Id);
            if (entity != null && entity.TinhTrangID != CommonConstants.TINH_TRANG_HOAN_TAT) //không cho hủy đơn hàng đã hoàn tất
            {
                if (entity.TinhTrangID == CommonConstants.TINH_TRANG_CHO_DUYET)
                {
                    entity.TinhTrangID = CommonConstants.TINH_TRANG_DA_HUY;
                }
                else
                {
                    var result = db.ChiTietDonHangs.Where(x => !x.IsDeleted && x.DonHangID == entity.Id);
                    var listSP = new List<ChiTietDonHangInput>();
                    foreach (var sp in result)
                    {
                        var obj = Mapper.Map<ChiTietDonHangInput>(sp);
                        listSP.Add(obj);
                    }
                    foreach (var sp in listSP)
                    {
                        var obj = db.SanPhams.Find(sp.SanPhamID);
                        if (obj != null)
                            obj.SoLuong+=sp.SoLuong;
                    }
                    entity.TinhTrangID = CommonConstants.TINH_TRANG_DA_HUY;
                }
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}