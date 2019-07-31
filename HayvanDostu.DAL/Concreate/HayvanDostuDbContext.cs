using HayvanDostu.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HayvanDostu.DAL.Concreate
{
    public class HayvanDostuDbContext : DbContext
    {
        public HayvanDostuDbContext() : base("Server=.; Database=HayvanDostuDB; uid=sa; pwd=123;")
        {
            Database.SetInitializer<HayvanDostuDbContext>(new MyStrategy());
        }

        public DbSet<BireyselUye> BireyselUyeler { get; set; }
        public DbSet<KurumsalUye> KurumsalUyeler { get; set; }
        public DbSet<Veteriner> Veterinerler { get; set; }
        public DbSet<Cizelge> Cizelgeler { get; set; }
        public DbSet<Hayvan> Hayvanlar { get; set; }
        public DbSet<HayvanCinsi> HayvanCinsleri { get; set; }
        public DbSet<HayvanTuru> HayvanTurleri { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<Konaklama> Konaklamalar { get; set; }
        public DbSet<KonaklamaRezervasyon> KonaklamaRezervasyonlari { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Odeme> Odemeler { get; set; }
        public DbSet<Puan> Puanlar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Admin> Adminler { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            // Mappingler eklenecek
            // modelBuilder.Configurations.Add(new Mapping());

            modelBuilder.Properties().Where(a => a.PropertyType == typeof(DateTime)).Configure(a => a.HasColumnType("datetime2"));

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


        }
    }
}
