namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cap_nhat_bang_donhangs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "NgayGiaoDuKien", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "NgayGiaoDuKien");
        }
    }
}
