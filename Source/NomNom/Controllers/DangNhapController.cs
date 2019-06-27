using NomNom.Common;
using NomNom.DAL;
using NomNom.Models.TaiKhoans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Controllers
{
    public class DangNhapController : Controller
    {
        // GET: DangNhap
        public ActionResult Index()
        {
            if (Session[NomNom.Common.CommonConstants.USER_SESSION] == null)
                return View();
            return Redirect("~/home");
        }
        public ActionResult DangNhapThanhCong()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TaiKhoanInput input)
        {
            if (input.MatKhau != null && input.TenTaiKhoan != null)
            {
                var dal = new TaiKhoanDAL();
                var result = dal.Login(input.TenTaiKhoan, input.MatKhau);
                if (result == CommonConstants.DANG_KY_TAI_KHOAN_THANH_CONG)
                {
                    var Login = new UserLogin();
                    Login.UserID = dal.GetId(input.TenTaiKhoan);
                    Login.UserName = input.TenTaiKhoan;
                    var tk = dal.GetForView(Login.UserID);
                    Login.ChucVuID = tk.ChucVuID;
                    if (tk.Ten != null && tk.Ten != "")
                        Login.Name = tk.Ten;
                    else
                        Login.Name = tk.TenTaiKhoan;
                    if (tk.Avatar != null && tk.Avatar != "")
                        Login.Avatar = tk.Avatar;
                    else
                        Login.Avatar = "/assets/image/NoImage.png";
                    Session.Add(CommonConstants.USER_SESSION, Login);
                    return View("DangNhapThanhCong");
                }
                else
                {
                    if (result == CommonConstants.DANG_NHAP_MAT_KHAU_KHONG_DUNG)
                        ModelState.AddModelError("", "Mật khẩu không đúng");
                    else if (result == CommonConstants.DANG_NHAP_TAI_KHOAN_KHONG_TON_TAI)
                        ModelState.AddModelError("", "Tài khoản không tồn tại");
                    else if (result == CommonConstants.DANG_NHAP_TAI_KHOAN_BI_KHOA)
                        ModelState.AddModelError("", "Tài khoản đã bị khóa");
                }
            }            
            return View("Index");
        }
    }
}