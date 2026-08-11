using System;
using System.Collections.Generic;

public class Book
{
  public string ISBN { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  public string Category { get; set; }
  public bool IsCheckedOut { get; set; }

  public override string ToString()
  {
    return $"{Title} by {Author} (ISBN: {ISBN}, Category: {Category})";
  }
}

public class LibrarySystem
{
  private LinkedList<Book> _catalog;
  private Dictionary<string, List<Book>> _booksByCategory;
  private Stack<Book> _reshelveCart;


  public LibrarySystem()
  {
        _catalog = new LinkedList<Book>();
        _booksByCategory = new Dictionary<string, List<Book>>();
        _reshelveCart = new Stack<Book>();
        Console.WriteLine("Initialized the type parameters...");

  }
  public void AddBook(Book book){
    _catalog.AddLast(book);
   if (!_booksByCategory.ContainsKey(book.Category))
    {
        _booksByCategory[book.Category] = new List<Book>();
    }
    _booksByCategory[book.Category].Add(book);
    Console.WriteLine($"Added {book.Title} to category {book.Category}");
  }
   public void DisplayCatalog(){
    int bookCount = 0;
    foreach(var book in _catalog){
      bookCount++;
      Console.WriteLine($"{book.Title}, ISB: {book.ISBN} and category is {book.Category}.");

    }
    Console.WriteLine($"Total books are {bookCount}");
  }
    public void DisplayBooksByCategory(string category) {
    if(_booksByCategory.ContainsKey(category)){
        foreach (Book book in _booksByCategory[category])
        {
            Console.WriteLine($"- {book.Title}");
        }
      } else {
          Console.WriteLine("Book does not exist in this category.");
      }
  }
    public bool CheckoutBook(string ISBN) {
      foreach(var book in _catalog){
        if(book.ISBN == ISBN) {
          if(book.IsCheckedOut) {
            Console.WriteLine($"Book with ISBN {ISBN} is already checked out.");
            return false;
          }

          book.IsCheckedOut = true;
          Console.WriteLine($"Checkedout book is {book.Title}");
          return true;
        }
  
      }
      Console.WriteLine($"Book with ISBN {ISBN} does not exist.");
      return false;
   }
    public bool ReturnBook(string ISBN)
    {
      foreach (Book book in _catalog)
      {
        if (book.ISBN == ISBN)
        {
            if (!book.IsCheckedOut)
            {
                Console.WriteLine($"Book with ISBN {ISBN} was not checked out.");
                return false;
            }

            book.IsCheckedOut = false;
            _reshelveCart.Push(book);
            Console.WriteLine($"Returned \"{book.Title}\" and added it to the reshelve cart.");
            return true;
        }
      }

      Console.WriteLine($"No book found with ISBN {ISBN}.");
      return false;
}

  public void ProcessReshelveCart()
  {
    if (_reshelveCart.Count == 0)
    {
        Console.WriteLine("No books to reshelve.");
        return;
    }

    while (_reshelveCart.Count > 0)
    {
        Book book = _reshelveCart.Pop();
        Console.WriteLine($"Reshelved \"{book.Title}\".");
    }
  }
  

}

class Program
{
  static void Main(string[] args)
  {
    Book book1 = new Book { 
      ISBN = "123", 
      Title = "Whispers of the Cosmic Winds", 
      Author = "Elena Starling",
      Category = "Science Fiction" 
    };
    
    Book book2 = new Book { 
      ISBN = "456", 
      Title = "The Last Algorithm", 
      Author = "Marcus Chen",
      Category = "Technology" 
    };

    LibrarySystem library = new LibrarySystem();

    Console.WriteLine("\n=== Add Books to Catalog ===");
    library.AddBook(book1);
    library.AddBook(book2);

    Console.WriteLine("\n=== Display Catalog ===");
    library.DisplayCatalog();

    Console.WriteLine("\n=== Display Books by Category ===");
    library.DisplayBooksByCategory("Technolog");

    Console.WriteLine("\n=== Test Book Circulation ===");
    library.CheckoutBook("456");
    library.ReturnBook("123");
    library.ProcessReshelveCart();
  }
}