using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished: ");
        int number = 1;
        int sum = 0;
        int max = 0;
        int pos_min = 10000;
        double average = 0;
        while (number != 0)
        {
            Console.Write("Enter number: ");
            string number_str = Console.ReadLine();
            number = int.Parse(number_str);
            if (number !=0)
            {
                numbers.Add(number);
            }
        }
        foreach (int num in numbers)
        {
            sum = sum + num;
            if (num > max)
            {
                max = num;
            }
            if (num > 0 && pos_min > num)
            {
                pos_min = num;
            }
            
            
        }
        average = (double)sum / numbers.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {pos_min}");
        numbers.Sort();
        
        Console.WriteLine($"The sorted list is:");
        foreach (int num in numbers)
        {
            Console.WriteLine($"{num}");
        }

    }
}