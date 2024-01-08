class RemoteControlCar
{
    private readonly int _speed;
    private readonly int _batteryDrain;
    private int _distanceDriven;
    private int _battery = 100;

    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrain = batteryDrain;
    }

    public bool BatteryDrained() => _battery < _batteryDrain;

    public int DistanceDriven() => _distanceDriven;

    public void Drive()
    {
        if (BatteryDrained())
        {
            return;
        }

        _battery -= _batteryDrain;
        _distanceDriven += _speed;
    }

    public static RemoteControlCar Nitro() => new(50, 4);
}

class RaceTrack
{
    private readonly int _distance;

    public RaceTrack(int distance)
    {
        _distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (!car.BatteryDrained())
        {
            car.Drive();
        }

        return _distance <= car.DistanceDriven();
    }
}
