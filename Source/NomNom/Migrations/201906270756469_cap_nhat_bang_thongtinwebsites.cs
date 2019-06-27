namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cap_nhat_bang_thongtinwebsites : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ThongTinWebsite", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ThongTinWebsite", "Email");
        }
    }
}
