using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationSite.Data;
using static WebApplication1.Helpers.Enums;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
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
                bool alreadyRegister = db.Kullanicilar.Where(n => n.Email == Email).Any();
                if(alreadyRegister)
                {
                    ModelState.AddModelError("hata", "Kullanıcı Zaten Kayıtlı");
                    return View();
                }

                Kullanicilar newUser = new Kullanicilar();
                newUser.Name = Name;
                newUser.Lastname = Surname;
                newUser.Email = Email;
                newUser.Password = Password;
                db.Kullanicilar.Add(newUser);
                db.SaveChanges();

                Roller role = new Roller
                {
                     UserId = newUser.Id,
                     RoleId = (int)UserRole.User
                };
                db.Roller.Add(role);
                db.SaveChanges();

                HttpContext.Session.SetInt32("UserID", newUser.Id);
                HttpContext.Session.SetInt32("UserRole", role.RoleId.Value);

                return Redirect("/rezervasyon");
            }
            return View();
        }
    }
}