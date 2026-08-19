using System;

namespace BiblioInheritance
{
  class Program
  {
    static void Main(string[] args)
    {
      Resource test = new Resource("Anatomy 09", "Medicine");
      test.GetInfo();
      Book book = new Book("Code: The Hidden Language of Computer Hardware and Software","Non-Fiction", "Charles Petzold", 396);
      book.GetInfo();
      Periodical p = new Periodical("Wired", "Technology", "Monthly");
      p.UpdateStatus();
      Console.WriteLine(p.Status);
      Video v = new Video("Ex Machina", "Alex Garland", "Sci-Fi", 108, "On-Demand");
      v.UpdateStatus();
      v.GetInfo();
          
    }
  }
}