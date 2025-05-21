using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using InActiveLoginTracker.Models;
using InActiveLoginTracker.Helpers;

namespace InActiveLoginTracker.Services
{
    public class InActiveUserService
    {
        public List<string> GetInActiveUsers(List<UserLogin> activeUsers, int daysThreshold)
        {
            if (daysThreshold <= 0)
            {
                Console.WriteLine("Invalid day threshold window. Must be greater than 0.");
                return new List<string>(); // invalid threshold check
            }

            if (activeUsers.Count == 0)
            {
                Console.WriteLine("this is an empty list"); //empty list check
                return new List<string>(); // return empty
            }

            List<string> inActiveUsers = new List<string>();
            foreach (UserLogin userLogin in activeUsers)
            {

                if (string.IsNullOrEmpty(userLogin.UserId)) // null reference compiler error check
                {
                    continue;
                }

                if (userLogin.LastLogin == default)
                {
                    inActiveUsers.Add(userLogin.UserId); //optional safety check to treat default LastLogin as inactive
                    continue;
                }

                //check for future dated logins 
                if (userLogin.LastLogin > DateTime.Today)
                {
                    Console.WriteLine($"Warning: User {userLogin.UserId} has a future login date. ");
                    continue;
                }

                //check for inactivity 
                if (userLogin.LastLogin < DateTime.Today.AddDays(-daysThreshold))
                {
                    inActiveUsers.Add(userLogin.UserId);
                }
            }
            return inActiveUsers;
        }

        public void WriteInactiveUsersToFile(List<string> userIds)
        {
            if (userIds == null || userIds.Count == 0) //empty/null check
            {
                Console.WriteLine("Warning: No inactive users to write.");
                return;
            }
            List<string> linesToWrite = new List<string>(); //build a List of lines
            linesToWrite.Add("Inactive User IDs:"); //create a label
            linesToWrite.Add($"Timestamp: {DateTime.Now}");

            foreach (var id in userIds) // loop through userIds
            {
                linesToWrite.Add($"- {id}");
            }
            File.AppendAllLines("inactive-users-log.txt", linesToWrite); //write/add loop result to file
        }

        public void ExportInactiveUsersToCsv(List<UserLogin> inActiveUsers)
        {
            if (inActiveUsers == null || inActiveUsers.Count == 0)
            {
                Console.WriteLine("Warning: No inactive users to write."); //null check
                return;
            }
            string filePath = GetValidatedFilename(); // user helper to get filename
            List<string> linesToExport = CsvHelper.BuildCsvContent(inActiveUsers); // build csv lines

            File.AppendAllLines(filePath, linesToExport);

            Console.WriteLine($"\nSimulating cloud upload for: {filePath}...");
            Thread.Sleep(2000);// pause for 2 seconds to simulate delay
            Console.WriteLine("Upload successful: (simulated)");
            Console.WriteLine($"Uploading {filePath} to cloud storage.....[SIMULATED]");
        }

        private string GetValidatedFilename()
        {
            Console.WriteLine("Enter a filename for the export (without extension); ");
            string? userInputFile = Console.ReadLine();

            if (string.IsNullOrEmpty(userInputFile))
            {
                Console.WriteLine("No filename entered. Using default export name.");
                return $"inactive-users-{DateTime.Now:yyyy-MM-dd-HHmm}.csv";
            }

            if (string.IsNullOrWhiteSpace(Path.GetExtension(userInputFile)))
            {
                userInputFile += ".csv";
            }
            return userInputFile;
        }
    }
}