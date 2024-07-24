using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        
        Activity running = new Running(DateTime.Now.AddDays(-1), 30, 5.0); 
        Activity cycling = new Cycling(DateTime.Now.AddDays(-2), 60, 20.0); 
        Activity swimming = new Swimming(DateTime.Now.AddDays(-3), 45, 30); 

       
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

      
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine();
        }
    }
}
