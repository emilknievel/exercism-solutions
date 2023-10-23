static class AssemblyLine
{
    public static double SuccessRate(int speed)
    {
        switch (speed)
        {
            case 0:
                return 0;
            case >= 1 and <= 4:
                return 1.0;
            case >= 5 and <= 8:
                return 0.9;
            case 9:
                return 0.8;
            default:
                return 0.77;
        }
    }

    public static double ProductionRatePerHour(int speed) =>
        speed * 221 * SuccessRate(speed);

    public static int WorkingItemsPerMinute(int speed) =>
        (int)(ProductionRatePerHour(speed) / 60);
}
