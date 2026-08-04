using System;

namespace CorporatePolymorphism
{
 abstract public class Employee {

  public abstract void SubmitDailyReport();
  public virtual void Work() => Console.WriteLine("Employee is working.");
  public virtual void ClockIn() => Console.WriteLine("Employee clocks in.");

  }
}
