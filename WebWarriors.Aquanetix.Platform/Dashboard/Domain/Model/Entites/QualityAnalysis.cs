using WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Commands;

namespace WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Entities;

public class QualityAnalysis
{
    public int Id { get; private set; }

    public double Ph { get; private set; }

    public double Temperature { get; private set; }

    public double Turbidity { get; private set; }

    public string Status { get; private set; }

    public DateTime CreatedAt { get; private set; }

    protected QualityAnalysis() { }

    public QualityAnalysis(CreateQualityAnalysisCommand command)
    {
        Ph = command.Ph;
        Temperature = command.Temperature;
        Turbidity = command.Turbidity;
        Status = command.Status;
        CreatedAt = DateTime.UtcNow;
    }
}