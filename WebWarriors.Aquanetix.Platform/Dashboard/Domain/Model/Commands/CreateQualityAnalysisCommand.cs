namespace WebWarriors.Aquanetix.Platform.Dashboard.Domain.Model.Commands;

public record CreateQualityAnalysisCommand(
    double Ph,
    double Temperature,
    double Turbidity,
    string Status
);