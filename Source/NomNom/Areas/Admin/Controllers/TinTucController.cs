using NomNom.DAL;
using NomNom.Models.TinTucs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class TinTucController : BaseController
    {
        // GET: Admin/TinTuc
        public ActionResult Index()
        {
            var dal = new TinTucDAL();
            var list = dal.GetTinTuc(null);
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TinTucInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new TinTucDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
                else
                    return Redirect("/Admin/TinTuc");
            }
            return View("Create");
        }
        public ActionResult Delete(int Id)
        {
            var dal = new TinTucDAL();
            var result = dal.Delete(Id);
            if (result)
                return RedirectToAction("Index", "TinTuc");
            else
                //return view báo lỗi
                return RedirectToAction("Index", "TinTuc");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var dal = new TinTucDAL();
            var input = dal.GetForEdit(Id);
            if (input == null)
                return Redirect("/Admin/TinTuc");
            else
                return View(input);
        }
        [HttpPost]
        public ActionResult Edit(TinTucInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new TinTucDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
                else
                    return Redirect("/Admin/TinTuc");
            }
            return View("Edit");
        }
    }
}