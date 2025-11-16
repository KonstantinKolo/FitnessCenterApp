using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;

namespace ServiceLayer
{
    static internal class FitnessAppService
    {
        static internal FitnessDbContext dbContext = new FitnessDbContext();
        
        static internal EmployeeContext employeeContext = new EmployeeContext(dbContext);
        static internal FitnessCenterContext fitnessCenterContext = new FitnessCenterContext(dbContext);
        static internal MemberContext memberContext = new MemberContext(dbContext);
        static internal MembershipContext membershipContext = new MembershipContext(dbContext);
        static internal PaymentContext paymentContext = new PaymentContext(dbContext);
    }
}
