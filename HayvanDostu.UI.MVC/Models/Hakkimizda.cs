using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayvanDostu.UI.MVC.Models
{
    public class Hakkimizda
    {
        private static string hakkimizdaYazisi = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.";

        public static string _hakkimizdaYazisi
        {
            get { return hakkimizdaYazisi; }
            set { hakkimizdaYazisi = value; }
        }
        private static string hakkimizdaResimUrl = "pet.png";

        public static string _hakkimizdaResim
        {
            get { return hakkimizdaResimUrl; }
            set { hakkimizdaResimUrl = value; }
        }



    }
}