using System.Collections.Generic;
namespace CyberLibraryManagement {
    class Library {
        List<Book> books = new List<Book>();

        public void AddBook(Book book){
            books.Add(book);
        }
        public List<Book> SearchBooksByTitle(string search){
            List<Book> results = new List<Book>();
            foreach(Book book in books){
                if(book.Title.Contains(search)){
                    results.Add(book);
                }
            }
            return results;
        }
          public void DisplayAllBooks(){
            foreach(Book book in books){
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
    }
}