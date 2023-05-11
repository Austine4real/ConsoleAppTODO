using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTODO
{
    public class Task
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; }
    }
    public enum Priority
    {
        Low,
        Medium,
        High
    }
}
