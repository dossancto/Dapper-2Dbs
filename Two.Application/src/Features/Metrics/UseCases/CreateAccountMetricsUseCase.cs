
using Two.Application.Features.Metrics.Data;
using Two.Application.Features.Metrics.Entities;

namespace Two.Application.Features.Metrics.UseCases;

/// <summary>
/// This class is responsible for creating a AccountMetrics using a given repository.
/// </summary>
public class CreateAccountMetricsUseCase
{
    private readonly IAccountMetricsRepository _AccountMetricsRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateAccountMetricsUseCase"/> class.
    /// </summary>
    /// <param name="AccountMetricsRepository">The AccountMetrics repository.</param>
    public CreateAccountMetricsUseCase(IAccountMetricsRepository AccountMetricsRepository)
    {
        _AccountMetricsRepository = AccountMetricsRepository;
    }

    /// <summary>
    /// Executes the creation of a AccountMetrics.
    /// </summary>
    /// <param name="dto">The data transfer object containing the details of the AccountMetrics to be created.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<AccountMetrics> Execute(CreateAccountMetrics dto)
    => _AccountMetricsRepository.Save(dto.ToModel());
}
  

/// <summary>
/// Represents a data object for creating a AccountMetrics
/// </summary>
public class CreateAccountMetrics
{
    
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
      AccountCount = AccountCount,
	DayCount = DayCount
    };
    

}
    
