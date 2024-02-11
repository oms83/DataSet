using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAccessLayer
{
    public class clsCountryData
    {
        
        public static bool Find(int ID, ref string CountryName)
        {
            SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

            string Query = @"Select * From Countries Where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);
            
            bool isFound = false;

            try
            {
                connection.Open();
                
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;
                    CountryName = (string)reader["CountryName"];

                    //if (reader["Code"] != DBNull.Value)
                    //    Code = (string)reader["Code"];
                    //else
                    //    Code = "";

                    //if (reader["PhoneCode"] != DBNull.Value)
                    //    PhoneCode = (string)reader["PhoneCode"];
                    //else
                    //    PhoneCode = "";
                }

                reader.Close();

            }
            catch(Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            
            return isFound;
        }

        public static bool Find(ref int CountryID, string CountryName)
        {
            SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

            string Query = @"Select * From Countries Where CountryName = @CountryName";
            
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            bool isFound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    if (reader["CountryID"] != DBNull.Value)
                        CountryID = (int)reader["CountryID"];
                    else
                        CountryID = -1;
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

        public static int AddNewCountry(string CountryName)
        {
            SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

            string Query = @"Insert Into Countries (CountryName) Values (@CountryName);
                           Select Scope_Identity()";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            int CountryID = -1;
            
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int Inserted))
                {
                    CountryID = Inserted;
                }
                else
                {
                    CountryID = -1;
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return CountryID;
        }
        
        public static bool UpdateCountry(int CountryID, string CountryName)
        {
            SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

            string Query = @"Update Countries 
                             Set 
                             CountryName = @CountryName
                             Where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@CountryName", CountryName);

            int AffectedRows = 0;
            
            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return AffectedRows > 0;
        }

        public static bool DeleteCountry(int CountryID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

            string Query = "Delete From Countries Where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryID", CountryID);

            int AffectedRows = 0;

            try
            {
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            { 
                connection.Close(); 
            }

            return AffectedRows > 0;

        }

        public static DataTable GetAllCountries()
        {
            DataTable dt = new DataTable();
            
            SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

            string Query = "Select * From Countries";

            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
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
        
        public static bool isCountryExistByID(int ID)
        {
            SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

            string Query = "Select Found=1 From Countries Where CountryID = @ID";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@ID", ID);

            bool isFound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool isCountryExistByName(string CountryName)
        {
            SqlConnection connection = new SqlConnection(clsConnectionWithDB.ConnectionString);

            string Query = "Select Found=1 From Countries Where CountryName = @CountryName";

            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            bool isFound = false;

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                isFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
