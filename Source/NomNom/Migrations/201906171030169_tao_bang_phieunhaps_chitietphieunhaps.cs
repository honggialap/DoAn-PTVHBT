namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tao_bang_phieunhaps_chitietphieunhaps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietPhieuNhaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhieuNhapID = c.Int(nullable: false),
                        SanPhamID = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        GiaNhap = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PhieuNhaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ngay = c.DateTime(nullable: false),
                        NhaCungCapID = c.Int(nullable: false),
                        TongChi = c.Double(nullable: false),
                        GhiChu = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PhieuNhaps");
            DropTable("dbo.ChiTietPhieuNhaps");
        }
    }
}
