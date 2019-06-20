namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnhat_bang_donhangs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonHangs", "NgayHoanTat", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DonHangs", "NgayHoanTat");
        }
    }
}
