namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_bang_tintucs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TinTucs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TieuDe = c.String(),
                        MieuTa = c.String(),
                        HinhAnh = c.String(),
                        NoiDung = c.String(),
                        Ngay = c.DateTime(nullable: false),
                        SoView = c.Int(nullable: false),
                        GhiChu = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinTucs");
        }
    }
}
