using System;

namespace SmartHome 
{
  // Pre-implemented sensor simulation
  public class Sensors 
  {
    private static Random _random = new Random();
        
    public static double GetTemperature(string sensorId)
    {
      // Simulates temperature between 65-80 degrees
      return 65 + _random.NextDouble() * 15;
    }
        
    public static double GetHumidity(string sensorId) 
    {
      // Simulates humidity between 30-60%
      return 30 + _random.NextDouble() * 30;
    }
        
    public static double GetMotion(string sensorId)
    {
      // Simulates motion detection (0-1 scale)
      return _random.NextDouble();
    }
  }

  public class HomeAutomation 
  {
    // Basic Sensor System: Delegates will be declared here
    public delegate double SensorProcessor(string s);

    public void ProcessSensorData(string[] sensors, SensorProcessor sensorProcessor)
    {
      foreach(var s in sensors){
        Console.WriteLine(sensorProcessor(s));
      }
    }

    // Built-in Delegates: Built-in delegates will be defined here
    Func<double, bool>IsValidReading = s => s >= 0 && s <= 100;
    Action<string, double>LogReading = (sensorId, value) => Console.WriteLine($"{sensorId}: {value}");
    // Instance Methods and Predicates: Temperature control for method group conversion
    Predicate<double>IsCritical = reading => reading > 90;
    public class TemperatureControl 
    {
      public Predicate<double>IsComfortable = temp => temp >= 68 && temp <= 76;
    }
    public delegate void AutomationHandler(string device, string action);

    // Multicast Delegates: Fields for multicast example
    private double _currentTemp = 72.0;
    private bool _lightsOn = false;

    public void AdjustHVAC(string device, string action)
    {
      _currentTemp += action == "up" ? 1 : -1;
      Console.WriteLine($"Temperature now: {_currentTemp}");
    }

    public void ControlLights(string device, string action)
    {
      _lightsOn = action == "on";
      Console.WriteLine($"Lights are now {(_lightsOn ? "on" : "off")}");
    }

    // Complex Automation Rules: Base class for automation rules
    public class AutomationRule 
    {
      public string Action {get; set;}
      public string Device {get; set;}
      public Predicate<double> Condition {get; set;}
      public AutomationHandler Actions {get; set;}
    }

    public void ProcessRule(AutomationRule rule, double sensorReading)
    {
      if(rule.Condition(sensorReading)) {
        rule.Actions(rule.Device, rule.Action);
      }
    }

    public static void Main()
    {
      HomeAutomation home = new HomeAutomation();
      Console.WriteLine("Smart Home Automation Starting...");
      string[] tempSensors = {"TEMP1", "TEMP2"};
      SensorProcessor sensorP = Sensors.GetTemperature;
      home.ProcessSensorData(tempSensors, sensorP);

      Console.WriteLine(home.IsValidReading(110));
      Console.WriteLine(home.IsValidReading(50));
      Console.WriteLine(home.IsCritical(50.9));
      Console.WriteLine(home.IsCritical(95.0));
      home.LogReading("TEMP1", 48);
      home.LogReading("TEMP2", 72);
      Console.WriteLine(home.IsCritical(50.9));

      TemperatureControl tempControl = new TemperatureControl();
      Predicate <double>comfortable = tempControl.IsComfortable;

      Console.WriteLine(comfortable(66.34));

      double[] comfortTemp = { 65.0, 70.0, 75.0, 80.0 };
      var filteredTemp = Array.FindAll(comfortTemp, comfortable);
      foreach(var temp in filteredTemp){
        Console.WriteLine(temp);
      }

      AutomationHandler autoHandler = home.ControlLights;
      autoHandler += home.AdjustHVAC;
      autoHandler("MAIN", "on");
      AutomationRule autoRule = new AutomationRule {
        Condition = temp => temp < 68.0,
        Actions = autoHandler,
        Device = "MAIN",
        Action = "on"     
      };
      home.ProcessRule(autoRule, 66.0);
    }
  }
}