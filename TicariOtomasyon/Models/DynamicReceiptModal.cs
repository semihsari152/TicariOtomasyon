using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class DynamicReceiptModal
    {
        public IEnumerable<Receipt> value1 { get; set; }
        public IEnumerable<ReceiptDetail> value2 { get; set; }
    }
}
