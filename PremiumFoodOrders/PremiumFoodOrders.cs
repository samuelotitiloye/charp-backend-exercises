using System;
using System.Collections.Generic;
using CSharpStarter;


namespace customerRewards
{
    public class Order
    {
        public string? OrderId { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Order> foodOrders = new List<Order>
            {
                new Order { OrderId = "ORD001", TotalPrice = 10.00m },
                new Order { OrderId = "ORD002", TotalPrice = 15.55m },
                new Order { OrderId = "ORD003", TotalPrice = 20.50m },
                new Order { OrderId = "ORD004", TotalPrice = 22.31m },
                new Order { OrderId = "ORD005", TotalPrice = 25.99m },
            };
            List<string> ordersOver20 = GetOrdersAboveThreshold(foodOrders, 20.00m);

            Console.WriteLine("premium food Orders");

            foreach (var id in ordersOver20)
            {
                Console.WriteLine(id);
            }
        }

        public static List<string> GetOrdersAboveThreshold(List<Order> foodOrders, decimal threshold, string comparisonOperator = ">")
        {
            if(foodOrders.Count == 0)
            {
                Console.WriteLine("No orders available to process"); //if our foodOrder list/array is empty
                return new List<string>();
            } 

            List<string> qualifyOrders = new List<string>();
            foreach (Order order in foodOrders)
            {
                if( 
                    (comparisonOperator == ">" && order.TotalPrice > threshold) ||
                    (comparisonOperator == "<" && order.TotalPrice < threshold) ||
                    (comparisonOperator == "=" && order.TotalPrice == threshold)
                )
                {
                    qualifyOrders.Add(order.OrderId);
                }
            }
            if (qualifyOrders.Count == 0)
                {
                    Console.WriteLine("No premium orders found"); //if only foodOrders below $20 found
                }

            return qualifyOrders;
        }
    }
}

// User Story: Premium Orders for Customer Rewards
// As a restaurant manager, I want to know which food orders are above $20, so I can track premium purchases for customer rewards.

// Acceptance Criteria:
// Given a list of food orders (each with an order ID and total price),

// When the system filters for orders with a total above $20,

// Then it should return a list of order IDs that qualify as “premium orders”.


// Input – What kind of data do I have? (Hint: List of Order objects)
// class Orders { public int orderId get; set; } {public int totalPrice { get; set; } } 
// will need List<foodOrders> of some kind and populate it some dummy data to be worked on (different foods and their prices?)
//  a List<string>premiumOrders = GetPremiumOrders (foodOrders)

// Process – What’s the condition I’m checking?
// loop through list<foodOrders> data for orders with a total > $20
// add orders > $20 to premiumOrders (result.add)

// Output – What should I return?
// return List<string> result = new List<string>();
// return result