using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessLayer
{
	public class Payment
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Member is required.")]
		public Member Member { get; set; }

		[Required(ErrorMessage = "Amount is required.")]
		[Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
		[Column(TypeName = "decimal(18,2)")]
		public decimal Amount { get; set; }

		[Required(ErrorMessage = "Payment Date is required.")]
		[DataType(DataType.Date)]
		public DateTime PaymentDate { get; set; }

		[Required(ErrorMessage = "Payment method is required.")]
		public PaymentMethod Method { get; set; }


		public Payment()
		{

		}
		public Payment(Member member, decimal amount, DateTime paymentDate, PaymentMethod method)
		{
			Member = member;
			Amount = amount;
			PaymentDate = paymentDate;
			Method = method;
		}
	}
}
