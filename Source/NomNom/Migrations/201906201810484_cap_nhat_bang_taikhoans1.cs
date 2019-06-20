namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cap_nhat_bang_taikhoans1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaiKhoans", "Ho", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaiKhoans", "Ho");
        }
    }
}
