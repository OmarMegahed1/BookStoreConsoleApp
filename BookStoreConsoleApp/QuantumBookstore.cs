using BookStoreConsoleApp.Entities;

namespace BookStoreConsoleApp;

public class QuantumBookstore
{
    private readonly Dictionary<string, Book> inventory = new Dictionary<string, Book>();

    public void AddBook(Book book)
    {
        if (inventory.ContainsKey(book.ISBN))
        {
            Console.WriteLine($"Quantum book store: Book with ISBN {book.ISBN} already exists");
            return;
        }

        inventory[book.ISBN] = book;
        Console.WriteLine($"Quantum book store: Added {book.GetBookType()}: '{book.Title}' by {book.AuthorName}");
    }

    public List<Book> RemoveOutdatedBooks(int yearsOld)
    {
        int currentYear = DateTime.Now.Year;
        var outdatedBooks = inventory.Values
            .Where(book => currentYear - book.YearPublished > yearsOld)
            .ToList();

        foreach (var book in outdatedBooks)
        {
            inventory.Remove(book.ISBN);
            Console.WriteLine($"Quantum book store: Removed outdated book: '{book.Title}' ({book.YearPublished})");
        }

        return outdatedBooks;
    }

    public decimal BuyBook(string isbn, int quantity, string email, string address)
    {
        if (!inventory.ContainsKey(isbn))
        {
            throw new InvalidOperationException($"Quantum book store: Book with ISBN {isbn} not found");
        }

        Book book = inventory[isbn];

        if (book is ShowcaseBook)
        {
            throw new InvalidOperationException($"Quantum book store: '{book.Title}' is a showcase book and not for sale");
        }

        if (book is IPurchasable purchasableBook)
        {
            if (!purchasableBook.IsAvailable(quantity))
            {
                throw new InvalidOperationException($"Quantum book store: Insufficient quantity available");
            }

            decimal totalAmount = purchasableBook.CalculateTotal(quantity);
            purchasableBook.ProcessPurchase(quantity, email, address);

            Console.WriteLine($"Quantum book store: Purchase successful! Total amount: ${totalAmount:F2}");
            return totalAmount;
        }

        throw new InvalidOperationException($"Quantum book store: Book type cannot be purchased");
    }

    public void DisplayInventory()
    {
        Console.WriteLine("Quantum book store: Current Inventory:");
        foreach (var book in inventory.Values)
        {
            string stockInfo = book is PaperBook paperBook ? $", Stock: {paperBook.Stock}" : "";
            string fileTypeInfo = book is EBook eBook ? $", FileType: {eBook.FileType}" : "";
            Console.WriteLine($"  - {book.ISBN}: '{book.Title}' by {book.AuthorName} ({book.YearPublished}) - ${book.Price:F2} - {book.GetBookType()}{stockInfo}{fileTypeInfo}");
        }
    }
}
