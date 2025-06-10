using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class FitnessCenterContext : IDb<FitnessCenter, int>
    {
        FitnessDbContext dbContext;

        public FitnessCenterContext(FitnessDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(FitnessCenter item)
        {
            List<Employee> employees = new List<Employee>(item.EmployeesList.Count);
            for (int i = 0; i < item.EmployeesList.Count; ++i)
            {
                Employee employeeFromDb = dbContext.Employees.Find(item.EmployeesList[i].Id);
                if (employeeFromDb != null) employees.Add(employeeFromDb);
                else employees.Add(item.EmployeesList[i]);
            }
            item.EmployeesList = employees;

            dbContext.FitnessCenters.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            FitnessCenter fitnessCenterFromDb = Read(key);
            dbContext.FitnessCenters.Remove(fitnessCenterFromDb);
            dbContext.SaveChanges();
        }

        public FitnessCenter Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<FitnessCenter> query = dbContext.FitnessCenters;
            if (useNavigationalProperties) query = query
            .Include(b => b.EmployeesList);

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            FitnessCenter fitnessCenter = query.FirstOrDefault(b => b.Id == key);

            if (fitnessCenter == null) throw new ArgumentException($"FitnessCenter with Id {key} does not exist!");

            return fitnessCenter;
        }

        public List<FitnessCenter> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<FitnessCenter> query = dbContext.FitnessCenters;
            if (useNavigationalProperties) query = query
            .Include(b => b.EmployeesList);

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(FitnessCenter item, bool useNavigationalProperties = false)
        {
            FitnessCenter fitnessCenterFromDb = Read(item.Id, useNavigationalProperties);

            dbContext.Entry<FitnessCenter>(fitnessCenterFromDb).CurrentValues.SetValues(item);

            if (useNavigationalProperties)
            {
                List<Employee> employees = new List<Employee>(item.EmployeesList.Count);
                for (int i = 0; i < item.EmployeesList.Count; ++i)
                {
                    Employee employeeFromDb = dbContext.Employees.Find(item.EmployeesList[i].Id);
                    if (employeeFromDb != null) employees.Add(employeeFromDb);
                    else employees.Add(item.EmployeesList[i]);
                }
                fitnessCenterFromDb.EmployeesList = employees;
            }

            dbContext.SaveChanges();
        }
    }
}