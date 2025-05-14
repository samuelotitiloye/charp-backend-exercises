using System;
using System.Collections.Generic;
using CSharpStarter;

namespace repairOrder
{
    public class Vehicle
    {
        public string? VehicleId { get; set; }
        public int Mileage { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)

        {
            List<Vehicle> vehicleList = new List<Vehicle>
            {
                new Vehicle {VehicleId =  "ABC123", Mileage = 9500},
                new Vehicle {VehicleId =  "XYZ789", Mileage = 9000},
                new Vehicle {VehicleId =  "DEF159", Mileage = 12500},
                new Vehicle {VehicleId =  "MNO456", Mileage = 18000},
                new Vehicle {VehicleId =  "QRS357", Mileage = 1000},
            };
            List<string> vehiclesNeedingService = GetVehiclesNeedingService (vehicleList);

            Console.WriteLine ("vehicles Needing Service:");
            foreach (var id in vehiclesNeedingService)
            {
                Console.WriteLine (id);
            }

        }

        public static List<string> GetVehiclesNeedingService(List<Vehicle> vehicles)
        {
            List<string> result = new List<string>();
            foreach (Vehicle vehicle in vehicles)
            {
                if (vehicle.Mileage > 10000)
                {
                    result.Add(vehicle.VehicleId);
                }
            }

        return result;
        }
    }
}




// write a function that takes a list of numbers and returns a new list containing only the even numbers
// Input: [1, 2, 3, 4, 5, 6 ]
// Output: [2, 4, 6]

// namespace ConsoleApp1;

// public class Class1
// {
//     //Entry point
//     static void Main(string[] args)
//     {
//         //sample list of numbers
//         List<int> numbers = new List<int>(){1, 2, 3, 4, 5, 6};

//         //call method to get even numbers
//         List<int> evenNumbers = GetEvenNumbers(numbers);

//         //print result
//         Console.WriteLine("Even Numbers");
//         foreach (int number in evenNumbers)
//         {
//             Console.WriteLine(number);
//         }
//     }

//     //method to return even numbers
//     static List<int> GetEvenNumbers(List<int> inputList)
//     {
//         List<int> result = new List<int>();
//         foreach (int num in inputList)
//         {
//             if(num % 2 == 0)
//             {
//                 result.Add(num);
//             }
//         }
//         return result;
//     }
// }

// Given a list of integers, 
//write a method that filters out only the odd numbers and returns a new list containing the square of each odd number.
// Loop through the list
// Check if each number is odd (num % 2 != 0)
// Square the odd number (num * num)
// Add it to a result list
// Return the result list
// // Print each item
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             List<int> numbers = new List<int>(1, 2, 3, 4, 5); // means i'm creating a List that holds ints, and i'm initializing the list with values(the 5 numbers)
            
//             List<int> oddSquares = GetOddSquares(numbers); // i'm calling a method named GetOddSquares, passing it to the list of numbers, and storing the returned list in a new var called oddSquares

//             Console.WriteLine("Squares of odd numbers");

//             foreach (int val in oddSquares)
//             {
//                 Console.WriteLine(val);
//             }
//         } 

//         static List<int> GetOddSquares(List<int> inputList)
//         {
//             List<int> result = new List<int>();

//             foreach (int num in inputList)
//             {
//                 if(num % 2 != 0) //odd check
//                 {
//                     result.Add(num * num); // square and add
//                 }
//             }
//         }
//         return result;
//     }
// }
// Given a list of integers, 
// return a new list that contains only the even numbers from the original list, evenNumbers - first get the even numbers, then create a method to double that
// with each even number doubled. doubledEvenNumber

// {
//     public class Program
//     {
//         public static void Main(string[] args)
//         {
//             //create a list, name it, create new list and initialize it with values
//             List<int> numbers = new List<int>{1, 2, 3, 4, 5 };
//             List<int> evenNumbers = GetEvenNumbers(numbers); // created 

//             Console.WriteLine("doubled even numbers");
//             foreach (int val in evenNumbers)
//             {
//                 Console.WriteLine(val);
//             }
//         }
//         private static List<int> GetEvenNumbers(List<int> inputList)
//         {
//             List<int> result = new List<int>();
//             foreach(int num in inputList)
//             {
//                 if(num % 2 == 0)//even check
//                 {
//                     result.Add(num * 2);//even doubled
//                 }
//             }
//             return result;
//         }
//     }
// }


// User Story:
// As a fleet manager, I want to receive a summary of vehicles that need maintenance soon, so that I can schedule service proactively.
// Acceptance Criteria:
// Given a list of vehicles with mileage data,
// When the system checks which vehicles have exceeded 10,000 miles since their last maintenance,
// Then it should return a list of vehicle IDs that require service.

// thinking:
// input - what do i have?
// --- list<> of vehiclesWithMileageData
// -- what does each item in the list contain
//    -- is it just a number?
//    -- or an object like "vehicle" with properties such as "vehicleId, "mileage"
 // properties would be class Vehicle {public string VehicleId { get; set; }, public int Mileage { get; set; }}
// new input would be List<Vehicle> vehicleWithMileageData

// process - what needs to be done?
// -- a way to check vehiclesWithMileageData > 10000 {miles} 
// check each vehicle's Mileage property
// if Mileage > 10000, keep that vehicle's VehicleId
// is 10000 a fixed value or should it be passed in a parameter?

// output - what should i return?
// -- result/return list<string> vehiclesNeedingService .

// solution: a method that takes in a list of vehicle object
// filters that list by checking if each vehicle's mileage is over 10K
// returns a list of VehicleIds for those that meet the condition
