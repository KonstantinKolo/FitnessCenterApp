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
        public int MemberId { get; set; }
        public Member Member { get; set; }


        [Required]
        public DateTime EndDate { get; set; }

        public Membership()
        {
            
        }
        public Membership(int id, int memberID, Member member, DateTime endDate)
        {
            Id = id;
            MemberId = memberID;
            Member = member;
            EndDate = endDate;
        }
    }
}