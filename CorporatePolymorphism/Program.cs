using System;
using System.Collections.Generic;

namespace CorporatePolymorphism
{
  class Program
  {
    static void Main(string[] args)
    { 
      Employee hrRep = new HR();

      hrRep.ClockIn();
      hrRep.Work();
      hrRep.SubmitDailyReport();
      Console.WriteLine(); //Line break


      Employee employee1 = new Engineer();
      Employee employee2 = new Manager();
      Employee employee3 = new Intern();
      Engineer myEngineer = employee1 as Engineer;
      if(myEngineer != null){
        myEngineer.SubmitDailyReport();
      }
      else {
        Console.WriteLine("Down cast failed!");
      }


      List<Employee> employees = new List<Employee>();
      employees.Add(employee1);
      employees.Add(employee2);
      employees.Add(employee3);
      foreach(Employee employee in employees){
        if(employee is Engineer){
          Console.WriteLine("This is an Engineer.");
          employee.Work();
          employee.SubmitDailyReport();
          employee.ClockIn();
        }
        else if(employee is Manager){
          Console.WriteLine("This is a Manager.");
          employee.Work();
          employee.SubmitDailyReport();
          employee.ClockIn();
        }
         else if(employee is Intern){
          Console.WriteLine("This is an Intern.");
          employee.Work();
          employee.SubmitDailyReport();
          employee.ClockIn();
        }
        else {
          Console.WriteLine("No category for this employee.");
        }
      }


    }
  }
}
