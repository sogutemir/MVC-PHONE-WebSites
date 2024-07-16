using PhoneProg.Data.Models;
using PhoneProg.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelefonSistemi.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        UnitOfWork unitOfWork;
        public UyeController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var telefon = unitOfWork.GetRepository<Uyeler>().GetAll();


            return View(telefon);
        }
        public ActionResult Ekle()
        {
            
            ViewBag.Uyeler = unitOfWork.GetRepository<Uyeler>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult EkleJson(string newUyeAd, string newUyeSoyad, string newUyeTelefon)
        {
            Uyeler uye = new Uyeler();
            
            uye.Ad = newUyeAd;
            uye.Soyad = newUyeSoyad;
            uye.TelNo = newUyeTelefon;
           

            unitOfWork.GetRepository<Uyeler>().Add(uye);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }

        [HttpPost]
        public JsonResult SilJson(int userId)
        {
            unitOfWork.GetRepository<Uyeler>().Delete(userId);


            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }

        public ActionResult Guncelle(int uyeId)
        {

            var uye = unitOfWork.GetRepository<Uyeler>().GetById(uyeId);
            return View(uye);
        }

        [HttpPost]
        public JsonResult GuncelleJson(int uyeId, string newUyeAd, string newUyeSoyad, string newUyeTelefon)
        {
            var uye = unitOfWork.GetRepository<Uyeler>().GetById(uyeId);
            
            uye.Ad= newUyeAd;
            uye.TelNo= newUyeSoyad;
            uye.Soyad= newUyeTelefon;

            var durum = unitOfWork.SaveChanges();

            if (durum > 0) return Json("1");
            else return Json("0");
        }
    }
}