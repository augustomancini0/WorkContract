using System;
using System.Globalization;
using WorkContract.Entities;
using WorkContract.Entities.Enums;

namespace WorkContract
{
    class program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter the departament's Name : ");
            string departmant = Console.ReadLine();

            Console.Write("Enter worker data : ");

            Console.Write("Name : ");
            string name = Console.ReadLine();

            Console.Write("Level (Junior/MiddleLevel/Senior : ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base Salary : ");
            double basesalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new Department(departmant);
            Worker worker = new Worker(name, level, basesalary, department);

            Console.Write("How many contracts to this worker? : ");
            int contracts = int.Parse(Console.ReadLine());
            for (int i = 1; i <= contracts; i++)
            {
                Console.WriteLine($"Enter #{i} contract data : ");

                Console.Write("Date (DD / MM / YYYY) : ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour : ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration(hours) : ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date,valuePerHour,hours);
                worker.AddContract(contract);

            }

            Console.Write($"Enter month and year to calculate income (MM/YYYY) :");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.Write($"Name : {worker.Name}");
            Console.WriteLine("");
            Console.Write($"Department : {worker.Department.Name}");
            Console.WriteLine("");
            Console.Write($"Income for : {monthAndYear + ':' + worker.Income(year,month)}");

        }
    }
}