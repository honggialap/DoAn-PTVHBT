using NomNom.DAL;
using NomNom.Models.ThongTinWebsites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            var dal = new DonHangDAL();
            var now = DateTime.Now;
            ViewBag.DoanhThuThang = String.Format("{0:0,0}", dal.DoanhThuThang(now.Month, now.Year)); 
            ViewBag.DoanhThuNam = String.Format("{0:0,0}", dal.DoanhThuNam(now.Year));
            ViewBag.DonHangDangCho = dal.DonHangChoDuyet();
            return View();
        }
        [HttpGet]
        public ActionResult ThongTinWebsite()
        {
            var dal = new ThongTinWebsiteDAL();
            var input = dal.Get();
            return View(input);
        }
        [HttpPost]
        public ActionResult ThongTinWebsite(ThongTinWebsiteInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new ThongTinWebsiteDAL();
                var result = dal.Update(input);
                if (result == false)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
                else
                    return RedirectToAction("Index", "Home");
            }
            return View("ThongTinWebsite");
        }
    }
}