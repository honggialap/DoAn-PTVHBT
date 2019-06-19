namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tao_bang_donhang_chitietdonhangs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDonHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonHangID = c.Int(nullable: false),
                        SanPhamID = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        GiaOrder = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DonHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ngay = c.DateTime(nullable: false),
                        KhachHangID = c.Int(nullable: false),
                        TinhTrangID = c.Int(nullable: false),
                        ThanhTien = c.Double(nullable: false),
                        TenNguoiNhan = c.String(),
                        SoDienThoai = c.String(),
                        DiaChi = c.String(),
                        KhuVucID = c.Int(nullable: false),
                        PhiShip = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DonHangs");
            DropTable("dbo.ChiTietDonHangs");
        }
    }
}
