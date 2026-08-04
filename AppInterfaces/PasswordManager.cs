using System;

namespace SavingInterface
{
  class PasswordManager: IDisplayable, IResetable
  {
    public string HeaderSymbol {get;} = "-";
    private string password;
    protected string Password
    { get{
      return password;
    }
    set {
      if(value.Length < 8){
        Console.WriteLine("Password must contain atleast eight characters.");
      } else {
        password = value;
      }
    } }

    public bool Hidden
    { get; private set; }

    public PasswordManager(string password, bool hidden)
    {
      Password = password;
      Hidden = hidden;
    }
      public void Display(){
          Console.WriteLine("Password");
          Console.WriteLine(new string(HeaderSymbol[0], 11));
          if(Hidden){
            Console.WriteLine("***");
          } 
          else {
            Console.WriteLine(Password);
          }
        }
      public void Reset(){
        password = "";
        Hidden = false;
      }
      public bool ChangePassword(string p1, string p2){
        if(p1 == Password){
          Password = p2;
          return true;
        }
        return false;
      }

        
  }
}