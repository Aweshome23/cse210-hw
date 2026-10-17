using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        int number = 1;
        int total = 0;
        int lenght = 0;
        int highNumber = 0;
        List<int> numbers = new List<int>();

        while (number != 0)
        {
            Console.Write("What number would you like to add to the list? ");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);
            numbers.Add(number);
        }

        foreach (int listNumber in numbers)
        {
            total += listNumber;
            lenght += 1;

            if (listNumber > highNumber)
            {
                highNumber = listNumber;
            }
        }

        Console.WriteLine($"The total is : {total}");
        double average = (double)total/(lenght - 1);
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest numer is: {highNumber}");
    }
}