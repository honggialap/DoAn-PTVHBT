using NomNom.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.KhuVucs
{
    [Table("KhuVucs")]
    public class KhuVuc : BaseModel
    {
        //=0 sử dụng cho các thành phố, tỉnh thành
        //!= sử dụng cho các quận huyện    
        public int ParentID { get; set; } 
        public string Ten { get; set; }
        public int ThoiGianShipMin { get; set; }
        public int ThoiGianShipMax { get; set; }
        public double PhiShip { get; set; }
        public string GhiChu { get; set; }
        public bool HoatDong { get; set; }
        public KhuVuc()
        {
            ParentID = 0;
            ThoiGianShipMax = CommonConstants.THOI_GIAN_SHIP_MAX_MACDINH;
            ThoiGianShipMin = CommonConstants.THOI_GIAN_SHIP_MIN_MACDINH;
            PhiShip = CommonConstants.PHI_SHIP_MACDINH;
            HoatDong = false; // mặc định = false, không ship đến khu vực này
        }
        public KhuVuc(int Id,int ParentID, string Ten) //constructor để tạo seeds, dont use this
        {
            this.Id = Id;
            this.ParentID = ParentID;
            this.ThoiGianShipMax = CommonConstants.THOI_GIAN_SHIP_MAX_MACDINH;
            this.ThoiGianShipMin = CommonConstants.THOI_GIAN_SHIP_MIN_MACDINH;
            this.PhiShip = CommonConstants.PHI_SHIP_MACDINH;
            this.HoatDong = false;
            this.Ten = Ten;
        }
    }
}