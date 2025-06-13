using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace TestingLayer
{
    [TestFixture]
    public class MemberContextTests
    {
        static MemberContext memberContext;
        static MemberContextTests()
        {
            memberContext = new MemberContext(TestManager.dbContext);
        }

        [Test]
        public void CreateMember()
        {
            // Arrange
            Member member = new Member("Gringo", "Mitkov", new Membership(new DateTime(2025,6,3)));
            int membersBefore = TestManager.dbContext.Members.Count();

            // Act
            memberContext.Create(member);

            // Assert
            int membersAfter = TestManager.dbContext.Members.Count();
            Member lastMember = TestManager.dbContext.Members.Last();
            Assert.That(membersBefore + 1 == membersAfter &&
                        lastMember.FirstName == member.FirstName,
                        "Names are not equal or member is missing!");
        }

        [Test]
        public void ReadMember()
        {
            // Arrange
            Member newMember = new Member("Koce", "Kolovski", new Membership(new DateTime(2025,6,3)));
            memberContext.Create(newMember);

            Member member = memberContext.Read(newMember.Id);

            Assert.That(member.FirstName == "Koce",
                        "Read() does not get Member by id!");
        }

        [Test]
        public void ReadAllMembers()
        {
            int membersBefore = TestManager.dbContext.Members.Count();

            int membersAfter = memberContext.ReadAll().Count();

            Assert.That(membersBefore == membersAfter,
                        "ReadAll() does not get all Members!");
        }

        [Test]
        public void UpdateMember()
        {
            Member newMember = new Member("Kiko", "Pekata", new Membership(new DateTime(2025,6,3)));
            memberContext.Create(newMember);

            Member lastMember = memberContext.ReadAll().Last();
            lastMember.FirstName = "Kristiqn";

            memberContext.Update(lastMember);

            Assert.That(memberContext.Read(lastMember.Id).FirstName == "Kristiqn",
                        "Update() does not update Member!");
        }

        [Test]
        public void UpdateUserWithNavigationalProperties()
        {
            // Create test member
            Member newMember = new Member("Alice", "Brown", new Membership(new DateTime(2025,6,3)));
            memberContext.Create(newMember);
            
            // Create test membership
            Membership testMembership = new Membership(new DateTime(2030,12,12));
            TestManager.dbContext.Memberships.Add(testMembership);
            TestManager.dbContext.SaveChanges();
            
            // Update member with interest
            Member member = memberContext.Read(newMember.Id);
            member.Membership = testMembership;
            memberContext.Update(member, true);
            
            // Verify update
            Member updatedMember = memberContext.Read(member.Id, true);
            Assert.That(updatedMember.Membership.Id == testMembership.Id,
                       "UpdateWithNav() does not update Member!");
        }

        [Test]
        public void DeleteMember()
        {
            Member newMember = new Member("Sigma", "Chadski", new Membership(new DateTime(2025,6,3)));
            memberContext.Create(newMember);

            List<Member> members = memberContext.ReadAll();
            int membersBefore = members.Count;
            Member member = members.Last();

            memberContext.Delete(member.Id);

            int membersAfter = memberContext.ReadAll().Count;
            Assert.That(membersBefore == membersAfter + 1, "Delete() does not delete a member!");
        }

	    // II way: Check if the deleted item is really the one with the primary key we sent:
        [Test]
        public void DeleteMember2()
        {
            Member newMember = new Member("Vasko", "Prasko", new Membership(new DateTime(2025,6,3)));
            memberContext.Create(newMember);

            Member member = memberContext.ReadAll().Last();
            int memberId = member.Id;

            memberContext.Delete(memberId);

            try
            {
                Member testMember = memberContext.Read(memberId);


                Assert.That(false,
                            $"Deleted member with id {memberId} has beeb found!");
            }
            catch
            {
                Assert.That(true);
            }
        }
    }
}