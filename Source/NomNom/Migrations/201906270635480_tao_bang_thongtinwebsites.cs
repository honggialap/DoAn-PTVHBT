namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tao_bang_thongtinwebsites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ThongTinWebsite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Logo = c.String(),
                        SoDienThoai = c.String(),
                        DiaChi = c.String(),
                        ThongTin = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ThongTinWebsite");
        }
    }
}
