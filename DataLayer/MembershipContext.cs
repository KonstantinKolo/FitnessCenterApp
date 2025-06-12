using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class MembershipContext : IDb<Membership, int>
    {
        FitnessDbContext dbContext;

        public MembershipContext(FitnessDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Membership item)
        {
            dbContext.Memberships.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Membership membershipFromDb = Read(key);
            dbContext.Memberships.Remove(membershipFromDb);
            dbContext.SaveChanges();
        }

        public Membership Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Membership> query = dbContext.Memberships;

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Membership membership = query.FirstOrDefault(b => b.Id == key);

            if (membership == null) throw new ArgumentException($"Membership with Id {key} does not exist!");

            return membership;
        }

        public List<Membership> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Membership> query = dbContext.Memberships;

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Membership item, bool useNavigationalProperties = false)
        {
            Membership membershipFromDb = Read(item.Id, useNavigationalProperties);

            dbContext.Entry<Membership>(membershipFromDb).CurrentValues.SetValues(item);

            dbContext.SaveChanges();
        }
    }
}