public class Swimming : Activity
{
    private int _numberOfLaps;

    public Swimming()
    {}

    private void SetSwimmingLaps()
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.Write("Enter swimming laps: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out _numberOfLaps) && _numberOfLaps > 0)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("⚠ Invalid input. Please enter a valid positive number of laps.");
            }
        }
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
            distance = GetSwimmingLaps() * 50 / 1000.0; // Convert laps to km
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
        return (distance / GetExerciseDuration()) * 60; // Speed = (Distance / Time) * 60
    }

    public override double CalculatePace()
    {
        double distance = CalculateDistance(); // Get computed distance
        return GetExerciseDuration() / distance; // Pace = Time / Distance
    }

    public void StartSwimming()
    {
        StartExercise();
        SetSwimmingLaps();
    }
}

