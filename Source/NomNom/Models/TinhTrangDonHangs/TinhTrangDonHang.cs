using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.TinhTrangDonHangs
{
    [Table("TinhTrangDonHangs")]
    public class TinhTrangDonHang : BaseModel
    {
        public string Ten { get; set; }
        public string GhiChu { get; set; }
    }
}