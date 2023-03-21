using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        public IFormFile CategoryImage { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
