using AutoMapper;
using NomNom.Models.ChucVus;
using NomNom.Models.DonHangs;
using NomNom.Models.GioHangs;
using NomNom.Models.KhuVucs;
using NomNom.Models.LoaiSanPhams;
using NomNom.Models.NhaCungCaps;
using NomNom.Models.PhieuNhaps;
using NomNom.Models.SanPhams;
using NomNom.Models.TaiKhoans;
using NomNom.Models.ThongTinWebsites;
using NomNom.Models.ThuongHieus;
using NomNom.Models.TinhTrangDonHangs;
using NomNom.Models.TinTucs;
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
            //Nhà cung cấp
            CreateMap<NhaCungCap, NhaCungCapDTO>();
            CreateMap<NhaCungCap, NhaCungCapInput>();
            CreateMap<NhaCungCapInput, NhaCungCap>();
            //Phiếu nhập
            CreateMap<PhieuNhap, PhieuNhapDTO>();
            CreateMap<PhieuNhap, PhieuNhapInput>();
            CreateMap<PhieuNhapInput, PhieuNhap>();
            //Chi tiết phiếu nhập
            CreateMap<ChiTietPhieuNhap, ChiTietPhieuNhapInput>();
            CreateMap<ChiTietPhieuNhapInput, ChiTietPhieuNhap>();
            //Tình trạng đơn hàng
            CreateMap<TinhTrangDonHang, TinhTrangDonHangDTO>();
            //Khu vực
            CreateMap<KhuVuc, KhuVucDTO>();
            CreateMap<KhuVucInput, KhuVuc>();
            CreateMap<KhuVuc, KhuVucInput>();
            //Đon hàng
            CreateMap<DonHang, DonHangDTO>();
            CreateMap<DonHang, DonHangInput>();
            CreateMap<DonHangInput, DonHang>();
            //Chi tiết đơn hàng
            CreateMap<ChiTietDonHang, ChiTietDonHangDTO>();
            CreateMap<ChiTietDonHang, ChiTietDonHangInput>();
            CreateMap<ChiTietDonHangInput, ChiTietDonHang>();
            //Chức vụ
            CreateMap<ChucVu, ChucVuDTO>();
            CreateMap<ChucVu, ChucVuInput>();
            CreateMap<ChucVuInput, ChucVu>();
            //Giỏ hàng
            CreateMap<GioHang, GioHangDTO>();
            //Thông tin website
            CreateMap<ThongTinWebsite, ThongTinWebsiteInput>();
            CreateMap<ThongTinWebsiteInput, ThongTinWebsite>();
            //Tin tức
            CreateMap<TinTuc, TinTucDTO>();
            CreateMap<TinTuc, TinTucInput>();
            CreateMap<TinTucInput, TinTuc>();
        }
    }
}