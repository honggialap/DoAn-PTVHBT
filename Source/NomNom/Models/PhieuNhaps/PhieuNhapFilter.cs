using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.PhieuNhaps
{
    public class PhieuNhapFilter
    {
        public DateTime NgayMin { get; set; }
        public DateTime NgayMax { get; set; }
        public int NhaCungCapID { get; set; }     
    }
}