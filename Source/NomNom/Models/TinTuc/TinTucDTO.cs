using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Models.TinTucs
{
    public class TinTucDTO: Entity<int>
    {
        public string TieuDe { get; set; }
        public string MieuTa { get; set; } //miêu tả ngắn gọn về tin tức
        public string HinhAnh { get; set; }
        [AllowHtml]
        public string NoiDung { get; set; } //Nội dung đầy đủ
        public DateTime Ngay { get; set; }
        public int SoView { get; set; }
        public string GhiChu { get; set; }
    }
}