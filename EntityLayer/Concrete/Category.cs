using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
     
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
      
        public string CategoryImage { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
