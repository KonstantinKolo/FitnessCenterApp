using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{

    public class EmployeeContext : IDb<Employee, int>
    {
        private FitnessDbContext dbContext;

        public EmployeeContext(FitnessDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Create(Employee item)
        {
            FitnessCenter workplacefromDb = dbContext.FitnessCenters.Find(item.Workplace.Id);
		    if (workplacefromDb != null) item.Workplace = workplacefromDb;

            dbContext.Employees.Add(item);
            dbContext.SaveChanges();
        }

        public void Delete(int key)
        {
            Employee employeeFromDb = Read(key);
            dbContext.Employees.Remove(employeeFromDb);
            dbContext.SaveChanges();
        }

        public Employee Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Employee> query = dbContext.Employees;
            if (useNavigationalProperties) query = query
            .Include(b => b.Workplace);

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            Employee employee = query.FirstOrDefault(b => b.Id == key);

            if (employee == null) throw new ArgumentException($"Employee with id {key} does not exist!");

            return employee;
        }

        public List<Employee> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Employee> query = dbContext.Employees;
            if (useNavigationalProperties) query = query
            .Include(b => b.Workplace);

            if (isReadOnly) query = query.AsNoTrackingWithIdentityResolution();

            return query.ToList();
        }

        public void Update(Employee item, bool useNavigationalProperties = false)
        {
            Employee employeeFromDb = Read(item.Id, useNavigationalProperties);

            dbContext.Entry<Employee>(employeeFromDb).CurrentValues.SetValues(item);

            if (useNavigationalProperties)
            {
                FitnessCenter workplaceFromDb = dbContext.FitnessCenters.Find(item.Workplace.Id);
                if (workplaceFromDb != null) employeeFromDb.Workplace = workplaceFromDb;
                else employeeFromDb.Workplace = item.Workplace;
            }

            dbContext.SaveChanges();
        }
    }
}