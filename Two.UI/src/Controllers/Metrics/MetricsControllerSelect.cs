using Microsoft.AspNetCore.Mvc;
using Two.Application.Features.Metrics.Entities;

namespace Two.UI.Controllers.Metrics;

public partial class MetricsController
{
    /// <summary>
    /// List All AccountMetricss
    /// </summary>
    /// <remarks>List all AccountMetricss</remarks>
    /// <response code="200">The list of AccountMetricss</response>
    /// <response code="500">Fail while searching for AccountMetrics</response>
    [ProducesResponseType(typeof(List<AccountMetrics>), 200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<IActionResult> ListAccountMetrics()
    {
        var result = await _selectAccountMetrics.All();

        return Ok(result);
    }

    /// <summary>
    /// Get AccountMetrics by Id
    /// </summary>
    /// <remarks>Get a AccountMetrics by id</remarks>
    /// <response code="200">Find a AccountMetrics by id</response>
    /// <response code="500">Fail while searching for AccountMetrics</response>
    [ProducesResponseType(typeof(List<AccountMetrics>), 200)]
    [ProducesResponseType(500)]
    [HttpGet("{id}")]
    public async Task<IActionResult> ById(string id)
    {
        var result = await _selectAccountMetrics.ById(id);

        return Ok(result);
    }
}
