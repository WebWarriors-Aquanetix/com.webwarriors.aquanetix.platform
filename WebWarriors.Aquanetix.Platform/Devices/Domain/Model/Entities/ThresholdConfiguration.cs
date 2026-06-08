using WebWarriors.Aquanetix.Platform.Devices.Domain.Model.ValueObjects;

namespace WebWarriors.Aquanetix.Platform.Devices.Domain.Model.Entities;

public class ThresholdConfiguration
{
    public int Id { get; private set; }
    public int SensorId { get; private set; }
    public double MinValue { get; private set; }
    public double MaxValue { get; private set; }
    public string Unit { get; private set; }
    public AlertLevel AlertLevel { get; private set; }

    public ThresholdConfiguration(int sensorId, double minValue, 
        double maxValue, string unit, 
        AlertLevel alertLevel)
    {
        SensorId = sensorId;
        MinValue = minValue;
        MaxValue = maxValue;
        Unit = unit;
        AlertLevel = alertLevel;
    }

    public void Update(double minValue, double maxValue)
    {
        MinValue = minValue;
        MaxValue = maxValue;
    }
}