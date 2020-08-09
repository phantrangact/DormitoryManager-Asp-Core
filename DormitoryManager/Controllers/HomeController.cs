using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DormitoryManager.Models;
using DormitoryManager.Extensions;
using Microsoft.AspNetCore.Authorization;


namespace DormitoryManager.Controllers
{

    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            //var email = User.GetSpecificClaim("FullName");
            return new RedirectResult("/Admin/Account");
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
