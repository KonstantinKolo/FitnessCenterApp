using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace TestingLayer
{
    [TestFixture]
    public class MembershipContextTests
    {
        static MembershipContext membershipContext;
        static MembershipContextTests()
        {
            membershipContext = new MembershipContext(TestManager.dbContext);
        }

        [Test]
        public void CreateMembership()
        {
            Membership membership = new Membership(new DateTime(2025,1,1));
            int membershipsBefore = TestManager.dbContext.Memberships.Count();

            membershipContext.Create(membership);

            int membershipsAfter = TestManager.dbContext.Memberships.Count();
            Membership lastMembership = TestManager.dbContext.Memberships.Last();
            Assert.That(membershipsBefore + 1 == membershipsAfter &&
                        lastMembership.EndDate == membership.EndDate,
                        "End dates are not equal or membership is missing!");
        }

        [Test]
        public void ReadMembership()
        {
            Membership newMembership = new Membership(new DateTime(2025,2,2));
            membershipContext.Create(newMembership);

            Membership membership = membershipContext.Read(newMembership.Id);

            Assert.That(membership.EndDate == newMembership.EndDate,
                        "Read() does not get Membership by id!");
        }

        [Test]
        public void ReadAllMembersships()
        {
            int membershipsBefore = TestManager.dbContext.Memberships.Count();

            int membershipsAfter = membershipContext.ReadAll().Count;

            Assert.That(membershipsBefore == membershipsAfter,
                        "ReadAll() does not return all Memberships!");
        }

        [Test]
        public void UpdateMembership()
        {
            Membership newMembership = new Membership(new DateTime(2025,3,3));
            membershipContext.Create(newMembership);

            Membership lastMembership = TestManager.dbContext.Memberships.Last();
            lastMembership.EndDate = new DateTime(2025,4,4);

            membershipContext.Update(lastMembership);

            Assert.That(membershipContext.Read(lastMembership.Id).EndDate == new DateTime(2025,4,4),
                        "Update() does not update Membership!");
        }

        [Test]
        public void DeleteMembership()
        {
            Membership newMembership = new Membership(new DateTime(2025,5,5));
            membershipContext.Create(newMembership);

            List<Membership> memberships = membershipContext.ReadAll();
            int membershipsBefore = memberships.Count;
            Membership membership = memberships.Last();

            membershipContext.Delete(membership.Id);

            int membershipsAfter = membershipContext.ReadAll().Count;
            Assert.That(membershipsBefore == membershipsAfter + 1,
                        "Delete() does not delete Membership!");
        }

        [Test]
        public void DeleteMember2()
        {
            Membership newMembership = new Membership(new DateTime(2025,6,6));
            membershipContext.Create(newMembership);

            Membership membership = membershipContext.ReadAll().Last();
            int membershipId = membership.Id;

            membershipContext.Delete(membershipId);

            try 
            {
                Membership testMembership = membershipContext.Read(membershipId);

                Assert.That(false,
                            "Delete2() does not delete Membership!");
            }
            catch
            {
                Assert.That(true);
            }
        }
    }
}