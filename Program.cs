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
                    Task1.Execute();
                    break;
                //case "2":
                //    Task2MaxSequenceOfEqualElements.Execute();
                //    break;
                //case "3":
                //    Task3Train.Execute();
                //    break;
                //case "4":
                //    Task4CardsGame.Execute();
                //    break;
                //case "5":
                //    Task5CoauntCharsInString.Execute();
                //    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
