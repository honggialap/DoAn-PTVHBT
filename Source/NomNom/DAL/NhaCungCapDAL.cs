using AutoMapper;
using NomNom.Models;
using NomNom.Models.NhaCungCaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NomNom.Common;
using PagedList.Mvc;
using PagedList;

namespace NomNom.DAL
{
    public class NhaCungCapDAL
    {
        NomNomDbContext db = null;
        public NhaCungCapDAL()
        {
            db = new NomNomDbContext();
        }
        public int CreateOrEdit(NhaCungCapInput input)
        {
            if (input.Id == 0)
            {
                return Create(input);
            }
            else
                return Update(input);
        }
        
       
       public List<NhaCungCapDTO> GetNhaCungCap(NhaCungCapFilter filter)
        {

            var result = db.NhaCungCaps.Where(x => !x.IsDeleted);
            if (filter != null)
            {
                if (filter.Ten != null)
                {
                    result = result.Where(x => x.Ten.Contains(filter.Ten));
                }
            }
            var list = new List<NhaCungCapDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<NhaCungCapDTO>(item);//new LoaiSanPhamDTO();
                //obj.Id = item.Id;
                //obj.Ten = item.Ten;
                //obj.GhiChu = item.GhiChu;
                list.Add(obj);
            }
            return list;
            //return result.Select(x=>Mapper.Map<NhaCungCapDTO>(x)).ToList();
        }
        private int Create(NhaCungCapInput input)
        {
            var entity = Mapper.Map<NhaCungCap>(input);
            db.NhaCungCaps.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Delete(int Id)
        {
            var entity = db.NhaCungCaps.Find(Id);
            if (entity == null)
                return false;
            else
            {
                entity.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
        }

        private int Update(NhaCungCapInput input)
        {
            var entity = db.NhaCungCaps.SingleOrDefault(x => x.Id == input.Id);
            if (entity != null)
            {
                //entity = Mapper.Map<NhaCungCap>(input);   
                entity.Ten = input.Ten;
                entity.GhiChu = input.GhiChu;
                db.SaveChanges();
                return entity.Id;
            }
            return 0;
        }

        public NhaCungCapInput GetForEdit(int Id)
        {
            var entity = db.NhaCungCaps.Find(Id);
            if (entity == null)
                return null;
            else
                return Mapper.Map<NhaCungCapInput>(entity);
        }
    }
}