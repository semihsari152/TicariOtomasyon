using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Receipt
    {
        [Key]
        public int ReceiptID { get; set; }

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
