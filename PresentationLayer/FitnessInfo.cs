using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLayer;

namespace PresentationLayer
{
    static public class FitnessInfo
    {
        static public FitnessCenterService fitnessCenterService;
        static public EmployeeService employeeService;
        static public MemberService memberService;

        static FitnessInfo()
        {
            fitnessCenterService = new FitnessCenterService();
            employeeService = new EmployeeService();
            memberService = new MemberService();
        }

    }

}