namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cap_nhat_bang_donhangs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "NgayGiaoDuKienMin", c => c.DateTime(nullable: false));
            AddColumn("dbo.DonHangs", "NgayGiaoDuKienMax", c => c.DateTime(nullable: false));
            DropColumn("dbo.DonHangs", "NgayGiaoDuKien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonHangs", "NgayGiaoDuKien", c => c.DateTime(nullable: false));
            DropColumn("dbo.DonHangs", "NgayGiaoDuKienMax");
            DropColumn("dbo.DonHangs", "NgayGiaoDuKienMin");
        }
    }
}
