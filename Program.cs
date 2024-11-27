using System.Linq.Expressions;
using System.Xml.Linq;
using Task_Menager;


internal class Program
{
    private static void Main(string[] args)
    {
        Task_Menager.Task task1 = new Task_Menager.Task(TaskMenager.counter++, "test1", "test1", Category.Work, Priority.High);
        Task_Menager.Task task2 = new Task_Menager.Task(TaskMenager.counter++, "test2", "test2", Category.Work, Priority.High);
        Task_Menager.Task task3 = new Task_Menager.Task(TaskMenager.counter++, "test3", "test3", Category.Work, Priority.High);

        TaskMenager.AddTask(task1);
        TaskMenager.AddTask(task2);
        TaskMenager.AddTask(task3);

        Console.WriteLine("This is your tasks: ");
        Console.WriteLine();
        TaskMenager.DisplayDetails();

        Console.WriteLine("1. Finish Task");
        Console.WriteLine("2. Add Task");
        Console.WriteLine("3. Remove Task");
        Console.WriteLine("4. Start Task");

        string input = Console.ReadLine();

        switch (input)
        {
            case "1":

                Console.WriteLine("Give task number to finish");
                try
                {
                    TaskMenager.ChangeStatusCompleted(TaskMenager.Parser(Console.ReadLine()));
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong Value");
                    break;
                }

                break;
            case "2":

                TaskMenager.AddTaskByUser();

                break;
            case "3":

                Console.WriteLine("Give task number to delete: ");
                TaskMenager.RemoveTask(TaskMenager.Parser(Console.ReadLine()));

                break;
            default:
                // code block
                break;
        }
    }
}