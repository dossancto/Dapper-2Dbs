
using Two.Application.Features.Metrics.Entities;

namespace Two.Application.Features.Metrics.Data;

/// <summary>
/// Defines operations for a AccountMetrics repository.
/// </summary>
public interface IAccountMetricsRepository
{
   /// <summary>
   /// Save a new AccountMetrics
   /// </summary>
   /// <param name="entity">The entity to save</param>
   /// <returns>The created AccountMetrics</returns>
   Task<AccountMetrics> Save(AccountMetrics entity);

   /// <summary>
   /// Update a existint AccountMetrics
   /// </summary>
   /// <param name="entity">The entity to update</param>
   /// <returns>The updated AccountMetrics</returns>
   Task<AccountMetrics> Update(AccountMetrics entity);

   /// <summary>
   /// Search for a AccountMetrics using it Id
   /// </summary>
   /// <param name="id">The Entity Id</param>
   /// <returns>The search result or null, if not found</returns>
   Task<AccountMetrics?> FindById(string id);

   /// <summary>
   /// List all AccountMetrics
   /// </summary>
   /// <returns>A list of all AccountMetrics</returns>
   Task<IEnumerable<AccountMetrics>> All();

   /// <summary>
   /// Delete a AccountMetrics
   /// </summary>
   Task Delete(string id);
}
