namespace ClassLibrary.Models;

public class ThreeOnThreeMatch
{
    public User     Player           { get; set; }
    public DateTime DateCreated      { get; set; }
    public int      OnePointAttempts { get; set; }
    public int      TwoPointAttempts { get; set; }
    public int      OnePointMakes    { get; set; }
    public int      TwoPointMakes    { get; set; }
    public int      Rebounds         { get; set; }
    public int      Assists          { get; set; }
}