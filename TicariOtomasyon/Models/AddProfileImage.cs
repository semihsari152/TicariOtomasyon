using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TicariOtomasyon.Models
{
    public class AddProfileImage
    {
        [Key]
        public int StaffID { get; set; }
    
        public String StaffName { get; set; }
       
        public String StaffSurname { get; set; }

     
        public IFormFile StaffImage { get; set; }
        public bool StaffStatus { get; set; }

     
        public string StaffMail { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }


        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
