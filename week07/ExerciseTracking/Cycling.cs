public class Cycling : Activity
{
    private int _cyclingSpeed;

    public Cycling()
    {}

    private void SetCyclingSpeed()
    {
        bool isValid = false;
        while (!isValid)
        {
            Console.Write("Enter cycling speed (km/h or mph): ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out _cyclingSpeed) && _cyclingSpeed > 0)
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("⚠ Invalid input. Please enter a valid positive number.");
            }
        }
    }

    private int GetCyclingSpeed()
    {
        return _cyclingSpeed;
    }

    public override double CalculateDistance()
    {
        return GetCyclingSpeed() * GetExerciseDuration() / 60.0; // Distance = Speed * Time / 60
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

