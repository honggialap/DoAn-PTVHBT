using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.ChucVus
{
    [Table("ChucVus")]
    public class ChucVu : BaseModel
    {
        public string Ten { get; set; }
        public string GhiChu { get; set; }
    }
}