using BookStoreConsoleApp.Services;

namespace BookStoreConsoleApp.Entities;

public class PaperBook : Book, IPurchasable
{
    public int Stock { get; private set; }

    public PaperBook(string isbn, string title, string authorName, int yearPublished, decimal price, int stock)
        : base(isbn, title, authorName, yearPublished, price)
    {
        Stock = stock;
    }

    public override string GetBookType() => "Paper Book";

    public bool IsAvailable(int quantity) => Stock >= quantity;

    public void ProcessPurchase(int quantity, string email, string address)
    {
        if (!IsAvailable(quantity))
            throw new InvalidOperationException($"Quantum book store: Not enough stock. Available: {Stock}");

        Stock -= quantity;
        ShippingService.Ship(this, quantity, address);
    }

    public decimal CalculateTotal(int quantity) => Price * quantity;
}
