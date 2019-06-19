﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.DonHangs
{
    [Table("DonHangs")]
    public class DonHang : BaseModel
    {
        public DateTime Ngay { get; set; }
        public int KhachHangID { get; set; }
        public int TinhTrangID { get; set; }
        public double ThanhTien { get; set; } //Tổng tiền sản phẩm, chưa tính phí ship
        public string TenNguoiNhan { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public int KhuVucID { get; set; }
        public double PhiShip { get; set; }
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