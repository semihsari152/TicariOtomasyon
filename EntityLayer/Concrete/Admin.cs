using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string AdminPermission { get; set; }
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public string AdminMail { get; set; }
    }
}
