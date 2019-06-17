using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models.NhaCungCaps
{
    public class NhaCungCapFilter
    {
        public NhaCungCapFilter(string Ten)
        {
            this.Ten = Ten;
        }
        public string Ten { get; set; }
    }
}