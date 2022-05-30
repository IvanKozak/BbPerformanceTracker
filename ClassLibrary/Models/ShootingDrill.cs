namespace ClassLibrary.Models;

public class ShootingDrill
{
    public User     Player             { get; set; }
    public DateTime DateCreated        { get; set; }
    public int      ThreePointAttempts { get; set; }
    public int      ThreePointMakes    { get; set; }
    public int      MidrangeAttempts   { get; set; }
    public int      MidrangeMakes      { get; set; }
    public int      PostUpAttempts     { get; set; }
    public int      PostUpMakes        { get; set; }
}