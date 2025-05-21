using System;
using System.Collections.Generic;
using InActiveLoginTracker.Models;

namespace InActiveLoginTracker.Helpers
{
    public static class CsvHelper
    {
        public static List<string> BuildCsvContent(List<UserLogin> users)
        {
            List<string> lines = new List<string> { "UserId,LastLogin" };
            
            foreach (var user in users)
            {
                lines.Add($"{user.UserId},{user.LastLogin:yyyy-MM-dd}");
            }
            return lines; // end BuildCsv  
        } 
    }
}