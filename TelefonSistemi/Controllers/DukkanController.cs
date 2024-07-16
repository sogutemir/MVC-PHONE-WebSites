using PhoneProg.Data.Models;
using PhoneProg.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelefonSistemi.Controllers
{
    public class DukkanController : Controller
    {


        UnitOfWork unitOfWork;
        public DukkanController()
        {
            unitOfWork = new UnitOfWork();
        }


     
        public ActionResult Index()
        {
            var dukkanlar = unitOfWork.GetRepository<Dukkanlar>().GetAll();


            return View(dukkanlar);
        }
        public ActionResult Tk1Index()
        {
            var telefonlar = unitOfWork.GetRepository<Telefonlar>().GetAll();

            return View(telefonlar);
        }
        public ActionResult TekbirIndex()
        {
            var telefonlar = unitOfWork.GetRepository<Telefonlar>().GetAll();

            return View(telefonlar);
        }
        public ActionResult TechIndex()
        {
            var telefonlar = unitOfWork.GetRepository<Telefonlar>().GetAll();

            return View(telefonlar);
        }
        public ActionResult Tk2Index()
        {
            var telefonlar = unitOfWork.GetRepository<Telefonlar>().GetAll();

            return View(telefonlar);
        }


        [HttpPost]
        public JsonResult EkleJson(string dknAd)
        {
            Dukkanlar dkn = new Dukkanlar();
            dkn.Ad = dknAd;
            var eklenenDkn = unitOfWork.GetRepository<Dukkanlar>().Add(dkn);
            unitOfWork.SaveChanges();
            return Json(
                new
                {
                    Result = new
                    {
                        Id = eklenenDkn.Id,
                        Ad = eklenenDkn.Ad,
                    },
                    JsonRequestBehavior.AllowGet
                });

        }
        [HttpPost]
        public JsonResult GuncelleJson(int dknId, string dknAd)
        {
            var dukkan = unitOfWork.GetRepository<Dukkanlar>().GetById(dknId);
            dukkan.Ad = dknAd;
            var durum = unitOfWork.SaveChanges();

            if (durum > 0) return Json("1");
            else return Json("0");
        }
        [HttpPost]
        public JsonResult SilJson(int dknId)
        {
            unitOfWork.GetRepository<Dukkanlar>().Delete(dknId);


            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }



        public ActionResult TechEkle()
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Dukkanlar = unitOfWork.GetRepository<Dukkanlar>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult TechEkleJson(List<string> kategoriler, List<string> dukkanlar, string telefonadı, string telefonAlıs, string telefonNo, string Imeil, string telefondurumu)
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
            telefon.Durum = telefondurumu;


            unitOfWork.GetRepository<Telefonlar>().Add(telefon);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }


        public ActionResult TekbirEkle()
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Dukkanlar = unitOfWork.GetRepository<Dukkanlar>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult TekbirEkleJson(List<string> kategoriler, List<string> dukkanlar, string telefonadı, string telefonAlıs, string telefonNo, string Imeil, string telefondurumu)
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
            telefon.Durum = telefondurumu;


            unitOfWork.GetRepository<Telefonlar>().Add(telefon);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }

        public ActionResult Tk1Ekle()
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Dukkanlar = unitOfWork.GetRepository<Dukkanlar>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult Tk1EkleJson(List<string> kategoriler, List<string> dukkanlar, string telefonadı, string telefonAlıs, string telefonNo, string Imeil, string telefondurumu)
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
            telefon.Durum = telefondurumu;


            unitOfWork.GetRepository<Telefonlar>().Add(telefon);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }

        public ActionResult Tk2Ekle()
        {
            ViewBag.Kategoriler = unitOfWork.GetRepository<Kategori>().GetAll();
            ViewBag.Dukkanlar = unitOfWork.GetRepository<Dukkanlar>().GetAll();
            return View();
        }

        [HttpPost]
        public JsonResult Tk2EkleJson(List<string> kategoriler, List<string> dukkanlar, string telefonadı, string telefonAlıs, string telefonNo, string Imeil, string telefondurumu)
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
            telefon.Durum = telefondurumu;


            unitOfWork.GetRepository<Telefonlar>().Add(telefon);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }


        public ActionResult Sat(int telefonId)
        {

            ViewBag.Telefonlar = unitOfWork.GetRepository<Telefonlar>().GetAll();


            var telefon = unitOfWork.GetRepository<Telefonlar>().GetById(telefonId);
            return View(telefon);
        }

        public ActionResult TechSatılanTelefon()
        {
            var telefon = unitOfWork.GetRepository<Telefonlar>().GetAll();
            return View(telefon);
        }

        public ActionResult TekbirSatılanTelefon()
        {
            var telefon = unitOfWork.GetRepository<Telefonlar>().GetAll();
            return View(telefon);
        }

        public ActionResult Tk1SatılanTelefon()
        {
            var telefon = unitOfWork.GetRepository<Telefonlar>().GetAll();
            return View(telefon);
        }

        public ActionResult Tk2SatılanTelefon()
        {
            var telefon = unitOfWork.GetRepository<Telefonlar>().GetAll();
            return View(telefon);
        }

        [HttpPost]
        public JsonResult SatJson(int telefonId, string telefonSatıs)
        {
            var telefon = unitOfWork.GetRepository<Telefonlar>().GetById(telefonId);



            telefon.SatısFiyatı = telefonSatıs;
            telefon.SatisTarihi = DateTime.Now;


            if (telefon != null)
            {
                telefon.Satildi = true;
            }


                unitOfWork.GetRepository<Telefonlar>().Update(telefon);
            var durum = unitOfWork.SaveChanges();
            if (durum > 0) return Json("1");
            else return Json("0");
        }


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


    }
}