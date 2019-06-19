using NomNom.Models.LoaiSanPhams;
using NomNom.Models.NhaCungCaps;
using NomNom.Models.PhieuNhaps;
using NomNom.Models.TinhTrangDonHangs;
using NomNom.Models.SanPhams;
using NomNom.Models.TaiKhoans;
using NomNom.Models.ThuongHieus;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NomNom.Models.KhuVucs;
using NomNom.Models.DonHangs;

namespace NomNom.Models
{
    public class NomNomDbContext : DbContext
    {
        public NomNomDbContext():base("name=NomNomConnectionString")
        {

        }
        
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<ThuongHieu> ThuongHieus { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public DbSet<TinhTrangDonHang> TinhTrangDonHangs { get; set; }
        public DbSet<KhuVuc> KhuVucs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}