using AutoMapper;
using NomNom.Models;
using NomNom.Models.TinhTrangDonHangs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.DAL
{
    public class TinhTrangDonHangDAL
    {
        private NomNomDbContext db = null;
        public TinhTrangDonHangDAL()
        {
            db = new NomNomDbContext();
        }
        public List<TinhTrangDonHangDTO> GetTinhTrang()
        {
            var result = db.TinhTrangDonHangs.Where(x => !x.IsDeleted);
            
            var list = new List<TinhTrangDonHangDTO>();
            foreach (var item in result)
            {
                var obj = Mapper.Map<TinhTrangDonHangDTO>(item);//new LoaiSanPhamDTO();
                //obj.Id = item.Id;
                //obj.Ten = item.Ten;
                //obj.GhiChu = item.GhiChu;
                list.Add(obj);
            }
            return list;
        }
    }
}