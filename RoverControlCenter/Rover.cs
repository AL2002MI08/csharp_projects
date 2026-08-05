namespace RoverControlCenter
{
  class Rover: Probe
  {
    public int YearLaunched {get; private set;}

    public Rover(string alias, int yearLanded) : base(alias,yearLanded)
    {
    }

    public override string Explore()
    {
      return "Rover is exploring the surface!";
    }

    public override string Collect()
    {
      return "Rover is collecting rocks!";
    }
  }
}