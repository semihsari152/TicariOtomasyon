using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class NotificationClass
    {
        NotificationManager nm = new NotificationManager(new EfNotificationRepository());
        public void NotificationAdd(string name,string value)
        {
          
            Notification notification = new Notification();
            notification.NotificationDate = DateTime.Now;
            notification.NotificationType = "Ekleme";
            notification.NotificationTypeSymbol = "mdi mdi-playlist-plus text-success";
            notification.NotificationStatus = true;
            notification.NotificationDetails = '"' + name + '"' + " isimli kayıt eklendi.";
            notification.NotificationValue =value ;
            nm.TAdd(notification);

        }
        public void NotificationUpdate(string name, string value)
        {

            Notification notification = new Notification();
            notification.NotificationDate = DateTime.Now;
            notification.NotificationType = "Güncelleme";
            notification.NotificationTypeSymbol = "mdi mdi-playlist-check text-primary";
            notification.NotificationStatus = true;
            notification.NotificationDetails = '"' + name + '"' + " isimli kayıt güncellendi.";
            notification.NotificationValue = value;
            nm.TAdd(notification);

        }
        public void NotificationDelete(string name, string value)
        {

            Notification notification = new Notification();
            notification.NotificationDate = DateTime.Now;
            notification.NotificationType = "Silme";
            notification.NotificationTypeSymbol = "mdi mdi-playlist-remove text-danger ";
            notification.NotificationStatus = true;
            notification.NotificationDetails ='"'+ name +'"' + " isimli kayıt silindi.";
            notification.NotificationValue = value;
            nm.TAdd(notification);

        }
        public void NotificationSell(string name, string value)
        {

            Notification notification = new Notification();
            notification.NotificationDate = DateTime.Now;
            notification.NotificationType = "Satış";
            notification.NotificationTypeSymbol = "mdi mdi-playlist-play text-warning ";
            notification.NotificationStatus = true;
            notification.NotificationDetails = '"' + name + '"' + " isimli kayıt satıldı.";
            notification.NotificationValue = value;
            nm.TAdd(notification);

        }
    }
}
