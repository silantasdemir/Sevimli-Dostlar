using HayvanDostu.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.DAL.Concreate
{
    public class MyStrategy : DropCreateDatabaseIfModelChanges<HayvanDostuDbContext>
    {
        protected override void Seed(HayvanDostuDbContext context)
        {

            // Proje ayağa kalkarken database dolu gelsin diye eklemeler yapılacak
            new List<Admin> { new Admin { KullaniciAdi = "Silan", Sifre = "Silan123" }, new Admin { KullaniciAdi = "Zeynep", Sifre = "Zeynep123" }, new Admin { KullaniciAdi = "Mehmet", Sifre = "Mehmet123" } }.ForEach(a => context.Adminler.Add(a));


            new List<BireyselUye> {
                new BireyselUye {KullaniciAdi="aysenur",Ad="Aysenur",Soyad="Bakirci",Adres="Basaksehir",Cinsiyet=true},
                new BireyselUye{ KullaniciAdi="dilara",Ad="Dilara", Soyad="Celikcivi",Adres="Halkali",Cinsiyet=true},
                new BireyselUye{ KullaniciAdi="gamze",Ad="Gamze", Soyad="Erol",Adres="Bakirkoy",Cinsiyet=true},
                new BireyselUye{ KullaniciAdi="rumeysa",Ad="Rumeysa", Soyad="Cini",Adres="Bayrampasa",Cinsiyet=true},
                new BireyselUye{ KullaniciAdi="ali",Ad="Ali", Soyad="Veli",Adres="Halkali",Cinsiyet=false},
                new BireyselUye{ KullaniciAdi="mahsun",Ad="Mahsun", Soyad="Veli",Adres="Halkali",Cinsiyet=false},
                new BireyselUye{ KullaniciAdi="besir",Ad="Besir", Soyad="Veli",Adres="Halkali",Cinsiyet=false},
                new BireyselUye{ KullaniciAdi="furkan",Ad="Ali", Soyad="Veli",Adres="Halkali",Cinsiyet=false},
                new BireyselUye{ KullaniciAdi="baris",Ad="Ali", Soyad="Veli",Adres="Halkali",Cinsiyet=false},
                new BireyselUye{ KullaniciAdi="cihan",Ad="Ali", Soyad="Veli",Adres="Halkali",Cinsiyet=false},
                new BireyselUye{ KullaniciAdi="muharrem",Ad="Ali", Soyad="Veli",Adres="Halkali",Cinsiyet=false},
                new BireyselUye{ KullaniciAdi="agah",Ad="Ali", Soyad="Veli",Adres="Halkali",Cinsiyet=false},
            }.ForEach(a => context.BireyselUyeler.Add(a));


            new List<KurumsalUye> {
                new KurumsalUye{KullaniciAdi="bilgeadam",KurumAdi="Bilge Adam",Adres="Bakirkoy" }

            }.ForEach(a => context.KurumsalUyeler.Add(a));

        }
    }
}
