using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Member
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
        public Membership LastMembership { get; set; }

        public Member()
        {
            
        }
        public Member(int id, string firstName, string lastName, Membership lastMembership)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            LastMembership = lastMembership;
        }
    }
}