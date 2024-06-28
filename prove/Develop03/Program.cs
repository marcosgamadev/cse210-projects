using System;
using System.Collections.Concurrent;


class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture("Mosiah", 4, 9, "9 Believe in God; believe that he is, and that he created all things, both in heaven and in earth; believe that he has all wisdom, and all power, both in heaven and in earth; believe that man doth not comprehend all the things which the Lord can comprehend.");
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide some words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);  

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine("The entire scripture is hidden!");
                break;
            }
        }
    }
}