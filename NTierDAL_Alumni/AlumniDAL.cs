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
    public class AlumniDAL
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["aileneDB"].ConnectionString;
        //this is the connection string call from web configuration

        private LoggingDAL LoggingDataAccessLayer = new LoggingDAL();
        //an instance for LoggingDAL to hold information.

        public List<AlumniDO> ReadAlumniRecord()
        {
            //method return a list of alumni record

            List<AlumniDO> alumniList = new List<AlumniDO>();
            //an instance for alumni list to be used as a return.

            try
            {
                //needed to be able to catch an error if any of the properties or object or functions are not met.

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    //connecting the program to the database
                    //where the stored procedure will be used.
                    SqlCommand sqlCommand = new SqlCommand("READ_ALUMNI_RECORDS", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        //using the reader,getting all the info one by one until all are recorded to the return.
                        AlumniDO alumniObject = new AlumniDO();
                        alumniObject.RecordID = sqlDataReader.GetInt32(0);
                        alumniObject.CompleteName = sqlDataReader.GetString(1);
                        alumniObject.YearGraduated = sqlDataReader.GetInt16(2);
                        alumniObject.Position = sqlDataReader.GetString(3);
                        alumniObject.Company = sqlDataReader.GetString(4);
                        alumniObject.ContactNumber = sqlDataReader.GetString(5);
                        alumniObject.DepartmentID = sqlDataReader.GetInt32(6);
                        alumniObject.Department.DeptName = sqlDataReader.GetString(7);
                        alumniList.Add(alumniObject);
                    }
                    //making sure that all connections are close and dispose
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogReadAlumniRecord(exc);
                //calling the LoggingDAL instance to pass on the info to the method.
            }
            return alumniList;
        }


        public AlumniDO ViewAlumniRecordByID(int alumniID)
        {
            //the method hold alumniID info that will be coming from the controller and returns an object back to controller

            AlumniDO alumniObject = new AlumniDO();
            //an instance that is needed for the return.

            try
            {
                //needed to be able to catch an error if any of the properties or object or functions are not met.

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    //connecting the program to the database
                    //where the stored procedure will be used.
                    SqlCommand sqlCommand = new SqlCommand("VIEW_ALUMNI_RECORD_BY_ID", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    //pass the id before open make a parameter for command
                    sqlCommand.Parameters.AddWithValue("@RecordID", alumniID);
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        //using the reader,getting all the info one by one until all are recorded to the return.
                        alumniObject = new AlumniDO();
                        alumniObject.RecordID = sqlDataReader.GetInt32(0);
                        alumniObject.CompleteName = sqlDataReader.GetString(1).Trim();
                        alumniObject.YearGraduated = sqlDataReader.GetInt16(2);
                        alumniObject.Position = sqlDataReader.GetString(3).Trim();
                        alumniObject.Company = sqlDataReader.GetString(4).Trim();
                        alumniObject.ContactNumber = sqlDataReader.GetString(5).Trim();
                        alumniObject.DepartmentID = sqlDataReader.GetInt32(6);
                    }
                    //making sure that all connections are close and dispose
                    sqlDataReader.Close();
                    sqlDataReader.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogViewAlumniRecordByID(exc);
                //calling the LoggingDAL instance to pass on the info to the method.
            }
            //return a single DO not a list
            return alumniObject;
        }


        public void CreateAlumniRecord(AlumniDO alumniCreateDO)
        {
            //method hold info about the properties in alumni record table and this has no return.

            try
            {
                //needed to be able to catch an error if any of the properties or object or functions are not met.

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    //connecting the program to the database
                    //where the stored procedure will be used.
                    SqlCommand sqlCommand = new SqlCommand("CREATE_ALUMNI_RECORDS", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();

                    //this time add value on each paramers that the sql stored procedure have.
                    //all value are stored to the method's parameter.
                    sqlCommand.Parameters.AddWithValue("@CompleteName", alumniCreateDO.CompleteName);
                    sqlCommand.Parameters.AddWithValue("@YearGraduated", alumniCreateDO.YearGraduated);
                    sqlCommand.Parameters.AddWithValue("@Position", alumniCreateDO.Position);
                    sqlCommand.Parameters.AddWithValue("@Company", alumniCreateDO.Company);
                    sqlCommand.Parameters.AddWithValue("@ContactNumber", alumniCreateDO.ContactNumber);
                    sqlCommand.Parameters.AddWithValue("@DepartmentID", alumniCreateDO.DepartmentID);
                    sqlCommand.ExecuteNonQuery();

                    //making sure that all connections are close and dispose
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogCreateAlumniRecords(exc);
                //calling the LoggingDAL instance to pass on the info to the method.
            }
        }


        public void UpdateAlumniRecord(AlumniDO alumniUpdateDO)
        {
            //method hold info about the properties in alumni record table and this has no return.

            try
            {
                //needed to be able to catch an error if any of the properties or object or functions are not met.

                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    //connecting the program to the database
                    //where the stored procedure will be used.
                    SqlCommand sqlCommand = new SqlCommand("UPDATE_ALUMNI_RECORDS", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@RecordID", alumniUpdateDO.RecordID);
                    sqlCommand.Parameters.AddWithValue("@CompleteName", alumniUpdateDO.CompleteName);
                    sqlCommand.Parameters.AddWithValue("@YearGraduated", alumniUpdateDO.YearGraduated);
                    sqlCommand.Parameters.AddWithValue("@Position", alumniUpdateDO.Position);
                    sqlCommand.Parameters.AddWithValue("@Company", alumniUpdateDO.Company);
                    sqlCommand.Parameters.AddWithValue("@ContactNumber", alumniUpdateDO.ContactNumber);
                    sqlCommand.Parameters.AddWithValue("@DepartmentID", alumniUpdateDO.DepartmentID);
                    sqlCommand.ExecuteNonQuery();

                    //making sure that all connections are close and dispose
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception exc)
            {
                LoggingDataAccessLayer.LogUpdateAlumniRecords(exc);
                //calling the LoggingDAL instance to pass on the info to the method.
            }
        }


        public void DeleteAlumniRecord(int recordID)
        {
            //method hold info of a recordID the need to be deleted.

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                //connecting the program to the database
                //where the stored procedure will be used.
                SqlCommand sqlCommand = new SqlCommand("DELETE_ALUMNI_RECORDS", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@RecordID", recordID);
                sqlCommand.ExecuteNonQuery();

                //making sure that all connections are close and dispose
                sqlConnection.Close();
                sqlConnection.Dispose();
                sqlCommand.Dispose();
            }
        }
    }
}
