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
            try
            {
                return View(DB.GetAllAdv());
            }
            catch (Exception)
            {
                return View("ErrorNoEntries");
            }
        }
        public ActionResult ByCreator(string ID)
        {
            try
            {
                ViewBag.Name = DB.GetUserById(ID).Name;
                ViewBag.Surname = DB.GetUserById(ID).Surname;
                return View(DB.GetCreatorsAds(ID));
            }
            catch (Exception)
            {
                return View("ErrorNoEntries");
            }

        }
        public ActionResult YourAds()
        {
            string id = User.Identity.GetUserId();
            try
            {
                return View(DB.GetCreatorsAds(id));
            }
            catch
            {
                return View("ErrorNoCreated");
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(AdvertisementsCreateModel adv)
        {
            if (ModelState.IsValid)
            {
                adv.CreatorId = User.Identity.GetUserId();
                DB.CreateAdv(adv);

                List<AdvertisementsCreateModel> list = DB.GetCreatorsAds(adv.CreatorId).ToList();
                return View("YourAds", list);
            }
            else
            {
                return View("Create", adv);
            }
        }
        public ActionResult Update(int id)
        {
            return View(DB.GetOneAd(id));
        }
        [HttpPost]
        public ActionResult Update(AdvertisementsCreateModel adv)
        {
            if (adv.CreatorId != User.Identity.GetUserId())
            {
                return View("Error");
            }
            if (ModelState.IsValid)
            {
                DB.UpdateAd(adv);
                List<AdvertisementsCreateModel> list = DB.GetCreatorsAds(adv.CreatorId).ToList();
                return View("YourAds", list);
            }
            else
            {
                return View("Update", adv);
            }
        }

        public ActionResult Delete(int id)
        {
            return View(DB.GetOneAd(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            AdvertisementsCreateModel adv = DB.GetOneAd(id);
            if (adv.CreatorId != User.Identity.GetUserId())
            {
                return View("Error");
            }
            else
            {
                DB.DeleteAdv(adv);
                List<AdvertisementsCreateModel> list = DB.GetCreatorsAds(adv.CreatorId).ToList();
                return View("YourAds", list);
            }
        }
        #region Errors
        public ActionResult ErrorAccessDenied()
        {
            return View();
        }
        public ActionResult ErrorNoEntries()
        {
            return View();
        }
        public ActionResult ErrorNoCreated()
        {
            return View();
        }
        #endregion
    }
}