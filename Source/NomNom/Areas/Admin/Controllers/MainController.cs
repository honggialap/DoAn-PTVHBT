using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using NomNom.Models;

namespace NomNom.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    
    public class MainController : Controller
    {
        ApplicationDbContext context;

        
        public ActionResult Index()
        {
          
            return View();
        }
    }
}
