namespace _01.Numbers
{
    using System;
    using System.Linq;

    public static class Numbers
    {
        public static void Main()
        {
            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var avg = nums.Average();
            var result = nums
                .Where(n => n > avg)
                .OrderByDescending(i => i)
                .Take(5);

            Console.WriteLine(result.Any() ? string.Join(" ", result) : "No");
        }
    }
}
 