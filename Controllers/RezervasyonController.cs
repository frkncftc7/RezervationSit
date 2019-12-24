using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSite.Data;
using WebApplication1.UI.Authorization;

namespace ReservationSite.Controllers
{
    [AuthorizeUser()]
    public class RezervasyonController : Controller
    {
        public IActionResult Index()
        {
            DBRezervasyon db = new DBRezervasyon();
            ViewBag.Oteller = db.Oteller.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Index(int OtelID, int KisiSayisi, int CocukSayisi, DateTime Baslangic, DateTime Bitis)
        {
            DBRezervasyon db = new DBRezervasyon();
            Rezervasyonlar rezervasyon = new Rezervasyonlar
            {
                OtelId = OtelID,
                KullaniciId = HttpContext.Session.GetInt32("UserID"),
                BaslangicTarih = Baslangic,
                SonTarih = Bitis,
                KisiSayisi = KisiSayisi
            };
            db.Rezervasyonlar.Add(rezervasyon);
            db.SaveChanges();

            return Redirect("/Rezervasyon/Rezervasyonlarim");
        }

        public IActionResult Rezervasyonlarim()
        {
            int? kullaniciId = HttpContext.Session.GetInt32("UserID");
            DBRezervasyon db = new DBRezervasyon();
            ViewBag.Rezervasyonlarim = db.Rezervasyonlar.Include(n => n.Otel).Where(n => n.KullaniciId == kullaniciId);

            return View();
        }

        public IActionResult Sil(int Id)
        {
            DBRezervasyon db = new DBRezervasyon();
            Rezervasyonlar rezervasyon = db.Rezervasyonlar.FirstOrDefault(n => n.Id == Id);
            db.Remove(rezervasyon);
            db.SaveChanges();

            return Redirect("/Rezervasyon/Rezervasyonlarim");
        }

    }
}