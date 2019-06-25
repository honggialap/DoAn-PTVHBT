namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class taobanggiohangs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GioHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaiKhoanID = c.Int(nullable: false),
                        SanPhamID = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GioHangs");
        }
    }
}
