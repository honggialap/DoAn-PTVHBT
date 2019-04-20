using NomNom.Models.BUS;
using NomNomConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class NhaCungCapAdminController : Controller
    {
        // GET: Admin/NhaCungCap
        public ActionResult Index()
        {
            var db = NhaCungCapBUS.DanhSachAdmin();
            return View(db);
        }

        // GET: Admin/NhaCungCap/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/NhaCungCap/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NhaCungCap/Create
        [HttpPost]
        public ActionResult Create(NhaCungCap ncc)
        {
            try
            {
                NhaCungCapBUS.Them(ncc);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/NhaCungCap/Edit/5
        public ActionResult Edit(string id)
        {
            var db = NhaCungCapBUS.ChiTiet(id);
            return View(db);
        }

        // POST: Admin/NhaCungCap/Edit/5
        [HttpPost]
        public ActionResult Edit(string id,FormCollection form)
        {
            try
            {
                // TODO: Add update logic here
                var ncc = new NhaCungCap();
                ncc.id = form["id"].ToString();
                ncc.ten = form["ten"].ToString();
                ncc.tinhtrang = Convert.ToInt32(form["tinhtrang"].ToString());
                NhaCungCapBUS.CapNhat(ncc);
                return RedirectToAction("Index");
            }
            catch
            {
               
                return View();
            }
        }

        // GET: Admin/NhaCungCap/Delete/5
        public ActionResult Delete(string id)
        {
            var db = NhaCungCapBUS.ChiTiet(id);
            db.tinhtrang = 0;
            return View(db);
        }

        // POST: Admin/NhaCungCap/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                // TODO: Add delete logic here
                var ncc = new NhaCungCap();
                ncc.id = form["id"].ToString();
                ncc.ten = form["ten"].ToString();
                ncc.tinhtrang = Convert.ToInt32(form["tinhtrang"].ToString());
                NhaCungCapBUS.CapNhat(ncc);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
