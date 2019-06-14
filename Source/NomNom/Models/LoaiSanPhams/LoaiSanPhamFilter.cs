using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.LoaiSanPhams
{
    public class LoaiSanPhamFilter
    {
        public string Ten { get; set; }
        public LoaiSanPhamFilter(string Ten)
        {
            this.Ten = Ten;
        }
    }
}