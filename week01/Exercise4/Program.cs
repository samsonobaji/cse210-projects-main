using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers from user input
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
                numbers.Add(input);
        } while (input != 0);

        // Calculate sum and find largest number
        int sum = 0, max = numbers[0];
        foreach (int num in numbers)
        {
            sum += num;
            if (num > max) max = num;
        }

        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Find the smallest positive number
        int minPositive = int.MaxValue;
        foreach (int num in numbers)
        {
            if (num > 0 && num < minPositive)
                minPositive = num;
        }

        if (minPositive == int.MaxValue)
            Console.WriteLine("No positive numbers were entered.");
        else
            Console.WriteLine($"The smallest positive number is: {minPositive}");

        // Sort and display numbers
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
