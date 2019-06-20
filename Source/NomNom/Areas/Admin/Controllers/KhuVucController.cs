using NomNom.DAL;
using NomNom.Models.KhuVucs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class KhuVucController : BaseController
    {
        // GET: Admin/KhuVuc
        public ActionResult Index()
        {
            var dal = new KhuVucDAL();         
            return View(dal.GetThanhPho());
        }
        public ActionResult TinhThanh(int Id)
        {
            var dal = new KhuVucDAL();
            ViewBag.ThanhPho = dal.GetForView(Id);
            var list = dal.GetQuanHuyen(Id);
            if (list == null)
                return RedirectToAction("Index","KhuVuc");
            else
            return View(list);
        }
        [HttpGet]
        public ActionResult Create(int tpId)
        {
            var dal = new KhuVucDAL();
            ViewBag.ThanhPho = dal.GetForView(tpId);
            var input = new KhuVucInput();
            input.ParentID = tpId;
            return View(input);            
        }
        [HttpPost]
        public ActionResult Create(KhuVucInput input)
        {
            var dal = new KhuVucDAL();
            if (ModelState.IsValid)
            {
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Tạo mới thất bại");
                }
                else
                    return RedirectToAction("TinhThanh", "KhuVuc", new { Id = input.ParentID });
            }
            ViewBag.ThanhPho = dal.GetForView(input.ParentID);
            return View("Create", input);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var dal = new KhuVucDAL();
            var input = dal.GetForEdit(Id);
            if (input == null)
                return RedirectToAction("Index", "KhuVuc");
            else
            {
                ViewBag.ThanhPho = dal.GetForView(input.ParentID);
                return View(input);
            }
        }
        [HttpPost]
        public ActionResult Edit(KhuVucInput input)
        {
            var dal = new KhuVucDAL();
            if (ModelState.IsValid)
            {              
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Cập nhật thất bại");
                }
                else
                    return RedirectToAction("TinhThanh", "KhuVuc",new { Id=input.ParentID});
            }          
            ViewBag.ThanhPho = dal.GetForView(input.ParentID);
            return View("Edit",input);
        }
        public ActionResult Delete(int Id)
        {
            var dal = new KhuVucDAL();
            var tpID = dal.GetForView(Id).ParentID;
            var result = dal.Delete(Id);
            if (result)
                return RedirectToAction("TinhThanh", "KhuVuc",new { Id = tpID });
            else
                //return view báo lỗi
                return RedirectToAction("Index", "KhuVuc");
        }

    }
}