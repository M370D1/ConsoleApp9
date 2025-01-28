namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose a task to execute (1-5):");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Task1.Execute(); // Zoo Animals
                    break;
                case "2":
                    Task2.Execute(); // School Grading System
                    break;
                case "3":
                    Task3.Execute(); // E-Commerce System
                    break;
                case "4":
                    Task4.Execute(); // Advanced Library Management System
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
