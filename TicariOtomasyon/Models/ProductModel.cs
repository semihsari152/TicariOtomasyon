using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductMark { get; set; }
        public short ProductStock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool ProductStatus { get; set; }
        public IFormFile ProductImage { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}
