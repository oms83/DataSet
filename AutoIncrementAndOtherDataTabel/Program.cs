using System;
using System.Data;
using System.Linq;

namespace AutoIncrementAndOtherDataTabel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDataTable = new DataTable();

            DataColumn dataColumn; 

            dataColumn = new DataColumn();
            
            dataColumn.ColumnName = "ID";
            dataColumn.AutoIncrement = true;
            dataColumn.AutoIncrementSeed = 1;
            dataColumn.AutoIncrementStep = 1;
            dataColumn.Caption = "Employee ID";
            dataColumn.DataType = typeof(int);
            dataColumn.ReadOnly = false;
            dataColumn.Unique = true;
            EmployeesDataTable.Columns.Add(dataColumn);


            dataColumn = new DataColumn();

            dataColumn.ColumnName = "FirstName";
            dataColumn.Caption = "Employee First Name";
            dataColumn.DataType = typeof(string);
            dataColumn.ReadOnly = false;
            dataColumn.Unique = false;
            EmployeesDataTable.Columns.Add(dataColumn);


            dataColumn = new DataColumn();

            dataColumn.ColumnName = "LastName";
            dataColumn.Caption = "Employee Last Name";
            dataColumn.DataType = typeof(string);
            dataColumn.ReadOnly = false;
            dataColumn.Unique = false;
            EmployeesDataTable.Columns.Add(dataColumn);


            dataColumn = new DataColumn();

            dataColumn.ColumnName = "Country";
            dataColumn.Caption = "Employee Country";
            dataColumn.DataType = typeof(string);
            dataColumn.ReadOnly = false;
            dataColumn.Unique = false;
            EmployeesDataTable.Columns.Add(dataColumn);

            
            dataColumn = new DataColumn();

            dataColumn.ColumnName = "Salary";
            dataColumn.Caption = "Employee Salary";
            dataColumn.DataType = typeof(double);
            dataColumn.ReadOnly = false;
            dataColumn.Unique = false;
            EmployeesDataTable.Columns.Add(dataColumn);


            dataColumn = new DataColumn();

            dataColumn.ColumnName = "Date";
            dataColumn.Caption = "Date";
            dataColumn.DataType = typeof(DateTime);
            dataColumn.ReadOnly = false;
            dataColumn.Unique = false;
            EmployeesDataTable.Columns.Add(dataColumn);


            EmployeesDataTable.Rows.Add(1, "Omer", "Memes", "Turkiye", 12000, DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Ali", "Memes", "Turkiye", 5000, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Osman", "Memes", "Syria", 2630, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Musa", "Bozkurt", "Syria", 3500, DateTime.Now);
            EmployeesDataTable.Rows.Add(5, "Osama", "Mohamed", "Jordan", 1400, DateTime.Now);
            EmployeesDataTable.Rows.Add(6, "Ali", "Sultan", "KSA", 12000, DateTime.Now);

            
            DataColumn []DataTableColumns = new DataColumn[1];
            DataTableColumns[0] = EmployeesDataTable.Columns["ID"];
            EmployeesDataTable.PrimaryKey = DataTableColumns;

            
            foreach (DataRow row in  EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}   FirstName: {1}  LastName: {2}   Country: {3}   Salary: {4}   Date: {5}",
                                   row["ID"], row["FirstName"], row["LastName"], row["Country"], row["Salary"], row["Date"]);
            }

            Console.ReadKey();

        }
    }
}
