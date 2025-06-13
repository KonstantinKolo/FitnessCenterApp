using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace TestingLayer
{
    [TestFixture]
    public class FitnessCenterContextTests
    {
        static FitnessCenterContext fitnessCenterContext;
        static FitnessCenterContextTests()
        {
            fitnessCenterContext = new FitnessCenterContext(TestManager.dbContext);
        }

        [Test]
        public void CreateFitness()
        {
            FitnessCenter fitnessCenter = new FitnessCenter("Sofia", "Fitness Center");
            int fitnessCentersBefore = TestManager.dbContext.FitnessCenters.Count();

            fitnessCenterContext.Create(fitnessCenter);

            int fitnessCentersAfter = TestManager.dbContext.FitnessCenters.Count();
            FitnessCenter lastFitnessCenter = TestManager.dbContext.FitnessCenters.Last();

            Assert.That(fitnessCentersBefore + 1 == fitnessCentersAfter &&
                        lastFitnessCenter.Name == fitnessCenter.Name,
                        "Names are not equal or fitnessCenter is missing!");
        }

        [Test]
        public void ReadFitness()
        {
            FitnessCenter newFitnessCenter = new FitnessCenter("Plovdiv", "Hammer Gym");
            fitnessCenterContext.Create(newFitnessCenter);

            FitnessCenter fitnessCenter = fitnessCenterContext.Read(newFitnessCenter.Id);

            Assert.That(fitnessCenter.Name == "Hammer Gym",
                        "Read() does not get FitnessCenter by id!");
        }

        [Test]
        public void ReadAllFitness()
        {
            int fitnessBefore = TestManager.dbContext.FitnessCenters.Count();

            int fintessAfter = fitnessCenterContext.ReadAll().Count();

            Assert.That(fitnessBefore == fintessAfter,
                        "ReadAll() does not get all FitnessCenters!");
        }

        [Test]
        public void UpdateFitness()
        {
            FitnessCenter fitnessCenter = new FitnessCenter("Varna", "Fitness Center");
            fitnessCenterContext.Create(fitnessCenter);

            FitnessCenter lastFitnessCenter = fitnessCenterContext.ReadAll().Last();
            lastFitnessCenter.Name = "Fitness Center 2";

            fitnessCenterContext.Update(lastFitnessCenter);

            Assert.That(lastFitnessCenter.Name == "Fitness Center 2",
                        "Update() does not update FitnessCenter!");
        }

        [Test]
        public void UpdateFitnessWithNavigationalProperties()
        {
            FitnessCenter newFitness = new FitnessCenter("Burgas", "Healthy Life");
            
            Employee employee1 = new Employee("Ivan", "Ivanov", "0888888888", newFitness);
            TestManager.dbContext.Employees.Add(employee1);
            TestManager.dbContext.SaveChanges();
            
            newFitness.EmployeesList.Add(employee1);
            
            // Update the employee list
            FitnessCenter fitnessCenter = fitnessCenterContext.Read(newFitness.Id, true);

            Employee employee2 = new Employee("Georgi", "Georgiev", "0888888888", newFitness);
            TestManager.dbContext.Employees.Add(employee2);
            TestManager.dbContext.SaveChanges();

            fitnessCenter.EmployeesList.Add(employee2);

            fitnessCenterContext.Update(fitnessCenter, true);

            // Verify
            FitnessCenter updatedFitnessCenter = fitnessCenterContext.Read(newFitness.Id, true);
            Assert.That(updatedFitnessCenter.EmployeesList.Count == 2,
                        "Update() does not update FitnessCenter with navigational properties!");
        }

        [Test]
        public void DeleteFitness()
        {
            FitnessCenter newFitness = new FitnessCenter("Varna", "Run Room");
            fitnessCenterContext.Create(newFitness);

            List<FitnessCenter> fitnessCenters = fitnessCenterContext.ReadAll();
            int fitnessCentersBefore = fitnessCenters.Count;
            FitnessCenter fitness = fitnessCenters.Last();

            fitnessCenterContext.Delete(fitness.Id);

            int fitnessCentersAfter = fitnessCenterContext.ReadAll().Count;
            Assert.That(fitnessCentersBefore - 1 == fitnessCentersAfter,
                        "Delete() does not delete the FitnessCenter!");
        }

        [Test]
        public void DeleteFitness2()
        {
            FitnessCenter newFitness = new FitnessCenter("Dobrich", "Gringo room");
            fitnessCenterContext.Create(newFitness);

            FitnessCenter fitness = fitnessCenterContext.ReadAll().Last();
            int fitnessId = fitness.Id;

            fitnessCenterContext.Delete(fitnessId);

            try
            {
                FitnessCenter testFitness = fitnessCenterContext.Read(fitnessId);

                Assert.That(false,
                            "Delete2() does not delete the FitnessCenter!");
            }
            catch
            {
                Assert.That(true);
            }
        }
    }
}