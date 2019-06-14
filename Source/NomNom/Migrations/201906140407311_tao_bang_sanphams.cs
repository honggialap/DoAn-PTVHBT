namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tao_bang_sanphams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SanPhams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ten = c.String(),
                        LoaiID = c.Int(nullable: false),
                        ThuongHieuID = c.Int(nullable: false),
                        HinhAnh = c.String(),
                        ThongTin = c.String(),
                        SoLuong = c.Int(nullable: false),
                        SoView = c.Int(nullable: false),
                        GiaBan = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SanPhams");
        }
    }
}
