using NomNom.Common;
using NomNom.DAL;
using NomNom.Models.DonHangs;
using NomNom.Models.SanPhams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class DonHangController : BaseController
    {
        // GET: Admin/DonHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChoDuyet()
        {
            var dal = new DonHangDAL();
            var filter = new DonHangFilter();
            filter.TinhTrangID = CommonConstants.TINH_TRANG_CHO_DUYET;
            var list = dal.GetDonHang(filter);
            return View(list);
        }
        public ActionResult DaDuyet()
        {
            var dal = new DonHangDAL();
            var filter = new DonHangFilter();
            filter.TinhTrangID = CommonConstants.TINH_TRANG_DA_DUYET;
            var list = dal.GetDonHang(filter);
            return View(list);
        }
        public ActionResult DangGiao()
        {
            var dal = new DonHangDAL();
            var filter = new DonHangFilter();
            filter.TinhTrangID = CommonConstants.TINH_TRANG_DANG_GIAO;
            var list = dal.GetDonHang(filter);
            return View(list);
        }
        public ActionResult DaHoanTat()
        {
            var dal = new DonHangDAL();
            var filter = new DonHangFilter();
            filter.TinhTrangID = CommonConstants.TINH_TRANG_HOAN_TAT;
            var list = dal.GetDonHang(filter);
            return View(list);
        }
        public ActionResult DaHuy()
        {
            var dal = new DonHangDAL();
            var filter = new DonHangFilter();
            filter.TinhTrangID = CommonConstants.TINH_TRANG_DA_HUY;
            var list = dal.GetDonHang(filter);
            return View(list);
        }
        public ActionResult ChiTiet(int Id)
        {
            var dal = new DonHangDAL();
            var result = dal.GetForView(Id);
            if (result != null)
            {
                ViewBag.listSanPham = dal.GetChiTietsForView(Id);
                return View(result);
            }
            return Redirect("/Admin/DonHang/Index");
        }
        public ActionResult Duyet (int Id)
        {
            var dal = new DonHangDAL();
            var result = dal.Duyet(Id);
            if (result)
                return Redirect("/Admin/DonHang/ChoDuyet");
            else
                return Redirect("/Admin/DonHang/ChoDuyet");
        }
        public ActionResult Giao(int Id)
        {
            var dal = new DonHangDAL();
            var result = dal.Giao(Id);
            if (result)
                return Redirect("/Admin/DonHang/DaDuyet");
            else
                return Redirect("/Admin/DonHang/DaDuyet");
        }
        public ActionResult HoanTat(int Id)
        {
            var dal = new DonHangDAL();
            var result = dal.HoanTat(Id);
            if (result)
                return Redirect("/Admin/DonHang/DangGiao");
            else
                return Redirect("/Admin/DonHang/DangGiao");
        }
        public ActionResult Huy(int Id,string redirect)
        {
            var dal = new DonHangDAL();
            var result = dal.Huy(Id);
            if (result)
                return Redirect("/Admin/DonHang/"+ redirect);
            else
                return Redirect("/Admin/DonHang/"+ redirect);
        }
    }
}