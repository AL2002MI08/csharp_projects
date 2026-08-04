using System;

namespace CorporatePolymorphism
{
  public class Intern : Employee {
     public override void Work() => Console.WriteLine("Intern assists with the project.");
     public override void SubmitDailyReport() => Console.WriteLine("Intern submits daily report.");
     public override void ClockIn() => Console.WriteLine("Intern clocks in.");
  }
}