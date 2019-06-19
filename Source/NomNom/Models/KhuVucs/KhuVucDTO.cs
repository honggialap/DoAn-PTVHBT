using NomNom.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.KhuVucs
{
    public class KhuVucDTO: Entity<int>
    {  
        public int ParentID { get; set; }
        public string Ten { get; set; }
        public int ThoiGianShipMin { get; set; }
        public int ThoiGianShipMax { get; set; }
        public double PhiShip { get; set; }
        public string GhiChu { get; set; }
        public bool HoatDong { get; set; }
    }
}