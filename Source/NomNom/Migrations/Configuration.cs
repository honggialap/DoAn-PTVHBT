namespace NomNom.Migrations
{
    using NomNom.Common;
    using NomNom.DAL;
    using NomNom.Models.LoaiSanPhams;
    using NomNom.Models.TaiKhoans;
    using NomNom.Models.ThuongHieus;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NomNom.Models.NomNomDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NomNom.Models.NomNomDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            #region taikhoan
            List<TaiKhoan> taikhoans = new List<TaiKhoan>();
            TaiKhoan obj = new TaiKhoan();
            obj.Id = 1;
            obj.TenTaiKhoan = "admin";
            obj.MatKhau = "123456";
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);
            obj = new TaiKhoan();
            obj.Id = 2;
            obj.TenTaiKhoan = "hoaithu";
            obj.MatKhau = "123456";
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);
            obj = new TaiKhoan();
            obj.Id = 3;
            obj.TenTaiKhoan = "gialap";
            obj.MatKhau = "123456";
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);

            context.TaiKhoans.AddOrUpdate(taikhoans.ToArray());
            #endregion

            #region loaisanpham
            List<LoaiSanPham> loaisanphams = new List<LoaiSanPham>();
            LoaiSanPham lsp = new LoaiSanPham();

            lsp.Id = 1;
            lsp.Ten = "Thực phẩm ăn liền";
            lsp.GhiChu = "Thực phẩm ăn liền là dạng thực phẩm không cần phải nấu nướng mà có thể thể sử dụng ngay,";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 2;
            lsp.Ten = "Thực phẩm đóng hộp";
            lsp.GhiChu = "Đóng hộp là một phương thức để bảo quản thực phẩm bằng cách chế biến và xử lý trong môi trường thiếu khí.";
            loaisanphams.Add(lsp);

            context.LoaiSanPhams.AddOrUpdate(loaisanphams.ToArray());
            #endregion

            #region thuonghieu
            List<ThuongHieu> thuonghieus = new List<ThuongHieu>();
            ThuongHieu th = new ThuongHieu();

            th.Id = 1;
            th.Ten = "Organica";
            th.GhiChu = "Cửa hàng Organica mở ra vào tháng 6/2013 với chỉ 5 - 6 loại rau trồng theo phương thức hữu cơ (quy mô của nhà cung cấp nhỏ)," +
                " 4 loại gạo và 8 loại trà… với diện tích chỉ khoảng 25m2.\n Sau đó hai tháng," +
                " một chủ trang trại rau từ Đà Lạt đang trồng theo hướng hữu cơ đã liên kết và cung cấp các sản phẩm ớt chuông," +
                " cà chua, một số loại xà lách hữu cơ do họ trồng được, giúp mở rộng quy mô và đa dạng các mặt hàng cung cấp." +
                " Organica là đơn vị đầu tiên cả nước có được hai chứng nhận quốc tế về organic cho vườn rau hữu cơ." +
                " Hiện cửa hàng có danh sách trên 500 mặt hàng organic, được coi đa dạng và phong phú nhất trong các nhà cung cấp thực phẩm hữu cơ hiện tại.";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = 2;
            th.Ten = "Vườn Kogi";
            th.GhiChu = "Tên của Vườn Kogi bắt nguồn từ tên của Bộ lạc da đỏ Kogi sống trên dãy núi Sierra Nevada ở Colombia." +
                " Đây là bộ tộc ăn chay, không ăn thịt, cá mà chỉ ăn rau, củ, quả. Họ sống nương tựa và hòa mình vào thiên nhiên. " +
                "Danh mục sản phẩm Kogi cung cấp cho khác hàng gồm các loại rau củ quả hữu cơ, trái cây hữu cơ, thực phẩm hữu cơ và đặc sản 3 miền.";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = 3;
            th.Ten = "Kirin";
            th.GhiChu = "Công ty TNHH nước giải khát Kirin là công ty con của tập đoàn chuyên về nước giải khát Kirin Japan." +
                " Kirin hợp tác với Interfood, công ty đã có hơn 20 năm kinh nghiệm trong thị trường Việt Nam " +
                "và nổi tiếng với thương hiệu Wonderfarm, mở ra hai nhà máy ở Đồng Nai và Bình Dương, " +
                "mong muốn sẽ làm hài lòng khách hàng với sản phẩm tốt nhất. Hiện tại, dòng sản phẩm của Kirin, " +
                "ice+, Latte và Wonderfarm, đã được phâm phối toàn khắp các siêu thị ở Việt Nam, trở thành một " +
                "nhãn hiệu quen thuộc với người tiêu dùng. ";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = 4;
            th.Ten = "Vina Acecook";
            th.GhiChu = "Thành lập năm 1995, công ty cổ phần Acecook Việt Nam (Vina Acecook)" +
                " là một nhà phân phối thực phẩm, chủ yếu mì gói. Với mục tiêu là mang đến cho" +
                " khách hàng những sản phẩm chất lượng và an toàn, Acecook không ngừng học hỏi " +
                "và áp dụng công nghệ hiện đại Nhật Bản vào hệ thống. Đạt được những giải thưởng" +
                " danh giá như ISO 9001: 2000, ISO 14001: 2004…, Vina Acecook trở thành một trong " +
                "những sự chọn lựa ưa thích của khách hàng. Càng nhiều sản phẩm như mì Hảo Hảo, " +
                "Lẩu Thái, Kim Chi…được bán ra cả thị trường trong và ngoài nước, góp phần làm " +
                "tăng lợi nhuận của Vina Acecook.";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = 4;
            th.Ten = "Nissin foods Vietnam";
            th.GhiChu = "Là một chi nhánh của tập đoàn Nissin, Nissin Việt Nam đi vào hoạt động năm 2001. " +
                "Với sự đầu tư mạnh trong việc xây dựng cơ sở vật chất kĩ thuật cao và công nghệ chuyển giao từ Nhật Bản," +
                " Nissin Việt Nam cam kết mang lại cho người tiêu dùng những sản phẩm mì gói ngon, an toàn và hợp vệ sinh. " +
                "Sản phẩm Nissin gồm những loại mì gói ăn liền đa dạng: mì bò tiêu xanh, mì rau răm… đều được phân phối trên" +
                " các cửa hàng và hệ thống siêu thị ở Việt Nam.";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = 5;
            th.Ten = "Ajinomoto";
            th.GhiChu = "Đi vào quĩ đạo hoạt động ở Việt Nam năm 1991, Ajinomoto Việt Nam, " +
                "chuyên về các mặt hàng như bột nêm gia vị, giấm, nước sốt mayonnaise, nước giải khát," +
                " là một nhánh của Ajinomoto Nhật Bản. Từ ngày thành lập, " +
                "Ajinomoto không ngừng học hỏi và mở rộng hoạt động kinh doanh. " +
                "Nhấn mạnh về tính an toàn và chất lượng cao, Ajinomoto là một nhãn hiệu thân thiết" +
                " với khách hàng qua những sản phẩm như: bột ngọt Ajinomoto, nước sốt mayonnaise Ajinomoto," +
                " cà phê Birdy, bột nêm Knorr…";
            thuonghieus.Add(th);
            context.ThuongHieus.AddOrUpdate(thuonghieus.ToArray());
            #endregion



        }
    }
}
