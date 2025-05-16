namespace CSharpStarter
{
    public class subscriptionExpiryReminder
    {
        public class User
        {
            public string? UserId { get; set; }
            public DateTime ExpirationDate { get; set; }
        }

        public class Program
        {
            public static void Main(string[] args)
            {
                List<User> subscriptionUsers = new List<User>
                {
                    new User { UserId = "00001", ExpirationDate = DateTime.Today},
                    new User { UserId = "00002", ExpirationDate = DateTime.Today.AddDays(10) },
                    new User { UserId = "00003", ExpirationDate = DateTime.Today.AddDays(35) },
                    new User { UserId = "00004", ExpirationDate = DateTime.Today.AddDays(-5) },
                    new User { UserId = "00005", ExpirationDate = DateTime.Today.AddDays(15) },
                    new User { UserId = "00006", ExpirationDate = DateTime.Today.AddDays(25) },
                };
                List<string> usersExpiringSoon = GetUsersExpiringSoon (subscriptionUsers, 15);

                Console.WriteLine ("Users with subscription expiring in the next 30 days:");
                foreach(var id in usersExpiringSoon ) 
                {
                    Console.WriteLine (id);
                }
            }
            public static List<string> GetUsersExpiringSoon (List<User> subscriptionUsers, int daysUntilExpiry)
            {
                if(daysUntilExpiry <= 0)
                {
                    Console.WriteLine("Invalid expiration window. Must be greater than 0."); // 
                    return new List<string>();
                }

                if(subscriptionUsers.Count == 0)
                {
                    //return null;
                    Console.WriteLine("This list is empty "); //check if list is empty
                    return new List<string>();
                }

                List<string> expiringUserIds = new List<string>();
                foreach (User user in subscriptionUsers)
                {
                    if (user.ExpirationDate >= DateTime.Today && 
                        user.ExpirationDate <= DateTime.Today.AddDays(daysUntilExpiry))
                    {
                        if(!string.IsNullOrEmpty(user.UserId))
                        {
                            expiringUserIds.Add(user.UserId);
                        }
                    }
                }

                if(expiringUserIds.Count == 0)
                {
                    Console.WriteLine("No user IDs found with subscriptions expiring soon.");
                }
                return expiringUserIds ;
            }
        }
    }
}

// User Story: Subscription Expiry Reminder
// As a support system, I want to identify users whose subscriptions expire in the next 30 days,
// so that we can send them a renewal reminder.

// Acceptance Criteria (what the solution must do):
// Takes in a list of User objects

// Each user has:
// a UserId (string)
// an expiringUserIds   (DateTime) ?
// Filters the list to find users whose expiringUserIds  is:

// greater than or equal to today
// less than or equal to 30 days from today
// Returns a list of matching UserIds

// Prints a message if:
// the list is empty
// no users match the criteria

// INPUT:
// create a user object with properties public class User { public string UserId { get; set; }, public DateTime expiringUserIds { get; set; } } - done
// List<User> users = new List<User>{ create dummy data to manipulate }; - done


// PROCESS:
// Filters the list - loops through the user list
// use DateTime.Today/Now to represent the current date
// use DateTime.Today.AddDays(30) to get the 30-day mark.
// for each user : user.expiringUserIds >= DateTime.Today && user.expiringUserIds   <= DateTime.Today.AddDays(30) 

// OUTPUT:
// A List<string> of UserId's
// Plus: console messages if needed

// Remix/Minor Stretch goal #1
// Make subscription window dynamic
// Pass in daysUntilExpiry as a parameter to filter users based on expiration range (e.g., 15, 60, or 90 days)
//  Goal:
// instead of always using 30 days, we'll
// 1. Accept a parameter int daysUntilExpiry
// 2. Filter users whose ExpirationDate is:
// a. >= DateTime.Today
// b. <= DateTime.Today.AddDays(daysUntilExpiry)
