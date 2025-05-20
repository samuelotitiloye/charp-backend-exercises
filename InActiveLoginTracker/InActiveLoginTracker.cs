namespace CSharpExercises.csharp_backend_exercises.InActiveLoginTracker
{
    public class InActiveUserLoginTracker
    {
        public class UserLogin
        {
            public string? UserId { get; set; }
            public DateTime LastLogin { get; set; }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                List<UserLogin> activeUsers = new List<UserLogin>
                {
                    new UserLogin { UserId = "6f1e4500", LastLogin = DateTime.Today.AddDays(31) },
                    new UserLogin { UserId = "6f1e4501", LastLogin = DateTime.Today.AddDays(-31)},
                    new UserLogin { UserId = "6f1e4502", LastLogin = DateTime.Today.AddDays(30) },
                    new UserLogin { UserId = "6f1e4503", LastLogin = DateTime.Today.AddDays(25) },
                    new UserLogin { UserId = "6f1e4504", LastLogin = DateTime.Today.AddDays(35) },
                    new UserLogin { UserId = "6f1e4505", LastLogin = DateTime.Today.AddDays(10) },
                    new UserLogin { UserId = "6f1e4506", LastLogin = DateTime.Today.AddDays(-1) },
                    new UserLogin { UserId = "6f1e4507", LastLogin = DateTime.Today.AddDays(45) },
                };
                List<string> InActiveUsers = GetInActiveUsers(activeUsers, 30);

                Console.WriteLine("users with inActive login userIds: ");
                foreach (var id in InActiveUsers)
                {
                    Console.WriteLine(id);
                }
                WriteInactiveUsersToFile(InActiveUsers);
                var inActiveUsers = new List<UserLogin>
                {  
                    new UserLogin { UserId = "abc123", LastLogin = DateTime.Today.AddDays(-30)}
                };
                ExportInactiveUsersToCsv(inActiveUsers);
            }
            public static List<string> GetInActiveUsers(List<UserLogin> activeUsers, int daysThreshold)
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

            //add a new method WriteInactiveUsersToFile(List<string>userIds)
            //format the data with timestamps + labels
            //use File.AppendAllText() or StreamWriter to write a .txt file
            public static void WriteInactiveUsersToFile(List<string> userIds)
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

            public static void ExportInactiveUsersToCsv(List<UserLogin> inActiveUsers)
            {
                //  extend the existing method that writes to a .txt file to instead output a .csv file
                //  with structured data that could later be sent via email or uploaded to cloud storage.

                //1. check if is null/empty - done
                //2. Define the file path("inactive-users.csv")
                //3. prepare a list of lines to write (List<string> linesToExport)
                //4. if file doesn't exist, add header "UserId,LastLogin"
                //5. Loop through inactiveUsers, and add lines like "userId,date"
                //6. append to file
                //7. stretch?: confirm in console

                if (inActiveUsers == null || inActiveUsers.Count == 0)
                {
                    Console.WriteLine("Warning: No inactive users to write."); //null check
                    return;
                }
                string filePath = "inactive-users.csv"; // define file path
                List<string> linesToExport = new List<string>(); // list of lines to write/export
            
                // add header
                if (!File.Exists(filePath))
                {
                    linesToExport.Add("UserId,LastLogin"); // append to file
                }

                //loop through inactiveUsers
                foreach (var user in inActiveUsers)
                {
                    linesToExport.Add($"{user.UserId},{user.LastLogin:yyyy-MM-dd}");; 
                }
                
                File.AppendAllLines(filePath, linesToExport);
                Console.WriteLine("Export complete. File Updated.");
            }
        }
    }
}

// Problem:
// Given a list of user login timestamps (DateTime), 
// write a method to find users who have been inactive for more than 30 days 
// (i.e., last login was more than 30 days ago).
// Return their user IDs.

// Input:
// - a List<> of user objects (or a list of user IDs + their last login) e.g 
// class UserLogin { public string UserId { get; set; } public DataTime LastLogin { get; set; } }

// Process:
// receive the list of users with their last login times
// foreach user, check if their last login was before 30 days ago
// if yes, add their UserId to the result list
// // Return List<string>(InActiveUserIds)
// account for If list is empty → return empty
// If LastLogin is null or default → count as inactive
// If LastLogin is in the future → skip or log warning
// Otherwise, check if LastLogin < DateTime.Today.AddDays(-threshold)

// Output:
// A list of user IDs (strings) who have been inactive for more than 30 days
// inactive means LastLogin date is older than DateTime.Today.AddDays(-30)

// Stretch/remix/Next steps
// Write results to a file:
// As an Admin, I want to save a list of inactive user IDs to a file,
// so that i can review or process them later

//Input:
// what kind of data do we already have?
//  -> a List of inActiveUsers IDs
// what data type are we working with?
//  -> List<string>

//Process:
// what action are we performing with that data?
//  -> save a list of existing inActiveUser Ids to a file
// what kind of formatting or logic is needed
//  -> do we want each user Id on its own line? something like 6f1e4501, 6f1e4504, 6f1e4507
//  -> should there be a timestamp?
//  -> maybe labels or separators? 
//  ----> something like: InActive User IDs:
//                        - 6f1e4501  
//                        - 6f1e4504
//  -> should it overwrite the file every time? probably not a good idea for long term data history access
//  -> should it append to the existing file?
//  -> should a new file be created if one doesn't exist?
//  -> should a new file be created each time the db is queried for inActiveUser IDs?

//Output:
// what is the expected result?
// --> save a List<> of inActiveUser IDs to a file.

// where should the result be stored?
//  --> a .txt file? evolve to a CSV later (learn/research how to do this)
//  --> project directory for now, or bin/Debug/netX folder?

// error handling - do we need this now on a micro scale?
// failure due to different permissions? this would depend on a larger scale project i'd assume

// in general, before we save anything, how do we want to shape, format and manage the data being written?