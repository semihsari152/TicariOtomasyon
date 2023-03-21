using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SalesMovement //Satış Hareketleri
    {
        [Key]
        public int SalesMovementsID { get; set; }
        public DateTime SalesMovementsDate { get; set; }
        public int SalesMovementsUnit { get; set; }//Adet
        public decimal SalesMovementsPrice { get; set; }
        public decimal SalesMovementsTotal { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int StaffID { get; set; }
        public Staff Staff { get; set; }

        public int CurrentID { get; set; }
        public Current Current { get; set; }
    }
}
