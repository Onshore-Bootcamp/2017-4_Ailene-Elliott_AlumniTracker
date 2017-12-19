using NTierDAL_Alumni.Logging;
using NTierDAL_Alumni.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace NTierDAL_Alumni
{
    public class UserDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["aileneDB"].ConnectionString;
        private LoggingDAL LoggingDataAccessLayer = new LoggingDAL();

        public UserDO ViewUserByUsername(string username)
        {
            UserDO userObject = new UserDO();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("VIEW_USER_BY_USERNAME", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Username", username);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        userObject = new UserDO();
                        userObject.UserID = sqlDataReader.GetInt64(0);
                        userObject.CompleteName = sqlDataReader.GetString(1).Trim();
                        userObject.UserName = sqlDataReader.GetString(2).Trim();
                        userObject.Password = sqlDataReader.GetString(3).Trim();
                        userObject.RoleID = sqlDataReader.GetInt32(4);
                    }
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogViewUserByUsername(exc);
            }
            return userObject;
        }

        public bool RegisterUser(UserDO newUser)
        {
            bool success = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("REGISTER_USER", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CompleteName", newUser.CompleteName);
                    sqlCommand.Parameters.AddWithValue("@UserName", newUser.UserName);
                    sqlCommand.Parameters.AddWithValue("@Password", newUser.Password);
                    sqlCommand.Parameters.AddWithValue("@RoleID", newUser.RoleID);
                    sqlConnection.Open();
                    success = sqlCommand.ExecuteNonQuery() > 0;
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogRegisterUser(exc);
            }
            return success;
        }

        public List<UserDO> ReadUser()
        {
            DataTable table = new DataTable();
            List<UserDO> userList = new List<UserDO>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("READ_USER", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UserDO userObject = new UserDO();
                        userObject.UserID = sqlDataReader.GetInt64(0);
                        userObject.CompleteName = sqlDataReader.GetString(1);
                        userObject.UserName = sqlDataReader.GetString(2);
                        userObject.Password = sqlDataReader.GetString(3);
                        userObject.RoleID = sqlDataReader.GetInt32(4);
                        userList.Add(userObject);
                    }
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogReadUser(exc);
            }
            return userList;
        }

        public UserDO ViewUserByID(int userID)
        {
            UserDO userObject = new UserDO();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("VIEW_USER_BY_ID", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserID", userID);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while(sqlDataReader.Read())
                    {
                        userObject = new UserDO();
                        userObject.UserID = sqlDataReader.GetInt64(0);
                        userObject.CompleteName = sqlDataReader.GetString(1).Trim();
                        userObject.UserName = sqlDataReader.GetString(2).Trim();
                        userObject.Password = sqlDataReader.GetString(3).Trim();
                        userObject.RoleID = sqlDataReader.GetInt32(4);
                    }
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogViewUserByID(exc);
            }
            return userObject;
        }

        public void CreateUser(UserDO userCreateDO)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("CREATE_USER", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@CompleteName", userCreateDO.CompleteName);
                    sqlCommand.Parameters.AddWithValue("@UserName", userCreateDO.UserName);
                    sqlCommand.Parameters.AddWithValue("@Password", userCreateDO.Password);
                    sqlCommand.Parameters.AddWithValue("RoleID", userCreateDO.RoleID);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogCreateUser(exc);
            }
        }

        public void UpdateUser(UserDO userUpdateDO)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("UPDATE_USER", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@UserID", userUpdateDO.UserID);
                    sqlCommand.Parameters.AddWithValue("@CompleteName", userUpdateDO.CompleteName);
                    sqlCommand.Parameters.AddWithValue("@UserName", userUpdateDO.UserName);
                    sqlCommand.Parameters.AddWithValue("@Password", userUpdateDO.Password);
                    sqlCommand.Parameters.AddWithValue("@RoleID", userUpdateDO.RoleID);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogCreateUser(exc);
            }
        }

        public void DeleteUser(int userID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("DELETE_USER", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@UserID", userID);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }
    }
}
