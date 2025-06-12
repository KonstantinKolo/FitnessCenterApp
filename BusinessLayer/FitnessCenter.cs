using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FitnessCenter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Address cannot be more than 150 symbols!")]
        public string Address { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Name cannot be more than 40 symbols!")]
        public string Name { get; set; }

        public List<Employee> EmployeesList = new List<Employee>();

        public FitnessCenter()
        {
            
        }
        public FitnessCenter(string address, string name)
        {
            Address = address;
            Name = name;
        }
    }
}