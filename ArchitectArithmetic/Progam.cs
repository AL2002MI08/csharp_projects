using System;

namespace ArchitectArithmetic
{
  class Program
  {
    public static void Main(string[] args)
    {
      CalculateCost();
    }
    static double TriangleArea(double bottom, double height){
      return 0.5 * (bottom * height);
    }
    static double RectangleArea(double length,double width){
      return length * width;
    }

    static double CircleArea(double radius){
      return Math.PI * Math.Pow(radius, 2);
    }
    static double CostPerSqMeter = 180;

    static void CalculateCost(){
      Console.WriteLine("What monument would you like to work with?");
      string userInput = Console.ReadLine();
      double totalArea;
      switch(userInput) {
        case "Teotihuacan":
            double circleArea = CircleArea(375);
            double rectangleArea = RectangleArea(1500, 2500) ;
            double triangleArea = TriangleArea((double)500, (double)750);
            totalArea = rectangleArea + (circleArea / 2) + triangleArea;
            break;
        case "Taj Mahal":
            totalArea = RectangleArea(90.5, 90.5) - (4 * TriangleArea(24, 24));
            break;
        case "Great Mosque Mecca":
            totalArea = 2 * (RectangleArea(284, 264)) - (TriangleArea(84, 264));
            break;
        default:
            Console.WriteLine("No monument provided");
            return;

      }
      double totalCost = totalArea * CostPerSqMeter;
      Console.WriteLine($"The plan for that monument costs {Math.Round(totalCost, 2, MidpointRounding.AwayFromZero)} pesos!");
      
    }
  }
}
