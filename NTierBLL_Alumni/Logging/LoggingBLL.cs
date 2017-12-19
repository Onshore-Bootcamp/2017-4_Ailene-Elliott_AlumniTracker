namespace NTierBLL_Alumni
{
    using System;
    using System.Configuration;
    using System.IO;

    public class LoggingBLL
    {
        private readonly string filePath = ConfigurationManager.AppSettings["aileneLOG"];

        public Exception LogGroupByDepartment(Exception exc)
        {
            using (StreamWriter Exceptions = new StreamWriter(filePath, true))
            {
                Exceptions.WriteLine(string.Format("{0},  {1},  {2},  {3},  {4}", DateTime.Now, "Error", "BusinessLogicLayer", "Group_By_Department", exc.Message));
            }
            return exc;
        }
    }
}