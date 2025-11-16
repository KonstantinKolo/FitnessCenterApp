using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
	public class PaymentService
	{
		private PaymentContext paymentContext = FitnessAppService.paymentContext;
		private MemberContext memberContext = FitnessAppService.memberContext;

		public List<int> PaymentIds = new List<int>();

		public void CreatePayment(int memberId, decimal amount, DateTime date, PaymentMethod method)
		{
			try
			{
				Member member = memberContext.Read(memberId);

				Payment payment = new Payment(member, amount, date, method);

				paymentContext.Create(payment);
				PaymentIds.Add(payment.Id);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("Could not create payment", ex);
			}
		}

		public Payment GetPayment(int paymentId)
		{
			try
			{
				return paymentContext.Read(paymentId, true);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("Could not get payment", ex);
			}
		}

		public List<Payment> GetAllPayments(bool navProps = false)
		{
			try
			{
				return paymentContext.ReadAll(navProps);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("Could not read payments", ex);
			}
		}

		public void UpdatePayment(Payment payment, bool navProps = false)
		{
			try
			{
				paymentContext.Update(payment, navProps);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("Could not update payment", ex);
			}
		}

		public void DeletePayment(int paymentId)
		{
			try
			{
				paymentContext.Delete(paymentId);
				PaymentIds.Remove(paymentId);
			}
			catch (Exception ex)
			{
				throw new ArgumentException("Could not delete payment", ex);
			}
		}
	}
}
