using Microsoft.AspNetCore.Mvc;
using Two.Application.Features.Metrics.UseCases;
using Two.Application.Features.Metrics.Entities;

namespace Two.UI.Controllers.Metrics;

public partial class MetricsController
{
    /// <summary>
    /// Create AccountMetricss
    /// </summary>
    /// <remarks>List all AccountMetricss</remarks>
    /// <response code="200">The list of AccountMetricss</response>
    /// <response code="500">Fail while searching for AccountMetrics</response>
    [ProducesResponseType(typeof(List<AccountMetrics>), 200)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<IActionResult> CreateAccountMetrics(CreateAccountMetrics request)
    {
        var result = await _createAccountMetrics.Execute(request);

        return Ok(result);
    }
}

