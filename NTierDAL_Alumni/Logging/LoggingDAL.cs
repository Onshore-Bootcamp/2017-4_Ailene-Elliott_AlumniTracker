using System;
using System.Configuration;
using System.IO;


namespace NTierDAL_Alumni.Logging
{
    public class LoggingDAL
    {
        private readonly string filePath = ConfigurationManager.AppSettings["aileneLOG"];

        public Exception LogReadAlumniRecord(Exception exc)
        {
            //the method holds an exception message from the data access and return the error message.

            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                //where using the streamwriter,the message will be sent to the filePath which is a folder in the hardrive

                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "READ_ALUMNI_RECORDS", exc.Message));
                //message include the exact time it happened,error warning,which part of the class/layer it occurs,what database is affected
                //specific error while you execute the program.
            }
            return exc;
        }

        public Exception LogViewAlumniRecordByID(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "VIEW_ALUMNI_RECORD_BY_ID", exc.Message));
            }
            return exc;
        }

        public Exception LogCreateAlumniRecords(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "CREATE_ALUMNI_RECORDS", exc.Message));
            }
            return exc;
        }

        public Exception LogUpdateAlumniRecords(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "UPDATE_ALUMNI_RECORDS", exc.Message));
            }
            return exc;
        }

        public Exception LogReadDepartment(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "READ_DEPARTMENT", exc.Message));
            }
            return exc;
        }

        public Exception LogViewDepartmentByID(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "VIEW_DEPARTMENT_BY_ID", exc.Message));
            }
            return exc;
        }

        public Exception LogCreateDepartment(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "CREATE_DEPARTMENT", exc.Message));
            }
            return exc;
        }

        public Exception LogUpdateDepartment(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "UPDATE_DEPARTMENT", exc.Message));
            }
            return exc;
        }

        public Exception LogReadRole(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "READ_ROLE", exc.Message));
            }
            return exc;
        }

        public Exception LogViewUserByUsername(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "VIEW_USER_BY_USERNAME", exc.Message));
            }
            return exc;
        }

        public Exception LogRegisterUser(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "REGISTER_USER", exc.Message));
            }
            return exc;
        }

        public Exception LogReadUser(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "READ_USER", exc.Message));
            }
            return exc;
        }

        public Exception LogViewUserByID(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "VIEW_USER_BY_ID", exc.Message));
            }
            return exc;
        }

        public Exception LogCreateUser(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "CREATE_USER", exc.Message));
            }
            return exc;
        }

        public Exception LogUpdateUser(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "DataAccessLayer", "UPDATE_USER", exc.Message));
            }
            return exc;
        }
    }
}
