using HayvanDostu.BLL.Abstract;
using HayvanDostu.Model;
using HayvanDostu.Model.Entity;
using HayvanDostu.UI.MVC.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HayvanDostu.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        IBireyselUyeService _bireyselUyeService;
        IKurumsalUyeService _kurumsalUyeService;
        IAdminService _adminService;
        IRezervasyonService _rezervasyonService;


        public AccountController(IBireyselUyeService bireyselUyeService, IKurumsalUyeService kurumsalUyeService, IAdminService adminService, IRezervasyonService rezervasyonService)
        {
            this._bireyselUyeService = bireyselUyeService;
            this._kurumsalUyeService = kurumsalUyeService;
            this._adminService = adminService;
            this._rezervasyonService = rezervasyonService;

        }
        [HttpGet]
        public ActionResult BireyselUyeOl()
        {

            return View();
        }

        [HttpPost]
        public ActionResult BireyselUyeOl(BireyselUye bireyselUye, HttpPostedFileBase file)
        {

            // after successfully uploading redirect the user
            // return RedirectToAction("actionname", "controller name");

            try
            {
                if (ModelState.IsValid)
                {
                    _bireyselUyeService.GetUploadPhoto(bireyselUye, file);

                    try
                    {
                        string icerik = "Merhaba , <b>" + bireyselUye.Ad + " " + bireyselUye.Soyad + "</b></br>Üyelik talebinizi aldık. Talebiniz onaylandıktan sonra giriş yapabilirsiniz.</br>Sevimli dostlarla tanışmak için onay mailini bekleyin.";
                        bool sonuc = MailHelper.SendConfirmationMail("Hoşgeldiniz", icerik, bireyselUye.Email);
                        if (!sonuc)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Mail gönderilemedi !";
                    }

                    return RedirectToAction("Login");
                }

            }
            catch (Exception e)
            {
                ViewBag.Error = "Kayıt işlemi başarısız ! ";
                return View();
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Login()
        {
            Session.RemoveAll();
            return View();
        }

        [HttpPost]
        public ActionResult Login(BireyselUye bireyselUye, KurumsalUye kurumsalUye, Admin admin)
        {
            Session.RemoveAll();

            var gelenKullaniciAdmin = _adminService.GetUserByLogin(admin.KullaniciAdi, admin.Sifre);
            if (gelenKullaniciAdmin == null)
            {
                var gelenKullaniciBireysel = _bireyselUyeService.GetUserByLogin(bireyselUye.KullaniciAdi, bireyselUye.Sifre);
                if (gelenKullaniciBireysel == null)
                {
                    var gelenKullaniciKurumsal = _kurumsalUyeService.GetUserByLogin(kurumsalUye.KullaniciAdi, kurumsalUye.Sifre);
                    if (gelenKullaniciKurumsal == null)
                    {
                        ViewBag.Error = "Kullanıcı Bulunamadı";
                        return View();
                    }
                    else if (!gelenKullaniciKurumsal.OnaylandiMi)
                    {
                        ViewBag.Error = "Kurumsal Üyemiz Henüz Onaylanmamıs";
                        return View();
                    }
                    else
                    {
                        Session["kurumsalKullanici"] = gelenKullaniciKurumsal;
                        return RedirectToAction("KurumsalGuncelle", "Account");
                    }
                }
                else if (!gelenKullaniciBireysel.OnaylandiMi)
                {
                    ViewBag.Error = "Bireysel Üyemiz Henüz Onaylanmamıs";
                    return View();
                }
                else
                {
                    Session["bireyselKullanici"] = gelenKullaniciBireysel;
                    return RedirectToAction("BireyselAnaSayfa", "Home");
                }
            }
            else
            {
                Session["adminKullanici"] = gelenKullaniciAdmin;
                return RedirectToAction("Home", "Admin");
            }
        }
        public ActionResult KurumsalUyeOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KurumsalUyeOl(KurumsalUye kurumsalUye, HttpPostedFileBase file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _kurumsalUyeService.GetUploadPhoto(kurumsalUye, file);
                    return RedirectToAction("Login");
                }

                _kurumsalUyeService.Insert(kurumsalUye);
                try
                {
                    string icerik = "Merhaba , <b>" + kurumsalUye.KurumAdi + "</b></br>Üyelik talebinizi aldık. Talebiniz onaylandıktan sonra giriş yapabilirsiniz.</br>Sevimli dostlarla tanışmak için onay mailini bekleyin.";
                    bool sonuc = MailHelper.SendConfirmationMail("Hoşgeldiniz", icerik, kurumsalUye.Email);
                    if (!sonuc)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Mail gönderilemedi !";
                }

            }
            catch (Exception e)
            {
                ViewBag.Error = "Kayıt işlemi başarısız ! ";
                return View();
            }
            return RedirectToAction("Anasayfa", "Home");
        }

        [HttpPost]
        public ActionResult SifreDegistirme(string mail)
        {
            string icerik = "Merhaba ,";
            var bireysel = _bireyselUyeService.GetMail(mail);
            if (bireysel == null)
            {
                var kurumsal = _kurumsalUyeService.GetMail(mail);
                if (kurumsal == null)
                {
                    ViewBag.Error = "Mail sistemde yok ! ";
                }
                else
                {
                    try
                    {
                        icerik += "<b>" + kurumsal.KurumAdi + "</b></br> Şifre değiştirme talebini aldık ve hemen cevapladık.</br>Şifren :  <b>" + kurumsal.Sifre + "</b></br>Bir daha unutmaman dileğiyle .. ";
                        bool sonuc = MailHelper.SendConfirmationMail("Şifre Değiştirme", icerik, kurumsal.Email);
                        if (!sonuc)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Sevgili" + kurumsal.KurumAdi + " mail gönderilemedi , hatırlamaya çalış !";
                    }

                    ViewBag.Error = "Sevgili" + kurumsal.KurumAdi + " mail gönderildi";
                }
            }
            else
            {
                try
                {
                    icerik += "<b>" + bireysel.Ad + " " + bireysel.Soyad + "</b></br> Şifre değiştirme talebini aldık ve hemen cevapladık.</br>Şifren :  <b>" + bireysel.Sifre + "</b></br>Bir daha unutmaman dileğiyle .. ";
                    bool sonuc = MailHelper.SendConfirmationMail("Şifre Değiştirme", icerik, bireysel.Email);
                    if (!sonuc)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Sevgili" + bireysel.Ad + " " + bireysel.Soyad + " mail gönderilemedi , hatırlamaya çalış !";
                }

                ViewBag.Error = "Sevgili" + bireysel.Ad + " " + bireysel.Soyad + " mail gönderildi";
            }
            return RedirectToAction("Login");
        }
        public ActionResult RezervasyonGuncelle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RezervasyonGuncelle(Rezervasyon rezervasyon)
        {
            _rezervasyonService.DeleteByID(rezervasyon.ID);
            return View();
        }
        [HttpGet]
        public ActionResult KurumsalGuncelle()
        {
            KurumsalUye kurumsalUye = Session["kurumsalKullanici"] as KurumsalUye;
            return View(kurumsalUye);
        }
        [HttpPost]
        public ActionResult KurumsalGuncelle(KurumsalUye kurumsalUye)
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult _Rezervasyonlar()
        {
            KurumsalUye kurumsalUye = Session["kurumsalKullanici"] as KurumsalUye;
            int id = kurumsalUye.ID;
            List<Rezervasyon> rezervasyonlar = _rezervasyonService.GetAllByKurumId(id).ToList();
            if (rezervasyonlar.Count == 0)
            {
                ViewBag.Error = "Rezervasyon Bulunmamaktadır.";
                return PartialView();
            }
            return PartialView(rezervasyonlar);
        }
    }
}