using NomNom.DAL;
using NomNom.Models.TaiKhoans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        // GET: Admin/TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TaiKhoanInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new TaiKhoanDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Thêm tài khoản thất bại.");
                }
                else
                    return RedirectToAction("Index", "TaiKhoan");
            }
            return View("Index");
        }
    }
}