using NomNom.DAL;
using NomNom.Models.LoaiSanPhams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        // GET: Admin/LoaiSanPham
        public ActionResult Index(string Ten)
        {
            var dal = new LoaiSanPhamDAL();
            var filter = new LoaiSanPhamFilter(Ten);
            return View(dal.GetLoaiSanPham(filter));
        }
    }
}