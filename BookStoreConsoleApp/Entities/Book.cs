namespace BookStoreConsoleApp.Entities;

public abstract class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string AuthorName { get; set; }
    public int YearPublished { get; set; }
    public decimal Price { get; set; }

    protected Book(string isbn, string title, string authorName, int yearPublished, decimal price)
    {
        ISBN = isbn;
        Title = title;
        AuthorName = authorName;
        YearPublished = yearPublished;
        Price = price;
    }

    public abstract string GetBookType();
}
