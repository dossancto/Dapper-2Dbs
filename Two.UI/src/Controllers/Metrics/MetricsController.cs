using Microsoft.AspNetCore.Mvc;

using Two.Application.Features.Metrics.UseCases;

namespace Two.UI.Controllers.Metrics;

/// <summary>
/// Controller responsible for handling operations related to Metrics.
/// </summary>
[ApiController]
[Route("[controller]")]
public partial class MetricsController : ControllerBase
{
    private readonly CreateAccountMetricsUseCase _createAccountMetrics;
    private readonly UpdateAccountMetricsUseCase _updateAccountMetrics;
    private readonly DeleteAccountMetricsUseCase _deleteAccountMetrics;
    private readonly SelectAccountMetricsUseCase _selectAccountMetrics;

    /// <summary>
    /// Initializes a new instance of the <see cref="MetricsController"/> class.
    /// </summary>
    public MetricsController(SelectAccountMetricsUseCase selectAccountMetrics, DeleteAccountMetricsUseCase deleteAccountMetrics, UpdateAccountMetricsUseCase updateAccountMetrics, CreateAccountMetricsUseCase createAccountMetrics)
    {
        _selectAccountMetrics = selectAccountMetrics;
        _deleteAccountMetrics = deleteAccountMetrics;
        _updateAccountMetrics = updateAccountMetrics;
        _createAccountMetrics = createAccountMetrics;
    }
}
