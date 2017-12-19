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
    public class RoleDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["aileneDB"].ConnectionString;
        private LoggingDAL LoggingDataAccessLayer = new LoggingDAL();

        public List<RoleDO> ReadRole()
        {
            List<RoleDO> roleList = new List<RoleDO>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("READ_ROLE", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        RoleDO roleObject = new RoleDO();
                        roleObject.RoleID = sqlDataReader.GetInt32(0);
                        roleObject.Name = sqlDataReader.GetString(1);
                        roleObject.Description = sqlDataReader.GetString(2);
                        roleList.Add(roleObject);
                    }
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogReadRole(exc);
            }
            return roleList;
        }
    }
}
