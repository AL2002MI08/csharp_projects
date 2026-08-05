namespace RoverControlCenter
{
  class Probe
  {
    public string Alias
    { get; set; }
    public int YearLanded
    {get; set;}

    public Probe(string alias, int yearLanded)
    {
      Alias = alias;
      YearLanded = yearLanded;
    }
    public string GetInfo()
    {
      return $"Alias: {Alias}, YearLanded: {YearLanded}";
    }
    public virtual string Explore()
    {
      return "Probe is exploring the surface!";
    }

    public virtual string Collect()
    {
      return "Probe is collecting rocks!";
    }
  }
}