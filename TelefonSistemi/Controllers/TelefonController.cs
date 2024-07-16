using PhoneProg.Data.Models;
using PhoneProg.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelefonSistemi.Controllers
{
    public class TelefonController : Controller
    {
        // GET: Telefon
        UnitOfWork unitOfWork;
        public TelefonController()
        {
            unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var telefon = unitOfWork.GetRepository<Telefonlar>().GetAll();


            return View(telefon);
        }

        public ActionResult SatılanTelefon()
        {
            var telefon = unitOfWork.GetRepository<Telefonlar>().GetAll();
            return View(telefon);
        }

        ///Telefon Ekleme 
        public ActionResult Ekle()
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Dukkanlar = unitOfWork.GetRepository<Dukkanlar>().GetAll();
            return View();
        }
     
        [HttpPost]
        public JsonResult EkleJson(List<string> kategoriler, List<string> dukkanlar, string telefonadı, string telefonAlıs, string telefonNo, string Imeil,string telefondurumu)
        {

            List<Kategori> ktgler = new List<Kategori>();
            foreach (var kategoriId in kategoriler)
            {
                var kategoriID = Convert.ToInt32(kategoriId);
                var kategori = unitOfWork.GetRepository<Kategori>().GetById(kategoriID);
                ktgler.Add(kategori);
            }

            Console.WriteLine(ktgler.Count);


            List<Dukkanlar> dknlar = new List<Dukkanlar>();
            foreach (var dknId in dukkanlar)
            {
                var dknID = Convert.ToInt32(dknId);
                var dukkan = unitOfWork.GetRepository<Dukkanlar>().GetById(dknID);
                dknlar.Add(dukkan);
            }


            Telefonlar telefon = new Telefonlar();


            telefon.AdSoyad = telefonadı;
            telefon.TelefonAlısFiyati = telefonAlıs;
            telefon.TelefonNo = telefonNo;
            telefon.Imeil = Imeil;
            telefon.EklenmeTarihi = DateTime.Now;
            telefon.Kategoriler = ktgler;
            telefon.Dukkanlar = dknlar;
            telefon.Durum=telefondurumu;


            unitOfWork.GetRepository<Telefonlar>().Add(telefon);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }
        

        ///Telefon Güncelleme
        public ActionResult Guncellle(int telefonId)
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Dukkanlar = unitOfWork.GetRepository<Dukkanlar>().GetAll();

            var telefon = unitOfWork.GetRepository<Telefonlar>().GetById(telefonId);
            return View(telefon);
        }
        
        [HttpPost]
        public JsonResult GuncellleJson(int telefonId, List<string> kategoriler, List<string> dukkanlar, string telefonadı, string telefonAlıs, string telefonNo, string Imeil)
        {
            var telefon = unitOfWork.GetRepository<Telefonlar>().GetById(telefonId);

            // Save old kategori and dukkan data
            var eskiKategoriler = telefon.Kategoriler.ToList();
            var eskiDukkanlar = telefon.Dukkanlar.ToList();

            List<Kategori> yeniKategoriler = new List<Kategori>();
            foreach (var kategoriId in kategoriler)
            {
                var kategoriID = Convert.ToInt32(kategoriId);
                var kategori = unitOfWork.GetRepository<Kategori>().GetById(kategoriID);
                yeniKategoriler.Add(kategori);
            }

            List<Dukkanlar> yeniDukkanlar = new List<Dukkanlar>();
            foreach (var dknId in dukkanlar)
            {
                var dknID = Convert.ToInt32(dknId);
                var dukkan = unitOfWork.GetRepository<Dukkanlar>().GetById(dknID);
                yeniDukkanlar.Add(dukkan);
            }

            telefon.AdSoyad = telefonadı;
            telefon.TelefonAlısFiyati = telefonAlıs;
            telefon.TelefonNo = telefonNo;
            telefon.Imeil = Imeil;
            telefon.EklenmeTarihi = DateTime.Now;

            // Update kategori and dukkan data
            telefon.Kategoriler.Clear();
            telefon.Dukkanlar.Clear();
            foreach (var kategori in yeniKategoriler)
            {
                telefon.Kategoriler.Add(kategori);
            }
            foreach (var dukkan in yeniDukkanlar)
            {
                telefon.Dukkanlar.Add(dukkan);
            }

            unitOfWork.GetRepository<Telefonlar>().Update(telefon);
            var durum = unitOfWork.SaveChanges();

            if (durum > 0) return Json("1");
            else
            {
                // Rollback changes if save fails
                telefon.Kategoriler.Clear();
                telefon.Dukkanlar.Clear();
                foreach (var kategori in eskiKategoriler)
                {
                    telefon.Kategoriler.Add(kategori);
                }
                foreach (var dukkan in eskiDukkanlar)
                {
                    telefon.Dukkanlar.Add(dukkan);
                }

                unitOfWork.GetRepository<Telefonlar>().Update(telefon);
                unitOfWork.SaveChanges();

                return Json("0");
            }
        }
        //public JsonResult SilJson(int telefonId)
        //{
        //    unitOfWork.GetRepository<Telefonlar>().Delete(telefonId);


        //    var durum = unitOfWork.SaveChanges();
        //    if (durum > 0) return Json("1");
        //    else return Json("0");
        //}


        ///Telefon Satma
        public ActionResult Sat(int telefonId)
        {

            ViewBag.Telefonlar = unitOfWork.GetRepository<Telefonlar>().GetAll();
            

            var telefon = unitOfWork.GetRepository<Telefonlar>().GetById(telefonId);
            return View(telefon);
        }

        [HttpPost]
        public JsonResult SatJson(int telefonId, string telefonSatıs)
        {
            var telefon = unitOfWork.GetRepository<Telefonlar>().GetById(telefonId);

            

            telefon.SatısFiyatı = telefonSatıs;
            telefon.SatisTarihi = DateTime.Now;


            unitOfWork.GetRepository<Telefonlar>().Update(telefon);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }


    }
}