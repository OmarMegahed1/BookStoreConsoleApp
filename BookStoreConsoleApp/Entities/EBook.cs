using BookStoreConsoleApp.Services;

namespace BookStoreConsoleApp.Entities;

public class EBook : Book, IPurchasable
{
    public string FileType { get; set; }

    public EBook(string isbn, string title, string authorName, int yearPublished, decimal price, string fileType)
        : base(isbn, title, authorName, yearPublished, price)
    {
        FileType = fileType;
    }

    public override string GetBookType() => "EBook";

    public bool IsAvailable(int quantity) => true; // EBooks are always available

    public void ProcessPurchase(int quantity, string email, string address)
    {
        MailService.SendEmail(this, quantity, email);
    }

    public decimal CalculateTotal(int quantity) => Price * quantity;
}
