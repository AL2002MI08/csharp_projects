using System;

namespace DatingProfile
{ 
  class Profile {
  private string Name{get;set;}
  private string City{get; set;}
  private string Country {get; set;}
  private string Pronouns{get; set;}
  private string[] hobbies = Array.Empty<string>();

  private int Age {
    get; set;
  }
  public Profile(string name, int age, string city, string country, string pronouns){
    Name = name;
    Age = age;
    City = city;
    Country = country;
    Pronouns = pronouns;
  }
  public void SetHobbies(string[] hobbies){
    this.hobbies = hobbies;
  }
  public string ViewProfile(){
    return $"The user {Name} is {Age} years old. {Pronouns} lives in {City}, {Country}. Hobbies include: {string.Join(", ", hobbies)}";
  }
  
  }

}
