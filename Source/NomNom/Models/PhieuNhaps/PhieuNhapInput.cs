using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.PhieuNhaps
{
    public class ChiTietPhieuNhapInput : Entity<int>
    {
        [Display(Name = "You won't see this")]
        public int PhieuNhapID { get; set; }
        [Display(Name = "Sản phẩm")]
        public int SanPhamID { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
        [Display(Name = "Giá nhập")]
        public double GiaNhap { get; set; }
        public ChiTietPhieuNhapInput(int SanPhamID,int SoLuong,double GiaNhap)
        {
            this.SanPhamID = SanPhamID;
            this.SoLuong = SoLuong;
            this.GiaNhap = GiaNhap;
        }
    }
    public class PhieuNhapInput: Entity<int>
    {   
        [Display(Name="Ngày")]
        public DateTime Ngay { get; set; }
        [Display(Name = "Nhà cung cấp")]
        public int NhaCungCapID { get; set; }
        [Display(Name = "Tổng chi")]
        public double TongChi { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
        [Display(Name = "You won't see this")]
        public List<ChiTietPhieuNhapInput> ChiTiets { get; set; }
        public PhieuNhapInput()
        {

        }
        public PhieuNhapInput(string json)
        {
            JObject jObject = JObject.Parse(json);
            Id = jObject["Id"]==null?0:(int)jObject["Id"];
            Ngay = Convert.ToDateTime(jObject["Ngay"].ToString());
            NhaCungCapID = (int)jObject["NhaCungCapID"];
            GhiChu = jObject["GhiChu"].ToString();
            var temp = jObject["ChiTiets"];
            ChiTiets = new List<ChiTietPhieuNhapInput>();
            foreach (var o in temp.Children<JToken>())
            {
                ChiTiets.Add(new ChiTietPhieuNhapInput((int)o["SanPhamID"], (int)o["SoLuong"], (double)o["GiaNhap"]));
            }
        }
    }
}