using System;
using System.Linq;
using System.Collections.Generic;

namespace SigmaSoftwareTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bananaPanama = { "banana", "panama" };
            string[] products = { "redShirt", "greenPants", "redShirt", "orangeShoes", "blackPants", "blackPants" };
            
            string[] expectedResults = { "redShirt", "panama" };

            string[] actualResults = featuredProducts(bananaPanama, products);

            if (actualResults.SequenceEqual(expectedResults))
            {
                Console.WriteLine("The code works correctly");
            }
            else
            {
                var ac = string.Join(" ", actualResults);
                var ex = string.Join(" ", expectedResults);
                Console.WriteLine("Mistake: ", ac, " != ", ex);
            }
        }

        public static string[] featuredProducts(string[] bananaPanama, string[] products)
        {
            List<string> productsList = products.ToList();

            var purchasedTwice =
                productsList.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            purchasedTwice.Sort();

            string[] purchasedTwiceArr = purchasedTwice.ToArray();
            int a = purchasedTwiceArr.Length;

            string[] answer = { purchasedTwiceArr[a-1], bananaPanama[1] };

            return answer;
        }
    }
}
