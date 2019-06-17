using NomNom.Models.LoaiSanPhams;
using NomNom.Models.NhaCungCaps;
using NomNom.Models.PhieuNhaps;
using NomNom.Models.SanPhams;
using NomNom.Models.TaiKhoans;
using NomNom.Models.ThuongHieus;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

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

    }
}