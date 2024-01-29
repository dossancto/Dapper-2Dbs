using Two.Application.Features.Users.Entities;
using Two.Application.Features.Users.Data;

using System.ComponentModel.DataAnnotations;
using Two.Adapters.Cryptographies;

namespace Two.Application.Features.Users.UseCases;

/// <summary>
/// Register a new User
/// </summary>
public class SelectUserUseCase
{
    private readonly IUserRepository _userRepository;

    /// <summary>
    /// Dependency invert the login usecase
    /// </summary>
    public SelectUserUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Executes the Login method
    /// </summary>
    public Task<IEnumerable<User>> All()
    => _userRepository.All();
}
