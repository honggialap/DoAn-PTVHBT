using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.LoaiSanPhams
{
    public class LoaiSanPham : BaseModel
    {
        public string Ten { get; set; }
        public string GhiChu { get; set; }
    }
}