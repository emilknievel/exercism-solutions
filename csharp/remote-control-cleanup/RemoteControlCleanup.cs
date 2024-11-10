public class RemoteControlCar
{
    private Speed _currentSpeed;

    public RemoteControlCar()
    {
        Telemetry = new RcTelemetry(this);
    }

    public string CurrentSponsor { get; private set; }
    public ITelemetry Telemetry { get; }

    public string GetSpeed() => _currentSpeed.ToString();

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;
    }

    private void SetSpeed(Speed speed)
    {
        _currentSpeed = speed;
    }

    public interface ITelemetry
    {
        void Calibrate();
        bool SelfTest();
        void ShowSponsor(string sponsorName);
        void SetSpeed(decimal amount, string unitsString);
    }

    private class RcTelemetry(RemoteControlCar car) : ITelemetry
    {
        public void Calibrate()
        {
        }

        public bool SelfTest() => true;

        public void ShowSponsor(string sponsorName)
        {
            car.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            var speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            car.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    private readonly struct Speed(decimal amount, SpeedUnits speedUnits)
    {
        public override string ToString()
        {
            var unitsString = "meters per second";
            if (speedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return amount + " " + unitsString;
        }
    }

    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }
}
