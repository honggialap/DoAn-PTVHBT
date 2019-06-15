using NomNom.DAL;
using NomNom.Models.ThuongHieus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class ThuongHieuController : Controller
    {
        // GET: Admin/ThuongHieu
        public ActionResult Index(string Ten)
        {
            var dal = new ThuongHieuDAL();
            var filter = new ThuongHieuFilter(Ten);
            return View(dal.GetThuongHieu(filter));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ThuongHieuInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new ThuongHieuDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
                else
                    return RedirectToAction("Index", "ThuongHieu");
            }
            return View("Create");
        }
        public ActionResult Delete(int Id)
        {
            var dal = new ThuongHieuDAL();
            var result = dal.Delete(Id);
            if (result)
                return RedirectToAction("Index", "ThuongHieu");
            else
                //return view báo lỗi
                return RedirectToAction("Index", "ThuongHieu");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var dal = new ThuongHieuDAL();
            var input = dal.GetForEdit(Id);
            if (input == null)
                return View("Index");
            else
                return View(input);
        }
        [HttpPost]
        public ActionResult Edit(ThuongHieuInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new ThuongHieuDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
                else
                    return RedirectToAction("Index", "ThuongHieu");
            }
            return View("Edit");
        }
    }
}