namespace _02.SoftUniCoffeeOrders
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var count = int.Parse(Console.ReadLine());
            var totalPrice = 0M;

            for (int i = 0; i < count; i++)
            {
                var pricePerCapsule = decimal.Parse(Console.ReadLine());
                var orderDate = Console.ReadLine().Split('/').Select(int.Parse).ToArray();
                var capsulesCount = int.Parse(Console.ReadLine());

                var price =  (long)DateTime.DaysInMonth(orderDate[2], orderDate[1]) * capsulesCount * pricePerCapsule;
                totalPrice += price;
                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
