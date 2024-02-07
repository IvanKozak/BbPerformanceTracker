namespace APILibrary.Models;
public record ShootingRecord
{
    public ShootingRecord(int makes, int attempts)
    {
        if (makes > attempts)
        {
            throw new MakesMoreThanAttemptsException(makes, attempts);
        }

        Attempts = attempts;
        Makes = makes;
    }

    public double Accuracy => Attempts == 0 ? 0 : (double)Makes / Attempts;
    public int Makes { get; init; }
    public int Attempts { get; init; }
}

public class MakesMoreThanAttemptsException : Exception
{
    public MakesMoreThanAttemptsException(int makes, int attempts)
        : base($"You cannot make more shots than you attempt. Current values: {makes} / {attempts}")
    {

    }
}
