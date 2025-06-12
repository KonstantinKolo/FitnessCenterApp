using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Membership
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public Membership()
        {
            
        }
        public Membership(DateTime endDate)
        {
            EndDate = endDate;
        }
    }
}