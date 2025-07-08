using BookStoreConsoleApp.Entities;

namespace BookStoreConsoleApp.Services;

public static class ShippingService
{
    public static void Ship(PaperBook book, int quantity, string address)
    {
        Console.WriteLine($"Quantum book store: Shipping {quantity} copies of '{book.Title}' to {address}");
    }
}
