using Microsoft.AspNet.Identity;
using NomNom.Models.BUS;
using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Controllers
{
    [Authorize]
    public class GioHangController : Controller
    {
        // GET: GioHang
        public ActionResult Index()
        {
            var dsgiohang = GioHangBUS.DanhSach(User.Identity.GetUserId());
            List<SanPham> dssanpham = new List<SanPham>();
            ViewBag.Tongtien = 0;
            foreach (var item in dsgiohang)
            {
                var sp = SanPhamBUS.ChiTiet(item.sanpham_id);
                sp.soluongton = item.soluong;
                dssanpham.Add(sp);
                ViewBag.Tongtien += sp.soluongton * sp.giaban;
            }
            return View(dssanpham);
        }

        // GET: GioHang/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GioHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GioHang/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GioHang/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GioHang/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: GioHang/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GioHang/Delete/5
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
        [HttpPost]
        public ActionResult Them(string sanpham_id,int soluong)
        {
            try
            {
                // TODO: Add update logic here
                GioHangBUS.Them(User.Identity.GetUserId(), sanpham_id, soluong);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CapNhat(string sanpham_id, int soluong)
        {
            try
            {
                // TODO: Add update logic here
                GioHangBUS.CapNhat(User.Identity.GetUserId(), sanpham_id, soluong);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Xoa(string sanpham_id)
        {
            try
            {
                // TODO: Add update logic here
                GioHangBUS.Xoa(User.Identity.GetUserId(), sanpham_id);
                return RedirectToAction("Index");
            }
            catch
            {
                return Content("Có lỗi xảy ra");
            }
        }
    }
}
