using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationSite.Data;
using WebApplication1.UI.Authorization;
using static WebApplication1.Helpers.Enums;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeUser(UserRole.Admin)]
    public class KullanicilarController : Controller
    {
        public IActionResult Index()
        {
            DBRezervasyon db = new DBRezervasyon();
            ViewBag.Kullanicilar = db.Kullanicilar.ToList();

            return View();
        }

        public IActionResult Delete(int Id)
        {
            DBRezervasyon db = new DBRezervasyon();
            Kullanicilar user = db.Kullanicilar.FirstOrDefault(n => n.Id == Id);
            db.Kullanicilar.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}