using NomNom.Models.BUS;
using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class ThuongHieuAdminController : Controller
    {
        // GET: Admin/ThuongHieu
        public ActionResult Index()
        {
            var db = ThuongHieuBUS.DanhSachAdmin();
            return View(db);
        }

        // GET: Admin/ThuongHieu/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ThuongHieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ThuongHieu/Create
        [HttpPost]
        public ActionResult Create(ThuongHieu th)
        {
            try
            {
                ThuongHieuBUS.Them(th);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ThuongHieu/Edit/5
        public ActionResult Edit(string id)
        {
            var db = ThuongHieuBUS.ChiTiet(id);
            return View(db);
        }

        // POST: Admin/ThuongHieu/Edit/5
        [HttpPost]
        public ActionResult Edit(string id,FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                var th = new ThuongHieu();
                th.id = form["id"].ToString();
                th.ten = form["ten"].ToString();
                th.tinhtrang = Convert.ToInt32(form["tinhtrang"].ToString());
                ThuongHieuBUS.CapNhat(th);
                return RedirectToAction("Index");
            }
            catch
            {
               
                return View();
            }
        }

        // GET: Admin/ThuongHieu/Delete/5
        public ActionResult Delete(string id)
        {
            var db = ThuongHieuBUS.ChiTiet(id);
            db.tinhtrang = 0;
            return View(db);
        }

        // POST: Admin/ThuongHieu/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                var th = new ThuongHieu();
                th.id = form["id"].ToString();
                th.ten = form["ten"].ToString();
                th.tinhtrang = Convert.ToInt32(form["tinhtrang"].ToString());
                ThuongHieuBUS.CapNhat(th);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
