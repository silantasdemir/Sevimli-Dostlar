using HayvanDostu.BLL.Abstract;

using HayvanDostu.Model;
using HayvanDostu.UI.MVC.Tools;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HayvanDostu.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        IBireyselUyeService _bireyselUyeService;
        IHayvanService _hayvanService;
        IHayvanCinsiService _hayvanCinsiService;

        public HomeController(IBireyselUyeService bireyselUyeService, IHayvanService hayvan, IHayvanCinsiService hayvanCinsi)
        {
            this._bireyselUyeService = bireyselUyeService;
            this._hayvanService = hayvan;
            this._hayvanCinsiService = hayvanCinsi;
        }

        // GET: Home

        public ActionResult Hakkimizda()
        {
            return View();
        }
        private void BindCinsDDL()
        {
            List<SelectListItem> cinsler = new List<SelectListItem>();

            foreach (HayvanCinsi item in _hayvanCinsiService.GetAll())
            {
                cinsler.Add(new SelectListItem()
                {
                    Text = item.Cinsi,
                    Value = item.ID.ToString()
                });
            }
            ViewBag.Cinsler = cinsler;
        }
        public ActionResult HayvanSayfasi()
        {
            BindCinsDDL();
            return View();
        }

        [HttpPost]
        public ActionResult HayvanSayfasi(Hayvan hayvan, HttpPostedFileBase file, HayvanCinsi cinsi)
        {

            // after successfully uploading redirect the user
            // return RedirectToAction("actionname", "controller name");

            try
            {
                if (ModelState.IsValid)
                {
                    BireyselUye uye = Session["bireyselKullanici"] as BireyselUye;
                    hayvan.BireyselUyeID = uye.ID;
                    hayvan.HayvanCinsiID = 1;
                    _hayvanService.GetUploadPhoto(hayvan, file);

                    //_hayvanService.Insert(hayvan);

                    try
                    {
                        string icerik = "Merhaba , <b>" + uye.Ad + " " + "</b></br>Üyelik talebinizi aldık. Talebiniz onaylandıktan sonra giriş yapabilirsiniz.</br>Sevimli dostlarla tanışmak için onay mailini bekleyin.";
                        bool sonuc = MailHelper.SendConfirmationMail("Hoşgeldiniz", icerik, uye.Email);
                        if (!sonuc)
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = "Mail gönderilemedi !";
                    }

                    return RedirectToAction("BireyselAnaSayfa", "Home");
                }

            }
            catch (Exception e)
            {
                ViewBag.Error = "Kayıt işlemi başarısız ! ";
                return View();
            }
            return RedirectToAction("HayvanSayfasi", "Home");
        }
        //public JsonResult Get()
        //{
        //    var bireyseller = _bireyselUyeService.GetAll().OrderBy(a => a.Ad).ToList();
        //    return Json(new { data = bireyseller }, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult BireyselAnaSayfa()
        {
            BireyselUye birey = Session["bireyselKullanici"] as BireyselUye;

            return View(birey);
            //var bireyseller = _bireyselUyeService.GetAll().OrderBy(a => a.Ad).ToList();
            //return View(bireyseller);
        }

        [HttpPost]
        public ActionResult BireyselAnaSayfa(BireyselUye bireyselUye)
        {
            return View();
        }
        public ActionResult SahiplenmeSayfasi()
        {
            var hayvanlar = _hayvanService.GetAll();
            return View(hayvanlar);
        }

        [HttpPost]
        public ActionResult SahiplenmeSayfasi(BireyselUye bireyselUye)
        {
            return View();
        }

    }
}