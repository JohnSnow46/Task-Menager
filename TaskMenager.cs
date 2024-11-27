using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Task_Menager
{
    public static class TaskMenager
    {
        public static List<Task> tasks = new List<Task>();
        public static int counter = 1;
        public static void AddTask(Task task)
        {
            tasks.Add(task);
        }

        public static void RemoveTask(int x)
        {
            try
            {
                tasks.RemoveAt(x - 1);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong Value!");
            }
        }

        public static void MarkAsCompleted(Task task)
        {
            task.Status = TaskStatus.Completed;
            task.EndDate = DateTime.Now;
        }

        public static void ChangeStatusCompleted(int x)
        {
            if (x - 1 < tasks.Count && x > 0)
            {
                tasks[x - 1].Status = TaskStatus.Completed;
                tasks[x - 1].EndDate = DateTime.Now;
            }
            else
            {
                Console.WriteLine("Wrong number! try again");
                var newX = Console.ReadLine();
                ChangeStatusCompleted(int.Parse(newX));
            }
        }

        public static void DisplayDetails()
        {
            foreach (var task in tasks)
            {
                Console.WriteLine($"Task nr. {task.Id}");
                Console.WriteLine($"Name: {task.Name}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Category: {task.Category}");
                Console.WriteLine($"Priority: {task.Priority}");
                Console.WriteLine($"Status: {task.Status}");
                Console.WriteLine($"Start Date: {task.StartDate}");
                if (task.EndDate != null)
                    Console.WriteLine($"End Date: {task.EndDate}");
                Console.WriteLine();
            }
        }
        public static void AddTaskByUser()
        {
            var objTask = new Task();

            Console.WriteLine("AddTask: ");
            Console.WriteLine($"Name: ");
            objTask.Name = Console.ReadLine();
            Console.WriteLine($"Description: ");
            objTask.Description = Console.ReadLine();
            Console.WriteLine($"Category: ");
            objTask.StartDate = DateTime.Now;

            Console.WriteLine("Select Priority (1. Low, 2. Medium, 3.High, q - quit)");
            string input = Console.ReadLine();
            SelectPriority(input, objTask);

            Console.WriteLine("Select Category (1. Education, 2. Work, 3.Personal, q - quit)");
            input = Console.ReadLine();
            SelectCategory(input, objTask);

            objTask.Id = counter++;

            tasks.Add(objTask);
            DisplayDetails();
        }
        public static void SelectPriority(string input, Task task)
        {
            switch (input.ToLower())
            {
                case "1":
                    task.Priority = Priority.Low;
                    break;
                case "2":
                    task.Priority = Priority.Medium;
                    break;
                case "3":
                    task.Priority = Priority.High;
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine("Wrong number, try again!");
                    string input2 = Console.ReadLine();
                    SelectPriority(input2, task);
                    break;
            }
        }
        public static void SelectCategory(string input, Task task)
        {
            switch (input.ToLower())
            {
                case "1":
                    task.Category = Category.Education;
                    break;
                case "2":
                    task.Category = Category.Work;
                    break;
                case "3":
                    task.Category = Category.Personal;
                    break;
                case "q":
                    break;
                default:
                    Console.WriteLine("Wrong number, try again!");
                    string input2 = Console.ReadLine();
                    SelectPriority(input2, task);
                    break;
            }
        }

        public static int Parser(string input)
        {
            try
            {
                return int.Parse(input);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong Value");
                return -1;
            }
        }
    }
}
