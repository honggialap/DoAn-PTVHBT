namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tao_bang_khuvucs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KhuVucs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(nullable: false),
                        Ten = c.String(),
                        ThoiGianShipMin = c.Int(nullable: false),
                        ThoiGianShipMax = c.Int(nullable: false),
                        PhiShip = c.Double(nullable: false),
                        GhiChu = c.String(),
                        HoatDong = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KhuVucs");
        }
    }
}
