using NomNom.Common;
using NomNom.DAL;
using NomNom.Models.DonHangs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Controllers
{
    public class DonHangController : BaseController
    {
        // GET: DonHang
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dat()
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                var user = (UserLogin)session;
                var dal = new GioHangDAL();
                var kvDAL = new KhuVucDAL();
                var tkDAL = new TaiKhoanDAL();
                ViewBag.TaiKhoan = tkDAL.GetForView(user.UserID);
                ViewBag.TinhThanh = kvDAL.GetThanhPho();
                var list = dal.GetGioHang(user.UserID);
                if (list.Count() == 0)
                    return Redirect("/SanPham");
                ViewBag.GioHang = list;
                return View();
            }
            return Redirect("/Home");
        }
        [HttpPost]
        public ActionResult Create(DonHangInput input)
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                var user = (UserLogin)session;
                var dal = new DonHangDAL();
                input.KhachHangID = user.UserID;
                var result = dal.LapDonHang(input);
                Redirect("/DonHang");
            }
            return Redirect("/DangNhap");
        }
        public JsonResult GetQuanHuyen(int Id)
        {
            var dal = new KhuVucDAL();
            var list = dal.GetQuanHuyen(Id);
            return Json(new
            {
                data = list,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
    }
}