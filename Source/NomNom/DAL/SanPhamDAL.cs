using AutoMapper;
using NomNom.Models;
using NomNom.Models.SanPhams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NomNom.Common;
using PagedList.Mvc;
using PagedList;

namespace NomNom.DAL
{
    public class SanPhamDAL
    {
        NomNomDbContext db = null;
        public SanPhamDAL()
        {
            db = new NomNomDbContext();
        }
        public int CreateOrEdit(SanPhamInput input)
        {
            if (input.Id == 0)
            {
                return Create(input);
            }
            else
                return Update(input);
        }
        
       
       public List<SanPhamDTO> GetSanPham(SanPhamFilter filter)
        {

            var result = db.SanPhams.Where(x => !x.IsDeleted);
            if (filter.Ten != null)
            {
                result = result.Where(x => x.Ten.Contains(filter.Ten));
            }
            if (filter.LoaiID != 0)
            {
                result = result.Where(x => x.LoaiID == filter.LoaiID);
            }
            if (filter.ThuongHieuID!=0)
            {
                result = result.Where(x => x.ThuongHieuID == filter.ThuongHieuID);
            }
            if (filter.GiaBanMin != 0)
            {
                result = result.Where(x => x.GiaBan > filter.GiaBanMin);
            }
            if (filter.GiaBanMax != 0)
            {
                result = result.Where(x => x.GiaBan < filter.GiaBanMax);
            }     
            
            return result.Select(x=>Mapper.Map<SanPhamDTO>(x)).ToList();
        }
        private int Create(SanPhamInput input)
        {
            var entity = Mapper.Map<SanPham>(input);
            db.SanPhams.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        private int Update(SanPhamInput input)
        {
            var entity = db.SanPhams.SingleOrDefault(x => x.Id == input.Id);
            if (entity != null)
            {
                entity = Mapper.Map<SanPham>(input);
                db.SaveChanges();
                return entity.Id;
            }
            return 0;
        }
    }
}