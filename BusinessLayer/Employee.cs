using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Name cannot be more than 40 symbols!")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Name cannot be more than 40 symbols!")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(40, ErrorMessage = "Name cannot be more than 40 symbols!")]
        public string Password { get; set; }

        [Required]
        public FitnessCenter Workplace { get; set; }

        public Employee()
        {
            
        }
        public Employee(string firstName, string lastName, string password, FitnessCenter workplace)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Workplace = workplace;
        }
    }
}