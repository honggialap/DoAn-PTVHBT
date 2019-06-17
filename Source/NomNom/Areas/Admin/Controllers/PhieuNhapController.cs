using NomNom.DAL;
using NomNom.Models.PhieuNhaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class PhieuNhapController : Controller
    {
        // GET: Admin/PhieuNhap
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData()
        {
            var dal = new PhieuNhapDAL();
            var result = dal.GetPhieuNhap
                (null);
            return Json(new
            {
                data = result,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var nccDAL = new NhaCungCapDAL();
            ViewBag.listNCC = nccDAL.GetNhaCungCap(null);
            return View();
        }
        [HttpPost]
        public ActionResult Create(PhieuNhapInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new PhieuNhapDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
                else
                    return RedirectToAction("Index", "PhieuNhap");
            }
            var nccDAL = new NhaCungCapDAL();
            ViewBag.listNCC = nccDAL.GetNhaCungCap(null);
            return View();
        }
       
    }
}