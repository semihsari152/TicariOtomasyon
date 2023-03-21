using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ToDoList
    {
        [Key]
        public int ToDoListID { get; set; }
        public string ToDoListName { get; set; }
        public bool ToDoListStatus { get; set; }
    }
}
