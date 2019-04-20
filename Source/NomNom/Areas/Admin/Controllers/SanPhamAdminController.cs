using NomNom.Models.BUS;
using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult Index()
        {
            var db = SanPhamBUS.DanhSachAdmin();
            return View(db);
        }

        // GET: Admin/SanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/SanPham/Create
        public ActionResult Create()
        {
            ViewBag.loai_id = new SelectList(LoaiSanPhamBUS.DanhSach(), "id", "ten");
            ViewBag.thuonghieu_id = new SelectList(ThuongHieuBUS.DanhSach(), "id", "ten");
            return View();
        }

        // POST: Admin/SanPham/Create
        [HttpPost]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    sp.hinhanh = sp.id+".png";
                    string fullpathwithfilename = "~/Images/" + sp.hinhanh ;
                    hpf.SaveAs(Server.MapPath(fullpathwithfilename));
                    
                }
                SanPhamBUS.Them(sp);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Cập nhật csdl thất bại");
                //return RedirectToAction("error", "Shared");
                //return View();
            }
        }

        // GET: Admin/SanPham/Edit/5
        public ActionResult Edit(string id)
        {           
            var db = SanPhamBUS.ChiTiet(id);
            ViewBag.loai_id = new SelectList(LoaiSanPhamBUS.DanhSach(), "id", "ten", db.loai_id);
            ViewBag.thuonghieu_id = new SelectList(ThuongHieuBUS.DanhSach(), "id", "ten", db.thuonghieu_id);
            return View(db);
        }

        // POST: Admin/SanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(SanPham sp)
        {
            try
            {
                sp.hinhanh = sp.id + ".png";
                var hpf = HttpContext.Request.Files[0];
                if (hpf.ContentLength > 0)
                {
                    sp.hinhanh = sp.id + ".png";
                    string fullpathwithfilename = "~/Images/" + sp.hinhanh;
                    hpf.SaveAs(Server.MapPath(fullpathwithfilename));
                }    
                SanPhamBUS.CapNhat(sp);             
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Cập nhật csdl thất bại");
                //return View();
            }
        }

        // GET: Admin/SanPham/Delete/5
        public ActionResult Delete(string id)
        {
            var db = SanPhamBUS.ChiTiet(id);
            ViewBag.loai_id = new SelectList(LoaiSanPhamBUS.DanhSach(), "id", "ten", db.loai_id);
            ViewBag.thuonghieu_id = new SelectList(ThuongHieuBUS.DanhSach(), "id", "ten", db.thuonghieu_id);
            return View(db);
        }

        // POST: Admin/SanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(SanPham sp)
        {
            try
            {
                sp.hinhanh = sp.id + ".png";
                sp.tinhtrang = 0;
                SanPhamBUS.CapNhat(sp);
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Cập nhật csdl thất bại");
                //return View();
            }
        }
    }
}
