
using Two.Application.Features.Metrics.Data;
using Two.Application.Features.Metrics.Entities;

namespace Two.Application.Features.Metrics.UseCases;

/// <summary>
/// This class is responsible for updating a AccountMetrics using a given repository.
/// </summary>
public class UpdateAccountMetricsUseCase
{
    private readonly IAccountMetricsRepository _AccountMetricsRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateAccountMetricsUseCase"/> class.
    /// </summary>
    /// <param name="AccountMetricsRepository">The AccountMetrics repository.</param>
    public UpdateAccountMetricsUseCase(IAccountMetricsRepository AccountMetricsRepository)
    {
        _AccountMetricsRepository = AccountMetricsRepository;
    }

    /// <summary>
    /// Executes the update of a AccountMetrics.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the AccountMetrics to be updated.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<AccountMetrics> Execute(UpdateAccountMetrics dto)
    => _AccountMetricsRepository.Save(dto.ToModel());
}

  

/// <summary>
/// Represents a data object for updating a AccountMetrics
/// </summary>
public class UpdateAccountMetrics
{
    
    /// <summary>
    /// Id
    /// </summary>
    /// <example>Id</example>
    public string Id {get; set;} = default!;
    

	
    /// <summary>
    /// AccountCount
    /// </summary>
    /// <example>AccountCount</example>
    public int AccountCount {get; set;} 
    

	
    /// <summary>
    /// DayCount
    /// </summary>
    /// <example>DayCount</example>
    public int DayCount {get; set;} 
    

    
    /// <summary>
    /// Converts the DTO to a model.
    /// </summary>
    /// <returns>The note model.</returns>
    public AccountMetrics ToModel()
    => new()
    {
      Id = Id,
	AccountCount = AccountCount,
	DayCount = DayCount
    };
    

}
    