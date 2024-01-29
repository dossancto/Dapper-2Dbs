using Two.Application.Features.Metrics.Data;

namespace Two.Application.Features.Metrics.UseCases;

/// <summary>
/// This class encapsulates the use case of deleting a AccountMetrics.
/// </summary>
public class DeleteAccountMetricsUseCase
{
    private readonly IAccountMetricsRepository _AccountMetricsRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteAccountMetricsUseCase"/> class.
    /// </summary>
    /// <param name="AccountMetricsRepository">The AccountMetrics repository.</param>
    public DeleteAccountMetricsUseCase(IAccountMetricsRepository AccountMetricsRepository)
    {
        _AccountMetricsRepository = AccountMetricsRepository;
    }

    /// <summary>
    /// Deletes a AccountMetrics by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the AccountMetrics.</param>
    public Task Execute(string id)
    => _AccountMetricsRepository.Delete(id);
}