using NomNom.DAL;
using NomNom.Models.LoaiSanPhams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : BaseController
    {
        // GET: Admin/LoaiSanPham
        public ActionResult Index(string Ten)
        {
            var dal = new LoaiSanPhamDAL();
            var filter = new LoaiSanPhamFilter(Ten);
            return View(dal.GetLoaiSanPham(filter));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(LoaiSanPhamInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new LoaiSanPhamDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
                else
                    return RedirectToAction("Index", "LoaiSanPham");
            }
            return View("Create");
        }
        public ActionResult Delete(int Id)
        {
            var dal = new LoaiSanPhamDAL();
            var result = dal.Delete(Id);
            if (result)
                return RedirectToAction("Index", "LoaiSanPham");
            else
                //return view báo lỗi
                return RedirectToAction("Index", "LoaiSanPham");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var dal = new LoaiSanPhamDAL();
            var input = dal.GetForEdit(Id);
            if (input == null)
                return View("Index");
            else
                return View(input);
        }
        [HttpPost]
        public ActionResult Edit(LoaiSanPhamInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new LoaiSanPhamDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
                else
                    return RedirectToAction("Index", "LoaiSanPham");
            }
            return View("Edit");
        }
    }
}