using Newtonsoft.Json;
using NomNom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult Index()
        {
            var lspDAL = new LoaiSanPhamDAL();
            var thDAL = new ThuongHieuDAL();
            ViewBag.listLoaiSanPham = lspDAL.GetLoaiSanPham(null);
            ViewBag.listThuongHieu = thDAL.GetThuongHieu(null);
            return View();
        }
        public ActionResult ChiTiet(int Id)
        {
            var dal = new SanPhamDAL();
            var input = dal.GetForView(Id);
            return View(input);
        }
        [HttpGet]
        public JsonResult LoadData(string jsonFilter)
        {
            dynamic stuff = JsonConvert.DeserializeObject(jsonFilter);
            var lsp = new List<int>();
            var th = new List<int>();
            var ten = new List<string>();
            var count = (int)stuff.spCount;
            foreach(var item in stuff.LoaiSanPham)
            {
                lsp.Add((int)item);
            }
            foreach (var item in stuff.ThuongHieu)
            {
                th.Add((int)item);
            }
            foreach (var item in stuff.Ten)
            {
                ten.Add((string)item);
            }
            var dal = new SanPhamDAL();
            var result = dal.GetSanPhamArr(lsp,th,ten,count);
            return Json(new
            {
                data = result
            }, JsonRequestBehavior.AllowGet);
        }
    }
}