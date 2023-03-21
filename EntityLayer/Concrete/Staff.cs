using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Staff
    {
        [Key]
        public int StaffID { get; set; }
     
        public String StaffName { get; set; }
      
        public String StaffSurname { get; set; }

    
        public string StaffImage { get; set; }
        public bool StaffStatus { get; set; }

   
        public string StaffMail { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }


        public int DepartmentID { get; set; }
        public Department Department { get; set; }
    }
}
