using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
	public class PaymentContext : IDb<Payment, int>
	{
		private FitnessDbContext dbContext;

		public PaymentContext(FitnessDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public void Create(Payment item)
		{
			Member memberFromDb = dbContext.Members.Find(item.Member.Id);

			if (memberFromDb != null)
				item.Member = memberFromDb;

			dbContext.Payments.Add(item);
			dbContext.SaveChanges();
		}

		public void Delete(int key)
		{
			Payment paymentFromDb = Read(key);
			dbContext.Payments.Remove(paymentFromDb);
			dbContext.SaveChanges();
		}

		public Payment Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
		{
			IQueryable<Payment> query = dbContext.Payments;

			if (useNavigationalProperties)
				query = query.Include(p => p.Member);

			if (isReadOnly)
				query = query.AsNoTrackingWithIdentityResolution();

			Payment payment = query.FirstOrDefault(p => p.Id == key);

			if (payment == null)
				throw new ArgumentException($"Payment with id {key} does not exist!");

			return payment;
		}

		public List<Payment> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
		{
			IQueryable<Payment> query = dbContext.Payments;

			if (useNavigationalProperties)
				query = query.Include(p => p.Member);

			if (isReadOnly)
				query = query.AsNoTrackingWithIdentityResolution();

			return query.ToList();
		}

		public void Update(Payment item, bool useNavigationalProperties = false)
		{
			Payment paymentFromDb = Read(item.Id, useNavigationalProperties);

			dbContext.Entry(paymentFromDb).CurrentValues.SetValues(item);

			if (useNavigationalProperties)
			{
				Member memberFromDb = dbContext.Members.Find(item.Member.Id);
				if (memberFromDb != null)
					paymentFromDb.Member = memberFromDb;
				else
					paymentFromDb.Member = item.Member;
			}

			dbContext.SaveChanges();
		}
	}
}
