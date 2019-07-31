using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace HayvanDostu.UI.MVC.Tools
{
    public class MailHelper
    {
        public static bool SendConfirmationMail(string baslik, string icerik, string gonderilecekKisi)
        {
            bool result = false;
            MailMessage msg = new MailMessage();
            msg.IsBodyHtml = true;
            msg.Subject = baslik;
            msg.Body = icerik;
            msg.To.Add(gonderilecekKisi);
            msg.From = new MailAddress("sevimlidostunuz@gmail.com");

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            NetworkCredential credential = new NetworkCredential("sevimlidostunuz@gmail.com", "Bilge1530insan.");
            smtpClient.Credentials = credential;

            try
            {
                smtpClient.Send(msg);
                result = true;
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }
    }
}