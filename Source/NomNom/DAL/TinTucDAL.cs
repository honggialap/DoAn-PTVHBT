using AutoMapper;
using NomNom.Models;
using NomNom.Models.TinTucs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.DAL
{
    public class TinTucDAL
    {
        private NomNomDbContext db = null;
        public TinTucDAL()
        {
            db = new NomNomDbContext();
        }
        public List<TinTucDTO> GetTinTuc(TinTucFilter filter)
        {
            var result = db.TinTucs.Where(x => !x.IsDeleted);
            if (filter != null)
            {
                if (filter.TieuDe != null)
                {
                    result = result.Where(x => x.TieuDe.Contains(filter.TieuDe));
                }
            }
            var list = new List<TinTucDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<TinTucDTO>(item);
                list.Add(obj);
            }
            return list;
        }
        public List<TinTucDTO> GetTinTuc(TinTucFilter filter,int skip,int take)
        {
            var result = db.TinTucs.Where(x => !x.IsDeleted);
            if (filter != null)
            {
                if (filter.TieuDe != null)
                {
                    result = result.Where(x => x.TieuDe.Contains(filter.TieuDe));
                }
            }
            result = result.Skip(skip).Take(take);
            var list = new List<TinTucDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<TinTucDTO>(item);
                list.Add(obj);
            }
            return list;
        }

        public TinTucInput GetForEdit(int Id)
        {
            var entity = db.TinTucs.Find(Id);
            if (entity == null)
                return null;
            else
                return Mapper.Map<TinTucInput>(entity);
        }
        public int CreateOrEdit(TinTucInput input)
        {
            if (input.Id == 0)
            {
                return Create(input);
            }
            else
                return Update(input);
        }
        private int Create(TinTucInput input)
        {
            var entity = Mapper.Map<TinTuc>(input);
            entity.Ngay = DateTime.Now;
            db.TinTucs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Delete(int Id)
        {
            var entity = db.TinTucs.Find(Id);
            if (entity == null)
                return false;
            else
            {
                entity.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
        }

        private int Update(TinTucInput input)
        {
            var entity = db.TinTucs.SingleOrDefault(x => x.Id == input.Id);
            if (entity != null)
            {
                // entity = Mapper.Map<ThuongHieu>(input);   
                entity.TieuDe = input.TieuDe;
                entity.MieuTa = input.MieuTa;
                entity.HinhAnh = input.HinhAnh;
                entity.NoiDung = input.NoiDung;
                entity.GhiChu = input.GhiChu;
                db.SaveChanges();
                return entity.Id;
            }
            return 0;
        }

    }
}