using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrDashboard.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        public ActionResult PosIndex()
        {
            return View();
        }

        public ActionResult ActivePositions()
        {
            return View();
        }

        public ActionResult VacantPositions()
        {
            return View();
        }

        public ActionResult InactivePosition()
        {
            return View();
        }
    }
}