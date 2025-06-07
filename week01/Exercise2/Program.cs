using System;

class Program
{
    static void Main()
    {
        // Get grade input
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        string letter = "";
        string sign = "";

        // Determine letter grade
        if (grade >= 90)
            letter = "A";
        else if (grade >= 80)
            letter = "B";
        else if (grade >= 70)
            letter = "C";
        else if (grade >= 60)
            letter = "D";
        else
            letter = "F";

        // Determine sign (+, -, or none)
        int lastDigit = grade % 10;
        if (lastDigit >= 7)
            sign = "+";
        else if (lastDigit < 3)
            sign = "-";

        // Handle exceptions (No A+ and No F+ or F-)
        if (letter == "A" && sign == "+")
            sign = "";  // No A+
        if (letter == "F")
            sign = "";  // No F+ or F-

        // Display final grade
        Console.WriteLine($"Your grade is {letter}{sign}.");

        // Pass or fail message
        if (grade >= 70)
            Console.WriteLine("Congratulations! You passed.");
        else
            Console.WriteLine("Keep working hard! You'll improve next time.");
    }
}
