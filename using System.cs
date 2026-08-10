using System;

namespace MyFirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- YOUR CODE GOES HERE ---
            Console.Write("Enter your age: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int age))
            {
                Console.WriteLine($"Valid number: {age}");
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            // ---------------------------
        }
    }
}
