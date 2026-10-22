using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");

        string proceed = "";

        while (proceed != "quit")
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            // If everything is hidden, show the final prompt and exit on the next input
            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Press enter to finish:");
                proceed = Console.ReadLine();

                if (proceed != "quit")
                {
                    proceed = "quit";
                }
            }
            else
            {
                Console.WriteLine("Press enter to continue or type 'quit' to finish:");
                proceed = Console.ReadLine();

                if (proceed != "quit")
                {
                    scripture.HideRandomWords(3);
                }
            }
        }
    }
}