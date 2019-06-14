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
        NomNomDbContext db = null;
        public TaiKhoanDAL()
        {
            db = new NomNomDbContext();
        }
        public int CreateOrEdit(TaiKhoanInput input)
        {
            if (input.Id == 0)
            {
                return Create(input);
            }
            else
                return Update(input);
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
        public int GetId(string tentaikhoan)
        {
            var entity = db.TaiKhoans.SingleOrDefault(x => x.TenTaiKhoan == tentaikhoan);
            if (entity != null)
                return entity.Id;
            else
                return 0;
        }
        //trả vê 0 nếu tên tài khoản đã tôn tại
        //trả về id nếu tạo thành công
        private int Create(TaiKhoanInput input)
        {
            if (GetId(input.TenTaiKhoan) != 0)
                return 0;
            var entity = Mapper.Map<TaiKhoan>(input);
            entity.MatKhau = Encryptor.MD5Hash(entity.MatKhau);
            db.TaiKhoans.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        private int Update(TaiKhoanInput input)
        {
            var entity = db.TaiKhoans.SingleOrDefault(x => x.Id == input.Id);
            if (entity != null)
            {
                entity = Mapper.Map<TaiKhoan>(input);
                entity.MatKhau = Encryptor.MD5Hash(entity.MatKhau);
                db.SaveChanges();
                return entity.Id;
            }
            return 0;
        }
    }
}