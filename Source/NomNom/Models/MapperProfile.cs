using AutoMapper;
using NomNom.Models.SanPhams;
using NomNom.Models.TaiKhoans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            //Tài khoản
            CreateMap<TaiKhoan, TaiKhoanDTO>();
            CreateMap<TaiKhoan, TaiKhoanInput>();
            CreateMap<TaiKhoanInput, TaiKhoan>();
            //Sản phẩm
            CreateMap<SanPham, SanPhamDTO>();
            CreateMap<SanPham, SanPhamInput>();
            CreateMap<SanPhamInput, SanPham>();
        }
    }
}