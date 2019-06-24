using NomNom.Common;
using NomNom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NomNom.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
               filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "DangNhap", action = "Index"}));             
            }
            else
            {
                var userLogin = (UserLogin)session;
                var dal = new TaiKhoanDAL();
                var user = dal.GetForView(userLogin.UserID);
                if (user.IsBan)
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "DangNhap", action = "Index"}));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}