using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NomNom.Models.ThongTinWebsites
{
    [Table("ThongTinWebsite")]
    public class ThongTinWebsite : BaseModel
    {
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string ThongTin { get; set; }      
    }
}