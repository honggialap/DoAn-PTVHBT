using AutoMapper;
using NomNom.Models;
using NomNom.Models.TaiKhoans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NomNom.Common;

namespace NomNom.DAL
{
    public class TaiKhoanDAL
    {
        private NomNomDbContext db = null;
        public TaiKhoanDAL()
        {
            db = new NomNomDbContext();
        }
        public bool Ban(int Id,bool isBan)
        {
            var result = db.TaiKhoans.Find(Id);
            if (result != null&&result.ChucVuID!=CommonConstants.CHUC_VU_ADMIN)
            {
                result.IsBan = isBan;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public List<TaiKhoanDTO> GetTaiKhoan(TaiKhoanFilter filter)
        {
            var result = db.TaiKhoans.Where(x => !x.IsDeleted);

            if (filter != null)
            {
                if (filter.TenTaiKhoan != null)
                    result.Where(x => x.TenTaiKhoan.Contains(filter.TenTaiKhoan));
                if (filter.ChucVuID != 0)
                    result.Where(x => x.ChucVuID == filter.ChucVuID);
            }

            var list = new List<TaiKhoanDTO>();
            foreach(var item in result)
            {
                var obj = Mapper.Map<TaiKhoanDTO>(item);
                list.Add(obj);
            }
            foreach(var obj in list)
            {
                var cv = db.ChucVus.Find(obj.ChucVuID);
                if (cv != null)
                    obj.ChucVuTen = cv.Ten;
                else
                    obj.ChucVuTen = "";
            }
            return list;
        }
        public TaiKhoanDTO GetForView(int Id)
        {
            var result = db.TaiKhoans.Find(Id);
            if (result != null)
            {
                var obj = Mapper.Map<TaiKhoanDTO>(result);
                var cv = db.ChucVus.Find(obj.ChucVuID);
                if (cv != null)
                    obj.ChucVuTen = cv.Ten;
                else
                    obj.ChucVuTen = "";
                return obj;
            }
            return null;
        }
        public TaiKhoanInput GetForEdit(int Id)
        {
            var result = db.TaiKhoans.Find(Id);
            if (result != null)
            {
                var obj = Mapper.Map<TaiKhoanInput>(result);
                return obj;
            }
            return null;
        }

        public int Login(string tentaikhoan, string matkhau)
        {
            matkhau = Encryptor.MD5Hash(matkhau);
            var rs = db.TaiKhoans.Where(x => !x.IsDeleted);
            rs = rs.Where(x => x.TenTaiKhoan == tentaikhoan);
            if (rs.Count() == 0)
                return CommonConstants.DANG_NHAP_TAI_KHOAN_KHONG_TON_TAI;
            rs = rs.Where(x => x.MatKhau == matkhau);
            if (rs.Count() == 0)
                return CommonConstants.DANG_NHAP_MAT_KHAU_KHONG_DUNG;
            rs = rs.Where(x => !x.IsBan);
            if (rs.Count()==0)
                return CommonConstants.DANG_NHAP_TAI_KHOAN_BI_KHOA;

            return CommonConstants.DANG_NHAP_THANH_CONG;
        }
        public int GetId(string tentaikhoan)
        {
            var entity = db.TaiKhoans.SingleOrDefault(x => x.TenTaiKhoan == tentaikhoan);
            if (entity != null)
                return entity.Id;
            else
                return 0;
        }
        public int CreateKH(TaiKhoanInput input)
        {
            if (db.TaiKhoans.Where(x => x.Email == input.Email).Count() > 0)
                return CommonConstants.DANG_KY_TAI_KHOAN_EMAIL_DA_TON_TAI;
            if (db.TaiKhoans.Where(x => x.TenTaiKhoan == input.TenTaiKhoan).Count()>0)
                return CommonConstants.DANG_KY_TAI_KHOAN_TEN_TAI_KHOAN_DA_TON_TAI;
            if (input.MatKhau.Length < 8)
                return CommonConstants.DANG_KY_TAI_KHOAN_MAT_KHAU_DUOI_8;
            var entity = Mapper.Map<TaiKhoan>(input);
            entity.ChucVuID = CommonConstants.CHUC_VU_KHACH_HANG;
            entity.MatKhau = Encryptor.MD5Hash(entity.MatKhau);
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return CommonConstants.DANG_KY_TAI_KHOAN_THANH_CONG;
        }
        public int UpdateThongTin(TaiKhoanInput input)
        {
            var entity = db.TaiKhoans.SingleOrDefault(x => x.Id == input.Id);
            if (entity != null)
            {
                //entity = Mapper.Map<SanPham>(input);
                
                entity.Email = input.Email;
                entity.DiaChi = input.DiaChi;
                entity.Ho = input.Ho;
                entity.Ten = input.Ten;
                if (input.Avatar!=null&&input.Avatar!="")
                    entity.Avatar = input.Avatar;
                entity.NgaySinh = input.NgaySinh;
                entity.SDT = input.SDT;
                db.SaveChanges();
                return 1;
            }
            return 0;
        }
        public int DoiMatKhau(int Id,string MatKhauCu, string MatKhauMoi)
        {
            var entity = db.TaiKhoans.SingleOrDefault(x => x.Id == Id);
            if (entity != null)
            {
                if (MatKhauMoi.Length < 8)
                    return CommonConstants.DOI_MAT_KHAU_MAT_KHAU_MOI_DUOI_8;
                MatKhauCu = Encryptor.MD5Hash(MatKhauCu);
                if (MatKhauCu == entity.MatKhau)
                {
                    MatKhauMoi = Encryptor.MD5Hash(MatKhauMoi);
                    entity.MatKhau = MatKhauMoi;
                    db.SaveChanges();
                    return CommonConstants.DOI_MAT_KHAU_THANH_CONG;
                }
                else
                    return CommonConstants.DOI_MAT_KHAU_MAT_KHAU_CU_KHONG_DUNG;
            }
            return CommonConstants.DOI_MAT_KHAU_THAT_BAI;
        }
    }
}