using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
		public Membership Membership { get; set; }

		public List<Payment> Payments { get; set; } = new List<Payment>();


		public Member()
		{

		}
		public Member(string firstName, string lastName, Membership membership)
		{
			FirstName = firstName;
			LastName = lastName;
			Membership = membership;
		}
	}
}