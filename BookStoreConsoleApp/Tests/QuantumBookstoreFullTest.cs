using BookStoreConsoleApp.Entities;

namespace BookStoreConsoleApp.Tests;

public class QuantumBookstoreFullTest
{
    public static void RunTests()
    {
        Console.WriteLine("Quantum book store: Starting tests...\n");

        var bookstore = new QuantumBookstore();



        Console.WriteLine("Quantum book store: Test 1 - Adding books");
        var paperBook1 = new PaperBook("ISBN001", "The Fall", "Albert Camus", 2020, 29.99m, 50);
        var eBook1 = new EBook("ISBN002", "The Stranger", "Albert Camus", 2023, 19.99m, "PDF");
        var showcaseBook1 = new ShowcaseBook("ISBN003", "Showcase Book", "Demo Author", 2024);

        bookstore.AddBook(paperBook1);
        bookstore.AddBook(eBook1);
        bookstore.AddBook(showcaseBook1);
        bookstore.DisplayInventory();
        Console.WriteLine();



        Console.WriteLine("Quantum book store: Test 2 - Buying books");
        try
        {
            decimal amount1 = bookstore.BuyBook("ISBN001", 2, "customer@email.com", "123 Main St");
            Console.WriteLine($"Quantum book store: Paid amount for paper book: ${amount1:F2}");

            decimal amount2 = bookstore.BuyBook("ISBN002", 1, "customer@email.com", "N/A");
            Console.WriteLine($"Quantum book store: Paid amount for ebook: ${amount2:F2}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        Console.WriteLine();



        Console.WriteLine("Quantum book store: Test 3 - Trying to buy showcase book");
        try
        {
            bookstore.BuyBook("ISBN003", 1, "customer@email.com", "123 Main St");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Expected error: {ex.Message}");
        }
        Console.WriteLine();

        

        Console.WriteLine("Quantum book store: Test 4 - Removing outdated books");
        var oldBook = new PaperBook("ISBN004", "Old Book", "Old Author", 2010, 15.99m, 10);
        bookstore.AddBook(oldBook);

        var removedBooks = bookstore.RemoveOutdatedBooks(10);
        Console.WriteLine($"Quantum book store: Removed {removedBooks.Count} outdated books");
        Console.WriteLine();

        

        Console.WriteLine("Quantum book store: Test 5 - Insufficient stock");
        try
        {
            bookstore.BuyBook("ISBN001", 100, "customer@email.com", "123 Main St");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Expected error: {ex.Message}");
        }
        Console.WriteLine();

        

        Console.WriteLine("Quantum book store: Final inventory:");
        bookstore.DisplayInventory();
    }
}
