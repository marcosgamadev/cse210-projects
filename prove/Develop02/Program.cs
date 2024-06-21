using System;
using System.IO;
using System.Collections.Generic;
using System.Timers;

class Program
{
    static List<string> journalEntries = new List<string>();
    static System.Timers.Timer reminderTimer;
    static DateTime reminderTime;
    static bool dailyReminder = true;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        bool quit = false;

        while (!quit)
        {
            DisplayOptions();

            int choice;
            Console.Write("What is your choice? ");
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 6)
            {
                Console.WriteLine("Invalid option. Please choose a valid number.");
                Console.Write("Enter the desired option number: ");
            }

            switch (choice)
            {
                case 1:
                    WriteJournalEntry();
                    break;
                case 2:
                    DisplayJournal();
                    break;
                case 3:
                    LoadJournal();
                    break;
                case 4:
                    SaveJournal();
                    break;
                case 5:
                    SetReminder();
                    break;
                case 6:
                    quit = true;
                    break;
            }
        }

        if (reminderTimer != null)
        {
            reminderTimer.Stop();
            reminderTimer.Dispose();
        }
    }

    static void DisplayOptions()
    {
        Console.WriteLine("Please select one of the following choices: ");
        string[] options = { "Write", "Display", "Load", "Save", "Set Reminder", "Quit" };

        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
    }

    static void WriteJournalEntry()
    {
        string[] questions = {
           "What brought you joy today?",
           "What challenges did you face today and how did you handle them?",
           "What was the highlight of your day and why?",
           "What are your most dominant thoughts and feelings at the moment?",
           "What are your goals and objectives for tomorrow or the near future?",
           "What did you learn today?"
        };

        Random random = new Random();
        int randomIndex = random.Next(0, questions.Length);

        Console.WriteLine(questions[randomIndex]);

        Console.Write("> ");
        string answer = Console.ReadLine();

        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToString();
        string journalEntry = $"Date: {dateText} - Prompt: {questions[randomIndex]}: {answer}";

        journalEntries.Add(journalEntry);

        Console.WriteLine("Journal entry added successfully.");
    }

    static void DisplayJournal()
    {
        Console.WriteLine("Journal Entries:");

        foreach (string entry in journalEntries)
        {
            Console.WriteLine(entry);
        }
    }

    static void LoadJournal()
    {
        Console.Write("Enter the file name to load: ");
        string fileName = Console.ReadLine();

        Console.WriteLine("Loading journal entries...");

        try
        {
            if (File.Exists(fileName))
            {
                journalEntries = new List<string>(File.ReadAllLines(fileName));
                foreach (string entry in journalEntries)
                {
                    Console.WriteLine(entry);
                }
            }
            else
            {
                Console.WriteLine("No journal entries found.");
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while loading the journal: {e.Message}");
        }
    }

    static void SaveJournal()
    {
        Console.Write("Enter the file name to save: ");
        string fileName = Console.ReadLine();

        Console.WriteLine("Saving journal...");

        try
        {
            File.WriteAllLines(fileName, journalEntries);
            Console.WriteLine("Journal saved successfully.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"An error occurred while saving the journal: {e.Message}");
        }
    }

    // Exceeding Requirements -  the user to set reminders for writing journal entriess 
    static void SetReminder()
    {
        Console.Write("Enter the reminder time (HH:mm): ");
        string timeInput = Console.ReadLine();

        Console.Write("Do you want a daily reminder? (yes/no): ");
        string dailyInput = Console.ReadLine();

        dailyReminder = dailyInput.Equals("yes", StringComparison.OrdinalIgnoreCase);

        if (DateTime.TryParseExact(timeInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out reminderTime))
        {
            reminderTime = DateTime.Today.Add(reminderTime.TimeOfDay);

            if (reminderTimer != null)
            {
                reminderTimer.Stop();
                reminderTimer.Dispose();
            }

            reminderTimer = new System.Timers.Timer(60000); 
            reminderTimer.Elapsed += CheckReminder;
            reminderTimer.Start();

            Console.WriteLine("Reminder set successfully.");
        }
        else
        {
            Console.WriteLine("Invalid time format. Please enter the time in HH:mm format.");
        }
    }

    static void CheckReminder(object sender, ElapsedEventArgs e)
    {
        DateTime currentTime = DateTime.Now;

        if (currentTime.Hour == reminderTime.Hour && currentTime.Minute == reminderTime.Minute)
        {
            Console.WriteLine("Reminder: It's time to write in your journal!");

            if (!dailyReminder)
            {
                reminderTimer.Stop();
                reminderTimer.Dispose();
            }
        }
    }
}
