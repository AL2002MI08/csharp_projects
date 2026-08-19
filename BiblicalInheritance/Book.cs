using System;

namespace BiblioInheritance
{
 class Book: Resource {
  protected string[] Author {get; set;} = Array.Empty<string>();
  protected int PageCount {get; set;}
  public string writer = "";

  public Book(string title, string category,string[] author, int pageCount): base(title, category) {
    Author = author;
    PageCount = pageCount;
  }
  public void DisplayAuthors(string[] authors){
    foreach(string author in authors){
      writer = author;
    }
  }
 }
}