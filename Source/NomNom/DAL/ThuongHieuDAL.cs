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

namespace NomNom.DAL
{
    public class ThuongHieuDAL
    {
        NomNomDbContext db = null;
        public ThuongHieuDAL()
        {
            db = new NomNomDbContext();
        }
        public int CreateOrEdit(ThuongHieuInput input)
        {
            if (input.Id == 0)
            {
                return Create(input);
            }
            else
                return Update(input);
        }
        
       
       public List<ThuongHieuDTO> GetThuongHieu(ThuongHieuFilter filter)
        {

            var result = db.ThuongHieus.Where(x => !x.IsDeleted);
            if (filter != null)
            {
                if (filter.Ten != null)
                {
                    result = result.Where(x => x.Ten.Contains(filter.Ten));
                }
            }
            var list = new List<ThuongHieuDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<ThuongHieuDTO>(item);//new LoaiSanPhamDTO();
                //obj.Id = item.Id;
                //obj.Ten = item.Ten;
                //obj.GhiChu = item.GhiChu;
                list.Add(obj);
            }
            return list;
            //return result.Select(x=>Mapper.Map<ThuongHieuDTO>(x)).ToList();
        }
        private int Create(ThuongHieuInput input)
        {
            var entity = Mapper.Map<ThuongHieu>(input);
            db.ThuongHieus.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Delete(int Id)
        {
            var entity = db.ThuongHieus.Find(Id);
            if (entity == null)
                return false;
            else
            {
                entity.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
        }

        private int Update(ThuongHieuInput input)
        {
            var entity = db.ThuongHieus.SingleOrDefault(x => x.Id == input.Id);
            if (entity != null)
            {
                entity = Mapper.Map<ThuongHieu>(input);             
                db.SaveChanges();
                return entity.Id;
            }
            return 0;
        }

        public ThuongHieuInput GetForEdit(int Id)
        {
            var entity = db.ThuongHieus.Find(Id);
            if (entity == null)
                return null;
            else
                return Mapper.Map<ThuongHieuInput>(entity);
        }
    }
}