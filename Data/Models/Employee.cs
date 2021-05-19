using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAngulardotnet.Data.Models
{
    //[Table("Employee")]
    public class Employee
    {
        public Employee()
        {

        }
        //[Key]
        //[Required]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
    }
}
