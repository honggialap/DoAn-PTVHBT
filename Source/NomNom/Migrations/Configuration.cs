namespace NomNom.Migrations
{
    using NomNom.Common;
    using NomNom.DAL;
    using NomNom.Models.LoaiSanPhams;
    using NomNom.Models.TaiKhoans;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NomNom.Models.NomNomDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NomNom.Models.NomNomDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            List<TaiKhoan> taikhoans = new List<TaiKhoan>();
            TaiKhoan obj = new TaiKhoan();
            obj.Id = 1;
            obj.TenTaiKhoan = "admin";
            obj.MatKhau = "123456";
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);
            obj = new TaiKhoan();
            obj.Id = 2;
            obj.TenTaiKhoan = "hoaithu";
            obj.MatKhau = "123456";
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);
            obj = new TaiKhoan();
            obj.Id = 3;
            obj.TenTaiKhoan = "gialap";
            obj.MatKhau = "123456";
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);


            context.TaiKhoans.AddOrUpdate(taikhoans.ToArray());

            List<LoaiSanPham> loaisanphams = new List<LoaiSanPham>();
            LoaiSanPham lsp = new LoaiSanPham();

            lsp.Id = 1;
            lsp.Ten = "Thực phẩm ăn liền";
            lsp.GhiChu = "Thực phẩm ăn liền là dạng thực phẩm không cần phải nấu nướng mà có thể thể sử dụng ngay,";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 2;
            lsp.Ten = "Thực phẩm đóng hộp";
            lsp.GhiChu = "Đóng hộp là một phương thức để bảo quản thực phẩm bằng cách chế biến và xử lý trong môi trường thiếu khí.";
            loaisanphams.Add(lsp);

            context.LoaiSanPhams.AddOrUpdate(loaisanphams.ToArray());

        }
    }
}
