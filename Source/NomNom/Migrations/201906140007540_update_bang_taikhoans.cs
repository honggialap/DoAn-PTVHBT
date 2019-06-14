namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_bang_taikhoans : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaiKhoans", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.TaiKhoans", "IsDelete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaiKhoans", "IsDelete", c => c.Boolean(nullable: false));
            DropColumn("dbo.TaiKhoans", "IsDeleted");
        }
    }
}
