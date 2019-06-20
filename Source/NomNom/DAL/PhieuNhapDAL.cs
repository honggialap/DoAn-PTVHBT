
using AutoMapper;
using NomNom.Models;
using NomNom.Models.PhieuNhaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NomNom.Common;
using PagedList.Mvc;
using PagedList;

namespace NomNom.DAL
{
    public class PhieuNhapDAL
    {
        private NomNomDbContext db = null;
        public PhieuNhapDAL()
        {
            db = new NomNomDbContext();
        }
        public int CreateOrEdit(PhieuNhapInput input)
        {
            if (input.ChiTiets == null)
                input.ChiTiets = new List<ChiTietPhieuNhapInput>();
                    
            
            if (input.Id == 0)
            {
                return Create(input);
            }
            else
                return Update(input);
        }


        public List<PhieuNhapDTO> GetPhieuNhap(PhieuNhapFilter filter)
        {
            var result = db.PhieuNhaps.Where(x => !x.IsDeleted);
            if (filter != null)
            {
                if (filter.NgayMin != null)
                {
                    result = result.Where(x => DateTime.Compare(filter.NgayMin, x.Ngay) <= 0);
                }
                if (filter.NgayMax != null)
                {
                    result = result.Where(x => DateTime.Compare(filter.NgayMax, x.Ngay) >= 0);
                }
                if (filter.NhaCungCapID != 0)
                {
                    result = result.Where(x => x.NhaCungCapID == filter.NhaCungCapID);
                }
            }
            var list = new List<PhieuNhapDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<PhieuNhapDTO>(item);           
                list.Add(obj);
            }
            foreach(var item in list)
            {
                item.NhaCungCapTen = db.NhaCungCaps.SingleOrDefault(x => x.Id == item.NhaCungCapID).Ten;
            }
            return list;
            //return result.Select(x=>Mapper.Map<ThuongHieuDTO>(x)).ToList();
        }
        private int Create(PhieuNhapInput input)
        {
            //Tăng số lượng
            foreach(var item in input.ChiTiets)
            {
                var spEntity = db.SanPhams.Find(item.SanPhamID);
                if (spEntity != null)
                {
                    spEntity.SoLuong += item.SoLuong;
                }
            }
            //Tính tổng tiền
            input.TongChi = 0;
            foreach(var item in input.ChiTiets)
            {
                input.TongChi += item.GiaNhap*item.SoLuong;
            }
            //Add bảng phiếu nhập
            var entity = Mapper.Map<PhieuNhap>(input);
            db.PhieuNhaps.Add(entity);
            db.SaveChanges();//save để lấy id phiếu nhập
            //add bảng chi tiết phiếu nhập
            foreach (var chitiet in input.ChiTiets)
            {
                var chitietEntity = Mapper.Map<ChiTietPhieuNhap>(chitiet);
                chitietEntity.PhieuNhapID = entity.Id;
                db.ChiTietPhieuNhaps.Add(chitietEntity);
            }        
            db.SaveChanges();
            return entity.Id;
        }

        public bool Delete(int Id)
        {
            var entity = db.PhieuNhaps.Find(Id);
            if (entity == null)
                return false;
            else
            {
                entity.IsDeleted = true;
                var listChiTiet = db.ChiTietPhieuNhaps.Where(x => !x.IsDeleted && x.PhieuNhapID == entity.Id);
                foreach(var item in listChiTiet)
                {
                    item.IsDeleted = true;
                }
                db.SaveChanges();
                return true;
            }
        }

        private int Update(PhieuNhapInput input)
        {
            
            //Tính tổng tiền
            input.TongChi = 0;
            foreach (var item in input.ChiTiets)
            {
                input.TongChi += item.GiaNhap * item.SoLuong;
            }

            var entity = db.PhieuNhaps.Find(input.Id);
            if (entity == null)
            {
                return 0;
            }
            //map data
            entity.TongChi = input.TongChi;
            entity.Ngay = input.Ngay;
            entity.NhaCungCapID = input.NhaCungCapID;

            //
            
            //Add bảng chi tiết phiếu nhập
            //Xóa bản ghi cũ
            var dbChiTiets = db.ChiTietPhieuNhaps.Where(x => !x.IsDeleted&&x.PhieuNhapID==entity.Id).ToArray();
                
                foreach (var item in dbChiTiets)
                {
                    var spEntity = db.SanPhams.Find(item.SanPhamID);
                    if (spEntity != null)
                    {
                        spEntity.SoLuong -= item.SoLuong;
                    }
                    if (!input.ChiTiets.Exists(x => x.SanPhamID == item.SanPhamID))
                    {
                        item.IsDeleted = true;
                    }
                }
            //Cập nhật số lượng

            foreach (var item in input.ChiTiets)
            {
                var spEntity = db.SanPhams.Find(item.SanPhamID);
                if (spEntity != null)
                {
                    spEntity.SoLuong += item.SoLuong;
                }
            }
            //--
            //Thêm hoặc update chi tiết phiếu nhập
            foreach (var chitiet in input.ChiTiets)
            {
                var chitietEntity=new ChiTietPhieuNhap();
                try
                {
                    chitietEntity = db.ChiTietPhieuNhaps.SingleOrDefault(x => !x.IsDeleted &&x.PhieuNhapID==entity.Id&& x.SanPhamID == chitiet.SanPhamID);
                }
                catch(Exception e)
                {
                    chitietEntity = null;
                }
                if (chitietEntity != null)
                {
                    chitietEntity.SoLuong = chitiet.SoLuong;
                    chitietEntity.GiaNhap = chitiet.GiaNhap;
                }
                else
                {
                    chitietEntity = Mapper.Map<ChiTietPhieuNhap>(chitiet);
                    chitietEntity.PhieuNhapID = entity.Id;
                    db.ChiTietPhieuNhaps.Add(chitietEntity);
                }
            }
            db.SaveChanges();
            return entity.Id;
        }

        public PhieuNhapInput GetForEdit(int Id)
        {
            var entity = db.PhieuNhaps.Find(Id);
            if (entity == null)
                return null;
            else
            {
                var input = Mapper.Map<PhieuNhapInput>(entity);
                input.ChiTiets = new List<ChiTietPhieuNhapInput>();
                //load danh sách chi tiết
                var listChiTiet = db.ChiTietPhieuNhaps.Where(x => !x.IsDeleted && x.PhieuNhapID == input.Id);
                foreach(var chitiet in listChiTiet)
                {
                    var chitietInput = Mapper.Map<ChiTietPhieuNhapInput>(chitiet);
                    input.ChiTiets.Add(chitietInput);
                }
                return input;
            }
                
        }
    }
}