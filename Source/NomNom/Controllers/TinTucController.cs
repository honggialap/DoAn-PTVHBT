using NomNom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NomNom.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult Index()
        {
            var dal = new TinTucDAL();
            return View();
        }
        public ActionResult ChiTiet(int Id)
        {
            var dal = new TinTucDAL();
            var tintuc = dal.GetForEdit(Id);
            return View(tintuc);
        }
        [HttpGet]
        public JsonResult LoadTinTuc(int skip,int take)
        {
            var dal = new TinTucDAL();
            var data = dal.GetTinTuc(null,skip, take);
            return Json(new
            {
                data = data
            }, JsonRequestBehavior.AllowGet);
        }
    }
}