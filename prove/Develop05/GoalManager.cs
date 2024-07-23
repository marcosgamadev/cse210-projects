using System;
using System.Collections.Generic;
using System.IO;

namespace GoalTracking
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            bool exit = false;
            while (!exit)
            {
            
                Console.WriteLine("1. List Goal");
                Console.WriteLine("2. Create Goal");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Quit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListGoal();
                        break;
                    case "2":
                        CreateGoal();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        LoadGoals();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public void ListGoal()
        {
            foreach (var goal in _goals)
            {
                Console.WriteLine(goal.GetDetailsString());
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("Enter goal type (1. SimpleGoal, 2. EternalGoal, 3. ChecklistGoal): ");
            string goalType = Console.ReadLine();

            Console.WriteLine("Enter goal name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter goal description: ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter goal points: ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal = null;

            switch (goalType)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.WriteLine("Enter target times to complete: ");
                    int target = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter bonus points for completing: ");
                    int bonus = int.Parse(Console.ReadLine());

                    newGoal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }

            if (newGoal != null)
            {
                _goals.Add(newGoal);
                Console.WriteLine("Goal created successfully.");
            }
        }

        public void RecordEvent()
        {
            Console.WriteLine("Enter goal number to record event: ");
            int goalNumber = int.Parse(Console.ReadLine());

            if (goalNumber >= 0 && goalNumber < _goals.Count)
            {
                _goals[goalNumber].RecordEvent();
                if (_goals[goalNumber].IsComplete())
                {
                    _score += _goals[goalNumber].GetPoints();
                    Console.WriteLine("Goal completed! Points awarded.");
                }
                else
                {
                    Console.WriteLine("Event recorded.");
                }
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        public void SaveGoals()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt"))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully.");
        }

        public void LoadGoals()
        {
            if (File.Exists("goals.txt"))
            {
                using (StreamReader reader = new StreamReader("goals.txt"))
                {
                    _score = int.Parse(reader.ReadLine());
                    _goals.Clear();

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(':');
                        string goalType = parts[0];
                        string[] goalDetails = parts[1].Split(',');

                        Goal loadedGoal = null;

                        switch (goalType)
                        {
                            case "SimpleGoal":
                                loadedGoal = new SimpleGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]));
                                if (bool.Parse(goalDetails[3]))
                                {
                                    ((SimpleGoal)loadedGoal).RecordEvent(); // Mark as complete if necessary
                                }
                                break;
                            case "EternalGoal":
                                loadedGoal = new EternalGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]));
                                break;
                            case "ChecklistGoal":
                                loadedGoal = new ChecklistGoal(goalDetails[0], goalDetails[1], int.Parse(goalDetails[2]), int.Parse(goalDetails[4]), int.Parse(goalDetails[5]));
                                break;
                        }

                        if (loadedGoal != null)
                        {
                            _goals.Add(loadedGoal);
                        }
                    }
                }

                Console.WriteLine("Goals loaded successfully.");
            }
            else
            {
                Console.WriteLine("No saved goals found.");
            }
        }
    }
}
