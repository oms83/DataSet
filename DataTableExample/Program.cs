using System;
using System.Data;
using System.Linq;

namespace DataTableExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable Employees = new DataTable();
            Employees.Columns.Add("ID", typeof(int));
            Employees.Columns.Add("FirstName", typeof(string));
            Employees.Columns.Add("LastName", typeof(string));
            Employees.Columns.Add("Salary", typeof(double));
            Employees.Columns.Add("Country", typeof(string));
            Employees.Columns.Add("Date", typeof(DateTime));

            Employees.Rows.Add(1, "Omer", "MEMES", 12000, "Turkiye", DateTime.Now);
            Employees.Rows.Add(2, "Ali", "MEMES", 4344, "KSA", DateTime.Now);
            Employees.Rows.Add(3, "Osman", "MEMES", 5000, "Syria", DateTime.Now);
            Employees.Rows.Add(4, "Yusuf", "MEMES", 5522, "Jordan", DateTime.Now);
            Employees.Rows.Add(5, "Musa", "MEMES", 9000, "Turkiye", DateTime.Now);
            Employees.Rows.Add(6, "Abd-alrahman", "MEMES", 5433, "Turkiye", DateTime.Now);

            Console.WriteLine("Employees");

            foreach (DataRow row in Employees.Rows)
            {
                Console.WriteLine("ID: {0}  FirstName: {1}  LastName: {2}  Salary: {3}  Country: {4}  Date: {5}",
                                   row["ID"], row["FirstName"], row["LastName"], row["Salary"], row["Country"], 
                                   row["Date"]);
            }


            int CountOfEmployees = Employees.Rows.Count;
            double SumOfSalary = Convert.ToDouble(Employees.Compute("SUM(Salary)", string.Empty));
            double AvgOfSalary = Convert.ToDouble(Employees.Compute("AVG(Salary)", string.Empty));
            double MinOfSalary = Convert.ToDouble(Employees.Compute("Min(Salary)", string.Empty));
            double MaxOfSalary = Convert.ToDouble(Employees.Compute("Max(Salary)", string.Empty));

            Console.WriteLine("Result Count: {0}", CountOfEmployees);
            
            Console.WriteLine($"Sum of Salary {SumOfSalary}");
            Console.WriteLine($"Avg of Salary {AvgOfSalary}");
            Console.WriteLine($"Min of Salary {MinOfSalary}");
            Console.WriteLine($"Max of Salary {MaxOfSalary}");


            Console.WriteLine();
            Console.WriteLine();



            DataRow[] DataResult;

            DataResult = Employees.Select("Country = 'Turkiye'");

            Console.WriteLine("Emplyees Filter Turkiye");

            foreach(DataRow row in DataResult)
            {
                Console.WriteLine("ID: {0}  FirstName: {1}  LastName: {2}  Salary: {3}  Country: {4}  Date: {5}",
                                   row["ID"], row["FirstName"], row["LastName"], row["Salary"], row["Country"],
                                   row["Date"]);
            }

            Console.WriteLine("Result Count: {0}", DataResult.Count());

            SumOfSalary = Convert.ToDouble(Employees.Compute("SUM(Salary)", "Country = 'Turkiye'"));
            AvgOfSalary = Convert.ToDouble(Employees.Compute("AVG(Salary)", "Country = 'Turkiye'"));
            MinOfSalary = Convert.ToDouble(Employees.Compute("Min(Salary)", "Country = 'Turkiye'"));
            MaxOfSalary = Convert.ToDouble(Employees.Compute("Max(Salary)", "Country = 'Turkiye'"));

            Console.WriteLine($"Sum of Salary {SumOfSalary}");
            Console.WriteLine($"Avg of Salary {AvgOfSalary}");
            Console.WriteLine($"Min of Salary {MinOfSalary}");
            Console.WriteLine($"Max of Salary {MaxOfSalary}");
              


            Console.WriteLine();
            Console.WriteLine();



            DataResult = Employees.Select("Country = 'Turkiye' or Country = 'Syria'");

            Console.WriteLine("Emplyees Filter Turkiye or Syria");

            foreach (DataRow row in DataResult)
            {
                Console.WriteLine("ID: {0}  FirstName: {1}  LastName: {2}  Salary: {3}  Country: {4}  Date: {5}",
                                   row["ID"], row["FirstName"], row["LastName"], row["Salary"], row["Country"],
                                   row["Date"]);
            }

            SumOfSalary = Convert.ToDouble(Employees.Compute("SUM(Salary)", "Country = 'Turkiye' or  Country = 'Syira'"));
            AvgOfSalary = Convert.ToDouble(Employees.Compute("AVG(Salary)", "Country = 'Turkiye' or  Country = 'Syira'"));
            MinOfSalary = Convert.ToDouble(Employees.Compute("Min(Salary)", "Country = 'Turkiye' or  Country = 'Syira'"));
            MaxOfSalary = Convert.ToDouble(Employees.Compute("Max(Salary)", "Country = 'Turkiye' or  Country = 'Syira'"));
            Console.WriteLine("Result Count: {0}", DataResult.Count());

            Console.WriteLine($"Sum of Salary {SumOfSalary}");
            Console.WriteLine($"Avg of Salary {AvgOfSalary}");
            Console.WriteLine($"Min of Salary {MinOfSalary}");
            Console.WriteLine($"Max of Salary {MaxOfSalary}");



            Console.WriteLine();
            Console.WriteLine();



            DataResult = Employees.Select("ID=1");
            Console.WriteLine("Emplyees Filter ID=1");

            foreach (DataRow row in DataResult)
            {
                Console.WriteLine("ID: {0}  FirstName: {1}  LastName: {2}  Salary: {3}  Country: {4}  Date: {5}",
                                   row["ID"], row["FirstName"], row["LastName"], row["Salary"], row["Country"],
                                   row["Date"]);
            }


            Console.ReadKey();
        }
    }
}
