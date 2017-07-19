using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdvIdentity.Models;

namespace AdvIdentity.Controllers
{
    public class AdvertisementsController : Controller
    {
        DBAccess DB = new DBAccess();
        // GET: Advertisements
        public ActionResult List()
        {
            return View(DB.GetAllAdv());
        }
        public ActionResult ByCreator(string ID)
        {
            return View(DB.GetCreatorsAds(ID));
        }
        public ActionResult YourAds()
        {
            string id = User.Identity.GetUserId();
            return View(DB.GetCreatorsAds(id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AdvertisementsCreateModel obj)
        {
            if (ModelState.IsValid)
            {
                obj.CreatorId = User.Identity.GetUserId();
                DB.CreateAdv(obj);
                List<AdvertisementsViewModel> list = DB.GetCreatorsAds(obj.CreatorId).ToList();
                return View("YourAds", list);
            }
            else
            {
                return View("Create",obj);
            }
        }
    }
}