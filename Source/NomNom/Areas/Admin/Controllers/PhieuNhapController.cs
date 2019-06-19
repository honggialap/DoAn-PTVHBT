using Newtonsoft.Json;
using NomNom.DAL;
using NomNom.Models.PhieuNhaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NomNom.Areas.Admin.Controllers
{
    public class PhieuNhapController : BaseController
    {
        // GET: Admin/PhieuNhap
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult LoadData()
        {
            var dal = new PhieuNhapDAL();
            var result = dal.GetPhieuNhap(null);
            return Json(new
            {
                data = result,
                status = true
            },JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var nccDAL = new NhaCungCapDAL();
            ViewBag.listNCC = nccDAL.GetNhaCungCap(null);
            return View();
        }
        [HttpPost]
        public ActionResult Create(PhieuNhapInput input)
        {
            if (ModelState.IsValid)
            {
                var dal = new PhieuNhapDAL();              
                var result = dal.CreateOrEdit(input);
                if (result == 0)
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
                else
                    return RedirectToAction("Index", "PhieuNhap");
            }
            var nccDAL = new NhaCungCapDAL();
            ViewBag.listNCC = nccDAL.GetNhaCungCap(null);
            return View();
        }
        [HttpPost]
        public JsonResult JsonCreate(string jsonInput)
        {
            var input = new PhieuNhapInput(jsonInput);
            var dal = new PhieuNhapDAL();
            var result = dal.CreateOrEdit(input);
            var status = false;
            if (result == 0)
                status = false;
            else
                status = true;
            return Json(new {
                status = status
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var dal = new PhieuNhapDAL();
            var input = dal.GetForEdit(Id);
            if (input == null)
                return View("Index");
            else
            {
                var nccDAL = new NhaCungCapDAL();
                var spDAL = new SanPhamDAL();
                var listChiTiets = new List<ChiTietPhieuNhapDTO>();
                foreach(var item in input.ChiTiets)
                {
                    var chitiet = new ChiTietPhieuNhapDTO();
                    chitiet.SanPhamID = item.SanPhamID;
                    chitiet.SoLuong = item.SoLuong;
                    chitiet.GiaNhap = item.GiaNhap;
                    chitiet.Id = item.Id;
                    chitiet.SanPhamTen = spDAL.GetForEdit(chitiet.SanPhamID).Ten;
                    listChiTiets.Add(chitiet);
                }          
                ViewBag.listNCC = nccDAL.GetNhaCungCap(null);
                ViewBag.listChiTiet = JsonConvert.SerializeObject(listChiTiets);           
                return View(input);
            }
           
            
        }
    }
}