using NomNom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dal = new SanPhamDAL();
            ViewBag.listMoiNhat = dal.SanPhamMoiNhat();
            ViewBag.listQuanTam = dal.SanPhamDuocQuanTam();
            ViewBag.listBanChay = dal.SanPhamBanChay();
            return View();
        }
       
    }
}