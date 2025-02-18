public class Running : Activity
{
    private double _runningDistance;

    public Running()
    {}

    private void SetRunningDistance()
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.Write("Enter distance ran: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out _runningDistance) && _runningDistance > 0)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("⚠ Invalid input. Please enter a valid positive distance.");
            }
        }
    }

    private double GetRunningDistance()
    {
        return _runningDistance;
    }

    public override double CalculateDistance()
    {
        double distance = 0;
        if (GetMetricUnit() == "km" || GetMetricUnit() == "miles")
        {
            distance = GetRunningDistance(); // Distance is input directly
        }
        return distance;
    }

    public override double CalculateSpeed()
    {
        return (GetRunningDistance() / GetExerciseDuration()) * 60; // Speed = (Distance / Time) * 60
    }

    public override double CalculatePace()
    {
        return GetExerciseDuration() / GetRunningDistance(); // Pace = Time / Distance
    }

    public void StartRunning()
    {
        StartExercise();
        SetRunningDistance();
    }
}

