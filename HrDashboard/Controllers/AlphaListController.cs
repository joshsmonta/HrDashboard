using HrDashboard.ModelInitialize;
using HrDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrDashboard.Controllers
{
    [CustomAuthorize(Roles = RoleName.Admin)]
    public class AlphaListController : Controller
    {
        HRContext context;
        public AlphaListController()
        {
            context = new HRContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewAlpha()
        {
            return View();
        }

        public ActionResult Retirees()
        {
            return View();
        }

        public ActionResult ATDetails(int id)
        {
            var aTeam = context.AlphaLists.SingleOrDefault(c => c.Id == id);
            if (aTeam == null)
            {
                return HttpNotFound();
            }
            return View(aTeam);
        }
        
    }
}