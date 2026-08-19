using System;
public interface IValidatable {
  bool IsValid();
}
class ValidatableAmount: IValidatable {
 private decimal _value;
 private decimal _min;
 private decimal _max;
 public ValidatableAmount(decimal value,decimal min, decimal max) {
  _value = value;
  _min = min;
  _max = max;
 }
 public bool IsValid() {
  return _value >= _min  && _value <= _max;
 }
}
public class SafeValue<T> where T: IValidatable  
{
   private T? _value;
   public SafeValue(T initialValue){
    if(!initialValue.IsValid()) {
      throw new Exception("Invalid initial value!");
    }
    _value = initialValue;
   }
   public T? GetValue(){
    return _value;
   }
   public void SetValue(T value) {
    if(!value.IsValid()){
       throw new Exception("Invalid value provided!");
    }
   _value = value;
   }
   public bool HasValue(){
    return _value != null;
   }
  
}

class Program 
{
  static void Main()
  {
    ValidatableAmount value = new ValidatableAmount(50, 0, 100);
    SafeValue<ValidatableAmount> safeValue1 = new SafeValue<ValidatableAmount>(value);
    Console.WriteLine("Initial value set successfully.");
    Console.WriteLine("HasValue after construction: " + safeValue1.HasValue());
    try {
      ValidatableAmount validUpdate = new ValidatableAmount(75, 0, 100);
      safeValue1.SetValue(validUpdate);
      Console.WriteLine("SetValue succeeded: " + safeValue1.GetValue().IsValid());
      Console.WriteLine("HasValue after successful SetValue: " + safeValue1.HasValue());
    }
    catch (Exception e) {
      Console.WriteLine($"Unexpected SetValue failure: {e.Message}");
    }
    try {
      ValidatableAmount invalidUpdate = new ValidatableAmount(200, 0, 100);
      safeValue1.SetValue(invalidUpdate);
      Console.WriteLine("SetValue unexpectedly succeeded.");
    }
    catch (Exception e) {
      Console.WriteLine($"Caught expected SetValue error: {e.Message}");
    }

    Console.WriteLine("HasValue after FAILED SetValue: " + safeValue1.HasValue());
    Console.WriteLine("Value still valid: " + safeValue1.GetValue().IsValid());

    try {
      ValidatableAmount value2 = new ValidatableAmount(70, 0, 100);
      SafeValue<ValidatableAmount> safeValue2 = new SafeValue<ValidatableAmount>(value2);
      Console.WriteLine("Second value set successfully.");
    }
    catch (Exception e) {
      Console.WriteLine($"Failed to create SafeValue: {e.Message}");
    }
  }
}
