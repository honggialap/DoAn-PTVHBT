using AutoMapper;
using NomNom.Models;
using NomNom.Models.KhuVucs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.DAL
{
    public class KhuVucDAL
    {
        NomNomDbContext db = null;
        public KhuVucDAL()
        {
            db = new NomNomDbContext();
        }
        public int CreateOrEdit(KhuVucInput input)
        {
            if (input.Id == 0)
            {
                return Create(input);
            }
            else
                return Update(input);
        }
        public KhuVucInput GetForEdit(int Id)
        {
            var entity = db.KhuVucs.Find(Id);
            //Tạm thời ko cho edit thành phố
            if (entity == null || entity.ParentID == 0 || entity.IsDeleted)
                return null;
            else
                return Mapper.Map<KhuVucInput>(entity);
        }
        public KhuVucDTO GetForView(int Id)
        {
            var entity = db.KhuVucs.Find(Id );
            if (entity == null || entity.IsDeleted)
                return null;
            else
                return Mapper.Map<KhuVucDTO>(entity);
        }

        public List<KhuVucDTO> GetQuanHuyen(int Id)
        {          
            var tinhthanh = db.KhuVucs.Find(Id);
            if (tinhthanh != null && tinhthanh.ParentID == 0)
            {
                var result = db.KhuVucs.Where(x => !x.IsDeleted && x.ParentID == Id);
                var list = new List<KhuVucDTO>();
                foreach (var item in result)
                {
                    var obj = Mapper.Map<KhuVucDTO>(item);

                    list.Add(obj);
                }
                return list;
            }
            else return null;

        }
        public List<KhuVucDTO> GetThanhPho()
        {
            var result = db.KhuVucs.Where(x => !x.IsDeleted&&x.ParentID==0);
            var list = new List<KhuVucDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<KhuVucDTO>(item);
               
                list.Add(obj);
            }
            return list;
        }
        private int Create(KhuVucInput input)
        {
            var entity = Mapper.Map<KhuVuc>(input);
            db.KhuVucs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Delete(int Id)
        {
            var entity = db.KhuVucs.Find(Id);
            if (entity == null||entity.ParentID==0)
                return false;
            else
            {
                entity.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
        }

        private int Update(KhuVucInput input)
        {
            var entity = db.KhuVucs.SingleOrDefault(x => x.Id == input.Id);
            if (entity != null&&entity.ParentID!=0)
            {
                // entity = Mapper.Map<KhuVuc>(input);   
                entity.HoatDong = input.HoatDong;
                entity.GhiChu = input.GhiChu;
                entity.PhiShip = input.PhiShip;
                entity.ThoiGianShipMax = input.ThoiGianShipMax;
                entity.ThoiGianShipMin = input.ThoiGianShipMin;
                entity.Ten = input.Ten;
                db.SaveChanges();
                return entity.Id;
            }
            return 0;
        }
    }
}