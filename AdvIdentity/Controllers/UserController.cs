using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AdvIdentity.Models;
using System.Collections.Generic;

namespace AdvIdentity.Controllers
{
    public class UserController : Controller
    {
        DBAccess DB = new DBAccess();
        // GET: User
        public ActionResult Index()
        {
            return View(DB.GetAllUsers().ToList());
        }
        public ActionResult Details(string ID)
        {
            return View(DB.GetUserById(ID));
        }
    }
}