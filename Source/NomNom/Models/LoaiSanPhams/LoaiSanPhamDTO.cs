using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.LoaiSanPhams
{
    public class LoaiSanPhamDTO: Entity<int>
    {
        public string Ten { get; set; }
        public string GhiChu { get; set; }
    }
}