using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.NhaCungCaps
{
    [Table("NhaCungCaps")]
    public class NhaCungCap : BaseModel
    {
        public string Ten { get; set; }
        public string GhiChu { get; set; }
    }
}