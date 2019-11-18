﻿using System.Configuration;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace StopWatch.Data
{
    public class SqliteDataAccess
    {
        public static void SaveLaborEntry(TimeTrackerModel AddSaveLaborEntry)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute("insert into TimeTracker (TimeType, SubGroupTimeType, Notes, WorkedDate, TimeWorkedAmount, DateTimeEntered) values (@TimeType, @SubGroupTimeType, @Notes, @WorkedDate, @TimeWorkedAmount, @DateTimeEntered)", AddSaveLaborEntry); 
            }
        }
        
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
