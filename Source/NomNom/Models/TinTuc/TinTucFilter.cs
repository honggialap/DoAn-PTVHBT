using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.TinTucs
{
    public class TinTucFilter
    {
        public TinTucFilter(string TieuDe)
        {
            this.TieuDe = TieuDe;
        }
        public string TieuDe { get; set; }
    }
}