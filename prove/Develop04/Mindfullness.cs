using System;
using System.Collections.Generic;
using System.Threading;

namespace ActivityProgram
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _duration = 30; 
        }

        public void DisplayStartingMessage()
        {
            Console.WriteLine($"Starting {_name}");
            Console.WriteLine(_description);
            Console.WriteLine($"Duration: {_duration} seconds");
            Pause(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine($"You completed {_name} for {_duration} seconds.");
            Console.WriteLine("Good job!");
            Pause(3);
        }

        public void ShowSpinner(int seconds)
        {
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < endTime)
            {
                Console.Write("/");
                Thread.Sleep(100);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(100);
                Console.Write("\b \b");
            }
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }

        public void Pause(int seconds)
        {
            ShowSpinner(seconds);
        }

        public abstract void Run();
    }

    public class BreathingActivity : Activity
    {
        public BreathingActivity(string name, string description) : base(name, description) { }

        public override void Run()
        {
             DisplayStartingMessage();
    int totalSeconds = _duration;
    int breatheInTime = 5;
    int breatheOutTime = 5;

    while (totalSeconds > 0)
    {
        Console.WriteLine("Breathe in...");
        ShowCountDown(breatheInTime);
        totalSeconds -= breatheInTime;

        if (totalSeconds <= 0) break;

        Console.WriteLine("Breathe out...");
        ShowCountDown(breatheOutTime);
        totalSeconds -= breatheOutTime;
    }
        }
    }

    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a moment when you stood out.",
            "Think of a moment when you helped someone."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience significant to you?",
            "What did you learn from this experience?"
        };

        public ReflectingActivity(string name, string description) : base(name, description) { }

        public override void Run()
        {
            DisplayStartingMessage();
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            foreach (string question in _questions)
            {
                Console.WriteLine(question);
                Pause(5);
            }
            DisplayEndingMessage();
        }
    }

    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "List people you appreciate.",
            "List your personal strengths."
        };

        public ListingActivity(string name, string description) : base(name, description) { }

        public override void Run()
        {
            DisplayStartingMessage();
            Random rand = new Random();
            string prompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Pause(3);
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrEmpty(item))
                {
                    items.Add(item);
                }
            }
            int count = items.Count;
            Console.WriteLine($"You listed {count} items.");
            DisplayEndingMessage();
        }
    }
}
