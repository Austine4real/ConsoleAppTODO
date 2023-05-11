using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppTODO
{
    public class MyMethod
    {
        static readonly int tableWidth = 95;
        public static void DisplayCalHeader()
        {
            string headerText = "TODO APPLICATION";
            int headerWidth = headerText.Length + 4;
            int centerPosition = (Console.WindowWidth / 2) - (headerWidth / 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(new string('=', 120));
            Console.WriteLine($"{new string(' ', centerPosition)}|  {headerText}  |");
            Console.WriteLine(new string('=', 120));
            Console.ResetColor();
        }

        public static void PrintTable(List<Task> tasks)
        {
            Console.Clear();
            Console.WriteLine(CentreText(" TODO APPLICATION", tableWidth));
            PrintLine();
            PrintRow("ID", "Title", "Description", "Due Date", "Priority", "Status");
            PrintLine();

            foreach (Task task in tasks)
            {
                int taskId = tasks.IndexOf(task) + 1;
                string status = task.IsCompleted ? "Completed" : "Not Completed";
                PrintRow(taskId.ToString(), task.Title, task.Description, task.DueDate.ToString("yyyy-MM-dd"), task.Priority.ToString().ToLower(), status);
            }

            PrintLine();
            Console.WriteLine("\n \n");
        }
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length + 1) / columns.Length;
            string row = "|";
            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;
            return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
        }

        static string CentreText(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            int totalSpaces = width - text.Length;
            int leftSpaces = totalSpaces / 2;
            return new string(' ', leftSpaces) + text + new string(' ', totalSpaces - leftSpaces);
        }

        public static void DisplayTaskMenu(string name) 
        {
            Console.WriteLine($"Welcome, {name}!");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. Edit Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Complete Task");
            Console.WriteLine("6. Log out");
            Console.Write("Enter choice: ");
        }
        public static void DisplayMenu() 
        {
            Console.WriteLine("Please log in or register for an account.");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Log in");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
        }

        public static void DisplayInvalidInputMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public static void DisplaySuccessInputMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
