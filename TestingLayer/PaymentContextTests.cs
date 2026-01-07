using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace TestingLayer
{
    [TestFixture]
    public class PaymentContextTests
    {
        static PaymentContext paymentContext;
        static PaymentContextTests()
        {
            paymentContext = new PaymentContext(TestManager.dbContext);
        }

        [Test]
        public void CreatePayment()
        {
            Payment payment = new Payment(new Member("Koce", "Kolo", new Membership(DateTime.UtcNow)), 99.99m, DateTime.UtcNow, PaymentMethod.Cash);
            int paymentsBefore = TestManager.dbContext.Payments.Count();

            paymentContext.Create(payment);

            int paymentsAfter = TestManager.dbContext.Payments.Count();
            Payment lastPayment = TestManager.dbContext.Payments.Last();
            Assert.That(paymentsBefore + 1 == paymentsAfter &&
                        lastPayment.PaymentDate == payment.PaymentDate,
                        "Payment dates are not equal or payment is missing!");
        }

        [Test]
        public void ReadPayment()
        {
            Payment newPayment = new Payment(new Member("Koce", "Kolo", new Membership(DateTime.UtcNow)), 99.99m, DateTime.UtcNow, PaymentMethod.Cash);
            paymentContext.Create(newPayment);

            Payment payment = paymentContext.Read(newPayment.Id);

            Assert.That(payment.PaymentDate == newPayment.PaymentDate,
                        "Read() does not get Payment by id!");
        }

        [Test]
        public void ReadAllPayments()
        {
            int paymentsBefore = TestManager.dbContext.Payments.Count();

            int paymentsAfter = paymentContext.ReadAll().Count;

            Assert.That(paymentsBefore == paymentsAfter,
                        "ReadAll() does not return all Payments!");
        }

        [Test]
        public void UpdatePayment()
        {
            Payment newPayment = new Payment(new Member("Koce", "Kolo", new Membership(DateTime.UtcNow)), 99.99m, DateTime.UtcNow, PaymentMethod.Cash);
            paymentContext.Create(newPayment);

            Payment lastPayment = TestManager.dbContext.Payments.Last();
            lastPayment.PaymentDate = new DateTime(2025, 4, 4);

            paymentContext.Update(lastPayment);

            Assert.That(paymentContext.Read(lastPayment.Id).PaymentDate == new DateTime(2025, 4, 4),
                        "Update() does not update Payment!");
        }

        [Test]
        public void DeletePayment()
        {
            Payment newPayment = new Payment(new Member("Koce", "Kolo", new Membership(DateTime.UtcNow)), 99.99m, DateTime.UtcNow, PaymentMethod.Cash);
            paymentContext.Create(newPayment);

            List<Payment> payments = paymentContext.ReadAll();
            int paymentsBefore = payments.Count;
            Payment payment = payments.Last();

            paymentContext.Delete(payment.Id);

            int paymentsAfter = paymentContext.ReadAll().Count;
            Assert.That(paymentsBefore == paymentsAfter + 1,
                        "Delete() does not delete Payment!");
        }

        [Test]
        public void DeletePayment2()
        {
            Payment newPayment = new Payment(new Member("Koce", "Kolo", new Membership(DateTime.UtcNow)), 99.99m, DateTime.UtcNow, PaymentMethod.Cash);
            paymentContext.Create(newPayment);

            Payment payment = paymentContext.ReadAll().Last();
            int paymentId = payment.Id;

            paymentContext.Delete(paymentId);

            try
            {
                Payment testPayment = paymentContext.Read(paymentId);

                Assert.That(false,
                            "Delete2() does not delete Payment!");
            }
            catch
            {
                Assert.That(true);
            }
        }
    }
}