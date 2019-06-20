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
            return View();
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