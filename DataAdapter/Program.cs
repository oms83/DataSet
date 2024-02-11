using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        string ConnectionString = "Server=.; Database=HR_Database; User Id=sa; Password=sa123456;";
        
        string Query = "Select * From Employees";
            
        SqlConnection connection = new SqlConnection(ConnectionString);

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, ConnectionString);

        DataSet dataSet = new DataSet();

        connection.Open();

        sqlDataAdapter.SelectCommand.Connection = connection;

        sqlDataAdapter.Fill(dataSet, "Employees");

        connection.Close();

        DataTable dataTable = dataSet.Tables["Employees"];

        foreach (DataRow row in dataTable.Rows)
        {
            Console.WriteLine("ID {0}  FirstName {1}  LastName {2}",
                row["ID"], row["FirstName"], row["LastName"]);
        }


        Console.ReadKey();

        connection.Open();

        sqlDataAdapter.UpdateCommand.Connection = connection;

        sqlDataAdapter.Update(dataSet, "Employees");

        connection.Close();
    }
}
