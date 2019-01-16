using HrDashboard.ModelInitialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrDashboard.Controllers
{
    [CustomAuthorize]
    public class BetaListController : Controller
    {
        private HRContext context;
        public BetaListController()
        {
            context = new HRContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: BetaList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewBeta()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var bTeam = context.BetaLists.SingleOrDefault(c => c.Id == id);
            if (bTeam == null) {
                return HttpNotFound();
            }
            return View(bTeam);
        }
    }
}