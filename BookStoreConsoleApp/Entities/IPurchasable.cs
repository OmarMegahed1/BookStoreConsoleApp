namespace BookStoreConsoleApp.Entities;

public interface IPurchasable
{
    bool IsAvailable(int quantity);
    void ProcessPurchase(int quantity, string email, string address);
    decimal CalculateTotal(int quantity);
}
