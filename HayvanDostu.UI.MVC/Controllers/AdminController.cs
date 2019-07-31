using HayvanDostu.BLL.Abstract;
using HayvanDostu.Model;
using HayvanDostu.UI.MVC.CustomFilters;
using HayvanDostu.UI.MVC.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HayvanDostu.UI.MVC.Controllers
{
    [AdminLoginFilter()]
    public class AdminController : Controller
    {
        IAdminService _adminService;
        IBireyselUyeService _bireyselUyeService;
        IKurumsalUyeService _kurumsalUyeService;

        public AdminController(IAdminService adminService, IBireyselUyeService bireyselUyeService, IKurumsalUyeService kurumsalUyeService)
        {
            this._adminService = adminService;
            this._bireyselUyeService = bireyselUyeService;
            this._kurumsalUyeService = kurumsalUyeService;
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult HakkimizdaGuncelleme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HakkimizdaGuncelleme(HttpPostedFileBase guncellenecekImage, string guncellenecekYazı)
        {
            Models.Hakkimizda._hakkimizdaYazisi = guncellenecekYazı;
            return View();
        }

        public ActionResult _BireyselUyelikTalepleri()
        {
            return PartialView(_bireyselUyeService.GetAll(false));
        }

        public ActionResult _KurumsalUyelikTalepleri()
        {
            return PartialView(_kurumsalUyeService.GetAll(false));
        }

        public ActionResult OnaylaBireysel(int id)
        {
            BireyselUye bireysel = _bireyselUyeService.Get(id);
            string icerik = "Merhaba ,";

            try
            {
                icerik += "<b>" + bireysel.Ad + " " + bireysel.Soyad + "</b></br>Üyelik talebinizi onayladık.</br>Sevimli dostlarla tanışmak için hemen giriş yapın : <a href=\"/Account/Login\"></a>";
                bool sonuc = MailHelper.SendConfirmationMail("Üyelik Talebi", icerik, bireysel.Email);
                if (!sonuc)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Mail gönderilemedi !";
            }

            bireysel.OnaylandiMi = true;
            _bireyselUyeService.Update(bireysel);
            return RedirectToAction("Home");
        }

        public ActionResult ReddetBireysel(int id)
        {
            BireyselUye bireysel = _bireyselUyeService.Get(id);
            string icerik = "Merhaba ,";

            try
            {
                icerik += "<b>" + bireysel.Ad + " " + bireysel.Soyad + "</b></br>Üyelik talebinizi reddettik, kusura bakmayın.";
                bool sonuc = MailHelper.SendConfirmationMail("Üyelik Talebi", icerik, bireysel.Email);
                if (!sonuc)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Mail gönderilemedi !";
            }

            bireysel.IsDeleted = true;
            bireysel.OnaylandiMi = true;
            _bireyselUyeService.Update(bireysel);
            return RedirectToAction("Home");
        }

        public ActionResult OnaylaKurumsal(int id)
        {
            KurumsalUye kurumsal = _kurumsalUyeService.Get(id);
            string icerik = "Merhaba ,";

            try
            {
                icerik += "<b>" + kurumsal.KurumAdi + "</b></br>Üyelik talebinizi onayladık.</br>Sevimli dostlarla tanışmak için hemen giriş yapın : <a href=\"/Account/Login\"></a>";
                bool sonuc = MailHelper.SendConfirmationMail("Üyelik Talebi", icerik, kurumsal.Email);
                if (!sonuc)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Mail gönderilemedi !";
            }


            kurumsal.OnaylandiMi = true;
            _kurumsalUyeService.Update(kurumsal);
            return RedirectToAction("Home");
        }

        public ActionResult ReddetKurumsal(int id)
        {
            KurumsalUye kurumsal = _kurumsalUyeService.Get(id);
            string icerik = "Merhaba ,";

            try
            {
                icerik += "<b>" + kurumsal.KurumAdi + "</b></br>Üyelik talebinizi reddettik, kusura bakmayın.";
                bool sonuc = MailHelper.SendConfirmationMail("Üyelik Talebi", icerik, kurumsal.Email);
                if (!sonuc)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Mail gönderilemedi !";
            }

            kurumsal.IsDeleted = true;
            kurumsal.OnaylandiMi = true;
            _kurumsalUyeService.Update(kurumsal);
            return RedirectToAction("Home");
        }

        public ActionResult BireyselUyelerList()
        {
            var bireyselUyeler = _bireyselUyeService.GetAll();
            return View(bireyselUyeler);
        }

        public JsonResult GetBireysel()
        {

            var bireyseller = _bireyselUyeService.GetAll(true).OrderBy(a => a.Ad).ToList();
            return Json(new { data = bireyseller }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult _BireyselKaydet(int id)
        {
            var v = _bireyselUyeService.GetAll().Where(a => a.ID == id).FirstOrDefault();
            return View(v);
        }

        [HttpPost]
        public JsonResult _BireyselKaydet(BireyselUye bireysel)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                if (bireysel.ID > 0)
                {
                    //Edit 
                    var v = _bireyselUyeService.GetAll().Where(a => a.ID == bireysel.ID).FirstOrDefault();
                    if (v != null)
                    {
                        v.Ad = bireysel.Ad;
                        v.Soyad = bireysel.Soyad;
                        v.Telefon = bireysel.Telefon;
                        v.Adres = bireysel.Adres;
                        v.KullaniciAdi = bireysel.KullaniciAdi;
                        v.Email = bireysel.Email;
                        v.Sifre = bireysel.Sifre;
                    }
                }
                else
                {
                    //Save
                    _bireyselUyeService.Insert(bireysel);
                }
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult _BireyselSil(int id)
        {
            var v = _bireyselUyeService.GetAll().Where(a => a.ID == id).FirstOrDefault();
            if (v != null)
            {
                return View(v);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ActionName("_BireyselSil")]
        public JsonResult _BireyselSilPost(int id)
        {
            bool status = false;
            var v = _bireyselUyeService.GetAll().Where(a => a.ID == id).FirstOrDefault();
            if (v != null)
            {
                _bireyselUyeService.Delete(v);
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }






    }
}