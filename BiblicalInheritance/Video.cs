using System;

namespace BiblioInheritance
{
  class Video: Resource {
    public string Director {get; protected set;}
    public int Runtime {get; protected set;}
    public string MediaType {get; protected set;}

    public Video(string title, string director, string category, int runtime, string mediaType): base(title, category) {
      Director = director;
      Runtime = runtime;
      MediaType = mediaType;
    }
    public override void GetInfo(){
      Console.WriteLine($"Title: {Title}\n Category: {Category}\n Status: {Status}\n Director: {Director}\n Runtime: {Runtime}");
    }
    public override void UpdateStatus(){
      if(Status == "On-demand") {
        Status = "DVD";
      } else {
        Status = "On-demand";
      }
    }
    
  }

}
