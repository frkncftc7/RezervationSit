using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSite.Data;
using WebApplication1.UI.Authorization;
using static WebApplication1.Helpers.Enums;

namespace ReservationSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeUser(UserRole.Admin)]
    public class RezervasyonlarController : Controller
    {
        public IActionResult Index()
        {
            DBRezervasyon db = new DBRezervasyon();
            ViewBag.Rezervasyonlar = db.Rezervasyonlar.Include(n => n.Otel).Include(n => n.Kullanici).ToList();

            return View();
        }
        public IActionResult Delete(int Id)
        {
            DBRezervasyon db = new DBRezervasyon();
            Rezervasyonlar rezervasyon = db.Rezervasyonlar.FirstOrDefault(n => n.Id == Id);
            db.Rezervasyonlar.Remove(rezervasyon);
            db.SaveChanges();

            return Redirect("/admin/rezervasyonlar");
        }
    }
}