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
            if (filter.Ten != null)
            {
                result = result.Where(x => x.Ten.Contains(filter.Ten));
            }
             
            return result.Select(x=>Mapper.Map<ThuongHieuDTO>(x)).ToList();
        }
        private int Create(ThuongHieuInput input)
        {
            var entity = Mapper.Map<ThuongHieu>(input);
            db.ThuongHieus.Add(entity);
            db.SaveChanges();
            return entity.Id;
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
    }
}