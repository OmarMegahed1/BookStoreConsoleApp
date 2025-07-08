namespace BookStoreConsoleApp.Entities;

public class ShowcaseBook : Book
{
    public ShowcaseBook(string isbn, string title, string authorName, int yearPublished)
        : base(isbn, title, authorName, yearPublished, 0)
    {
    }

    public override string GetBookType() => "Showcase/Demo Book";
}
