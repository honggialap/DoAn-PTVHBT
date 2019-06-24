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
    public class TaiKhoanController : BaseController
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            var user = (UserLogin)Session[NomNom.Common.CommonConstants.USER_SESSION];
            var dal = new TaiKhoanDAL();
            var input = dal.GetForEdit(user.UserID);
            return View(input);
        }
        [HttpGet]
        public ActionResult DoiMatKhau()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoiMatKhau(FormCollection form)
        {
            if (ModelState.IsValid)
            {
                string MatKhauCu = form["MatKhauCu"].ToString();
                string MatKhauMoi = form["MatKhauMoi"].ToString();
                string MatKhau2 = form["MatKhau2"].ToString();
                if (MatKhauMoi!=MatKhau2)
                    ModelState.AddModelError("", "Mật khẩu không trùng khớp");
                else
                {
                    var dal = new TaiKhoanDAL();
                    var userID = ((UserLogin)Session[NomNom.Common.CommonConstants.USER_SESSION]).UserID;
                    var result = dal.DoiMatKhau(userID, MatKhauCu, MatKhauMoi);
                    if (result == CommonConstants.DOI_MAT_KHAU_THANH_CONG)
                        return Redirect("/TaiKhoan");
                    if (result == CommonConstants.DOI_MAT_KHAU_MAT_KHAU_MOI_DUOI_8)
                        ModelState.AddModelError("", "Mật khẩu mới phải ít nhất 8 kí tự");
                    if (result ==CommonConstants.DOI_MAT_KHAU_MAT_KHAU_CU_KHONG_DUNG)
                        ModelState.AddModelError("", "Mật khẩu cũ không chính xác");
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult CapNhat()
        {
            var user = (UserLogin)Session[NomNom.Common.CommonConstants.USER_SESSION];
            var dal = new TaiKhoanDAL();
            var input = dal.GetForEdit(user.UserID);
            if (input != null)
                return View(input);


            return Redirect("/TaiKhoan/Index");
        }
        [HttpPost]
        public ActionResult CapNhat(TaiKhoanInput input)
        {
            var session = Session[NomNom.Common.CommonConstants.USER_SESSION];
            if (session != null) {
                var user = (UserLogin)session;
               
                    try
                    {
                        var hpf = HttpContext.Request.Files[0];
                        if (hpf.ContentLength > 0)
                        {
                            input.Avatar = "/Assets/image/avatar/"+"USERAVATAR_" +input.Id+".jpg";
                            string fullpathwithfilename = "~"+input.Avatar;
                            hpf.SaveAs(Server.MapPath(fullpathwithfilename));
                        }                     
                    }
                    catch
                    {
                        return Content("Có lỗi xảy ra");
                    }
                
                var dal = new TaiKhoanDAL();
                input.Id = user.UserID;
                var result = dal.UpdateThongTin(input);
                if (result == 1)
                    return Redirect("/TaiKhoan");              
            }
            return View();
        }
        public ActionResult DangXuat()
        {
            Session.Abandon();
            return Redirect("~/home");
        }
    }
}