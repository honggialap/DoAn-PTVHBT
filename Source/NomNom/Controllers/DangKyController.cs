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
    public class DangKyController : Controller
    {
        // GET: DangKy
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKyThanhCong()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TaiKhoanInput input)
        {
            if (ModelState.IsValid)
            {
                if (input.MatKhau != input.MatKhau2)
                {
                    ModelState.AddModelError("", "Mật khẩu không trùng khớp");
                    return View("Index");
                }
                var dal = new TaiKhoanDAL();
                var result = dal.CreateKH(input);
                if (result == CommonConstants.DANG_KY_TAI_KHOAN_THANH_CONG)
                {
                    return View("DangKyThanhCong");
                }
                else
                {
                    if (result == CommonConstants.DANG_KY_TAI_KHOAN_TEN_TAI_KHOAN_DA_TON_TAI)
                        ModelState.AddModelError("", "Tên tài khoản đã tồn tại");
                    else if (result == CommonConstants.DANG_KY_TAI_KHOAN_EMAIL_DA_TON_TAI)
                        ModelState.AddModelError("", "Địa chỉ Email đã tồn tại");
                    else if (result == CommonConstants.DANG_KY_TAI_KHOAN_THAT_BAI)
                        ModelState.AddModelError("", "Có lỗi xảy ra, vui lòng thử lại trong giây lát");
                    else if (result == CommonConstants.DANG_KY_TAI_KHOAN_MAT_KHAU_DUOI_8)
                        ModelState.AddModelError("", "Mật khẩu phải có ít nhất 8 kí tự");
                }
            }
            return View("Index");
        }
    }
}