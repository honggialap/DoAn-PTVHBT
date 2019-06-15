using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.ThuongHieus
{
    [Table("ThuongHieus")]
    public class ThuongHieu : BaseModel
    {
        public string Ten { get; set; }
        public string GhiChu { get; set; }
    }
}