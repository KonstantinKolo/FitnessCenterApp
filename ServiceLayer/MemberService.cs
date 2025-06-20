using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class MemberService
    {
        private MemberContext memberContext = FitnessAppService.memberContext;
        private MembershipContext membershipContext = FitnessAppService.membershipContext;

        public List<int> MemberIds = new List<int>();

        public void CreateMember(string firstName, string lastName, DateTime? endDate = null)
        {
            try
            {
                // make a default membership that is expired
                if (endDate == null)
                {
                    endDate = new DateTime(2000, 1, 1);
                }

                Member member = new Member(firstName, lastName, new Membership((DateTime)endDate));

                memberContext.Create(member);
                MemberIds.Add(member.Id);

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not create member", ex);
            }
        }

        public int GetMemberId(string firstName, string lastName) 
        {
            try
            {
                List<Member> members = memberContext.ReadAll();

                foreach (Member member in members)
                {
                    if (member.FirstName == firstName && member.LastName == lastName)
                    {
                        return member.Id;
                    }
                }

                throw new ArgumentException("Member not found");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not get member id", ex);
            }
        }

        public bool IsMembershipValid(int memberId)
        {
            try
            {
                Member member = memberContext.Read(memberId);
                return member.Membership.EndDate > DateTime.Now;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not check membership", ex);
            }
        }

        public void RenewMembership(int memberId, int durationInDays)
        {
            try
            {
                Member member = memberContext.Read(memberId);

                Membership membership = member.Membership;
                membership.EndDate = DateTime.Now.AddDays(durationInDays);
                membershipContext.Update(membership);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not renew membership", ex);
            }
        }

        public void DeleteMember(int memberId)
        {
            try
            {
                memberContext.Delete(memberId);
                MemberIds.Remove(memberId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not delete member", ex);
            }
        }
    }
}