
using Two.Application.Features.Metrics.Data;
using Two.Application.Features.Metrics.Entities;

namespace Two.Application.Features.Metrics.UseCases;

/// <summary>
/// This class is responsible getting data from AccountMetricss
/// </summary>
public class SelectAccountMetricsUseCase
{
    private readonly IAccountMetricsRepository _AccountMetricsRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="SelectAccountMetricsUseCase"/> class.
    /// </summary>
    /// <param name="AccountMetricsRepository">The AccountMetrics repository.</param>
    public SelectAccountMetricsUseCase(IAccountMetricsRepository AccountMetricsRepository)
    {
        _AccountMetricsRepository = AccountMetricsRepository;
    }

    /// <summary>
    /// Retrieves a note by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the note.</param>
    /// <returns>The task result contains the note if found, null otherwise.</returns>
    public Task<AccountMetrics?> ById(string id)
    => _AccountMetricsRepository.FindById(id);

    /// <summary>
    /// Retrieves all notes.
    /// </summary>
    /// <returns>The task result contains a list of all notes.</returns>
    public Task<List<AccountMetrics>> All()
    => _AccountMetricsRepository.All();
}

  