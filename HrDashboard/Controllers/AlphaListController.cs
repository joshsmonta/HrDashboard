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

        [HttpPost]
        public JsonResult Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                                                            //Use the following properties to get file's name, size and MIMEType
                int fileSize = file.ContentLength;
                string fileName = file.FileName;
                string mimeType = file.ContentType;
                System.IO.Stream fileContent = file.InputStream;
                //To save file, use SaveAs method
                file.SaveAs(Server.MapPath("~/Content/upload/images/") + fileName); //File will be saved in application root
            }
            return Json("Uploaded " + Request.Files.Count + " files");
        }
    }
}