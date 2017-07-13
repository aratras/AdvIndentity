using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using AdvIdentity.Models;
using AspNet.Identity.MySQL;

namespace AdvIdentity.Controllers
{
    public class UserController : Controller
    {
        List<ApplicationUser> Users = new List<ApplicationUser>();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}