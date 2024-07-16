using PhoneProg.Data.Models;
using PhoneProg.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelefonSistemi.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        private readonly UnitOfWork _unitOfWork;
        public IstatistikController()
        {
            _unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            //Sutun Grafiği işlemleri
            
            ViewBag.KategoriSayisi = _unitOfWork.GetRepository<Kategori>().GetAll().Count();
            ViewBag.TelefonSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll().Count();
            ViewBag.SatilanTelefonSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll().Where(x => x.SatısFiyatı !=null).Count();
            ViewBag.SatılmayanTelefonSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll().Where(x => x.SatısFiyatı == null).Count();




            //Ürün Marka Sayıları

            ViewBag.AksesuarSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı == null && x.Kategoriler.Any(k => k.Ad.Contains("Aksesuar"))).Count();

            ViewBag.IphoneSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı == null && x.Kategoriler.Any(k => k.Ad.Contains("Iphone"))).Count();

            ViewBag.HuaweiSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı == null && x.Kategoriler.Any(k => k.Ad.Contains("Huawei"))).Count();

            ViewBag.XiaomiSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı == null && x.Kategoriler.Any(k => k.Ad.Contains("Xiaomi"))).Count();

            ViewBag.SamsungSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı == null && x.Kategoriler.Any(k => k.Ad.Contains("Samsung"))).Count();







            //Satılan Ürün Sayıları
            ViewBag.satılanAksesuarSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Aksesuar"))).Count();

            ViewBag.satılanIphoneSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Iphone"))).Count();

            ViewBag.satılanHuaweiSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Huawei"))).Count();

            ViewBag.satılanXiaomiSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Xiaomi"))).Count();

            ViewBag.satılanSamsungSayisi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Samsung"))).Count();



            //Satılan Ürünlerin Cirosu

            decimal toplamFiyatAksesuar = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Aksesuar")))
                .Sum(x => Convert.ToDecimal(x.SatısFiyatı));
                    ViewBag.satılanAksesuarFiyati = toplamFiyatAksesuar;

            decimal toplamFiyatIphone = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Iphone")))
                .Sum(x => Convert.ToDecimal(x.SatısFiyatı));
                    ViewBag.satılanIphoneFiyati = toplamFiyatIphone;

            decimal toplamFiyatXiaomi = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Huawei")))
                .Sum(x => Convert.ToDecimal(x.SatısFiyatı));
                    ViewBag.satılanHuaweiFiyati = toplamFiyatXiaomi;

            decimal toplamFiyatSamsung = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Xiaomi")))
                .Sum(x => Convert.ToDecimal(x.SatısFiyatı));
                    ViewBag.satılanXiaomiFiyati = toplamFiyatSamsung;

            decimal toplamFiyatHuawei = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.SatısFiyatı != null && x.Kategoriler.Any(k => k.Ad.Contains("Samsung")))
                .Sum(x => Convert.ToDecimal(x.SatısFiyatı));
                    ViewBag.satılanSamsungFiyati = toplamFiyatHuawei;




            //Satılan Ürünlerin Maliyeti

            decimal toplamFiyatAksesuar2 = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.TelefonAlısFiyati != null && x.Kategoriler.Any(k => k.Ad.Contains("Aksesuar")))
                .Sum(x => Convert.ToDecimal(x.TelefonAlısFiyati));
            ViewBag.toplamAlınanAksesuarFiyatı = toplamFiyatAksesuar2;

            decimal toplamFiyatIphone2 = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.TelefonAlısFiyati != null && x.Kategoriler.Any(k => k.Ad.Contains("Iphone")))
                .Sum(x => Convert.ToDecimal(x.TelefonAlısFiyati));
            ViewBag.toplamAlınanIphoneFiyatı = toplamFiyatIphone2;

            decimal toplamFiyatXiaomi2 = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.TelefonAlısFiyati != null && x.Kategoriler.Any(k => k.Ad.Contains("Huawei")))
                .Sum(x => Convert.ToDecimal(x.TelefonAlısFiyati));
            ViewBag.toplamAlınanHuaweiFiyatı = toplamFiyatXiaomi2;

            decimal toplamFiyatSamsung2 = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.TelefonAlısFiyati != null && x.Kategoriler.Any(k => k.Ad.Contains("Xiaomi")))
                .Sum(x => Convert.ToDecimal(x.TelefonAlısFiyati));
            ViewBag.toplamAlınanXiaomiFiyatı = toplamFiyatSamsung2;

            decimal toplamFiyatHuawei2 = _unitOfWork.GetRepository<Telefonlar>().GetAll()
                .Where(x => x.TelefonAlısFiyati != null && x.Kategoriler.Any(k => k.Ad.Contains("Samsung")))
                .Sum(x => Convert.ToDecimal(x.TelefonAlısFiyati));
            ViewBag.toplamAlınanSamsungFiyatı = toplamFiyatHuawei2;

           



            //Ürün Gelir Giderleri
            ViewBag.AksesuarKar = ViewBag.satılanAksesuarFiyati - ViewBag.toplamAlınanAksesuarFiyatı;
            ViewBag.IphoneKar = ViewBag.satılanIphoneFiyati - ViewBag.toplamAlınanIphoneFiyatı;
            ViewBag.HuaweiKar = ViewBag.satılanHuaweiFiyati - ViewBag.toplamAlınanHuaweiFiyatı;
            ViewBag.XiaomiKar = ViewBag.satılanXiaomiFiyati - ViewBag.toplamAlınanXiaomiFiyatı;
            ViewBag.SamsungKar = ViewBag.satılanSamsungFiyati - ViewBag.toplamAlınanSamsungFiyatı;


            //Toplam Gelir Ve Giderler
            ViewBag.ToplamAlıs=toplamFiyatAksesuar2 + toplamFiyatIphone2 + toplamFiyatXiaomi2 + toplamFiyatSamsung2 + toplamFiyatHuawei2;
            ViewBag.ToplamSatıs= toplamFiyatAksesuar + toplamFiyatIphone + toplamFiyatXiaomi + toplamFiyatSamsung + toplamFiyatHuawei;
            ViewBag.ToplamKar = ViewBag.ToplamSatıs - ViewBag.ToplamAlıs;


            return View();
        }   
    }
}