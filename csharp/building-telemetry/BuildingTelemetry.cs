public class RemoteControlCar
{
    private int _batteryPercentage = 100;
    private int _distanceDrivenInMeters;
    private string[] _sponsors = new string[0];
    private int _latestSerialNum;

    public void Drive()
    {
        if (_batteryPercentage <= 0) return;
        _batteryPercentage -= 10;
        _distanceDrivenInMeters += 2;
    }

    public void SetSponsors(params string[] sponsors) => _sponsors = sponsors;

    public string DisplaySponsor(int sponsorNum) => _sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum < _latestSerialNum)
        {
            batteryPercentage = distanceDrivenInMeters = -1;
            serialNum = _latestSerialNum;
            return false;
        }

        batteryPercentage = _batteryPercentage;
        distanceDrivenInMeters = _distanceDrivenInMeters;
        _latestSerialNum = serialNum;
        return true;
    }

    public static RemoteControlCar Buy() => new();
}

public class TelemetryClient(RemoteControlCar car)
{
    public string GetBatteryUsagePerMeter(int serialNum) =>
        car.GetTelemetryData(ref serialNum, out var batteryPercentage, out var distanceDrivenInMeters) &&
        distanceDrivenInMeters > 0
            ? $"usage-per-meter={(100 - batteryPercentage) / distanceDrivenInMeters}"
            : "no data";
}
