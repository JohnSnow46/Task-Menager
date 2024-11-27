using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Menager
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Priority Priority { get; set; }
        public TaskStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Task(int Id,string name, string description, Category category, Priority priority)
        {
            this.Id = Id;
            Name = name;
            Description = description;
            Category = category;
            Priority = priority;
            Status = TaskStatus.ToDo;
            StartDate = DateTime.Now;
        }

        public Task()
        {
        }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public enum Category
    {
        Work,
        Personal,
        Education
    }

    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Completed
    }
}
