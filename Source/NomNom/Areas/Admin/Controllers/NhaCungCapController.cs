using NomNom.DAL;
using NomNom.Models.NhaCungCaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class NhaCungCapController : Controller
    {
        // GET: Admin/NhaCungCap
        public ActionResult Index(string Ten)
        {
            var dal = new NhaCungCapDAL();
            var filter = new NhaCungCapFilter(Ten);
            return View(dal.GetNhaCungCap(filter));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhaCungCapInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new NhaCungCapDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
                else
                    return RedirectToAction("Index", "NhaCungCap");
            }
            return View("Create");
        }
        public ActionResult Delete(int Id)
        {
            var dal = new NhaCungCapDAL();
            var result = dal.Delete(Id);
            if (result)
                return RedirectToAction("Index", "NhaCungCap");
            else
                //return view báo lỗi
                return RedirectToAction("Index", "NhaCungCap");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var dal = new NhaCungCapDAL();
            var input = dal.GetForEdit(Id);
            if (input == null)
                return View("Index");
            else
                return View(input);
        }
        [HttpPost]
        public ActionResult Edit(NhaCungCapInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new NhaCungCapDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
                else
                    return RedirectToAction("Index", "NhaCungCap");
            }
            return View("Edit");
        }
    }
}