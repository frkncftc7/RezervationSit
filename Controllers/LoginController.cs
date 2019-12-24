using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSite.Data;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Name, string Surname, string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                DBRezervasyon db = new DBRezervasyon();
                Kullanicilar hasUser = db.Kullanicilar.Include(n => n.Roller).Where(n => n.Email == Email && n.Password == Password).FirstOrDefault();
                if (hasUser != null)
                {
                    HttpContext.Session.SetInt32("UserID", hasUser.Id);
                    HttpContext.Session.SetInt32("UserRole", hasUser.Roller.FirstOrDefault().RoleId.Value);
                    HttpContext.Session.SetString("UserEmail", hasUser.Email);
                    return Redirect("/rezervasyon");
                }
                else
                {
                    ModelState.AddModelError("hata", "Kullanıcı Bulunamadı");
                    return View();
                }
            }
            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}