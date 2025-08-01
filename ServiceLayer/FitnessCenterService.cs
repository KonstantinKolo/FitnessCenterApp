using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataLayer;

namespace ServiceLayer
{
    public class FitnessCenterService
    {
        private FitnessCenterContext fitnessCenterContext = FitnessAppService.fitnessCenterContext;

        public List<int> FitnessCenterIds = new List<int>();

        public FitnessCenterService()
        {
            FitnessCenterIds.Add(2); // for testing purposes
        }

        public void CreateFitnessCenter(string address, string name)
        {
            try
            {
                FitnessCenter fitnessCenter = new FitnessCenter(address, name);
                fitnessCenterContext.Create(fitnessCenter);

                FitnessCenterIds.Add(fitnessCenter.Id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not create fitness center", ex);
            }
        }

        public Tuple<string, string> GetFitnessNameAndAddress(int fitnessCenterId)
        {
            try
            {
                FitnessCenter fitnessCenter = fitnessCenterContext.Read(fitnessCenterId);
                return new Tuple<string, string>(fitnessCenter.Name, fitnessCenter.Address);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not get fitness center", ex);
            }
        }

        public List<int> GetEmployeeIds(int fitnessCenterId)
        {
            try
            {
                FitnessCenter fitnessCenter = fitnessCenterContext.Read(fitnessCenterId);
                return fitnessCenter.EmployeesList.Select(e => e.Id).ToList();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not get employees", ex);
            }
        }

        public void DeleteFitnessCenter(int fitnessCenterId)
        {
            try
            {
                fitnessCenterContext.Delete(fitnessCenterId);
                FitnessCenterIds.Remove(fitnessCenterId);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Could not delete fitness center", ex);
            }
        }

        public Dictionary<int, string> LoadFitnessCenterNameAndId()
        {
            List<string> names = fitnessCenterContext.ReadAll().Select(e => e.Name).ToList();
            List<int> ids = fitnessCenterContext.ReadAll().Select(e => e.Id).ToList();

            Dictionary<int, string> output = new Dictionary<int, string>();

            for (int i = 0; i < names.Count; i++)
            {
                output.Add(ids[i], names[i]);
            }

            return output;
        }
    }
}