namespace ActivityProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Start Breathing Activity");
                Console.WriteLine("2. Start Reflecting Activity");
                Console.WriteLine("3. Start Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select a choice from the menu: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear(); 
                        RunActivity(new BreathingActivity("Breathing Activity", "This activity helps you relax through controlled breathing."));
                        break;
                    case "2":
                        Console.Clear(); 
                        RunActivity(new ReflectingActivity("Reflecting Activity", "This activity helps you reflect on important moments in your life."));
                        break;
                    case "3":
                        Console.Clear(); 
                        RunActivity(new ListingActivity("Listing Activity", "This activity helps you list good things in your life."));
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                
                Console.Clear(); 
            }
        }

        static void RunActivity(Activity activity)
        {
            Console.Write("Enter duration in seconds: ");
            int duration;
            while (!int.TryParse(Console.ReadLine(), out duration) || duration <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid positive number.");
                Console.Write("Enter duration in seconds: ");
            }

            activity.Duration = duration;
            activity.Run();
        }
    }
}
