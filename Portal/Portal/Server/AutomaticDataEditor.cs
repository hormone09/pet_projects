using System;
using System.Threading;
using Microsoft.Data.SqlClient;

namespace Portal.Server
{
    public static class AutomaticDataEditor
    {
        public static void Start()
        {
            Thread newThread = new Thread(EditDataBase);
            newThread.Start();
        }
        public static void EditDataBase()
        {
            string connectionString = "Server=DESKTOP-7FUSBPQ;Database=Portal;Trusted_Connection=True;MultipleActiveResultSets=true;";

            while(true)
            {
                string dateNow = $"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}";
                if ((DateTime.Now.Minute == 0) || (DateTime.Now.Minute == 15) 
                    || (DateTime.Now.Minute == 30) || (DateTime.Now.Minute == 45))
                {
                    using (var sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();
                        SqlCommand command = sqlConnection.CreateCommand();
                        command.Connection = sqlConnection;

                        string subjectsToday = 
                            $"UPDATE subjects SET IsToday = 1 WHERE date = '{dateNow}'";
                        string subjectTodayNot = 
                            $"UPDATE subjects SET IsToday = 0, IsFinished = 1 " +
                            $"WHERE date != '{dateNow}' AND IsToday = 1";
                        string activeBorders =
                            $"UPDATE borders SET IsNow  = 1 WHERE dateOfBegin = '{dateNow}'";
                        string finishedBorders = $"UPDATE borders SET IsNow = 0, IsFinished = 1" +
                            $"WHERE dateOfFinish <= '{dateNow}'";

                        string[] commands = 
                            { subjectsToday, subjectTodayNot , activeBorders , finishedBorders};

                        foreach (string _command in commands)
                        {
                            command.CommandText = _command;
                            command.ExecuteNonQuery();
                        }

                        sqlConnection.Close();
                    }
                }
            }
        }
    }
}
