using Two.Application.Features.Metrics.UseCases;

namespace Two.UI.Controllers.Metrics;

/// <summary>
/// Represents a request for updating a AccountMetrics
/// </summary>
public class UpdateAccountMetricsRequest
{

    /// <summary>
    /// AccountCount
    /// </summary>
    /// <example>AccountCount</example>
    public int AccountCount { get; set; }

    /// <summary>
    /// DayCount
    /// </summary>
    /// <example>DayCount</example>
    public int DayCount { get; set; }

    /// <summary>
    /// Converts the DTO to a model.
    /// </summary>
    /// <returns>The note model.</returns>
    public UpdateAccountMetrics ToModel(string id)
    => new()
    {
        Id = id,
        AccountCount = AccountCount,
        DayCount = DayCount
    };

}

