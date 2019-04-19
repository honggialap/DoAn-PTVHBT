using NomNom.Models.BUS;
using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class LoaiSanPhamAdminController : Controller
    {
        // GET: Admin/LoaiSanPham
        public ActionResult Index()
        {
            var db = LoaiSanPhamBUS.DanhSachAdmin();
            return View(db);
        }

        // GET: Admin/LoaiSanPham/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/LoaiSanPham/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LoaiSanPham/Create
        [HttpPost]
        public ActionResult Create(LoaiSanPham lsp)
        {
            try
            {
                LoaiSanPhamBUS.Them(lsp);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/LoaiSanPham/Edit/5
        public ActionResult Edit(string id)
        {
            var db = LoaiSanPhamBUS.ChiTiet(id);
            return View(db);
        }

        // POST: Admin/LoaiSanPham/Edit/5
        [HttpPost]
        public ActionResult Edit(string id,FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                var lsp = new LoaiSanPham();
                lsp.id = form["id"].ToString();
                lsp.ten = form["ten"].ToString();
                lsp.tinhtrang = Convert.ToInt32(form["tinhtrang"].ToString());
                LoaiSanPhamBUS.CapNhat(lsp);
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Nothing");
                //return View();
            }
        }

        // GET: Admin/LoaiSanPham/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/LoaiSanPham/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
