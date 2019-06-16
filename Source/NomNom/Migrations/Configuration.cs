namespace NomNom.Migrations
{
    using NomNom.Common;
    using NomNom.DAL;
    using NomNom.Models.LoaiSanPhams;
    using NomNom.Models.SanPhams;
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
            int n;
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
            lsp.Ten = "Không có";
            lsp.GhiChu = "Sử dụng khi không cần phân loại sản phẩm";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 2;
            lsp.Ten = "Rau - Củ - Quả";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 3;
            lsp.Ten = "Gia vị";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 4;
            lsp.Ten = "Đồ hộp";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 5;
            lsp.Ten = "Thực phẩm tươi";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 6;
            lsp.Ten = "Thực phẩm khô";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 7;
            lsp.Ten = "Thực phẩm ăn liền";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 8;
            lsp.Ten = "Thực phẩm đông lạnh và bảo quản mát";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 9;
            lsp.Ten = "Sữa - Kem & sản phẩm từ sữa";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 10;
            lsp.Ten = "Thực phẩm bổ dưỡng";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);          

            lsp = new LoaiSanPham();
            lsp.Id = 11;
            lsp.Ten = "Đồ ăn vặt";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 12;
            lsp.Ten = "Bánh";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 13;
            lsp.Ten = "Kẹo";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);

            lsp = new LoaiSanPham();
            lsp.Id = 14;
            lsp.Ten = "Thực phẩm chay";
            lsp.GhiChu = "";
            loaisanphams.Add(lsp);


            context.LoaiSanPhams.AddOrUpdate(loaisanphams.ToArray());
            #endregion

            #region thuonghieu
            List<ThuongHieu> thuonghieus = new List<ThuongHieu>();
            ThuongHieu th = new ThuongHieu();
            n = 1;
            th.Id = n++;
            th.Ten = "Không có";
            th.GhiChu = "Sử dụng cho các sản phẩm không phân loại thương hiệu";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = n++;
            th.Ten = "Vinamilk";
            th.GhiChu = "Công ty Cổ phần Sữa Việt Nam, tên khác: Vinamilk, " +
                "mã chứng khoán HOSE: VNM, là một công ty sản xuất, " +
                "kinh doanh sữa và các sản phẩm từ sữa cũng như thiết " +
                "bị máy móc liên quan tại Việt Nam. Theo thống kê của " +
                "Chương trình Phát triển Liên Hiệp Quốc, đây là công ty " +
                "lớn thứ 15 tại Việt Nam vào năm 2007.";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = n++;
            th.Ten = "Light Coffee";
            th.GhiChu = "Light Coffee là thương hiệu do Công ty CP Sản xuất " +
                "và Thương mại Kim Cương Xanh sáng lập và sở hữu (về sau gọi " +
                "Light Coffee đại diện cho công ty CP Sản xuất và Thương mại " +
                "Kim Cương Xanh) Là thương hiệu cho các loại cà phê rang mộc " +
                "nguyên chất 100% Robusta, Arabica, phối trộn bằng công thức " +
                "độc quyền,...";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = n++;
            th.Ten = "Vifon";
            th.GhiChu = "Là một trong những đơn vị đặt nền móng xây dựng nên " +
                "ngành thực phẩm ăn liền Việt Nam, VIFON đã trở thành thương " +
                "hiệu quen thuộc và gắn bó với người tiêu dùng thông qua nhiều" +
                " sản phẩm sợi ăn liền và gia vị.";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = n++;
            th.Ten = "TH true MILK";
            th.GhiChu = "Sự ra đời và phát triển ngoạn mục của thương hiệu sữa " +
                "tươi sạch TH true Milk từ cuối năm 2010 đến nay đã tạo ra một " +
                "hiện tượng trong ngành sữa Việt Nam. Bí quyết của thương hiệu " +
                "này là “Câu chuyện thật của TH”. Đó là nguồn nguyên liệu sữa " +
                "hoàn toàn tươi sạch từ Trang trại bò sữa TH tại Nghĩa Đàn, " +
                "Nghệ An, áp dụng công nghệ hiện đại nhất của thế giới vào " +
                "chăn nuôi, sản xuất; tạo ra sản phẩm thật, chất lượng cao " +
                "bằng một chiến lược đầu tư bài bản.Nhờ các yếu tố này, " +
                "nhận diện TH true MILK đã đi sâu vào tâm trí của người " +
                "tiêu dùng Việt Nam.";
            thuonghieus.Add(th);

            th = new ThuongHieu();
            th.Id = n++;
            th.Ten = "Nestlé";
            th.GhiChu = "Nestlé là công ty thực phẩm và đồ uống được xếp " +
                "hạng cao nhất trong nghiên cứu do APCO Insight, một công " +
                "ty nghiên cứu thị trường toàn cầu thực hiện.";
            thuonghieus.Add(th);
            context.ThuongHieus.AddOrUpdate(thuonghieus.ToArray());
            #endregion

            #region sanpham
            List<SanPham> sanphams = new List<SanPham>();
            SanPham sp = new SanPham();
            n = 1;
            sp.Id = n++;
            sp.Ten = "Kem đặc có đường Ngôi Sao Phương Nam hộp 1,284kg";
            sp.LoaiID = 9;
            sp.ThuongHieuID = 2;
            sp.HinhAnh = "/assets/filesimages/kemdacphuongnam.jpg";
            sp.ThongTin = "- Được làm từ các nguyên liệu tự nhiên" +
                " - Sản xuất theo công nghệ hiện đại" +
                " - Dạng hộp đẹp mắt và tiện lợi sử dụng";
            sp.GiaBan = 62900;
            sanphams.Add(sp);

            sp = new SanPham();
            sp.Id = n++;
            sp.Ten = "Sữa tươi tiệt trùng không đường 100% Organic Vinamilk hộp 1L";
            sp.LoaiID = 9;
            sp.ThuongHieuID = 2;
            sp.HinhAnh = "/assets/filesimages/suatuoivinamilk.jpg";
            sp.ThongTin = "Thương hiệu cao cấp, an toàn cho sức khỏe - " +
                "Thành phần sữa giàu canxi, vitamin và các dưỡng chất - " +
                "Hương vị thuần khiết, thơm ngon";
            sp.GiaBan = 54500;
            sanphams.Add(sp);

            sp = new SanPham();
            sp.Id = n++;
            sp.Ten = "Sữa tươi tiệt trùng ít đường Vinamilk hộp 180ml";
            sp.LoaiID = 9;
            sp.ThuongHieuID = 2;
            sp.HinhAnh = "/assets/filesimages/suatuoikhongduongvinamilk.jpg";
            sp.ThongTin = "Sản xuất từ nguyên liệu tự nhiên, không chất bảo quản - " +
                "Cung cấp canxi, vitamin D3, A, C và selen, hỗ trợ miễn dịch - " +
                "Sản phẩm đóng lốc 4 hộp, có ống hút tiện dụng ";
            sp.GiaBan = 7500;
            sanphams.Add(sp);

            context.SanPhams.AddOrUpdate(sanphams.ToArray());     
            #endregion


        }
    }
}
