using NomNom.Models.BUS;
using PagedList;
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
        public ActionResult Index(int page = 1, int pagesize = 9,string loai_id="all")
        {
            IPagedList danhsachsp;
            if (loai_id == "all")
            {
                danhsachsp = SanPhamBUS.DanhSach().ToPagedList(page, pagesize);
            }
            else
            {
                danhsachsp = SanPhamBUS.DanhSachbyloaisanpham(loai_id).ToPagedList(page, pagesize);
            }
                return View(danhsachsp);
        }
        public ActionResult ChiTiet(string id)
        { 
            var chitietsp = SanPhamBUS.ChiTiet(id);
            return View(chitietsp);
        }
    }
}