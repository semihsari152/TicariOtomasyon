using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
    
        public string DepartmentName { get; set; }
        public ICollection<Staff> Staffs { get; set; }
        public bool DepartmentStatus { get; set; }
    }
}
