using NomNom.Areas.Admin.Models;
using NomNom.Common;
using NomNom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            if ((UserLogin)Session[CommonConstants.ADMIN_SESSION] !=null)
                return Redirect("/Admin/Home");
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Abandon();
            return View("Index");
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dal = new TaiKhoanDAL();
                var result = dal.LoginAdmin(model.TenTaiKhoan, model.MatKhau);
                if (result)
                {
                    var Login = new UserLogin();
                    Login.UserID = dal.GetId(model.TenTaiKhoan);
                    Login.UserName = model.TenTaiKhoan;
                    var tk = dal.GetForView(Login.UserID);
                    if (tk.Ten != null && tk.Ten != "")
                        Login.Name = tk.Ten;
                    else
                        Login.Name = tk.TenTaiKhoan;
                    if (tk.Avatar != null && tk.Avatar != "")
                        Login.Avatar = tk.Avatar;
                    else
                        Login.Avatar = "/assets/image/NoImage.png";
                    Session.Add(CommonConstants.ADMIN_SESSION, Login);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
                }
            }
            return View("Index");
            
        }
    }
}