using System;

namespace CyberLibraryManagement{

  class Program{
    public static void Main(string[] args){
      Book b1 = new Book("The Great Gatsby", "F. Scott Fitzgerald"); 
      Book b2 = new Book("To Kill a Mockingbird", "Harper Lee");
      Library library = new Library();
      library.AddBook(b1);
      library.AddBook(b2);
      List<Book> results = library.SearchBooksByTitle("The Great Gatsby");
      foreach(Book book in results){
        Console.WriteLine("Title: {0}, Author: {1}", book.Title, book.Author);
      }
      library.DisplayAllBooks();
    }
  }
}
