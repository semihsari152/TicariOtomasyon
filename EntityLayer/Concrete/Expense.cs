using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Expense //Giderler
    {
        [Key]
        public int ExpenseID { get; set; }
     
        public string ExpenseDescription { get; set; }
        public DateTime ExpenseDate { get; set; }

        public string ExpenseTime { get; set; }
        public decimal ExpenseTotal { get; set; }
    }
}
