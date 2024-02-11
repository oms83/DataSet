﻿using System;
using System.Data;
using System.Linq;

namespace AutoIncrementAndOtherDataTabel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDataTable = new DataTable();

            EmployeesDataTable.Columns.Add("ID", typeof(int));
            EmployeesDataTable.Columns.Add("FirstName", typeof(string));
            EmployeesDataTable.Columns.Add("LastName", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("Salary", typeof(Double));
            EmployeesDataTable.Columns.Add("Date", typeof(DateTime));


            EmployeesDataTable.Rows.Add(1, "Omer", "Memes", "Turkiye", 12000, DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Ali", "Memes", "Turkiye", 5000, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Osman", "Memes", "Syria", 2630, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Musa", "Bozkurt", "Syria", 3500, DateTime.Now);
            EmployeesDataTable.Rows.Add(5, "Osama", "Mohamed", "Jordan", 1400, DateTime.Now);
            EmployeesDataTable.Rows.Add(6, "Ali", "Sultan", "KSA", 12000, DateTime.Now);


            Console.WriteLine("\n\nEmployees");
            foreach (DataRow row in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}   FirstName: {1}  LastName: {2}   Country: {3}   Salary: {4}   Date: {5}",
                                   row["ID"], row["FirstName"], row["LastName"], row["Country"], row["Salary"], row["Date"]);
            }



            DataTable DepartmentDataTable = new DataTable();
            DepartmentDataTable.Columns.Add("DepartmentID", typeof(int));
            DepartmentDataTable.Columns.Add("Name", typeof(string));

            DepartmentDataTable.Rows.Add(1, "Marketing");
            DepartmentDataTable.Rows.Add(1, "IT");
            DepartmentDataTable.Rows.Add(1, "HR");

            Console.WriteLine("\n\nDepatments");

            foreach (DataRow row in DepartmentDataTable.Rows)
            {
                Console.WriteLine("ID: {0} Department Name: {1}", row["DepartmentID"], row["Name"]);
            }



            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(EmployeesDataTable);
            dataSet.Tables.Add (DepartmentDataTable);

            Console.WriteLine("\n\nEmployees");

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine("ID: {0}   FirstName: {1}  LastName: {2}   Country: {3}   Salary: {4}   Date: {5}",
                                   row["ID"], row["FirstName"], row["LastName"], row["Country"], row["Salary"], row["Date"]);
            }



            Console.WriteLine("\n\nDepatments");

            foreach (DataRow row in dataSet.Tables[1].Rows)
            {
                Console.WriteLine("ID: {0} Department Name: {1}", row["DepartmentID"], row["Name"]);
            }

            Console.ReadKey();

        }
    }
}
