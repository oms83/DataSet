using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data.SqlClient;
using System.Data;

public class clsCityData
{
    public static DataTable GetAllCities()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From Cities";

        SqlCommand command = new SqlCommand(Query, connection);

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                dt.Load(reader);
            }

            reader.Close();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return dt;

    }
    public static bool Find(int ID, ref string CityName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From Cities Where CityID = @ID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ID", ID);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if(reader.Read())
            {
                isFound = true;
                if (reader["CityName"] != DBNull.Value)
                    CityName = (string)reader["CityName"];
                else
                    CityName = "";
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            isFound = false;
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }

    public static bool Find(ref int ID, string CityName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From Cities Where CityName = @CityName";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@CityName", CityName);

        bool isFound = false;

        try
        {
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                isFound = true;
                ID = (int)reader["CityID"];
            }
        }
        catch (Exception ex)
        {
            isFound = false;
        }
        finally
        {
            connection.Close();
        }

        return isFound;
    }

    public static int AddNew(string CityName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into Cities
                         (CityName)                                                  
                         VALUES
                         (CityName);
                         Select Scope_Identity();                                                  
                        ";
        
        SqlCommand command = new SqlCommand(Query, connection);

        int CityID = 0;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                CityID = Inserted;
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return CityID;
    }

    public static bool Delete(int ID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete Cities Where CityID = @ID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ID", ID);

        int AffectedRow = 0;

        try
        {
            connection.Open();
            AffectedRow = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return AffectedRow > 0;
    }

    public static bool Update(int ID, string CityName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update Cities 
                         Set 
                         CityName = @CityName 
                         Where 
                         CityID = @ID
                         ";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ID", ID);
        command.Parameters.AddWithValue("@CityName", CityName);

        int AffectedRow = 0;

        try
        {
            connection.Open();
            AffectedRow = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {

        }
        finally
        {
            connection.Close();
        }

        return AffectedRow > 0;
    }

    public static bool isExistCity(int ID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found = 1 From Cities Where CityID = @ID";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@ID", ID);

        bool isExist = false;

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            isExist = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {
            isExist = false;
        }
        finally
        {
            connection.Close();
        }

        return isExist;
    }

    public static bool isExistCity(string CityName)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found = 1 From Cities Where CityName = @CityName";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@CityName", CityName);

        bool isExist = false;

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            isExist = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {
            isExist = false;
        }
        finally
        {
            connection.Close();
        }

        return isExist;
    }
}

