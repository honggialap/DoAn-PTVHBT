namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cap_nhat_bang_thongtinwebsité : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ThongTinWebsite", "Facebook", c => c.String());
            AddColumn("dbo.ThongTinWebsite", "Twitter", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ThongTinWebsite", "Twitter");
            DropColumn("dbo.ThongTinWebsite", "Facebook");
        }
    }
}
