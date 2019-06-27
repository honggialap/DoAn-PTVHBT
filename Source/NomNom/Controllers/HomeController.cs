using NomNom.Common;
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
            var tintucDAL = new TinTucDAL();
            ViewBag.listMoiNhat = dal.SanPhamMoiNhat();
            ViewBag.listQuanTam = dal.SanPhamDuocQuanTam();
            ViewBag.listBanChay = dal.SanPhamBanChay();
            ViewBag.listTinTuc = tintucDAL.GetTinTuc(null,0,CommonConstants.SO_TIN_TUC);
            return View();
        }
        public ActionResult LienHe()
        {
            var dal = new ThongTinWebsiteDAL();
            return View(dal.Get());
        }
    }
}