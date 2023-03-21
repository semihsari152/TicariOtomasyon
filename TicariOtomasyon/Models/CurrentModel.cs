using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class CurrentModel
    {
        [Key]
        public int CurrentID { get; set; }
        public string CurrentName { get; set; }
        public string CurrentSurname { get; set; }
        public string CurrentCity { get; set; }
        public string CurrentMail { get; set; }
        public string CurrentPassword { get; set; }
        public bool CurrentStatus { get; set; }
        public IFormFile CurrentImage { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}
