namespace NomNom.Migrations
{
    using NomNom.Common;
    using NomNom.DAL;
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

            obj.Id = 2;
            obj.TenTaiKhoan = "hoaithu";
            obj.MatKhau = "123456";
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);

            obj.Id = 3;
            obj.TenTaiKhoan = "gialap";
            obj.MatKhau = "123456";
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);
            context.TaiKhoans.AddOrUpdate(taikhoans.ToArray());

        }
    }
}
