using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace TestingLayer
{
    [TestFixture]
    public class EmployeeContextTests
    {
        static EmployeeContext employeeContext;
        static EmployeeContextTests()
        {
            employeeContext = new EmployeeContext(TestManager.dbContext);
        }

        [Test]
        public void CreateEmployee()
        {
            FitnessCenter workplace = new FitnessCenter("Sofia", "Fitness Center");
            Employee employee = new Employee("Gosho", "Goshev", "123456", workplace);
            int employeesBefore = TestManager.dbContext.Employees.Count();

            employeeContext.Create(employee);

            int employeesAfter = TestManager.dbContext.Employees.Count();
            Employee lastEmployee = TestManager.dbContext.Employees.Last();
            Assert.That(employeesBefore + 1 == employeesAfter &&
                        lastEmployee.FirstName == employee.FirstName,
                        "Names are not equal or employee is missing!");
        }

        [Test]
        public void ReadEmployee()
        {
            FitnessCenter workplace = new FitnessCenter("Sofia", "Fitness Center");
            Employee newEmployee = new Employee("Koce", "Kolovski", "123456", workplace);
            employeeContext.Create(newEmployee);

            Employee employee = employeeContext.Read(newEmployee.Id);

            Assert.That(employee.FirstName == "Koce",
                        "Read() does not get Employee by id!");
        }

        [Test]
        public void ReadAllEmployees()
        {
            int employeesBefore = TestManager.dbContext.Employees.Count();

            int employeesAfter = employeeContext.ReadAll().Count;

            Assert.That(employeesBefore == employeesAfter,
                        "ReadAll() does not return all employees!");
        }

        [Test]
        public void UpdateEmployee()
        {
            FitnessCenter workplace = new FitnessCenter("Sofia", "Fitness Center");
            Employee newEmployee = new Employee("Prarsko", "Praskov", "123456", workplace);
            employeeContext.Create(newEmployee);

            Employee lastEmployee = TestManager.dbContext.Employees.Last();
            lastEmployee.FirstName = "Vasko";

            employeeContext.Update(lastEmployee);

            Assert.That(employeeContext.Read(lastEmployee.Id).FirstName == "Vasko",
                        "Update() does not update Employee!");
        }

        [Test]
        public void UpdateEmployeeWithNacigationalProperties()
        {
            FitnessCenter workplace = new FitnessCenter("Sofia", "Fitness Center");
            Employee newEmployee = new Employee("Kiko", "Kikov", "123456", workplace);
            employeeContext.Create(newEmployee);

            FitnessCenter testFitnessCenter = new FitnessCenter("Plovid", "Hammer");
            TestManager.dbContext.FitnessCenters.Add(testFitnessCenter);
            TestManager.dbContext.SaveChanges();

            Employee employee = employeeContext.Read(newEmployee.Id);
            employee.Workplace = testFitnessCenter;
            employeeContext.Update(employee, true);

            Employee updatedEmployee = employeeContext.Read(employee.Id, true);
            Assert.That(updatedEmployee.Workplace.Id == testFitnessCenter.Id,
                        "UpdateWithNav() does not update Employee");            
        }

        [Test]
        public void DeleteEmployee()
        {
            FitnessCenter workplace = new FitnessCenter("Sofia", "Fitness Center");
            Employee newEmployee = new Employee("Tung", "Sahur", "123456", workplace);
            employeeContext.Create(newEmployee);

            List<Employee> employees = employeeContext.ReadAll();
            int employeesBefore = employees.Count;
            Employee employee = employees.Last();

            employeeContext.Delete(employee.Id);

            int employeesAfter = employeeContext.ReadAll().Count;
            Assert.That(employeesBefore - 1 == employeesAfter,
                        "Delete() does not delete Employee!");
        }

        [Test]
        public void DeleteEmployee2()
        {
            FitnessCenter workplace = new FitnessCenter("Sofia", "Fitness Center");
            Employee newEmployee = new Employee("Tung", "Sahur", "123456", workplace);
            employeeContext.Create(newEmployee);

            Employee employee = employeeContext.ReadAll().Last();
            int employeeId = employee.Id;

            employeeContext.Delete(employeeId);

            try 
            {
                Employee testEmployee = employeeContext.Read(employeeId);

                Assert.That(false, "Delete2() does not delete Employee!");
            }
            catch
            {
                Assert.That(true);
            }
        }
    }
}