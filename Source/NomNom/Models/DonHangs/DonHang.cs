using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.DonHangs
{
    [Table("DonHangs")]
    public class DonHang : BaseModel
    {
        public DateTime Ngay { get; set; } // ngày đặt hàng, trường tự tạo
        public int KhachHangID { get; set; }
        public int TinhTrangID { get; set; }
        public double ThanhTien { get; set; } //Tổng tiền sản phẩm, chưa tính phí ship
        public string TenNguoiNhan { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public int KhuVucID { get; set; }
        //tự động được tạo từ bảng khu vực
        public double PhiShip { get; set; }
        // tự dộng được tạo khi đơn hàng được khởi tạo dựa trên ngày đặt và thông tin giao hàng lúc đó (lấy thông tin từ bảng khu vực)
        public DateTime NgayGiaoDuKienMin { get; set; }
        public DateTime NgayGiaoDuKienMax { get; set; }
        public DateTime? NgayHoanTat { get; set; } //ngày đơn hàng đc giao và hoàn tất thanh toán
    }
    [Table("ChiTietDonHangs")]
    public class ChiTietDonHang : BaseModel
    {
        public int DonHangID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuong { get; set; }
        public double GiaOrder { get; set; }
    }

}