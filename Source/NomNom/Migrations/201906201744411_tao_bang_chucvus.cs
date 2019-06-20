namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tao_bang_chucvus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChucVus",
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
            DropTable("dbo.ChucVus");
        }
    }
}
