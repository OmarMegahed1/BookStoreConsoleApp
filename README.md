# Quantum Bookstore Console Application

A C# console application that simulates a bookstore management system with support for different book types and purchase operations.

## Features

- **Multiple Book Types**: Support for Paper Books, EBooks, and Showcase Books
- **Inventory Management**: Add books, remove outdated books, and display current inventory
- **Purchase System**: Handle book purchases with different fulfillment methods
- **Stock Management**: Track inventory levels for physical books
- **Email & Shipping Services**: Automated delivery for digital and physical books

## Architecture

### Core Components

#### Entities
- **`Book`** (Abstract Base Class): Contains common properties for all book types
- **`PaperBook`**: Physical books with stock management
- **`EBook`**: Digital books with file type specification
- **`ShowcaseBook`**: Demo books that cannot be purchased
- **`IPurchasable`**: Interface for books that can be bought

#### Services
- **`MailService`**: Handles email delivery for EBooks
- **`ShippingService`**: Manages physical book shipping

#### Core Logic
- **`QuantumBookstore`**: Main bookstore management class
- **`QuantumBookstoreFullTest`**: Comprehensive test suite

## Class Hierarchy

```
Book (Abstract)
├── PaperBook (implements IPurchasable)
├── EBook (implements IPurchasable)
└── ShowcaseBook
```

## Getting Started

### Prerequisites
- .NET 8.0 or later
- Visual Studio 2022 or Visual Studio Code

### Installation
1. Clone the repository
2. Navigate to the project directory
3. Build the project:
   ```bash
   dotnet build
   ```

### Running the Application
```bash
dotnet run
```

The application will automatically run the test suite demonstrating all features.

## Usage Examples

### Adding Books to Inventory

```csharp
var bookstore = new QuantumBookstore();

// Add a paper book
var paperBook = new PaperBook("ISBN001", "The Fall", "Albert Camus", 2020, 29.99m, 50);
bookstore.AddBook(paperBook);

// Add an eBook
var eBook = new EBook("ISBN002", "The Stranger", "Albert Camus", 2023, 19.99m, "PDF");
bookstore.AddBook(eBook);

// Add a showcase book
var showcaseBook = new ShowcaseBook("ISBN003", "Demo Book", "Demo Author", 2024);
bookstore.AddBook(showcaseBook);
```

### Purchasing Books

```csharp
// Buy paper books (requires shipping address)
decimal total = bookstore.BuyBook("ISBN001", 2, "customer@email.com", "123 Main St");

// Buy eBooks (digital delivery)
decimal total = bookstore.BuyBook("ISBN002", 1, "customer@email.com", "N/A");
```

### Inventory Management

```csharp
// Display current inventory
bookstore.DisplayInventory();

// Remove books older than 10 years
var removedBooks = bookstore.RemoveOutdatedBooks(10);
```

## Book Types

### Paper Books
- **Properties**: ISBN, Title, Author, Year, Price, Stock
- **Features**: 
  - Stock tracking
  - Availability checking
  - Physical shipping
- **Limitations**: Limited by stock quantity

### EBooks
- **Properties**: ISBN, Title, Author, Year, Price, FileType
- **Features**:
  - Always available (no stock limits)
  - Email delivery
  - Multiple file formats
- **Limitations**: None

### Showcase Books
- **Properties**: ISBN, Title, Author, Year (Price is always 0)
- **Features**: Display only
- **Limitations**: Cannot be purchased

## API Reference

### QuantumBookstore Class

#### Methods
- `AddBook(Book book)`: Add a book to inventory
- `RemoveOutdatedBooks(int yearsOld)`: Remove books older than specified years
- `BuyBook(string isbn, int quantity, string email, string address)`: Purchase books
- `DisplayInventory()`: Show current inventory

### IPurchasable Interface

#### Methods
- `IsAvailable(int quantity)`: Check if quantity is available
- `ProcessPurchase(int quantity, string email, string address)`: Handle purchase
- `CalculateTotal(int quantity)`: Calculate total price

## Error Handling

The application handles various error scenarios:
- **Duplicate ISBN**: Prevents adding books with existing ISBNs
- **Book Not Found**: Throws exception when trying to buy non-existent books
- **Insufficient Stock**: Prevents purchasing more than available stock
- **Showcase Book Purchase**: Prevents purchasing demo books
- **Invalid Book Type**: Handles non-purchasable book types

## Testing

The application includes a comprehensive test suite (`QuantumBookstoreFullTest`) that covers:
1. Adding different book types
2. Purchasing paper books and eBooks
3. Error handling for showcase books
4. Removing outdated books
5. Stock management validation

### Running Tests
Tests run automatically when starting the application, or you can run them manually:
```csharp
QuantumBookstoreFullTest.RunTests();
```
