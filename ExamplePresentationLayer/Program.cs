using ServiceLayer;

namespace ExamplePresentationLayer;

class Program
{
    static void Main(string[] args)
    {
        EmployeeService employeeService = new EmployeeService();
        FitnessCenterService fitnessCenterService = new FitnessCenterService();
        MemberService memberService = new MemberService();
        
        System.Console.WriteLine(new string('|', 100));
        TakeEmployeeLogin(employeeService);
        System.Console.WriteLine(new string('|', 100));

        System.Console.WriteLine("Welcome " 
        + employeeService.GetEmployeeFullName(employeeService.LoggedInEmployeeId).Item1 + " "
        + employeeService.GetEmployeeFullName(employeeService.LoggedInEmployeeId).Item2 + "!");

        System.Console.WriteLine(new string('|', 100));
        ListCommands();



        // System.Console.WriteLine("Adding test fitness centers");
        // fitnessCenterService.CreateFitnessCenter("123 Main St", "Fitness Center 1");
        // fitnessCenterService.CreateFitnessCenter("456 Main St", "Fitness Center 2");

        // List<int> fitnessCenterIds = fitnessCenterService.FitnessCenterIds;

        // DisplayFitnessCenters(fitnessCenterService, fitnessCenterIds);


        // System.Console.WriteLine("Adding test employees");
        // employeeService.CreateEmployee("John", "Doe", "1234", fitnessCenterIds[0]);
        // employeeService.CreateEmployee("Jane", "Doe", "test", fitnessCenterIds[1]);

        // TestPasswordInput(employeeService);


        // System.Console.WriteLine("Adding test members");
        // memberService.CreateMember("Konstantin", "Kolovski");

        // TestMembershipValidity(memberService);
    }

    static private void TakeEmployeeLogin(EmployeeService employeeService)
    {
        System.Console.Write("Enter employee first name: ");
        string firstName = Console.ReadLine();

        System.Console.Write("Enter employee last name: ");
        string lastName = Console.ReadLine();

        System.Console.Write("Enter employee password: ");
        string password = Console.ReadLine();

        System.Console.WriteLine(new string('|', 100));
        System.Console.WriteLine();

        int id = employeeService.GetEmployeeId(firstName, lastName, password);
        employeeService.LoggedInEmployeeId = id;
    }

    static private void ListCommands()
    {
        System.Console.WriteLine("List of commands:");

        System.Console.WriteLine("\nAdd commands:");
        System.Console.WriteLine("    * AddE -> add a new employee");
        System.Console.WriteLine("    * AddM -> add a new member");
        System.Console.WriteLine("    * AddFC -> add a new fitness center");

        System.Console.WriteLine("\nUpdate commands:");
        System.Console.WriteLine("    * ChE -> change employee workplace");
        System.Console.WriteLine("    * ChM -> change member membership");
        System.Console.WriteLine("    * ChFC -> change fitness center name");

        // And so on
    }





    static private void TestMembershipValidity(MemberService memberService)
    {
        System.Console.WriteLine(new string('|', 20));
        System.Console.WriteLine("Testing the validity of a default membership and a new one.");

        bool isValid1 = memberService.IsMembershipValid(memberService.MemberIds[0]);

        memberService.RenewMembership(memberService.MemberIds[0], 30);
        bool isValid2 = memberService.IsMembershipValid(memberService.MemberIds[0]);

        System.Console.WriteLine("This should be false: " + isValid1);
        System.Console.WriteLine("This should be true: " + isValid2);

        System.Console.WriteLine(new string('|', 20));
    }

    static private void TestPasswordInput(EmployeeService employeeService)
    {
        System.Console.WriteLine(new string('|', 20));

        string fullname = string.Join(' ', employeeService.GetEmployeeFullName(employeeService.EmployeeIds[0]));
        
        System.Console.WriteLine("Enter password for employee: " + fullname);
        string password = System.Console.ReadLine();
        
        bool passwordCorrect = employeeService.TestPassword(employeeService.EmployeeIds[0], password);
        if (passwordCorrect) System.Console.WriteLine("Password correct");
        else System.Console.WriteLine("Password incorrect");

        System.Console.WriteLine(new string('|', 20));
    }

    static private void DisplayFitnessCenters(FitnessCenterService fitnessCenterService, List<int> fitnessCenterIds)
    {
        

        List<string> fitnessNames = new List<string>();

    System.Console.WriteLine(new string('|', 20));
        for (int i = 0; i < fitnessCenterIds.Count; i++)
        {
            Tuple<string, string> fitnessNameAndAddress = fitnessCenterService.GetFitnessNameAndAddress(fitnessCenterIds[i]);
            fitnessNames.Add(fitnessNameAndAddress.Item1);
            System.Console.WriteLine($"Fitness Center {i + 1} Name: {fitnessNameAndAddress.Item1} Address: {fitnessNameAndAddress.Item2}");
        }
        System.Console.WriteLine(new string('|', 20));
    }
}
