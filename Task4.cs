namespace ConsoleApp9
{
    internal class Task4
    {
        public interface IBorrowable
        {
            void Borrow(string borrower, DateTime dueDate);
            void Return();
        }

        public abstract class LibraryItem : IBorrowable
        {
            public string Title { get; set; }
            public bool IsBorrowed { get; private set; }
            public string Borrower { get; private set; }
            public DateTime DueDate { get; private set; }

            public void Borrow(string borrower, DateTime dueDate)
            {
                if (IsBorrowed)
                {
                    Console.WriteLine($"Error: '{Title}' is already borrowed.");
                    return;
                }

                IsBorrowed = true;
                Borrower = borrower;
                DueDate = dueDate;
                OnBorrow(borrower, dueDate);
            }

            public void Return()
            {
                if (!IsBorrowed)
                {
                    Console.WriteLine($"Error: '{Title}' is not currently borrowed.");
                    return;
                }

                IsBorrowed = false;
                Borrower = null;
                DueDate = default;
                Console.WriteLine($"'{Title}' has been returned.");
            }

            public void CheckStatus()
            {
                if (IsBorrowed)
                {
                    Console.WriteLine($"Title: {Title}, Borrowed by {Borrower}, Due on {DueDate:yyyy-MM-dd}.");
                }
                else
                {
                    Console.WriteLine($"Title: {Title}, Available for borrowing.");
                }
            }

            public void ExtendDueDate(int days)
            {
                if (IsBorrowed)
                {
                    DueDate = DueDate.AddDays(days);
                    Console.WriteLine($"Due date for '{Title}' extended by {days} days. New due date: {DueDate:yyyy-MM-dd}.");
                }
                else
                {
                    Console.WriteLine($"Error: '{Title}' is not currently borrowed, cannot extend due date.");
                }
            }

            protected abstract void OnBorrow(string borrower, DateTime dueDate);
        }

        public class Book : LibraryItem
        {
            public string Author { get; set; }

            protected override void OnBorrow(string borrower, DateTime dueDate)
            {
                Console.WriteLine($"Book '{Title}' by {Author} borrowed by {Borrower}, due on {DueDate:yyyy-MM-dd}.");
            }
        }

        public class Magazine : LibraryItem
        {
            public int IssueNumber { get; set; }

            protected override void OnBorrow(string borrower, DateTime dueDate)
            {
                Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) borrowed by {Borrower}, due on {DueDate:yyyy-MM-dd}.");
            }
        }

        public static void Execute()
        {
            var book1 = new Book { Title = "This is book 1", Author = "This is author 1" };
            var book2 = new Book { Title = "This is book 2", Author = "This is author 2" };
            var book3 = new Book { Title = "This is book 3", Author = "This is author 3" };
            var magazine1 = new Magazine { Title = "This is magazine 1", IssueNumber = 11 };

            List<LibraryItem> libraryItems = new List<LibraryItem> { book1, book2, book3, magazine1 };

            var borrower1 = "Meto";
            var borrower2 = "Nadezhda";

            book1.Borrow(borrower1, DateTime.Now.AddDays(14));
            magazine1.Borrow(borrower1, DateTime.Now.AddDays(7));
            book3.Borrow(borrower1, DateTime.Now.AddDays(10));
            book2.Borrow(borrower2, DateTime.Now.AddDays(21));

            Console.WriteLine("\nLibrary Item Statuses:");
            foreach (var item in libraryItems)
            {
                item.CheckStatus();
            }

            book1.Return();
            magazine1.ExtendDueDate(5);
        }
    }
}
