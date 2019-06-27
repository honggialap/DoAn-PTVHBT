using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Models.TinTucs
{
    [Table("TinTucs")]
    public class TinTuc : BaseModel
    {
        public string TieuDe { get; set; }
        public string MieuTa { get; set; } //miêu tả ngắn gọn về tin tức
        public string HinhAnh { get; set; }     
        public string NoiDung { get; set; } //Nội dung đầy đủ
        public DateTime Ngay { get; set; }
        public int SoView { get; set; }
        public string GhiChu { get; set; }
    }
}