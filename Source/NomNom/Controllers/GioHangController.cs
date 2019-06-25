using NomNom.Common;
using NomNom.DAL;
using NomNom.Models.GioHangs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Controllers
{
    public class GioHangController : BaseController
    {
        // GET: GioHang
        public ActionResult Index()
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                var user = (UserLogin)session;
                var dal = new GioHangDAL();
                return View(dal.GetGioHang(user.UserID));
            }
            return Redirect("/Home");
        }
        public JsonResult SoLuong()
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                var user = (UserLogin)session;
                var dal = new GioHangDAL();
                var rs = dal.SoLuong(user.UserID);
                return Json(new
                {
                    data = rs
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                data = 0
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Them(int SanPhamID)
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                var user = (UserLogin)session;
                var dal = new GioHangDAL();
                var input = new GioHang();
                input.SanPhamID = SanPhamID;
                input.TaiKhoanID = user.UserID;
                input.SoLuong = 1;
                var rs = dal.Add(input);
                return Json(new
                {
                    status = rs
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                status = CommonConstants.GIO_HANG_THEM_THAT_BAI
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateSoLuong(int SanPhamID,int SoLuong)
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                var user = (UserLogin)session;
                var dal = new GioHangDAL();
                var input = new GioHang();
                input.SanPhamID = SanPhamID;
                input.TaiKhoanID = user.UserID;
                input.SoLuong = SoLuong;
                var rs = dal.UpdateSoLuong(input);
                return Json(new
                {
                    status = rs
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                status = 0
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Remove(int SanPhamID)
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session != null)
            {
                var user = (UserLogin)session;
                var dal = new GioHangDAL();
                var rs = dal.Remove(user.UserID, SanPhamID);
                return Json(new
                {
                    status = rs
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                status = 1
            }, JsonRequestBehavior.AllowGet);
        }
    }
}