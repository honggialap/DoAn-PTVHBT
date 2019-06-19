using NomNom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class KhoHangController : Controller
    {
        // GET: Admin/KhoHang
        public ActionResult Index()
        {
            var spDAL = new SanPhamDAL();

            var listSanPham = spDAL.GetSanPham(null);
           
            return View(listSanPham);
        }
    }
}