namespace NomNom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cap_nhat_bang_taikhoans : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TaiKhoans", "ChucVuID", c => c.Int(nullable: false));
            AddColumn("dbo.TaiKhoans", "Ten", c => c.String());
            AddColumn("dbo.TaiKhoans", "NgaySinh", c => c.DateTime());
            AddColumn("dbo.TaiKhoans", "Email", c => c.String());
            AddColumn("dbo.TaiKhoans", "SDT", c => c.String());
            AddColumn("dbo.TaiKhoans", "DiaChi", c => c.String());
            AddColumn("dbo.TaiKhoans", "IsBan", c => c.Boolean(nullable: false));
            AddColumn("dbo.TaiKhoans", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TaiKhoans", "Avatar");
            DropColumn("dbo.TaiKhoans", "IsBan");
            DropColumn("dbo.TaiKhoans", "DiaChi");
            DropColumn("dbo.TaiKhoans", "SDT");
            DropColumn("dbo.TaiKhoans", "Email");
            DropColumn("dbo.TaiKhoans", "NgaySinh");
            DropColumn("dbo.TaiKhoans", "Ten");
            DropColumn("dbo.TaiKhoans", "ChucVuID");
        }
    }
}
