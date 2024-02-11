using System;
using System.Linq;
using System.Net;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;
using System.Diagnostics;

public class clsTravelerData
{

    static public bool Find(int ID, ref string FirstName, ref string LastName, ref string Email, ref string Phone, 
                     ref string PassportNo, ref string Address, ref string ImagePath, ref DateTime DateOfBirth, 
                     ref DateTime TripDate, ref int CountryID, ref int FromWhere, ref int ToWhere)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From Travelers Where TravelerID = @ID";

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

                if (reader["FirstName"] != DBNull.Value)
                    FirstName = (string)reader["FirstName"];
                else
                    FirstName = "";

                if (reader["LastName"] != DBNull.Value)
                    LastName = (string)reader["LastName"];
                else
                    LastName = "";

                if (reader["Email"] != DBNull.Value)
                    Email = (string)reader["Email"];
                else
                    Email = "";

                if (reader["Phone"] != DBNull.Value)
                    Phone = (string)reader["Phone"];
                else
                    Phone = "";

                if (reader["PassportNo"] != DBNull.Value)
                    PassportNo = (string)reader["PassportNo"];
                else
                    PassportNo = "";

                if (reader["Address"] != DBNull.Value)
                    Address = (string)reader["Address"];
                else
                    Address = "";

                if (reader["ImagePath"] != DBNull.Value)
                    ImagePath = (string)reader["ImagePath"];
                else
                    ImagePath = "";

                if (reader["CountryID"] != DBNull.Value)
                    CountryID = (int)reader["CountryID"];
                else
                    CountryID = -1;

                if (reader["FromWhere"] != DBNull.Value)
                    FromWhere = (int)reader["FromWhere"];
                else
                    FromWhere = -1;

                if (reader["ToWhere"] != DBNull.Value)
                    ToWhere = (int)reader["ToWhere"];
                else
                    ToWhere = -1;

                if (reader["DateOfBirth"] != DBNull.Value)
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                else
                    DateOfBirth = DateTime.Now;

                if(reader["TripDate"] != DBNull.Value)
                    TripDate = (DateTime)reader["TripDate"];
                else
                    TripDate = DateTime.Now;
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

    public static DataTable GetAllTravelers()
    {
        DataTable dtTravelers = new DataTable();

        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select * From Travelers";

        SqlCommand command = new SqlCommand(Query, connection);

        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if(reader.HasRows)
            {
                dtTravelers.Load(reader);
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
        return dtTravelers;
    }

    public static int AddNewTraveler(string FirstName, string LastName, string Email, string Phone, string Address, 
                                     string PassportNo, int CountryID, DateTime DateOfBirth, DateTime TripDate, string ImagePath, int FromWhere, int ToWhere)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Insert Into Travelers 

                         (FirstName, LastName, Email, Phone, Address, PassportNo, CountryID, DateOfBirth, TripDate, ImagePath, FromWhere, ToWhere) 
                         Values 
                         (@FirstName, @LastName, @Email, @Phone, @Address, @PassportNo, @CountryID, @DateOfBirth, @TripDate, @ImagePath, @FromWhere, @ToWhere);

                         Select Scope_Identity()
                         ";

        SqlCommand command = new SqlCommand(Query, connection);

        command.Parameters.AddWithValue("@FirstName", FirstName);
        command.Parameters.AddWithValue("@LastName", LastName);
        command.Parameters.AddWithValue("@Email", Email);
        command.Parameters.AddWithValue("@Phone", Phone);
        command.Parameters.AddWithValue("@Address", Address);
        command.Parameters.AddWithValue("@PassportNo", PassportNo);
        command.Parameters.AddWithValue("@CountryID", CountryID);
        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
        command.Parameters.AddWithValue("@TripDate", TripDate);
        command.Parameters.AddWithValue("@FromWhere", FromWhere);
        command.Parameters.AddWithValue("@ToWhere", ToWhere);
        if(ImagePath != null)
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
        else
            command.Parameters.AddWithValue("@ImagePath", string.Empty);

        int TravelerID = -1;

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if(result != null && int.TryParse(result.ToString(), out int Inserted))
            {
                TravelerID = Inserted;
            }
            else
            {
                TravelerID = -1;
            }

        }
        catch(Exception ex)
        {

        }
        finally 
        { 
            connection.Close(); 
        }

        return TravelerID;
    }

    public static bool Update(int ID, string FirstName, string LastName, string Email, string Phone, string Address,
                                     string PassportNo, int CountryID, DateTime DateOfBirth, DateTime TripDate, string ImagePath, int FromWhere, int ToWhere)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = @"Update Travelers 
                        SET
                        FirstName = @FirstName,
                        LastName = @LastName,
                        Email = @Email,
                        Phone = @Phone,
                        Address = @Address,
                        PassportNo = @PassportNo,
                        CountryID = @CountryID,
                        DateOfBirth = @DateOfBirth,
                        TripDate = @TripDate,
                        ImagePath = @ImagePath,
                        ToWhere = @ToWhere,
                        FromWhere = @FromWhere

                        WHERE
                        TravelerID = @ID
                        ";

        SqlCommand command = new SqlCommand(@Query, connection);

        command.Parameters.AddWithValue("@ID", ID);
        command.Parameters.AddWithValue("@FirstName", FirstName);
        command.Parameters.AddWithValue("@LastName", LastName);
        command.Parameters.AddWithValue("@Email", Email);
        command.Parameters.AddWithValue("@Phone", Phone);
        command.Parameters.AddWithValue("@Address", Address);
        command.Parameters.AddWithValue("@PassportNo", PassportNo);
        command.Parameters.AddWithValue("@CountryID", CountryID);
        command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
        command.Parameters.AddWithValue("@TripDate", TripDate);
        command.Parameters.AddWithValue("@FromWhere", FromWhere);
        command.Parameters.AddWithValue("@ToWhere", ToWhere);

        if (ImagePath != null)
            command.Parameters.AddWithValue("@ImagePath", ImagePath);
        else
            command.Parameters.AddWithValue("@ImagePath", string.Empty);

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

    public static bool Delete(int ID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Delete Travelers Where TravelerID = @ID";

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

    public static bool isExistTraveler(int ID)
    {
        SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

        string Query = "Select Found = 1 From Travelers Where TravelerID = @ID";

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

        return true;

    }

}
