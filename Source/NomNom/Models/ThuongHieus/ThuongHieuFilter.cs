using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.ThuongHieus
{
    public class ThuongHieuFilter
    {
        public ThuongHieuFilter(string Ten)
        {
            this.Ten = Ten;
        }
        public string Ten { get; set; }
    }
}