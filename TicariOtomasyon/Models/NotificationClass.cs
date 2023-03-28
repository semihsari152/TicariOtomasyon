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
        public void NotificationAdd(string name,string type)
        {
            Notification notification = new Notification();
            notification.NotificationDate = DateTime.Now;
            notification.NotificationStatus = true;
            notification.NotificationValue = type;
            notification.NotificationTypeSymbol = "mdi mdi-playlist-plus text-success";
            notification.NotificationType = "Ekleme";
            notification.NotificationDetails ='"'+name+'"' +  " isimli kayıt eklendi.";
            nm.TAdd(notification);
        }
        public void NotificationUpdate(string name, string type)
        {
            Notification notification = new Notification();
            notification.NotificationDate = DateTime.Now;
            notification.NotificationStatus = true;
            notification.NotificationValue = type;
            notification.NotificationTypeSymbol = "mdi mdi-playlist-check text-primary";
            notification.NotificationType = "Güncelleme";
            notification.NotificationDetails = '"' + name + '"' + " isimli kayıt güncellendi.";
            nm.TAdd(notification);
        }
        public void NotificationDelete(string name, string type)
        {
            Notification notification = new Notification();
            notification.NotificationDate = DateTime.Now;
            notification.NotificationStatus = true;
            notification.NotificationValue = type;
            notification.NotificationTypeSymbol = "mdi mdi-playlist-remove text-danger ";
            notification.NotificationType = "Silme";
            notification.NotificationDetails = '"' + name + '"' + " isimli kayıt silindi.";
            nm.TAdd(notification);
        }
        public void NotificationSell(string name, string type)
        {
            Notification notification = new Notification();
            notification.NotificationDate = DateTime.Now;
            notification.NotificationStatus = true;
            notification.NotificationValue = type;
            notification.NotificationTypeSymbol = "mdi mdi-playlist-play text-warning ";
            notification.NotificationType = "Satış";
            notification.NotificationDetails = '"' + name + '"' + " isimli kayıt satıldı.";
            nm.TAdd(notification);
        }
    }
}
