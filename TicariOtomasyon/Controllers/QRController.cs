using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Controllers
{
    public class QRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string code)
        {

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator generatecode = new QRCodeGenerator();
                QRCodeData codedata = generatecode.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                QRCode qrcode = new QRCode(codedata);

                using (Bitmap resim = qrcode.GetGraphic(20))
                {
                    resim.Save(ms, ImageFormat.Png);
                    ViewBag.karekodimage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }

            return View();
        }
    }
}
