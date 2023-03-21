using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class DynamicRequestModel
    {
        public string ReceiptSerialNumber { get; set; }

        public string ReceiptLineNumber { get; set; }

        public DateTime ReceiptDate { get; set; }

        public string ReceiptTaxAuthority { get; set; }//Vergi Dairesi


        public string ReceiptTime { get; set; }


        public string ReceiptSupplier { get; set; }//Teslim Eden


        public string ReceiptReceiver { get; set; }//Teslim Alan

        public decimal ReceiptTotal { get; set; }

        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
