namespace NomNom.Migrations
{
    using NomNom.Common;
    using NomNom.DAL;
    using NomNom.Models.ChucVus;
    using NomNom.Models.DonHangs;
    using NomNom.Models.KhuVucs;
    using NomNom.Models.LoaiSanPhams;
    using NomNom.Models.NhaCungCaps;
    using NomNom.Models.SanPhams;
    using NomNom.Models.TaiKhoans;
    using NomNom.Models.ThuongHieus;
    using NomNom.Models.TinhTrangDonHangs;
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
            obj.ChucVuID = CommonConstants.CHUC_VU_ADMIN;
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);
            obj = new TaiKhoan();
            obj.Id = 2;
            obj.TenTaiKhoan = "hoaithu";
            obj.MatKhau = "123456";
            obj.SDT = "0343562031";
            obj.Ten = "Hoài Thu";
            obj.Ho = "Nguyễn";
            obj.NgaySinh = new DateTime(1998,11,16);
            
            obj.Email = "hoaithu7604@gmail.com";
            obj.ChucVuID = CommonConstants.CHUC_VU_ADMIN;
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);
            obj = new TaiKhoan();
            obj.Id = 3;
            obj.TenTaiKhoan = "gialap";
            obj.MatKhau = "123456";
            obj.ChucVuID = CommonConstants.CHUC_VU_ADMIN;
            obj.IsDeleted = false;
            obj.MatKhau = Encryptor.MD5Hash(obj.MatKhau);
            taikhoans.Add(obj);
            obj = new TaiKhoan();
            obj.Id = 4;
            obj.TenTaiKhoan = "khachhang";
            obj.MatKhau = "123456";
            obj.ChucVuID = CommonConstants.CHUC_VU_KHACH_HANG;
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

            #region nhacungcap
            List<NhaCungCap> nhacungcaps = new List<NhaCungCap>();
            NhaCungCap ncc = new NhaCungCap();
            n = 1;
            ncc.Id = n++;
            ncc.Ten = "Không có";
            ncc.GhiChu = "Sử dụng khi không cần chọn NCC";
            nhacungcaps.Add(ncc);

            ncc = new NhaCungCap();
            ncc.Id = n++;
            ncc.Ten = "Thực phẩm IPP MIEN BAC";
            ncc.GhiChu = "Công ty TNHH MTV IPP Miền Bắc là công ty chuyên nhập khẩu" +
                " và phân phối độc quyền các sản phẩm snack, bánh kẹo, sữa và phân " +
                "phối độc quyền sữa hạt 137 Degrees Thái Lan từ Thailand.";
            nhacungcaps.Add(ncc);

            ncc = new NhaCungCap();
            ncc.Id = n++;
            ncc.Ten = "Công Ty Tnhh Thương Mại Dịch Vụ Xuất Nhập Khẩu Việt Liên Minh";
            ncc.GhiChu = "Địa chỉ: 128/10 Trần Kế Xương, Phường 07, Quận Phú Nhuận, " +
                "TP Hồ Chí Minh.  Mã số thuế: 0314318259";
            nhacungcaps.Add(ncc);

            context.NhaCungCaps.AddOrUpdate(nhacungcaps.ToArray());
            #endregion

            #region tinhtrangdonhang
            //Hiện tại không nên sửa ở đây
            List<TinhTrangDonHang> tinhtrangdonhangs = new List<TinhTrangDonHang>();
            TinhTrangDonHang ttdh = new TinhTrangDonHang();

            ttdh.Id = CommonConstants.TINH_TRANG_CHO_DUYET;
            ttdh.Ten = "Đang chờ duyệt";
            ttdh.GhiChu = "Sử dụng cho các đơn hàng đang chờ duyệt";
            tinhtrangdonhangs.Add(ttdh);

            ttdh = new TinhTrangDonHang();
            ttdh.Id = CommonConstants.TINH_TRANG_DA_DUYET;
            ttdh.Ten = "Đã duyệt";
            ttdh.GhiChu = "Sử dụng cho các đơn hàng đã duyệt";
            tinhtrangdonhangs.Add(ttdh);

            ttdh = new TinhTrangDonHang();
            ttdh.Id = CommonConstants.TINH_TRANG_DANG_GIAO;
            ttdh.Ten = "Đang giao";
            ttdh.GhiChu = "Sử dụng cho các đơn hàng đang trong quá trình giao hàng";
            tinhtrangdonhangs.Add(ttdh);

            ttdh = new TinhTrangDonHang();
            ttdh.Id = CommonConstants.TINH_TRANG_HOAN_TAT;
            ttdh.Ten = "Hoàn tất";
            ttdh.GhiChu = "Sử dụng cho các đơn hàng đã giao và thanh toán";
            tinhtrangdonhangs.Add(ttdh);

            ttdh = new TinhTrangDonHang();
            ttdh.Id = 5;
            ttdh.Ten = "Đã hủy";
            ttdh.GhiChu = "Sử dụng cho các đơn hàng đã bị hủy";
            tinhtrangdonhangs.Add(ttdh);



            context.TinhTrangDonHangs.AddOrUpdate(tinhtrangdonhangs.ToArray());
            #endregion

            #region khuvuc
            List<KhuVuc> khuvucs = new List<KhuVuc>()
            {
                new KhuVuc(1,0,"An Giang"), new KhuVuc(33,0,"Kon Tum"),
                new KhuVuc(2,0,"Bà Rịa – Vũng Tàu"), new KhuVuc(34,0,"Lai Châu"),
                new KhuVuc(3,0,"Bắc Giang"), new KhuVuc(35,0,"Lâm Đồng"),
                new KhuVuc(4,0,"Bắc Kạn "), new KhuVuc(36,0,"Lạng Sơn"),
                new KhuVuc(5,0,"Bạc Liêu"), new KhuVuc(37,0,"Lào Cai"),
                new KhuVuc(6,0,"Bắc Ninh"), new KhuVuc(38,0,"Long An"),
                new KhuVuc(7,0,"Bến Tre "), new KhuVuc(39,0,"Nam Định"),
                new KhuVuc(8,0,"Bình Định"), new KhuVuc(40,0,"Nghệ An"),
                new KhuVuc(9,0,"Bình Dương"), new KhuVuc(41,0,"Ninh Bình"),
                new KhuVuc(10,0,"Bình Phước"), new KhuVuc(42,0,"Ninh Thuận"),
                new KhuVuc(11,0,"Bình Thuận"), new KhuVuc(43,0,"Phú Thọ"),
                new KhuVuc(12,0,"Cà Mau"), new KhuVuc(44,0,"Phú Yên"),
                new KhuVuc(13,0,"Cần Thơ "), new KhuVuc(45,0,"Quảng Bình"),
                new KhuVuc(14,0,"Cao Bằng"), new KhuVuc(46,0,"Quảng Nam"),
                new KhuVuc(15,0,"Đà Nẵng"), new KhuVuc(47,0,"Quảng Ngãi"),
                new KhuVuc(16,0,"Đắk Lắk"), new KhuVuc(48,0,"Quảng Ninh"),
                new KhuVuc(17,0,"Đắk Nông"), new KhuVuc(49,0,"Quảng Trị"),
                new KhuVuc(18,0,"Điện Biên"), new KhuVuc(50,0,"Sóc Trăng"),
                new KhuVuc(19,0,"Đồng Nai"), new KhuVuc(51,0,"Sơn La"),
                new KhuVuc(20,0,"Đồng Tháp"), new KhuVuc(52,0,"Tây Ninh"),
                new KhuVuc(21,0,"Gia Lai "), new KhuVuc(53,0,"Thái Bình"),
                new KhuVuc(22,0,"Hà Giang"), new KhuVuc(54,0,"Thái Nguyên"),
                new KhuVuc(23,0,"Hà Nam"), new KhuVuc(55,0,"Thanh Hóa"),
                new KhuVuc(24,0,"Hà Nội"), new KhuVuc(56,0,"Thừa Thiên Huế"),
                new KhuVuc(25,0,"Hà Tĩnh"), new KhuVuc(57,0,"Tiền Giang"),
                new KhuVuc(26,0,"Hải Dương"), new KhuVuc(58,0,"TP Hồ Chí Minh"),
                new KhuVuc(27,0,"Hải Phòng"), new KhuVuc(59,0,"Trà Vinh"),
                new KhuVuc(28,0,"Hậu Giang"), new KhuVuc(60,0,"Tuyên Quang"),
                new KhuVuc(29,0,"Hòa Bình"), new KhuVuc(61,0,"Vĩnh Long"),
                new KhuVuc(30,0,"Hưng Yên"), new KhuVuc(62,0,"Vĩnh Phúc"),
                new KhuVuc(31,0,"Khánh Hòa"), new KhuVuc(63,0,"Yên Bái"),
                new KhuVuc(32,0,"Kiên Giang"),
                new KhuVuc(64,58,"Quận 1"),
                new KhuVuc(65,58,"Quận 12"),
                new KhuVuc(66,58,"Quận Thủ Đức"),
                new KhuVuc(67,58,"Quận 9"),
                new KhuVuc(68,58,"Quận Gò Vấp"),
                new KhuVuc(69,58,"Quận Bình Thạnh"),
                new KhuVuc(70,58,"Quận Tân Bình"),
                new KhuVuc(71,58,"Quận Tân Phú"),
                new KhuVuc(72,58,"Quận Phú Nhuận"),
                new KhuVuc(73,58,"Quận 2"),
                new KhuVuc(74,58,"Quận 3"),
                new KhuVuc(75,58,"Quận 10"),
                new KhuVuc(76,58,"Quận 11"),
                new KhuVuc(77,58,"Quận 4"),
                new KhuVuc(78,58,"Quận 5"),
                new KhuVuc(79,58,"Quận 6"),
                new KhuVuc(80,58,"Quận 8"),
                new KhuVuc(81,58,"Quận Bình Tân"),
                new KhuVuc(82,58,"Quận 7"),
                new KhuVuc(83,58,"Huyện Củ Chi"),
                new KhuVuc(84,58,"Huyện Hóc Môn"),
                new KhuVuc(85,58,"Huyện Bình Chánh"),
                new KhuVuc(86,58,"Huyện Nhà Bè"),
                new KhuVuc(87,58,"Huyện Cần Giờ"),
            };
            var KhuVucN = 88;
            for (int i = 0; i < 63; i++)
            {
                if (i + 1 != 58) 
                khuvucs.Add(new KhuVuc(KhuVucN + i, i + 1, "Tạm thời chưa có"));
            }

            context.KhuVucs.AddOrUpdate(khuvucs.ToArray());
            #endregion

            #region chucvu
            List<ChucVu> chucvus = new List<ChucVu>();
            ChucVu cv = new ChucVu();
            cv.Id = CommonConstants.CHUC_VU_ADMIN;
            cv.Ten = "Admin";
            cv.GhiChu = "";
            chucvus.Add(cv);

            cv = new ChucVu();
            cv.Id = CommonConstants.CHUC_VU_KHACH_HANG;
            cv.Ten = "Khách hàng";
            cv.GhiChu = "";
            chucvus.Add(cv);           
            context.ChucVus.AddOrUpdate(chucvus.ToArray());
            #endregion

            #region donhang
            List<DonHang> donhangs = new List<DonHang>();
            DonHang dh = new DonHang();
            n = 1;
            dh.Id = n++;
            dh.KhachHangID = 2;
            dh.TinhTrangID = CommonConstants.TINH_TRANG_CHO_DUYET;
            dh.ThanhTien = 30000;
            dh.TenNguoiNhan = "Hoài Thu";
            dh.SoDienThoai = "0343562031";
            dh.DiaChi = "Địa chỉ x";
            dh.KhuVucID = 85;
            dh.PhiShip = 10000;
            dh.Ngay = DateTime.Now;
            dh.NgayGiaoDuKienMin = new DateTime(2019, 7, 1);
            dh.NgayGiaoDuKienMax = new DateTime(2019, 7, 2);
            donhangs.Add(dh);
            context.DonHangs.AddOrUpdate(donhangs.ToArray());
            #endregion

            #region chitietdonhang
            List<ChiTietDonHang> chitietdonhangs = new List<ChiTietDonHang>();
            ChiTietDonHang ctdh = new ChiTietDonHang();
            n = 1;
            ctdh.Id = n++;
            ctdh.SanPhamID = 1;
            ctdh.SoLuong = 2;
            ctdh.GiaOrder = 5000;
            ctdh.DonHangID = 1;
            chitietdonhangs.Add(ctdh);
            ctdh = new ChiTietDonHang();
            ctdh.Id = n++;
            ctdh.SanPhamID = 2;
            ctdh.SoLuong = 2;
            ctdh.GiaOrder = 10000;
            ctdh.DonHangID = 1;
            chitietdonhangs.Add(ctdh);
            context.ChiTietDonHangs.AddOrUpdate(chitietdonhangs.ToArray());
            #endregion

        }

    }
}
