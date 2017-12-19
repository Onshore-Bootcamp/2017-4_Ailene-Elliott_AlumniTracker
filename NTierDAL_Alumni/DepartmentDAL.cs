using System;
using System.Collections.Generic;
using System.Configuration;
using NTierDAL_Alumni.Models;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using NTierDAL_Alumni.Logging;

namespace NTierDAL_Alumni
{
    public class DepartmentDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["aileneDB"].ConnectionString;
        private LoggingDAL LoggingDataAccessLayer = new LoggingDAL();

        public List<DepartmentDO> ReadDepartment()
        {
            List<DepartmentDO> departmentList = new List<DepartmentDO>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("READ_DEPARTMENT", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        DepartmentDO departmentObject = new DepartmentDO();
                        departmentObject.DeptID = sqlDataReader.GetInt32(0);
                        departmentObject.DeptName = sqlDataReader.GetString(1);
                        departmentObject.Description = sqlDataReader.GetString(2);
                        departmentObject.DeptHead = sqlDataReader.GetString(3);
                        departmentObject.DeptHeadSpecialization = sqlDataReader.GetString(4);
                        departmentList.Add(departmentObject);
                    }
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogReadDepartment(exc);
            }
            return departmentList;
        }

        public DepartmentDO ViewDepartmentByID(int departmentID)
        {
            DepartmentDO departmentObject = new DepartmentDO();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("VIEW_DEPARTMENT_BY_ID", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@DeptID", departmentID);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while(sqlDataReader.Read())
                    {
                        departmentObject = new DepartmentDO();
                        departmentObject.DeptID = sqlDataReader.GetInt32(0);
                        departmentObject.DeptName = sqlDataReader.GetString(1).Trim();
                        departmentObject.Description = sqlDataReader.GetString(2).Trim();
                        departmentObject.DeptHead = sqlDataReader.GetString(3).Trim();
                        departmentObject.DeptHeadSpecialization = sqlDataReader.GetString(4).Trim();
                    }
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogViewDepartmentByID(exc);
            }
            return departmentObject;
        }

        public void CreateDepartment (DepartmentDO departmentCreateDO)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("CREATE_DEPARTMENT", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@DeptName", departmentCreateDO.DeptName);
                    sqlCommand.Parameters.AddWithValue("@Description", departmentCreateDO.Description);
                    sqlCommand.Parameters.AddWithValue("@DeptHead", departmentCreateDO.DeptHead);
                    sqlCommand.Parameters.AddWithValue("@DeptHeadSpecialization", departmentCreateDO.DeptHeadSpecialization);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogCreateDepartment(exc);
            }
        }

        public void UpdateDepartment(DepartmentDO departmentUpdateDO)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("UPDATE_DEPARTMENT", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@DeptID", departmentUpdateDO.DeptID);
                    sqlCommand.Parameters.AddWithValue("@DeptName", departmentUpdateDO.DeptName);
                    sqlCommand.Parameters.AddWithValue("@Description", departmentUpdateDO.Description);
                    sqlCommand.Parameters.AddWithValue("@DeptHead", departmentUpdateDO.DeptHead);
                    sqlCommand.Parameters.AddWithValue("@DeptHeadSpecialization", departmentUpdateDO.DeptHeadSpecialization);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogUpdateDepartment(exc);
            }
        }

        public void DeleteDepartment(int deptID)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("CASCADE_DELETE_DEPARTMENT", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@DeptID", deptID);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }
    }
}
