using System;

namespace BiblioInheritance
{
 class Periodical: Resource {
    public string Period {get; protected set;}

    public Periodical(string title, string category, string period) : base(title, category) {
      Period = period;
    }
    public override void UpdateStatus(){
      if(Status == "Available"){
        Status = "In-use";
      } else {
        Status = "Available";
      }
    }

 }
}