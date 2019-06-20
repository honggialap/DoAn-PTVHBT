using AutoMapper;
using NomNom.Models;
using NomNom.Models.LoaiSanPhams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NomNom.Common;
using PagedList.Mvc;
using PagedList;

namespace NomNom.DAL
{
    public class LoaiSanPhamDAL
    {
        private NomNomDbContext db = null;
        public LoaiSanPhamDAL()
        {
            db = new NomNomDbContext();
        }
        public int CreateOrEdit(LoaiSanPhamInput input)
        {
            if (input.Id == 0)
            {
                return Create(input);
            }
            else
                return Update(input);
        }

        public LoaiSanPhamInput GetForEdit(int Id)
        {
            var entity = db.LoaiSanPhams.Find(Id);
            if (entity == null)
                return null;
            else
                return Mapper.Map<LoaiSanPhamInput>(entity);
        }
       public bool Delete(int Id)
        {
            var entity = db.LoaiSanPhams.Find(Id);
            if (entity == null)
                return false;
            else
            {
                entity.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
        }
       public List<LoaiSanPhamDTO> GetLoaiSanPham(LoaiSanPhamFilter filter)
        {
            var result = db.LoaiSanPhams.Where(x => !x.IsDeleted);
            if (filter != null)
            {
                if (filter.Ten != null && filter.Ten != "")
                {
                    result = result.Where(x => x.Ten.Contains(filter.Ten));
                }
            }
            var list = new List<LoaiSanPhamDTO>();
            foreach(var item in result)
            {
                var obj = Mapper.Map<LoaiSanPhamDTO>(item);//new LoaiSanPhamDTO();
                //obj.Id = item.Id;
                //obj.Ten = item.Ten;
                //obj.GhiChu = item.GhiChu;
                list.Add(obj);
            }
            return list;
            //return result.Select(x=>Mapper.Map<LoaiSanPhamDTO>(x)).ToList();
        }
        private int Create(LoaiSanPhamInput input)
        {
            var entity = Mapper.Map<LoaiSanPham>(input);
            db.LoaiSanPhams.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        private int Update(LoaiSanPhamInput input)
        {
            var entity = db.LoaiSanPhams.SingleOrDefault(x => x.Id == input.Id);
            if (entity != null)
            {
                //entity = Mapper.Map<LoaiSanPham>(input);        
                entity.Ten = input.Ten;
                entity.GhiChu = input.GhiChu;
                db.SaveChanges();
                return entity.Id;
            }
            return 0;
        }
    }
}