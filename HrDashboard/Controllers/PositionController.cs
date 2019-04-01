using AutoMapper;
using HrDashboard.ModelInitialize;
using HrDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HrDashboard.Controllers
{
    public class PositionController : Controller
    {
        HRContext context;
        public PositionController()
        {
            context = new HRContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        public ActionResult PosIndex()
        {
            return View();
        }

        public ActionResult PosEdit(int id)
        {
            var pos = context.Positions.SingleOrDefault(p => p.PosId == id);
            if (pos == null)
            { return HttpNotFound(); }

            return View("PosIndex", pos);
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