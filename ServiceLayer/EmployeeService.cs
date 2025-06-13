using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class EmployeeService
    {
        private EmployeeContext employeeContext = FitnessAppService.employeeContext;
        private FitnessCenterContext fitnessCenterContext = FitnessAppService.fitnessCenterContext;

        public List<int> EmployeeIds = new List<int>();
        public int LoggedInEmployeeId = -1;

        public void CreateEmployee(string firstName, string lastName, string password, int workplaceId)
        {
            try
            {
                FitnessCenter workplace = fitnessCenterContext.Read(workplaceId);
                Employee employee = new Employee(firstName, lastName, password, workplace);
                employeeContext.Create(employee);

                EmployeeIds.Add(employee.Id);

                if (!workplace.EmployeesList.Contains(employee))
                { 
                    workplace.EmployeesList.Add(employee);
                    fitnessCenterContext.Update(workplace, true);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not create employee", ex);
            }
        }

        public int GetEmployeeId(string firstName, string lastName, string password)
        {
            try
            {
                List<Employee> employees = employeeContext.ReadAll();

                foreach (Employee employee in employees)
                {
                    if (employee.FirstName == firstName && employee.LastName == lastName && employee.Password == password)
                    {
                        return employee.Id;
                    }
                }

                throw new ArgumentException("Employee not found");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not get employee id", ex);
            }
        }

        public bool TestPassword(int employeeId, string password)
        {
            try
            {
                Employee employee = employeeContext.Read(employeeId);
                return employee.Password == password;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not test password", ex);
            }
        }

        public int GetWorkPlaceId(int employeeId)
        {
            try
            {
                Employee employee = employeeContext.Read(employeeId);
                return employee.Workplace.Id;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not get workplace", ex);
            }
        }

        public Tuple<string,string> GetEmployeeFullName(int employeeId)
        {
            try
            {
                Employee employee = employeeContext.Read(employeeId);
                return new Tuple<string, string>(employee.FirstName, employee.LastName);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not get employee", ex);
            }
        }

        public void ChangeWorkplace(int employeeId, FitnessCenter workplace)
        {
            try
            {
                Employee employee = employeeContext.Read(employeeId);

                employee.Workplace.EmployeesList.Remove(employee);
                employee.Workplace = workplace;

                employeeContext.Update(employee, true);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not change workplace", ex);
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            try
            {
                employeeContext.Delete(employeeId);
                EmployeeIds.Remove(employeeId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not delete employee", ex);
            }
        }
    }
}