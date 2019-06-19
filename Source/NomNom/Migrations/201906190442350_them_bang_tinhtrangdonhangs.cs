namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class them_bang_tinhtrangdonhangs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TinhTrangDonHangs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        GhiChu = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TinhTrangDonHangs");
        }
    }
}
