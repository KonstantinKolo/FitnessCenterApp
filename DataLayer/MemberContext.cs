using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MemberContext : IDb<Member, int>
    {
        FitnessDbContext dbContext;

        public MemberContext(FitnessDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Member item)
        {
            Membership membershipFromDb = dbContext.Memberships.Find(item.LastMembership.Id);
            if (membershipFromDb != null) item.LastMembership = membershipFromDb;

            dbContext.Members.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Member memberFromDb = Read(key);
            dbContext.Members.Remove(memberFromDb);
            dbContext.SaveChanges();
        }

        public Member Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Member> query = dbContext.Members;
            if (useNavigationalProperties) query = query
            .Include(b => b.LastMembership);

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Member member = query.FirstOrDefault(b => b.Id == key);

            if (member == null) throw new ArgumentException($"Member with Id {key} does not exist!");

            return member;
        }

        public List<Member> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Member> query = dbContext.Members;
            if (useNavigationalProperties) query = query
            .Include(b => b.LastMembership);

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Member item, bool useNavigationalProperties = false)
        {
            throw new NotImplementedException();
        }
    }
}