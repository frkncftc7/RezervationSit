using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.UI.Authorization;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeUser(Helpers.Enums.UserRole.Admin)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}