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
     
        public bool Login(string tentaikhoan, string matkhau)
        {
            matkhau = Encryptor.MD5Hash(matkhau);
            var result = db.TaiKhoans.Count(x => !x.IsDeleted && x.TenTaiKhoan == tentaikhoan && x.MatKhau == matkhau);
            if (result > 0)
            {
                return true;
            }
            {
                return false;
            }
        }
        public bool LoginAdmin(string tentaikhoan, string matkhau)
        {
            matkhau = Encryptor.MD5Hash(matkhau);
            var result = db.TaiKhoans.Count(x => !x.IsDeleted && x.TenTaiKhoan == tentaikhoan && x.MatKhau == matkhau&&x.ChucVuID==CommonConstants.CHUC_VU_ADMIN);
            if (result > 0)
            {
                return true;
            }
            {
                return false;
            }
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
        
    }
}