using AutoMapper;
using NomNom.Models;
using NomNom.Models.ThongTinWebsites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.DAL
{
    public class ThongTinWebsiteDAL
    {
        private NomNomDbContext db = null;
        public ThongTinWebsiteDAL()
        {
            db = new NomNomDbContext();
        }
        public ThongTinWebsiteInput Get()
        {
            var entity = db.ThongTinWebsites.First();
            if (entity != null)
            {
                var rs = Mapper.Map<ThongTinWebsiteInput>(entity);
                return rs;
            }
            return null;
        }
        public bool Update(ThongTinWebsiteInput input)
        {
            var entity = db.ThongTinWebsites.First();
            if (entity == null)
            {
                entity = Mapper.Map<ThongTinWebsite>(input);
                db.ThongTinWebsites.Add(entity);
            }
            else
            {
                entity.Logo = input.Logo;
                entity.DiaChi = input.DiaChi;
                entity.Email = input.Email;
                entity.Facebook = input.Facebook;
                entity.Twitter = input.Twitter;
                entity.SoDienThoai = input.SoDienThoai;
                entity.ThongTin = input.ThongTin;
            }
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}