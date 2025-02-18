public class Swimming : Activity
{
    private int _numberOfLaps;

    public Swimming()
    {}

    private void SetSwimmingLaps()
    {
        Console.Write("Enter swimming laps: ");
        _numberOfLaps = int.Parse(Console.ReadLine());
    }

    private int GetSwimmingLaps()
    {
        return _numberOfLaps;
    }

    public override double CalculateDistance()
    {
        double distance = 0;
        if (GetMetricUnit() == "km")
        {
            distance = GetSwimmingLaps() * 50 / 1000.0; // Each lap = 50m, convert to km
        } 
        else if (GetMetricUnit() == "miles")
        {
            distance = GetSwimmingLaps() * 50 / 1000.0 * 0.62; // Convert to miles
        }
        return distance;
    }

    public override double CalculateSpeed()
    {
        double distance = CalculateDistance(); // Get computed distance
        double computeSpeed = (distance / GetExerciseDuration()) * 60; // Speed = (distance / time) * 60
        return computeSpeed;
    }

    public override double CalculatePace()
    {
        double distance = CalculateDistance(); // Get computed distance
        double computePace = GetExerciseDuration() / distance; // Pace = Time / Distance
        return computePace;
    }

    public void StartSwimming()
    {
        StartExercise();
        SetSwimmingLaps();
    }
}
