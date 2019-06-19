using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.DonHangs
{
    public class DonHangFilter
    {
        public DonHangFilter(string Ten)
        {
            this.Ten = Ten;
        }
        public string Ten { get; set; }
    }
}