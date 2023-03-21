using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; } 
        public string CurrentName { get; set; }
        public string CurrentSurname { get; set; }
        public string CurrentCity { get; set; } 
        public string CurrentMail { get; set; }
        public string CurrentPassword { get; set; }
        public bool CurrentStatus { get; set; } 
        public string CurrentImage { get; set; }
        public string CurrentPhone { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }

    }
}
