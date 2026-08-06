using System;

namespace HomeworkApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Ask how many workers there are
            Console.Write("Enter the number of workers: ");
            if (!int.TryParse(Console.ReadLine(), out int numWorkers) || numWorkers <= 0)
            {
                Console.WriteLine("Please enter a valid positive number for workers.");
                return;
            }

            double highestSalary = double.MinValue;
            int highestWorkerIndex = -1;

            // 2. Loop through each worker and prompt for their salary
            for (int i = 1; i <= numWorkers; i++)
            {
                Console.Write($"Enter salary for worker {i}: ");

                if (double.TryParse(Console.ReadLine(), out double currentSalary))
                {
                    // 3. Keep track of the maximum salary found
                    if (currentSalary > highestSalary)
                    {
                        highestSalary = currentSalary;
                        highestWorkerIndex = i;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid salary input. Please enter a valid number.");
                    i--; // Re-ask for this worker
                }
            }

            // 4. Print the result
            Console.WriteLine();
            Console.WriteLine($"Worker {highestWorkerIndex} has the highest salary: ${highestSalary:F2}");
        }
    }
}