using System;
using System.Collections.Generic;
using InActiveLoginTracker.Models;
using InActiveLoginTracker.Services;

namespace InActiveLoginTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var service = new InActiveUserService();
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

            int threshold = 30;
            var inActiveUsers = service.GetInActiveUsers(activeUsers, threshold);

            Console.WriteLine("users with inActive login userIds: ");
            foreach (var id in inActiveUsers)
            {
                Console.WriteLine(id);
            }
            service.ExportInactiveUsersToCsv(activeUsers);
        }
    }
}