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
        private NomNomDbContext db = null;
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
        public SanPhamDTO GetForView(int Id)
        {
            var entity = db.SanPhams.Find(Id);
            if (entity == null)
                return null;
            else
                return Mapper.Map<SanPhamDTO>(entity);
        }
        public SanPhamInput GetForEdit(int Id)
        {
            var entity = db.SanPhams.Find(Id);
            if (entity == null)
                return null;
            else
                return Mapper.Map<SanPhamInput>(entity);
        }
        public List<SanPhamDTO> GetSanPhamArr(List<int> lsp,List<int> th, List<string> ten,int count)
        {
            var result = db.SanPhams.Where(x => !x.IsDeleted).ToList();
            if (lsp.Count()>0)
            result = result.Where(x => lsp.Exists(y => x.LoaiID == y)).ToList();
            if(th.Count()>0)
            result = result.Where(x => th.Exists(y => x.ThuongHieuID == y)).ToList();
            if(ten.Count()>0)
            result = result.Where(x => ten.Exists(y => x.Ten.Contains(y))).ToList();
            result = result.Take(count).ToList();




            var list = new List<SanPhamDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<SanPhamDTO>(item);               
                list.Add(obj);
            }
            return list;
        }
        public List<SanPhamDTO> GetSanPham(SanPhamFilter filter)
        {

            var result = db.SanPhams.Where(x => !x.IsDeleted);
            if (filter != null)
            {
                if (filter.Ten != null)
                {
                    result = result.Where(x => x.Ten.Contains(filter.Ten));
                }
                if (filter.LoaiID != 0)
                {
                    result = result.Where(x => x.LoaiID == filter.LoaiID);
                }
                if (filter.ThuongHieuID != 0)
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
            }
            var list = new List<SanPhamDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<SanPhamDTO>(item);//new LoaiSanPhamDTO();
                //obj.Id = item.Id;
                //obj.Ten = item.Ten;
                //obj.GhiChu = item.GhiChu;
                list.Add(obj);
            }
            return list;
            //return result.Select(x=>Mapper.Map<SanPhamDTO>(x)).ToList();
        }
        public bool Delete(int Id)
        {
            var entity = db.SanPhams.Find(Id);
            if (entity == null)
                return false;
            else
            {
                entity.IsDeleted = true;
                db.SaveChanges();
                return true;
            }
        }
        public bool UpdateGiaBan(int Id,double GiaBan)
        {
            var entity = db.SanPhams.Find(Id);
            if (entity == null)
                return false;
            else
            {
                entity.GiaBan = GiaBan;
                db.SaveChanges();
                return true;
            }
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
                //entity = Mapper.Map<SanPham>(input);
                entity.Ten = input.Ten;
                entity.LoaiID = input.LoaiID;
                entity.ThuongHieuID = input.ThuongHieuID;
                entity.ThongTin = input.ThongTin;
                entity.HinhAnh = input.HinhAnh;
                entity.GiaBan = input.GiaBan;
                db.SaveChanges();
                return entity.Id;
            }
            return 0;
        }
    }
}