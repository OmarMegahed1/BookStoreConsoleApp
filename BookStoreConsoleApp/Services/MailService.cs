using BookStoreConsoleApp.Entities;

namespace BookStoreConsoleApp.Services;

public static class MailService
{
    public static void SendEmail(EBook book, int quantity, string email)
    {
        Console.WriteLine($"Quantum book store: Sending {book.FileType} file of '{book.Title}' to {email}");
    }
}
