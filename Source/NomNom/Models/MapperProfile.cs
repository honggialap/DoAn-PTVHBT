using AutoMapper;
using NomNom.Models.LoaiSanPhams;
using NomNom.Models.SanPhams;
using NomNom.Models.TaiKhoans;
using NomNom.Models.ThuongHieus;
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
            //Loại sản phẩm
            CreateMap<LoaiSanPham, LoaiSanPhamDTO>();
            CreateMap<LoaiSanPham, LoaiSanPhamInput>();
            CreateMap<LoaiSanPhamInput, LoaiSanPham>();
            //Thương hiệu
            CreateMap<ThuongHieu, ThuongHieuDTO>();
            CreateMap<ThuongHieu, ThuongHieuInput>();
            CreateMap<ThuongHieuInput, ThuongHieu>();
        }
    }
}