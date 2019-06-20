using NomNom.DAL;
using NomNom.Models.TaiKhoans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Areas.Admin.Controllers
{
    public class TaiKhoanController : BaseController
    {
        // GET: Admin/TaiKhoan
        public ActionResult Index()
        {
            var dal = new TaiKhoanDAL();
            return View(dal.GetTaiKhoan(null));
        }
        public ActionResult Khoa(int Id)
        {
            var dal = new TaiKhoanDAL();
            var result = dal.Ban(Id, true);
            return Redirect("/Admin/TaiKhoan");
        }
        public ActionResult MoKhoa(int Id)
        {
            var dal = new TaiKhoanDAL();
            var result = dal.Ban(Id, false);
            return Redirect("/Admin/TaiKhoan");
        }
        public ActionResult ChiTiet(int Id)
        {
            var dal = new TaiKhoanDAL();
            var result = dal.GetForView(Id);
            if (result!=null)
                return View(result);
            return Redirect("/Admin/TaiKhoan");
        }
    }
}