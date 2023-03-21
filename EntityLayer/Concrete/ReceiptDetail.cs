using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ReceiptDetail
    {
        [Key]
        public int ReceiptDetailsId { get; set; }
     
        public string ReceiptDetailsDescription { get; set; }
        public int ReceiptDetailsAmount { get; set; } //qty
        public decimal ReceiptDetailsUnitPrice { get; set; }
        public decimal ReceiptDetailsTotal { get; set; }
        public int ReceiptID { get; set; }
        public Receipt Receipt { get; set; }
    }
}
