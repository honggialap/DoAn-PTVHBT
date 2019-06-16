using NomNom.DAL;
using NomNom.Models.SanPhams;
using NomNom.Models.ThuongHieus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult Index()
        {
           
            var spDAL = new SanPhamDAL();
            var lspDAL = new LoaiSanPhamDAL();
            var thDAL = new ThuongHieuDAL();

            var listSanPham = spDAL.GetSanPham(null);
            ViewBag.listLoaiSanPham = lspDAL.GetLoaiSanPham(null);
            ViewBag.listThuongHieu = thDAL.GetThuongHieu(null);
            
            return View(listSanPham);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var lspDAL = new LoaiSanPhamDAL();
            var thDAL = new ThuongHieuDAL();
            ViewBag.listLoaiSanPham = lspDAL.GetLoaiSanPham(null);
            ViewBag.listThuongHieu = thDAL.GetThuongHieu(null);
            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPhamInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new SanPhamDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
                else
                    return RedirectToAction("Index", "SanPham");
            }
            var lspDAL = new LoaiSanPhamDAL();
            var thDAL = new ThuongHieuDAL();
            ViewBag.listLoaiSanPham = lspDAL.GetLoaiSanPham(null);
            ViewBag.listThuongHieu = thDAL.GetThuongHieu(null);
            
            return View("Create",input);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var dal = new SanPhamDAL();
            var input = dal.GetForEdit(Id);
            if (input == null)
                return View("Index");
            else
            {
                var lspDAL = new LoaiSanPhamDAL();
                var thDAL = new ThuongHieuDAL();
                ViewBag.listLoaiSanPham = lspDAL.GetLoaiSanPham(null);
                ViewBag.listThuongHieu = thDAL.GetThuongHieu(null);
                return View(input);
            }
        }
        [HttpPost]
        public ActionResult Edit(SanPhamInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new SanPhamDAL();
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
                else
                    return RedirectToAction("Index", "SanPham");
            }
            var lspDAL = new LoaiSanPhamDAL();
            var thDAL = new ThuongHieuDAL();
            ViewBag.listLoaiSanPham = lspDAL.GetLoaiSanPham(null);
            ViewBag.listThuongHieu = thDAL.GetThuongHieu(null);
            return View("Edit",input);
        }
        public ActionResult Delete(int Id)
        {
            var dal = new SanPhamDAL();
            var result = dal.Delete(Id);
            if (result)
                return RedirectToAction("Index", "SanPham");
            else
                //return view báo lỗi
                return RedirectToAction("Index", "SanPham");
        }
    }
}