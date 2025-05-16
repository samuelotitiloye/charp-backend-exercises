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

// Stretch/remix - possible edge cases?