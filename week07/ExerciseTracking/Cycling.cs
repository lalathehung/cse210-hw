public class Cycling : Activity
{
    private int _cyclingSpeed;

    public Cycling()
    {}

    private void SetCyclingSpeed()
    {
        Console.Write("Enter cycling speed (km/h or mph): ");
        _cyclingSpeed = int.Parse(Console.ReadLine());
    }

    private int GetCyclingSpeed()
    {
        return _cyclingSpeed;
    }

    public override double CalculateDistance()
    {
        double distance = 0;
        if (GetMetricUnit() == "km" || GetMetricUnit() == "miles")
        {
            distance = GetCyclingSpeed() * GetExerciseDuration() / 60.0; // Distance = Speed * Time / 60
        }
        return distance;
    }

    public override double CalculateSpeed()
    {
        return GetCyclingSpeed(); // Speed is given directly by user
    }

    public override double CalculatePace()
    {
        return 60.0 / GetCyclingSpeed(); // Pace = 60 / Speed
    }

    public void StartCycling()
    {
        StartExercise();
        SetCyclingSpeed();
    }
}
