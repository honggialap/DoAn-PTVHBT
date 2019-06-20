using NomNom.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models.KhuVucs
{
    public class KhuVucInput:Entity<int>
    {
        public int ParentID { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên khu vực")]
        [Display(Name = "Tên khu vực")]
        public string Ten { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá trị")]
        [Display(Name = "Thời gian ship nhanh nhất")]
        public int ThoiGianShipMin { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá trị")]
        [Display(Name = "Thời gian ship trễ nhất")]
        public int ThoiGianShipMax { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá trị")]
        [Display(Name = "Phí ship")]
        public double PhiShip { get; set; }
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }
        [Display(Name = "Hoạt động")]
        public bool HoatDong { get; set; }
        public KhuVucInput()
        {
            ParentID = 0;
            ThoiGianShipMax = CommonConstants.THOI_GIAN_SHIP_MAX_MACDINH;
            ThoiGianShipMin = CommonConstants.THOI_GIAN_SHIP_MIN_MACDINH;
            PhiShip = CommonConstants.PHI_SHIP_MACDINH;
            HoatDong = false; 
        }
    }
}